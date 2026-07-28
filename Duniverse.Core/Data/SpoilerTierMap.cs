using System;
using System.Collections.Generic;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Data
{
    /// <summary>
    /// The single place that records which entities are spoilers, and how far a reader must have
    /// read before it is safe to show them. Everything not listed here stays at the default
    /// <see cref="SpoilerTier.Dune"/>, meaning it is never hidden.
    ///
    /// This is deliberately one flat, grouped list rather than a tag scattered across ten seeder
    /// files, so the whole spoiler policy can be reviewed and adjusted in a single scan. Read it
    /// as "who gets hidden until which book." The calls here are a canon-informed first pass and
    /// are meant to be corrected freely: moving an entity between groups is the only edit needed
    /// to change when the site reveals it.
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
                ["char_ElroodIX"] = SpoilerTier.ExpandedUniverse,
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
        /// Stamps each listed tier onto its entity in the registry. Call once, after every seeder
        /// has been registered. In debug builds an id that matches no registered entity throws,
        /// so a typo here fails loudly during development rather than silently leaving a spoiler
        /// unprotected in production.
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
