using System.Net;
using System.Text;
using Duniverse.Data;
using Duniverse.Models;
using Duniverse.Services;

// Turns the published single-page app into a set of real pages.
//
// The whole site renders in the browser, which means every route except the front door is
// served by the SPA fallback and comes back with a 404 status. People never notice, because
// the router recovers and draws the page. Crawlers notice: they read the status line and
// leave, so two hundred entries of researched canon sit outside every search index there is.
//
// This walks every route the app can serve and writes a real index.html for each one, so the
// host answers with a 200 and a page that already has its title, its description, its share
// card and its text in the markup. The Blazor script is still in there and still boots, wipes
// the shell, and takes over, so nothing about the live experience changes.
//
// Spoilers are the reason this could not be built before. Whatever lands in the shell lands in
// Google's index, in link previews, and in front of readers who never asked for it. The
// tier-layered history split gave every record a version that is safe at its own tier, so this
// prints DetailedHistory and never touches HistoryLayers. Records sealed above the site's own
// default get a bare shell and a noindex, which keeps their URL working without publishing
// their name to the open web.

if (args.Length < 1)
{
    Console.Error.WriteLine("usage: Duniverse.Prerender <published-wwwroot> [site-origin]");
    return 1;
}

var root = args[0];
var origin = (args.Length > 1 ? args[1] : "https://www.duniverse.org").TrimEnd('/');

var templatePath = Path.Combine(root, "index.html");
if (!File.Exists(templatePath))
{
    Console.Error.WriteLine($"no index.html under {root}; run this after dotnet publish");
    return 1;
}

// The published copy, not the source one: publish rewrites the framework script's filename to
// its fingerprinted form, and a shell pointing at the unfingerprinted name would never boot.
var template = File.ReadAllText(templatePath);
var registry = RegistryFactory.CreateSeeded();

// The site's own default posture, and therefore the face it shows the public: protection on at
// book one, Expanded Universe off. A record outside that is written but not advertised.
static bool PubliclyVisible(SpoilerTier tier) => tier == SpoilerTier.Dune;

static string Esc(string? s) => WebUtility.HtmlEncode(s ?? string.Empty);

// Meta descriptions get cut to something a search result will actually show, and cut at a word
// so the tail never reads as a broken sentence.
static string Trim(string? s, int max = 155)
{
    s = (s ?? string.Empty).Replace('\n', ' ').Trim();
    if (s.Length <= max)
    {
        return s;
    }
    var cut = s.LastIndexOf(' ', Math.Min(max, s.Length - 1));
    return (cut > 40 ? s[..cut] : s[..max]).TrimEnd(',', ';', ':', '.') + "...";
}

var pages = new List<(string Route, string Title, string Description, string Body, bool Index)>();

// ---- the fixed routes -------------------------------------------------------------------
var siteBlurb = "An unofficial encyclopedia of Frank Herbert's Dune and its Expanded Universe. "
              + "Search every record, follow the connections, and read it without spoilers.";

pages.Add(("", "Duniverse, an unofficial Dune encyclopedia", siteBlurb,
    $"<h1>Duniverse</h1><p>{Esc(siteBlurb)}</p>", true));

var fixedRoutes = new (string Route, string Title, string Description)[]
{
    ("about", "About Dune", "Frank Herbert, the making of Dune, and why the saga still reads the way it does."),
    ("archives", "Archives", "Search every record in the Duniverse by name, by alias, or by something you half remember."),
    ("timeline", "Timeline", "The Imperium in order, from the Butlerian Jihad to the far reaches, dated in Guild reckoning."),
    ("bloodlines", "Bloodlines", "The Atreides, Harkonnen and Corrino lines, drawn as one chart and gated by how far you have read."),
    ("connections", "Trace a Connection", "Pick any two records and follow the shortest chain of relationships between them."),
    ("universe", "The Whole Duniverse", "Every record and every connection in one map you can pan and zoom."),
    ("terminology", "Terminology of the Imperium", "A glossary of the Imperium in the voice of Herbert's own appendices."),
    ("sayings", "Collected Sayings", "Epigraphs and sayings gathered from across the saga, by source."),
    ("trial", "The Mentat Trial", "A daily puzzle: five clues, six guesses, one record from the archive."),
};

foreach (var (route, title, description) in fixedRoutes)
{
    pages.Add((route, title, description, $"<h1>{Esc(title)}</h1><p>{Esc(description)}</p>", true));
}

// ---- category browse pages --------------------------------------------------------------
var byCategory = registry.GetAllEntities<DuneEntity>()
    .GroupBy(GraphLayoutService.CategorySlug)
    .Where(g => g.Key != "unknown");

