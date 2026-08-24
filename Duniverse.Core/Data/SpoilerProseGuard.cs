using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Duniverse.Data.Seeders;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Data
{
    /// <summary>
    /// Catches the spoilers the tier gate cannot see. The gate hides whole records and whole
    /// layers, never sentences, so a safe record's prose can still name a sealed one. Debug
    /// builds throw on it; Release never runs the check.
    /// </summary>
    public static class SpoilerProseGuard
    {
        /// <summary>
        /// Reads every line a record shows and fails when one names a record the reader has not
        /// unlocked. Run it after SpoilerTierMap, since it compares against the stamped tiers.
        /// </summary>
        public static void Validate(EntityRegistry registry)
        {
#if DEBUG
            var all = registry.GetAllEntities<DuneEntity>().ToList();
            var breaches = new List<string>();

            foreach (var source in all)
            {
                Scan(source.Id, source.Id, source.SpoilerTier, DisplayedText(source), "its own entry");

                foreach (var layer in source.HistoryLayers)
                {
                    Scan(source.Id, source.Id, layer.Tier, layer.Text, $"its {layer.Tier} layer");
                }
            }

            // Terminology entries print on their own page, and the ones carrying SeeEntityId
            // print on that record as well. Same rule applies to a definition as to prose.
            foreach (var term in GlossarySeeder.GetTerms())
            {
                Scan($"the term '{term.Term}'", term.SeeEntityId, term.Tier,
                    term.Term + " " + term.Definition, "its definition");
            }

            if (breaches.Count > 0)
            {
                throw new InvalidOperationException(
                    "Prose names records the reader has not unlocked:"
                    + Environment.NewLine + string.Join(Environment.NewLine, breaches)
                    + Environment.NewLine
                    + "Move the sentence into a HistoryLayer at the right tier, or raise the record's own tier.");
            }

            void Scan(string owner, string? selfId, SpoilerTier readAt, string? text, string where)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return;
                }

                foreach (var target in all)
                {
                    if (string.Equals(target.Id, selfId, StringComparison.OrdinalIgnoreCase)
                        || Admits(readAt, target.SpoilerTier))
                    {
                        continue;
                    }

                    // Two letters match inside ordinary words, so the shortest names sit this
                    // check out rather than cry wolf on every entry that contains them.
                    var hit = NamesOf(target).FirstOrDefault(name => name.Length >= 3 && Mentions(text, name));
                    if (hit is not null)
                    {
                        breaches.Add(
                            $"  {owner} ({readAt}) names '{hit}' in {where}, and {target.Id} is sealed until {target.SpoilerTier}.");
                    }
                }
            }
#endif
        }

#if DEBUG
        // The weakest reader who can reach this text. A novel passage assumes the Expanded
        // Universe toggle is off. An Expanded Universe passage assumes someone who opted in
        // and has only finished Dune, since the toggle runs free of novel progress.
        private static bool Admits(SpoilerTier readAt, SpoilerTier target)
        {
            if (readAt == SpoilerTier.ExpandedUniverse)
            {
                return target is SpoilerTier.Dune or SpoilerTier.ExpandedUniverse;
            }

            return target != SpoilerTier.ExpandedUniverse && target <= readAt;
        }

        // Reflection so a new field on a record joins the check for free. Layers carry their
        // own tier and get scanned on their own, so the HistorySegment list is not a string
        // list and falls through here untouched.
        private static readonly HashSet<string> NotShownAsProse = new(StringComparer.Ordinal)
        {
            nameof(DuneEntity.Id),
            nameof(DuneEntity.Name),
            nameof(DuneEntity.ImagePath),
            nameof(DuneEntity.RelatedEntityIds),
            nameof(Persona.AffiliationIds),
            nameof(House.HistoricalRivalries),
        };

        private static string DisplayedText(DuneEntity entity)
        {
            var builder = new StringBuilder();

            foreach (var property in entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (NotShownAsProse.Contains(property.Name))
                {
                    continue;
                }

                switch (property.GetValue(entity))
                {
                    case string text:
                        builder.Append(' ').Append(text);
                        break;
                    case IEnumerable<string> lines:
                        foreach (var line in lines)
                        {
                            builder.Append(' ').Append(line);
                        }
                        break;
                }
            }

            return builder.ToString();
        }

        private static IEnumerable<string> NamesOf(DuneEntity entity)
        {
            yield return entity.Name;
            foreach (var alias in entity.Aliases)
            {
                yield return alias;
            }
        }

        // Whole words only. Without the letter test either side, "Rakis" reports itself inside
        // "Arrakis" and every worthwhile hit drowns in noise.
        private static bool Mentions(string haystack, string needle)
        {
            int at = haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase);

            while (at >= 0)
            {
                int after = at + needle.Length;
                bool clearLeft = at == 0 || !char.IsLetter(haystack[at - 1]);
                bool clearRight = after >= haystack.Length || !char.IsLetter(haystack[after]);

                if (clearLeft && clearRight)
                {
                    return true;
                }

                at = haystack.IndexOf(needle, at + 1, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
#endif
    }
}
