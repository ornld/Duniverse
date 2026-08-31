using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Duniverse.Models;

namespace Duniverse.Services
{
    /// <summary>
    /// The engine behind the Mentat Trial, my daily deduction game. Each day it seals one record
    /// from the reader's visible pool, deals five clues vague to specific, and scores misses by
    /// link distance. Nothing here touches the clock or storage.
    /// </summary>
    public class MentatTrialService
    {
        /// <summary>How many guesses a trial allows before the record is revealed.</summary>
        public const int MaxGuesses = 6;

        /// <summary>How many clues every trial deals, one more revealed after each miss.</summary>
        public const int ClueCount = 5;

        // Every redacted word becomes this same bar regardless of its length, so the bars
        // reveal nothing about how long the hidden words are. Public so the trial page can
        // swap each bar for a drawn seal instead of printing the characters.
        public const string RedactionBar = "█████";

        private readonly EntityRegistry _registry;
        private readonly PathFinderService _pathFinder;

        public MentatTrialService(EntityRegistry registry, PathFinderService pathFinder)
        {
            _registry = registry;
            _pathFinder = pathFinder;
        }

        /// <summary>
        /// The answer pool at a given reading progress: every entity the tier rule admits,
        /// ordered by id the same way BuildFullGraph orders the universe, so one deterministic
        /// ordering convention serves the whole site.
        /// </summary>
        public IReadOnlyList<DuneEntity> BuildPool(Func<SpoilerTier, bool> tierVisible)
        {
            return _registry.GetAllEntities<DuneEntity>()
                .Where(entity => tierVisible(entity.SpoilerTier))
                .OrderBy(entity => entity.Id, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        /// <summary>
        /// A stable fingerprint of the pool's membership, for callers that persist a trial and
        /// need to notice the pool changing underneath it (a reader moving their reading
        /// progress mid-day). Two pools holding the same ids always fingerprint alike.
        /// </summary>
        public string PoolFingerprint(IReadOnlyList<DuneEntity> pool)
        {
            return HashPool(pool).ToString("x16");
        }

        /// <summary>
        /// A stable fingerprint of any text, on the same FNV-1a arithmetic as the pool hash.
        /// The trial page seals its stored ledger with it, so a record edited by hand stops
        /// parsing as one the app wrote.
        /// </summary>
        public static string Fingerprint(string text)
        {
            ulong hash = 14695981039346656037UL;
            foreach (var b in Encoding.UTF8.GetBytes(text))
            {
                hash = (hash ^ b) * 1099511628211UL;
            }
            return hash.ToString("x16");
        }

        /// <summary>
        /// The day's sealed record, or null on an empty pool. A date-derived number indexes the
        /// pool, fixed arithmetic and not System.Random, so every runtime lands the same. I mix
        /// it so consecutive days don't walk neighboring ids.
        /// </summary>
        public DuneEntity? SelectDaily(DateOnly date, IReadOnlyList<DuneEntity> pool)
        {
            if (pool.Count == 0)
            {
                return null;
            }

            ulong seed = Mix((ulong)date.DayNumber ^ HashPool(pool));
            return pool[(int)(seed % (ulong)pool.Count)];
        }

        /// <summary>
        /// The five clues, vague to specific: the shape of its web, category, book of first
        /// appearance, one visible connection, and last the redacted summary, the most
        /// identifying line the archive will surrender. Always exactly five and never empty,
        /// since missing data degrades to an honest archive line.
        /// </summary>
        public IReadOnlyList<string> BuildClues(DuneEntity answer, Func<SpoilerTier, bool> tierVisible)
        {
            return new[]
            {
                WebClue(answer, tierVisible),
                CategoryClue(answer),
                BookClue(answer),
                ConnectionClue(answer, tierVisible),
                SummaryClue(answer),
            };
        }

        /// <summary>
        /// Judges one guess: the record itself, the same category, and how many links separate
        /// the two through the visible web. Null distance means no visible chain joins them,
        /// since a route through sealed records would whisper what they hide.
        /// </summary>
        public TrialGuessResult EvaluateGuess(DuneEntity guess, DuneEntity answer, Func<SpoilerTier, bool> tierVisible)
        {
            bool correct = string.Equals(guess.Id, answer.Id, StringComparison.OrdinalIgnoreCase);
            bool sameCategory = GraphLayoutService.CategorySlug(guess) == GraphLayoutService.CategorySlug(answer);

            var path = _pathFinder.FindShortestPath(_registry, guess.Id, answer.Id,
                entity => tierVisible(entity.SpoilerTier), tierVisible);

            return new TrialGuessResult(correct, sameCategory, path is null ? null : path.Count - 1);
        }

        /// <summary>
        /// The category's display name, pluralized the way the universe legend spells them,
        /// shared here so the trial's clue and its reveal card agree with the rest of the site.
        /// </summary>
        public static string CategoryLabel(DuneEntity entity) => entity switch
        {
            Artifact => "Artifacts",
            Discipline => "Disciplines",
            FloraFauna => "Flora & Fauna",
            HistoricalEvent => "Historical Events",
            House => "Houses",
            Organization => "Organizations",
            Persona => "Personas",
            TheologicalSystem => "Theological Systems",
            Vehicle => "Vehicles",
            World => "Worlds",
            _ => "records beyond category",
        };

        // ---- Clue one: the shape of its web ----

        /// <summary>
        /// Structural facts only, nothing quoted. The summary line used to open the trial,
        /// but its unredacted words were a verbatim quote the archive's own search would
        /// trace to the answer in one paste. Counts and categories give search nothing.
        /// </summary>
        private string WebClue(DuneEntity answer, Func<SpoilerTier, bool> tierVisible)
        {
            var neighbors = _registry.GetDirectlyRelated(answer.Id, tierVisible)
                .Where(neighbor => tierVisible(neighbor.SpoilerTier))
                .ToList();

            if (neighbors.Count == 0)
            {
                return "No visible tie binds this record to the web. The archive holds it alone.";
            }

            if (neighbors.Count == 1)
            {
                return "A single visible tie binds this record to the rest of the archive.";
            }

            var leading = neighbors
                .GroupBy(CategoryLabel)
                .OrderByDescending(group => group.Count())
                .ThenBy(group => group.Key, StringComparer.Ordinal)
                .First().Key;

            return $"{CountWord(neighbors.Count)} visible ties bind this record to the web, {leading.ToLowerInvariant()} above all.";
        }

        // ---- Clue five: the redacted summary ----

        private static string SummaryClue(DuneEntity answer)
        {
            if (string.IsNullOrWhiteSpace(answer.ShortDescription))
            {
                return "The archive keeps no summary line for this record. Even the archivists found nothing safe to say.";
            }

            return RedactName(answer.ShortDescription, answer);
        }

        /// <summary>
        /// Blacks out every name, display and alias alike: full forms, words over three
        /// characters, and their fragments. Longer tokens go first so a fragment can't bite
        /// a bigger one. Short words survive; a bar draws more attention.
        /// </summary>
        /// <remarks>
        /// Aliases matter more than the name here. Paul's own summary never says Paul; it says
        /// Kwisatz Haderach, and unsealed that line simply hands the answer over.
        /// </remarks>
        private static string RedactName(string text, DuneEntity answer)
        {
            var tokens = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var knownAs in new[] { answer.Name }.Concat(answer.Aliases))
            {
                foreach (var word in knownAs.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    if (word.Length > 3)
                    {
                        tokens.Add(word.Trim('.', ',', '\''));
                    }

                    foreach (var fragment in word.Split('-', '\'', '’'))
                    {
                        if (fragment.Length > 3)
                        {
                            tokens.Add(fragment);
                        }
                    }
                }
            }

            var redacted = text;
            foreach (var token in tokens.OrderByDescending(t => t.Length))
            {
                // Apostrophes inside the token match either typographic form, and the optional
                // tail swallows a possessive. I use lookarounds instead of \b, since a token can
                // end next to punctuation \b treats as part of a word.
                var pattern = Regex.Escape(token).Replace("'", "['’]");
                redacted = Regex.Replace(
                    redacted,
                    $@"(?<![\w])(?:{pattern})(?:['’]s?)?(?![\w])",
                    RedactionBar,
                    RegexOptions.IgnoreCase);
            }

            // Neighbouring bars fuse into one, so a two-word name and a one-word name seal
            // the same and the bar count stops whispering the answer's shape.
            return Regex.Replace(redacted, $@"{RedactionBar}(?:[\s,]+{RedactionBar})+", RedactionBar);
        }

        // ---- Clue two: the category ----

        private static string CategoryClue(DuneEntity answer)
        {
            return $"This record is filed among the {CategoryLabel(answer)}.";
        }

        // ---- Clue three: the book of first appearance ----

        private static string BookClue(DuneEntity answer) => answer.SpoilerTier switch
        {
            SpoilerTier.Dune => "First enters the chronicles in Dune.",
            SpoilerTier.DuneMessiah => "First enters the chronicles in Dune Messiah.",
            SpoilerTier.ChildrenOfDune => "First enters the chronicles in Children of Dune.",
            SpoilerTier.GodEmperorOfDune => "First enters the chronicles in God Emperor of Dune.",
            SpoilerTier.HereticsOfDune => "First enters the chronicles in Heretics of Dune.",
            SpoilerTier.Chapterhouse => "First enters the chronicles in Chapterhouse: Dune.",
            SpoilerTier.ExpandedUniverse => "Belongs to the Expanded Universe, outside the six chronicles.",
            _ => "The chronicles disagree about where this record first appears.",
        };

        // ---- Clue four: one visible connection ----

        /// <summary>
        /// Names one connected record the reader can see, walking neighbors in id order so the
        /// same trial always names the same one. I prefer a neighbor whose label is also visible,
        /// and a label above the reader's tier stays unsaid.
        /// </summary>
        private string ConnectionClue(DuneEntity answer, Func<SpoilerTier, bool> tierVisible)
        {
            var neighbors = _registry.GetDirectlyRelated(answer.Id, tierVisible)
                .Where(neighbor => tierVisible(neighbor.SpoilerTier))
                .OrderBy(neighbor => neighbor.Id, StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (neighbors.Count == 0)
            {
                return "This record stands apart from the web of connections. Few do.";
            }

            foreach (var neighbor in neighbors)
            {
                if (_registry.GetRelationshipLabel(answer.Id, neighbor.Id) is { } label && tierVisible(label.Tier))
                {
                    return $"A direct connection is on record: {neighbor.Name}, noted in the archive as {label.Role}.";
                }
            }

            return $"A direct connection is on record: {neighbors[0].Name}.";
        }

        // Spelled out while the ledger voice can carry it, digits once it cannot. A count
        // opens the web clue's sentence, so every form here reads right at a capital.
        private static string CountWord(int count) => count switch
        {
            2 => "Two",
            3 => "Three",
            4 => "Four",
            5 => "Five",
            6 => "Six",
            7 => "Seven",
            8 => "Eight",
            9 => "Nine",
            10 => "Ten",
            11 => "Eleven",
            12 => "Twelve",
            _ => count.ToString(),
        };

        // ---- Deterministic arithmetic ----

        /// <summary>
        /// FNV-1a over the pool's ids, uppercased so the fingerprint shares the registry's
        /// indifference to letter case. Order-sensitive, which is safe since BuildPool always
        /// hands the pool over in its one canonical order.
        /// </summary>
        private static ulong HashPool(IReadOnlyList<DuneEntity> pool)
        {
            ulong hash = 14695981039346656037UL;
            foreach (var entity in pool)
            {
                foreach (var b in Encoding.UTF8.GetBytes(entity.Id.ToUpperInvariant()))
                {
                    hash = (hash ^ b) * 1099511628211UL;
                }
                hash = (hash ^ (byte)'\n') * 1099511628211UL;
            }
            return hash;
        }

        /// <summary>
        /// A splitmix-style avalanche: flipping one input bit flips about half the output
        /// bits, which is what stops consecutive day numbers from landing on consecutive
        /// pool indexes.
        /// </summary>
        private static ulong Mix(ulong value)
        {
            value ^= value >> 33;
            value *= 0xFF51AFD7ED558CCDUL;
            value ^= value >> 33;
            value *= 0xC4CEB9FE1A85EC53UL;
            value ^= value >> 33;
            return value;
        }
    }

    /// <summary>
    /// The judgment on a single guess: whether it is the answer, whether it shares the
    /// answer's category, and how many relationship links separate the two through the
    /// visible web. Null distance means no visible chain joins them.
    /// </summary>
    public readonly record struct TrialGuessResult(bool IsCorrect, bool SameCategory, int? LinkDistance);
}