foreach (var group in byCategory)
{
    var label = GraphLayoutService.CategoryTitle(group.First());
    var listed = group.Where(e => PubliclyVisible(e.SpoilerTier))
                      .OrderBy(e => e.Name, StringComparer.OrdinalIgnoreCase)
                      .ToList();

    var body = new StringBuilder();
    body.Append($"<h1>{Esc(label)}</h1>");
    body.Append($"<p>{listed.Count} records. Select one to see its full entry and connections.</p><ul>");
    foreach (var e in listed)
    {
        body.Append($"<li><a href=\"/entity/{Esc(e.Id)}/\">{Esc(e.Name)}</a> {Esc(e.ShortDescription)}</li>");
    }
    body.Append("</ul>");

    pages.Add(($"category/{group.Key}", label,
        $"Every {label.ToLowerInvariant()} record in the Duniverse archive.", body.ToString(), true));
}

// ---- one page per record ------------------------------------------------------------------
foreach (var entity in registry.GetAllEntities<DuneEntity>().OrderBy(e => e.Id, StringComparer.Ordinal))
{
    var route = $"entity/{entity.Id}";

    if (!PubliclyVisible(entity.SpoilerTier))
    {
        // The URL has to answer, or an in-app link breaks. It just answers with nothing: the
        // canonical id spells the name out, which is the leak the gate page works to avoid.
        pages.Add((route, "Spoiler-protected entry",
            "This entry draws on a later book in the saga. Open it on the site to decide for yourself.",
            "<h1>A spoiler lies ahead</h1><p>This entry draws on a book later in the saga than the "
            + "archive shows by default.</p>", false));
        continue;
    }

    var body = new StringBuilder();
    body.Append($"<h1>{Esc(entity.Name)}</h1>");
    body.Append($"<p>{Esc(entity.ShortDescription)}</p>");

    if (entity.Aliases.Count > 0)
    {
        body.Append($"<p>Also known as {Esc(string.Join(", ", entity.Aliases))}.</p>");
    }

    // Only the opening history. The later layers are the whole point of the tier split and must
    // never reach a crawler, a link preview, or a reader who has not asked for them.
    if (!string.IsNullOrWhiteSpace(entity.DetailedHistory))
    {
        body.Append($"<p>{Esc(entity.DetailedHistory)}</p>");
    }

    // Real links, so a crawler can walk the archive the way a reader does instead of finding
    // two hundred islands. Same spoiler rule as everywhere else.
    var related = registry.GetDirectlyRelated(entity.Id, PubliclyVisible)
        .Where(e => PubliclyVisible(e.SpoilerTier))
        .OrderBy(e => e.Name, StringComparer.OrdinalIgnoreCase)
        .ToList();

    if (related.Count > 0)
    {
        body.Append("<p>Connected records:</p><ul>");
        foreach (var r in related)
        {
            body.Append($"<li><a href=\"/entity/{Esc(r.Id)}/\">{Esc(r.Name)}</a></li>");
        }
        body.Append("</ul>");
    }

    var slug = GraphLayoutService.CategorySlug(entity);
    body.Append($"<p><a href=\"/category/{Esc(slug)}/\">Back to {Esc(GraphLayoutService.CategoryTitle(entity))}</a></p>");

    pages.Add((route, entity.Name,
        Trim(entity.ShortDescription ?? entity.DetailedHistory), body.ToString(), true));
}

// ---- write them out -----------------------------------------------------------------------
static string Swap(string html, string find, string replacement) =>
    html.Contains(find) ? html.Replace(find, replacement) : html;

// Checked once rather than per page: if the published shell ever stops looking like this, the
// run should stop with a message instead of quietly writing two hundred pages of nothing.
var appOpen = template.IndexOf("<div id=\"app\">", StringComparison.Ordinal);
var appEnd = template.IndexOf("<div id=\"blazor-error-ui\">", StringComparison.Ordinal);
if (appOpen < 0 || appEnd <= appOpen)
{
    Console.Error.WriteLine("index.html no longer has the expected #app container; nothing written");
    return 1;
}

int written = 0, noindexed = 0;
var indexable = new List<string>();

