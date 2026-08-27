using System;
using System.Collections.Generic;
using System.Linq;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Data
{
    /// <summary>
    /// The Siridar Register's data: who holds each world, era by era, in one reviewable
    /// file like the maps beside it. An era's Tier is the book that makes the holding
    /// known, so the register grows with the reader.
    /// </summary>
    public static class FiefMap
    {
        // Eras run in story order, not tier order. The prequel entries sit first where
        // they belong, and the last era a reader can see is the holder the register shows.

        // Arrakeen, Sietch Tabr and Onn stay off the register on purpose: they are places
        // on Arrakis, not planetary fiefs, and their stories live on their own records.
        public static readonly IReadOnlyList<FiefLine> Lines = new List<FiefLine>
        {
            new("loc_Arrakis", new[] { "loc_Rakis" }, new List<FiefEra>
            {
                new(SpoilerTier.ExpandedUniverse, "house_Richese", "House Richese", "the fief before the Harkonnens"),
                new(SpoilerTier.Dune, "house_Harkonnen", "House Harkonnen", "eighty years under Imperial fief"),
                new(SpoilerTier.Dune, "house_Atreides", "House Atreides", "granted as a trap, held as the imperial seat"),
                new(SpoilerTier.ChildrenOfDune, "char_LetoIIAtreides", "Leto II Atreides", "taken with the throne at the regency's end"),
                new(SpoilerTier.HereticsOfDune, "org_BeneGesserit", "Bene Gesserit stewardship", "over the priesthood of the Divided God, until the Honored Matres burned the world bare"),
            }),

            new("loc_Caladan", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.Dune, "house_Atreides", "House Atreides", "home for twenty-six generations"),
            }),

            new("loc_GiediPrime", new[] { "loc_Gammu" }, new List<FiefEra>
            {
                new(SpoilerTier.Dune, "house_Harkonnen", "House Harkonnen", "worked to soot and profit"),
                new(SpoilerTier.HereticsOfDune, "org_BeneGesserit", "Bene Gesserit", "a training and archive world, renamed Gammu"),
            }),

            new("loc_Kaitain", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.Dune, "house_Corrino", "House Corrino", "seat of the Golden Lion Throne"),
            }),

            new("loc_SalusaSecundus", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.Dune, "house_Corrino", "House Corrino", "prison world first, exile seat after Arrakeen"),
            }),

            new("loc_Ix", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.ExpandedUniverse, "house_Vernius", "House Vernius", "the Earls of Ix"),
                new(SpoilerTier.ExpandedUniverse, "org_BeneTleilax", "Bene Tleilax", "seized in the coup"),
                new(SpoilerTier.ExpandedUniverse, "house_Vernius", "House Vernius", "restored after the coup years"),
                // The record itself dodges the name at book one, so the register dodges
                // with it. A reader who opts into the prequels sees the family instead.
                new(SpoilerTier.Dune, null, "An Ixian noble house", null, VeiledByExpanded: true),
            }),

            new("loc_Tleilax", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.Dune, "org_BeneTleilax", "Bene Tleilax", "closed to every outsider"),
            }),

            new("loc_WallachIX", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.Dune, "org_BeneGesserit", "Bene Gesserit", "seat of the Mother School"),
            }),

            new("loc_Ecaz", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.Dune, "house_Ecaz", "House Ecaz"),
            }),

            new("loc_Richese", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.Dune, "house_Richese", "House Richese", "second only to Ix in the machine trades"),
            }),

            new("loc_Lankiveil", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.ExpandedUniverse, "house_Harkonnen", "House Harkonnen", "Abulurd Harkonnen's quiet whale-fur holding"),
            }),

            new("loc_Chapterhouse", Array.Empty<string>(), new List<FiefEra>
            {
                new(SpoilerTier.HereticsOfDune, "org_BeneGesserit", "Bene Gesserit", "held off every chart"),
            }),
        };

        // Section order: the imperial line first, then the Great Houses, then the orders.
        // Unranked holders follow in the order the register meets them.
        private static readonly string[] HolderRank =
        {
            "house_Corrino",
            "char_LetoIIAtreides",
            "house_Atreides",
            "house_Harkonnen",
            "house_Vernius",
            "house_Ecaz",
            "house_Richese",
            "org_BeneGesserit",
            "org_BeneTleilax",
        };

        /// <summary>
        /// The eras this reader has earned, in story order. A veiled era drops out once
        /// the Expanded Universe names what it hides.
        /// </summary>
        public static IEnumerable<FiefEra> VisibleEras(FiefLine line, Func<SpoilerTier, bool> visible)
        {
            bool expanded = visible(SpoilerTier.ExpandedUniverse);
            return line.Eras.Where(era => visible(era.Tier) && !(era.VeiledByExpanded && expanded));
        }

        /// <summary>The holder the register shows: the last era the reader can see.</summary>
        public static FiefEra? CurrentEra(FiefLine line, Func<SpoilerTier, bool> visible)
        {
            return VisibleEras(line, visible).LastOrDefault();
        }

        /// <summary>The register's row for one world, or null for a world it does not chart.</summary>
        public static FiefLine? LineFor(string worldId)
        {
            return Lines.FirstOrDefault(line =>
                string.Equals(line.WorldId, worldId, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Where a holder's section stands on the page. Unranked ids sort last.</summary>
        public static int HolderOrder(string? holderId)
        {
            if (holderId is null)
            {
                return int.MaxValue;
            }

            int at = Array.FindIndex(HolderRank, id => string.Equals(id, holderId, StringComparison.OrdinalIgnoreCase));
            return at < 0 ? int.MaxValue - 1 : at;
        }

        /// <summary>
        /// Debug-only id check, like the maps beside it. A typo here fails at startup
        /// instead of silently dropping a row in production.
        /// </summary>
        public static void Validate(EntityRegistry registry)
        {
#if DEBUG
            foreach (var line in Lines)
            {
                if (registry.GetEntity(line.WorldId) is null)
                {
                    throw new InvalidOperationException(
                        $"FiefMap references unknown world id '{line.WorldId}'. Fix the id or remove the line.");
                }

                foreach (var later in line.LaterNames)
                {
                    if (registry.GetEntity(later) is null)
                    {
                        throw new InvalidOperationException(
                            $"FiefMap references unknown later name '{later}' on {line.WorldId}.");
                    }
                }

                foreach (var era in line.Eras)
                {
                    if (era.HolderId is not null && registry.GetEntity(era.HolderId) is null)
                    {
                        throw new InvalidOperationException(
                            $"FiefMap references unknown holder id '{era.HolderId}' on {line.WorldId}.");
                    }
                }
            }
#endif
        }
    }
}
