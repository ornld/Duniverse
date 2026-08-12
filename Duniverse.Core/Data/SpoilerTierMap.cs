using System;
using System.Collections.Generic;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Data
{
    /// <summary>
    /// The one place that records which entities are spoilers and how far a reader must be before
    /// seeing them. Anything unlisted stays at <see cref="SpoilerTier.Dune"/> and never hides. I
    /// keep it flat so the whole policy reads in one scan.
    /// </summary>
    public static class SpoilerTierMap
    {
        public static readonly IReadOnlyDictionary<string, SpoilerTier> Tiers =
            new Dictionary<string, SpoilerTier>(StringComparer.OrdinalIgnoreCase)
            {
                // ---- Dune Messiah ----
                ["char_Scytale"] = SpoilerTier.DuneMessiah,          // Tleilaxu Face Dancer
                ["char_Edric"] = SpoilerTier.DuneMessiah,            // Guild Steersman conspirator
                ["char_Bijaz"] = SpoilerTier.DuneMessiah,            // Tleilaxu dwarf
                ["org_Qizarate"] = SpoilerTier.DuneMessiah,          // Muad'Dib's priesthood
                ["theo_ChurchOfMuadDib"] = SpoilerTier.DuneMessiah,
                ["disc_GholaCultivation"] = SpoilerTier.DuneMessiah, // gholas debut with Hayt
                ["art_StoneBurner"] = SpoilerTier.DuneMessiah,       // the weapon that blinds Paul
                ["event_MuadDibJihad"] = SpoilerTier.DuneMessiah,
                ["event_MessiahConspiracy"] = SpoilerTier.DuneMessiah,

                // ---- Children of Dune ----
                ["char_LetoIIAtreides"] = SpoilerTier.ChildrenOfDune,
                ["char_GhanimaAtreides"] = SpoilerTier.ChildrenOfDune,
                ["char_FaradnCorrino"] = SpoilerTier.ChildrenOfDune,
                ["char_WensiciaCorrino"] = SpoilerTier.ChildrenOfDune,
                ["char_Tyekanik"] = SpoilerTier.ChildrenOfDune,
                ["char_Javid"] = SpoilerTier.ChildrenOfDune,
                ["theo_GoldenPath"] = SpoilerTier.ChildrenOfDune,
                ["bio_LazaTiger"] = SpoilerTier.ChildrenOfDune,
                ["event_AliaRegency"] = SpoilerTier.ChildrenOfDune,
                ["event_GoldenPathBegins"] = SpoilerTier.ChildrenOfDune,
                ["event_TigerAssassinationAttempt"] = SpoilerTier.ChildrenOfDune,

                // ---- God Emperor of Dune ----
                ["char_MoneoAtreides"] = SpoilerTier.GodEmperorOfDune,
                ["char_SionaAtreides"] = SpoilerTier.GodEmperorOfDune,
                ["char_HwiNoree"] = SpoilerTier.GodEmperorOfDune,
                ["org_FishSpeakers"] = SpoilerTier.GodEmperorOfDune,
                ["org_MuseumFremen"] = SpoilerTier.GodEmperorOfDune,
                ["loc_Onn"] = SpoilerTier.GodEmperorOfDune,          // festival city of Leto II's reign
                ["event_DeathOfTheGodEmperor"] = SpoilerTier.GodEmperorOfDune,
                ["event_TheScattering"] = SpoilerTier.GodEmperorOfDune,

                // ---- Heretics of Dune / Chapterhouse: Dune ----
                ["char_MilesTeg"] = SpoilerTier.HereticsOfDune,
                ["char_DarwiOdrade"] = SpoilerTier.HereticsOfDune,
                ["char_Sheeana"] = SpoilerTier.HereticsOfDune,
                ["char_Taraza"] = SpoilerTier.HereticsOfDune,
                ["char_Waff"] = SpoilerTier.HereticsOfDune,
                ["char_Murbella"] = SpoilerTier.HereticsOfDune,
                ["char_Schwangyu"] = SpoilerTier.HereticsOfDune,     // Reverend Mother opposing the ghola project on Gammu
                ["org_HonoredMatres"] = SpoilerTier.HereticsOfDune,
                ["disc_HonoredMatreImprinting"] = SpoilerTier.HereticsOfDune,
                ["bio_Futar"] = SpoilerTier.HereticsOfDune,          // creatures out of the Scattering
                ["vehicle_NoShip"] = SpoilerTier.HereticsOfDune,     // prescience-proof ships
                ["loc_Rakis"] = SpoilerTier.HereticsOfDune,          // Arrakis, millennia later
                ["loc_Gammu"] = SpoilerTier.HereticsOfDune,          // formerly Giedi Prime
                ["loc_Chapterhouse"] = SpoilerTier.HereticsOfDune,   // hidden Bene Gesserit world
                ["event_DestructionOfRakis"] = SpoilerTier.HereticsOfDune,

                // ---- Expanded Universe (Legends of Dune, Prelude to Dune, Great Schools, and later) ----
                ["char_VorianAtreides"] = SpoilerTier.ExpandedUniverse,
                ["char_SerenaButler"] = SpoilerTier.ExpandedUniverse,
                ["char_NormaCenva"] = SpoilerTier.ExpandedUniverse,
                ["char_Omnius"] = SpoilerTier.ExpandedUniverse,
                ["char_Erasmus"] = SpoilerTier.ExpandedUniverse,
                ["char_XavierHarkonnen"] = SpoilerTier.ExpandedUniverse,
                ["char_AgamemnonTitan"] = SpoilerTier.ExpandedUniverse,
                ["char_RaquellaBertoAnirul"] = SpoilerTier.ExpandedUniverse,
                ["char_GilbertusAlbans"] = SpoilerTier.ExpandedUniverse,
                ["char_JosefVenport"] = SpoilerTier.ExpandedUniverse,
                ["char_BronsoOfIx"] = SpoilerTier.ExpandedUniverse,
                ["char_DominicVernius"] = SpoilerTier.ExpandedUniverse,
                ["char_DukePaulusAtreides"] = SpoilerTier.ExpandedUniverse, // the Old Duke is unnamed in Dune; the Paulus story is Prelude material
                ["char_HelenaAtreides"] = SpoilerTier.ExpandedUniverse,     // Leto's mother, and her hand in the bullring, are Prelude material too
                ["char_RhomburVernius"] = SpoilerTier.ExpandedUniverse,
                // char_ElroodIX sits at the default on purpose. Dune names him as Shaddam's
                // father, so hiding him kept a first-book reader from what their own appendix
                // already said. The decline and the poisoning wait in an ExpandedUniverse layer.
                ["char_AbulurdHarkonnen"] = SpoilerTier.ExpandedUniverse,
                ["org_LeagueOfNobles"] = SpoilerTier.ExpandedUniverse,
                ["org_SynchronizedWorlds"] = SpoilerTier.ExpandedUniverse,
                ["org_MentatSchool"] = SpoilerTier.ExpandedUniverse,
                ["house_Vernius"] = SpoilerTier.ExpandedUniverse,
                ["house_Moritani"] = SpoilerTier.ExpandedUniverse,
                ["house_Wayku"] = SpoilerTier.ExpandedUniverse,
                ["loc_Lankiveil"] = SpoilerTier.ExpandedUniverse,
                ["vehicle_CymekWalker"] = SpoilerTier.ExpandedUniverse,
                ["event_IxianCoup"] = SpoilerTier.ExpandedUniverse,
                ["event_DeathOfDukePaulus"] = SpoilerTier.ExpandedUniverse,
                ["event_ReverendMotherBreakthrough"] = SpoilerTier.ExpandedUniverse,
            };

        /// <summary>
        /// Stamps each listed tier onto its entity. Call once, after every seeder has registered.
        /// In debug builds an unknown id throws, so a typo fails loudly here rather than quietly
        /// leaving a spoiler unprotected in production.
        /// </summary>
        public static void Apply(EntityRegistry registry)
        {
            foreach (var (id, tier) in Tiers)
            {
                var entity = registry.GetEntity(id);
                if (entity is null)
                {
#if DEBUG
                    throw new InvalidOperationException(
                        $"SpoilerTierMap references unknown entity id '{id}'. Fix the id or remove the entry.");
#else
                    continue;
#endif
                }

                entity.SpoilerTier = tier;
            }
        }
    }
}
