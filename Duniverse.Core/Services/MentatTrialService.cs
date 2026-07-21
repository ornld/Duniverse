using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Duniverse.Models;

namespace Duniverse.Services
{
    /// <summary>
    /// The pure engine behind the Mentat Trial, the archive's daily deduction game. Each day
    /// it seals one record from the pool the reader's spoiler settings admit, deals out five
    /// clues from vague to specific, and measures every wrong guess by how many relationship
    /// links it sits from the answer. Nothing here touches the clock, the browser, or storage:
    /// the date and the visibility rule arrive as arguments, so the same inputs always produce
    /// the same trial and a plain console can exercise the whole game.
    ///
    /// Spoiler safety is the governing constraint throughout. The pool, the record named in
    /// the connection clue, the relationship label on that connection, and the graph the link
    /// distance is measured through are all filtered by the caller's tier rule, so a reader
    /// sees nothing from books they have not reached, not even as a hint.
    /// </summary>
    public class MentatTrialService
    {
        /// <summary>How many guesses a trial allows before the record is revealed.</summary>
        public const int MaxGuesses = 6;

        /// <summary>How many clues every trial deals, one more revealed after each miss.</summary>
        public const int ClueCount = 5;

        // Every redacted word becomes this same bar regardless of its length, so the bars
        // reveal nothing about how long the hidden words are.
        private const string RedactionBar = "█████";

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
        /// The day's sealed record, or null when the pool is empty. The site's convention for
        /// daily selection is the Home page's: a number derived from the date indexes a
        /// spoiler-filtered pool, with no randomness anywhere. This extends that idiom with a
        /// mixing step, because the raw day count would walk neighboring ids on consecutive
        /// days and a regular visitor would learn the pool's alphabet. The mix is fixed
        /// arithmetic (a splitmix-style finisher), not System.Random, so every runtime lands
        /// on the same record for the same date and pool. Different reading progress means a
        /// different pool and usually a different record; that is by design, since each tier's
        /// pool must stand alone without leaking what the others hold.
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
        /// The trial's five clues for a record, ordered vague to specific: the redacted
        /// summary, the category, the book of first appearance, one visible connection, and
        /// the shape of the name. Always exactly five, each non-empty; missing data degrades
        /// to an honest archive line rather than a gap.
        /// </summary>
        public IReadOnlyList<string> BuildClues(DuneEntity answer, Func<SpoilerTier, bool> tierVisible)
        {
            return new[]
            {
                SummaryClue(answer),
                CategoryClue(answer),
                BookClue(answer),
                ConnectionClue(answer, tierVisible),
                NameShapeClue(answer),
            };
        }

        /// <summary>
        /// Judges one guess against the answer: whether it is the record itself, whether it is
        /// filed in the same category, and how many relationship links separate the two through
        /// the spoiler-filtered web. A null distance means no visible chain joins them; the
        /// chain may exist in the full archive, but a route through sealed records must not be
        /// measured, or its length would whisper about what the seals hide.
        /// </summary>
        public TrialGuessResult EvaluateGuess(DuneEntity guess, DuneEntity answer, Func<SpoilerTier, bool> tierVisible)
        {
            bool correct = string.Equals(guess.Id, answer.Id, StringComparison.OrdinalIgnoreCase);
            bool sameCategory = GraphLayoutService.CategorySlug(guess) == GraphLayoutService.CategorySlug(answer);

            var path = _pathFinder.FindShortestPath(_registry, guess.Id, answer.Id,
                entity => tierVisible(entity.SpoilerTier));

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

        // ---- Clue one: the redacted summary ----

        private static string SummaryClue(DuneEntity answer)
        {
            if (string.IsNullOrWhiteSpace(answer.ShortDescription))
            {
                return "The archive keeps no summary line for this record. Even the archivists found nothing safe to say.";
            }

            return RedactName(answer.ShortDescription, answer.Name);
        }

        /// <summary>
        /// Blacks out the record's own name inside a piece of text: the full name, every word
        /// of it longer than three characters, and the fragments those words break into around
        /// hyphens and apostrophes. Matching is case-insensitive, tolerates the curly
        /// apostrophe, and swallows a trailing possessive, so "Muad'Dib's" falls with
        /// "Muad'Dib". Longer tokens are replaced first, keeping a fragment from biting a hole
        /// in a larger token it belongs to. Short words (of, the, Ix) survive; a bar for every
        /// two-letter word would draw more attention than the word itself.
        /// </summary>
        private static string RedactName(string text, string name)
        {
            var tokens = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in name.Split(' ', StringSplitOptions.RemoveEmptyEntries))
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

            var redacted = text;
            foreach (var token in tokens.OrderByDescending(t => t.Length))
            {
                // Apostrophes inside the token match either typographic form; the optional
                // tail swallows a possessive. Lookarounds stand in for \b because a token
                // can end next to punctuation \b treats as part of a word.
                var pattern = Regex.Escape(token).Replace("'", "['’]");
                redacted = Regex.Replace(
                    redacted,
                    $@"(?<![\w])(?:{pattern})(?:['’]s?)?(?![\w])",
                    RedactionBar,
                    RegexOptions.IgnoreCase);
            }

            return redacted;
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
        /// Names one directly connected record the reader is cleared to see, walking neighbors
        /// in id order so the same trial always names the same one. A neighbor whose
        /// relationship label is also admitted is preferred, and the label rides along exactly
        /// as the related sections show it; a label above the reader's tier stays unsaid even
        /// when the neighbor itself is visible, the precedent RelatedSection set. With no
        /// visible neighbors at all, the isolation is itself the clue.
        /// </summary>
        private string ConnectionClue(DuneEntity answer, Func<SpoilerTier, bool> tierVisible)
        {
            var neighbors = _registry.GetDirectlyRelated(answer.Id)
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

        // ---- Clue five: the shape of the name ----

        private static string NameShapeClue(DuneEntity answer)
        {
            var words = answer.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0)
            {
                return "The record's name is missing from the index. Its shape cannot be told.";
            }

            char first = words[0].FirstOrDefault(char.IsLetterOrDigit);
            if (first == default)
            {
                first = words[0][0];
            }
            first = char.ToUpperInvariant(first);

            return words.Length == 1
                ? $"One word. It begins with {first}."
                : $"{CountWord(words.Length)} words. The first begins with {first}.";
        }

        private static string CountWord(int count) => count switch
        {
            2 => "Two",
            3 => "Three",
            4 => "Four",
            5 => "Five",
            6 => "Six",
            _ => count.ToString(),
        };

        // ---- Deterministic arithmetic ----

        /// <summary>
        /// FNV-1a over the pool's ids, uppercased so the fingerprint shares the registry's
        /// indifference to letter case. Order-sensitive, which is safe because BuildPool
        /// always hands the pool over in its one canonical order.
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
