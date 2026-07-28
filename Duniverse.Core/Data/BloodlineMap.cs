using System;
using System.Collections.Generic;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Data
{
    /// <summary>
    /// The curated data behind the Bloodlines chart: who stands in it, where, and how the
    /// lines of descent and marriage run. Hand-placed rather than computed, the way a
    /// genealogist would draw it, so the Atreides and Harkonnen lines visibly converge on
    /// Paul and the chart below him narrows to the Golden Path.
    ///
    /// Spoiler behavior needs no special handling here: every node is gated by its entity's
    /// tier (plus its own, when presence in the chart is itself a reveal), and the page drops
    /// hidden people and every line touching them. Like the other maps, this is a
    /// canon-informed first pass, grouped for review; move people and lines freely.
    /// </summary>
    public static class BloodlineMap
    {
        // ---- The people, by generation (row) and column (0 to 1, left to right) ----
        public static readonly IReadOnlyList<BloodlineNode> Nodes = new List<BloodlineNode>
        {
            // Generation 0: founders of the Expanded Universe era
            new("char_VorianAtreides", 0, 0.18, "atreides"),
            new("char_XavierHarkonnen", 0, 0.78, "harkonnen"),

            // Generation 1: the elder generation of the classic era
            new("char_DukePaulusAtreides", 1, 0.12, "atreides"),
            new("char_HelenaAtreides", 1, 0.26, "other"),   // Richese blood, standing here only as Leto's mother
            new("char_ElroodIX", 1, 0.50, "corrino"),
            new("char_AbulurdHarkonnen", 1, 0.66, "harkonnen"),
            new("char_BaronHarkonnen", 1, 0.80, "harkonnen"),
            new("char_PardotKynes", 1, 0.95, "fremen"),

            // Generation 2: the players of Dune's opening
            new("char_DukeLetoAtreides", 2, 0.12, "atreides"),
            new("char_LadyJessica", 2, 0.26, "harkonnen", Ring: "atreides"),   // the secret of the chart
            new("char_ShaddamIV", 2, 0.55, "corrino"),
            new("char_GlossuRabban", 2, 0.72, "harkonnen"),
            new("char_FeydRautha", 2, 0.84, "harkonnen"),
            new("char_LietKynes", 2, 0.95, "fremen"),

            // Generation 3: Muad'Dib's generation
            new("char_DuncanIdaho", 3, 0.04, "other", Tier: SpoilerTier.ChildrenOfDune), // stands here only as Alia's husband
            new("char_AliaAtreides", 3, 0.16, "atreides", Ring: "harkonnen"),
            new("char_PaulAtreides", 3, 0.30, "atreides", Ring: "harkonnen"),
            new("char_Chani", 3, 0.44, "fremen"),
            new("char_PrincessIrulan", 3, 0.58, "corrino"),
            new("char_WensiciaCorrino", 3, 0.72, "corrino"),

            // Generation 4: the twins and the last Corrino hope
            new("char_LetoIIAtreides", 4, 0.30, "atreides", Ring: "fremen"),
            new("char_GhanimaAtreides", 4, 0.44, "atreides", Ring: "fremen"),
            new("char_FaradnCorrino", 4, 0.58, "corrino"),

            // Generations 5 and 6: the far end of the Golden Path
            new("char_MoneoAtreides", 5, 0.51, "atreides"),
            new("char_SionaAtreides", 6, 0.51, "atreides"),
        };

        // ---- Marriages, concubinages, and matches ----
        public static readonly IReadOnlyList<BloodlineUnion> Unions = new List<BloodlineUnion>
        {
            new("char_DukePaulusAtreides", "char_HelenaAtreides", "Political match, coldly kept"),
            new("char_DukeLetoAtreides", "char_LadyJessica", "Concubine, never wed"),
            new("char_PaulAtreides", "char_Chani", "His Fremen concubine and true bond"),
            new("char_PaulAtreides", "char_PrincessIrulan", "Marriage in name alone", Dashed: true),
            new("char_AliaAtreides", "char_DuncanIdaho", "Husband and wife", Tier: SpoilerTier.ChildrenOfDune),
            new("char_GhanimaAtreides", "char_FaradnCorrino", "Companioned by Leto II's decree", Tier: SpoilerTier.ChildrenOfDune),
        };

        // ---- Lines of descent ----
        public static readonly IReadOnlyList<BloodlineDescent> Descents = new List<BloodlineDescent>
        {
            // Across the ten-thousand-year gap
            new("char_DukePaulusAtreides", "char_VorianAtreides", Label: "Ten millennia of Atreides descent", Dashed: true),
            new("char_BaronHarkonnen", "char_XavierHarkonnen", Label: "Ten millennia of Harkonnen descent", Dashed: true),

            // Into the classic era
            new("char_DukeLetoAtreides", "char_DukePaulusAtreides", "char_HelenaAtreides"),
            new("char_ShaddamIV", "char_ElroodIX"),
            new("char_GlossuRabban", "char_AbulurdHarkonnen"),
            new("char_FeydRautha", "char_AbulurdHarkonnen"),
            new("char_GlossuRabban", "char_BaronHarkonnen", Label: "Nephew, his blunt instrument", Dashed: true),
            new("char_FeydRautha", "char_BaronHarkonnen", Label: "Nephew and chosen heir", Dashed: true),
            new("char_LietKynes", "char_PardotKynes"),

            // The reveal: Jessica is the Baron's daughter
            new("char_LadyJessica", "char_BaronHarkonnen", Label: "Daughter, hidden by the Bene Gesserit breeding program"),

            // Muad'Dib's generation
            new("char_PaulAtreides", "char_DukeLetoAtreides", "char_LadyJessica"),
            new("char_AliaAtreides", "char_DukeLetoAtreides", "char_LadyJessica"),
            new("char_Chani", "char_LietKynes"),
            new("char_PrincessIrulan", "char_ShaddamIV"),
            new("char_WensiciaCorrino", "char_ShaddamIV"),

            // The twins and Farad'n
            new("char_LetoIIAtreides", "char_PaulAtreides", "char_Chani"),
            new("char_GhanimaAtreides", "char_PaulAtreides", "char_Chani"),
            new("char_FaradnCorrino", "char_WensiciaCorrino"),

            // The Golden Path's long tail
            new("char_MoneoAtreides", "char_GhanimaAtreides", "char_FaradnCorrino",
                Label: "Descendant across thirty-five centuries of the breeding program", Dashed: true),
            new("char_SionaAtreides", "char_MoneoAtreides"),
        };

        // ---- Spans of time the chart does not draw person by person ----
        public static readonly IReadOnlyList<BloodlineBand> Bands = new List<BloodlineBand>
        {
            new(1, "Ten thousand years of unrecorded descent"),
            new(5, "Thirty-five centuries of the God Emperor's breeding program"),
        };

        /// <summary>
        /// Confirms every id in the chart matches a registered entity. Debug builds throw on a
        /// typo so it fails during development, never silently in production.
        /// </summary>
        public static void Validate(EntityRegistry registry)
        {
#if DEBUG
            void Check(string id, string where)
            {
                if (registry.GetEntity(id) is null)
                {
                    throw new InvalidOperationException(
                        $"BloodlineMap {where} references unknown entity id '{id}'. Fix the id or remove the entry.");
                }
            }

            foreach (var node in Nodes) Check(node.EntityId, "node");
            foreach (var union in Unions) { Check(union.PartnerAId, "union"); Check(union.PartnerBId, "union"); }
            foreach (var descent in Descents)
            {
                Check(descent.ChildId, "descent");
                Check(descent.ParentAId, "descent");
                if (descent.ParentBId is not null) Check(descent.ParentBId, "descent");
            }
#endif
        }
    }
}