foreach (var (route, title, description, body, index) in pages)
{
    // Trailing slash, because that is the address the host actually serves. Each route is a
    // folder with an index.html in it, and asking for the bare path gets a 301 onto the slashed
    // form. A canonical or a sitemap entry pointing at the unslashed version would name a URL
    // that redirects, which Search Console files under "page with redirect" rather than
    // indexing. The router handles either form, so the slash costs nothing.
    var url = route.Length == 0 ? $"{origin}/" : $"{origin}/{route}/";
    var pageTitle = route.Length == 0 ? title : $"{title} - Duniverse";
    var html = template;

    html = Swap(html, "<title>Duniverse, an unofficial Dune encyclopedia</title>",
                      $"<title>{Esc(pageTitle)}</title>");
    html = Swap(html, $"<meta name=\"description\" content=\"{siteBlurb}\" />",
                      $"<meta name=\"description\" content=\"{Esc(description)}\" />");
    html = Swap(html, "<link rel=\"canonical\" href=\"https://www.duniverse.org/\" />",
                      $"<link rel=\"canonical\" href=\"{Esc(url)}\" />");
    html = Swap(html, "<meta property=\"og:title\" content=\"Duniverse, an unofficial Dune encyclopedia\" />",
                      $"<meta property=\"og:title\" content=\"{Esc(pageTitle)}\" />");
    html = Swap(html, $"<meta property=\"og:description\" content=\"{siteBlurb}\" />",
                      $"<meta property=\"og:description\" content=\"{Esc(description)}\" />");
    html = Swap(html, "<meta property=\"og:url\" content=\"https://www.duniverse.org/\" />",
                      $"<meta property=\"og:url\" content=\"{Esc(url)}\" />");
    html = Swap(html, "<meta name=\"twitter:title\" content=\"Duniverse, an unofficial Dune encyclopedia\" />",
                      $"<meta name=\"twitter:title\" content=\"{Esc(pageTitle)}\" />");
    html = Swap(html, $"<meta name=\"twitter:description\" content=\"{siteBlurb}\" />",
                      $"<meta name=\"twitter:description\" content=\"{Esc(description)}\" />");

    if (!index)
    {
        html = Swap(html, "<meta name=\"theme-color\"",
                          "<meta name=\"robots\" content=\"noindex, follow\" />\n    <meta name=\"theme-color\"");
        noindexed++;
    }
    else
    {
        indexable.Add(url);
    }

    // The whole #app container is rebuilt: the boot screen stays exactly as it was designed, and
    // the entry's own markup goes in underneath it. Nothing is hidden with display:none, which
    // would read as cloaking and get the content discounted anyway. It does not need to be:
    // .boot-screen is fixed, inset 0 and opaque, so it covers the entry while the runtime loads,
    // and Blazor clears the container on its first render the way it always has. A visitor sees
    // the same loading art. A crawler reads the page sitting under it.
    // Located on this page's own copy, not on the template. The meta swaps above have already
    // changed the length of the string, so an offset measured against the template would slice
    // in the wrong place and take the boot script out with it.
    var open = html.IndexOf("<div id=\"app\">", StringComparison.Ordinal);
    var close = html.IndexOf("<div id=\"blazor-error-ui\">", StringComparison.Ordinal);

    var shell = new StringBuilder();
    shell.Append("<div id=\"app\">\n");
    shell.Append("        <div class=\"boot-screen\">\n");
    shell.Append("            <div class=\"boot-wordmark\">Duniverse</div>\n");
    shell.Append("            <div class=\"boot-seam\"><div class=\"boot-seam-fill\"></div></div>\n");
    shell.Append("            <p class=\"boot-line\">Opening the archives</p>\n");
    shell.Append("        </div>\n");
    shell.Append($"        <main class=\"prerendered-entry\">{body}</main>\n");
    shell.Append("    </div>\n\n    ");
    html = html[..open] + shell.ToString() + html[close..];

    var dir = route.Length == 0 ? root : Path.Combine(root, route.Replace('/', Path.DirectorySeparatorChar));
    Directory.CreateDirectory(dir);
    File.WriteAllText(Path.Combine(dir, "index.html"), html);
    written++;
}

// Regenerated from the same walk, so the sitemap can never drift from what actually exists.
var sitemap = new StringBuilder();
sitemap.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
sitemap.AppendLine("<!-- Written by Duniverse.Prerender from the routes it just emitted. Every URL");
sitemap.AppendLine("     here is a real file the host answers with a 200, and sealed records are left");
sitemap.AppendLine("     out on purpose: their pages exist and carry noindex. -->");
sitemap.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
foreach (var url in indexable)
{
    sitemap.AppendLine($"  <url><loc>{Esc(url)}</loc></url>");
}
sitemap.AppendLine("</urlset>");
File.WriteAllText(Path.Combine(root, "sitemap.xml"), sitemap.ToString());

Console.WriteLine($"prerendered {written} routes ({indexable.Count} indexable, {noindexed} noindex)");
Console.WriteLine($"sitemap.xml lists {indexable.Count} urls");
return 0;
