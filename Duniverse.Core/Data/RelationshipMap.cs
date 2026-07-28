using System;
using System.Collections.Generic;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Data
{
    /// <summary>
    /// The single place that gives connections their meaning. RelatedEntityIds says two entries
    /// touch; this map says how: mother and son, betrayer and betrayed, slayer and slain. Each
    /// entry is one pair read in both directions (FromRole is what From is to To, ToRole the
    /// reverse), and a pair not linked in any seeder becomes a real connection when registered,
    /// so canon links can be introduced here without touching ten seeder files.
    ///
    /// One label per pair. Where a relationship changes across books (Alia and the Baron), the
    /// label carries the tier of the fact it reveals, and the site hides the label (not the
    /// connection) from readers who haven't gotten there. Like SpoilerTierMap, these are
    /// canon-informed first-pass calls, grouped for review: correct anything freely.
    /// </summary>
    public static class RelationshipMap
    {
        public static readonly IReadOnlyList<EntityRelationship> Relationships = new List<EntityRelationship>
        {
            // ---- House Atreides: blood ----
            new("char_LadyJessica", "char_PaulAtreides", "Mother", "Son"),
            new("char_DukeLetoAtreides", "char_PaulAtreides", "Father", "Son"),
            new("char_LadyJessica", "char_AliaAtreides", "Mother", "Daughter"),
            new("char_DukeLetoAtreides", "char_AliaAtreides", "Father he never met", "Daughter born after his death"),
            new("char_PaulAtreides", "char_AliaAtreides", "Brother", "Sister"),
            new("char_DukeLetoAtreides", "char_LadyJessica", "Her Duke and beloved", "Concubine and truest counsel"),
            new("char_PaulAtreides", "char_Chani", "Her Usul", "Beloved concubine"),
            new("char_PaulAtreides", "char_PrincessIrulan", "Husband in name alone", "Wife in name alone"),
            new("char_PaulAtreides", "char_LetoIIAtreides", "Father", "Son"),
            new("char_PaulAtreides", "char_GhanimaAtreides", "Father", "Daughter"),
            new("char_Chani", "char_LetoIIAtreides", "Mother", "Son"),
            new("char_Chani", "char_GhanimaAtreides", "Mother", "Daughter"),
            new("char_LetoIIAtreides", "char_GhanimaAtreides", "Twin brother", "Twin sister"),
            new("char_GhanimaAtreides", "char_FaradnCorrino", "Betrothed by Leto's decree", "Betrothed by Leto's decree", SpoilerTier.ChildrenOfDune),

            // ---- The hidden Harkonnen line (revealed inside Dune itself) ----
            new("char_BaronHarkonnen", "char_LadyJessica", "Father, unknown to her", "Daughter of the breeding program"),
            new("char_BaronHarkonnen", "char_PaulAtreides", "Grandfather", "Grandson"),
            new("char_BaronHarkonnen", "char_AliaAtreides", "Grandfather", "Granddaughter and his slayer"),

            // ---- House Harkonnen ----
            new("char_BaronHarkonnen", "char_FeydRautha", "Uncle and patron", "Nephew and chosen heir"),
            new("char_BaronHarkonnen", "char_GlossuRabban", "Uncle", "Nephew, his blunt instrument"),
            new("char_GlossuRabban", "char_FeydRautha", "Elder brother", "Younger brother"),
            new("char_AbulurdHarkonnen", "char_GlossuRabban", "Father", "Son", SpoilerTier.ExpandedUniverse),
            new("char_PiterDeVries", "char_BaronHarkonnen", "Twisted Mentat in his service", "Master he schemed for"),
            new("char_PaulAtreides", "char_FeydRautha", "His slayer in the throne room", "Slain in the final duel"),

            // ---- Atreides retainers and teachers ----
            new("char_DuncanIdaho", "char_DukeLetoAtreides", "Swordmaster who died for his House", "His Duke"),
            new("char_DuncanIdaho", "char_PaulAtreides", "Swordmaster and boyhood friend", "The pupil he died shielding"),
            new("char_GurneyHalleck", "char_PaulAtreides", "Weapons teacher, warrior troubadour", "Pupil he trained for war"),
            new("char_ThufirHawat", "char_PaulAtreides", "Mentat tutor", "Pupil"),
            new("char_GurneyHalleck", "char_DukeLetoAtreides", "Warmaster", "His Duke"),
            new("char_ThufirHawat", "char_DukeLetoAtreides", "Master of Assassins", "His Duke"),
            new("char_WellingtonYueh", "char_DukeLetoAtreides", "Betrayer of his House", "The Duke he doomed"),
            new("char_WellingtonYueh", "char_PaulAtreides", "Betrayer who still armed his escape", "Son of the Duke he betrayed"),
            new("char_Stilgar", "char_PaulAtreides", "Naib who sheltered him", "His Duke and his prophet"),
            new("char_GaiusHelenMohiam", "char_LadyJessica", "Teacher at the Mother School", "Former student"),
            new("char_GaiusHelenMohiam", "char_PaulAtreides", "Tested him with the gom jabbar", "Survivor of her test"),

            // ---- The Imperial court ----
            new("char_HasimirFenring", "char_ShaddamIV", "Closest friend and quiet blade", "His Emperor"),
            new("char_HasimirFenring", "char_MargotFenring", "Husband", "Wife"),
            new("char_HasimirFenring", "char_PaulAtreides", "Refused the order to kill him", "Spared by his refusal"),
            new("char_ShaddamIV", "char_PrincessIrulan", "Father", "Eldest daughter"),
            new("char_ShaddamIV", "char_WensiciaCorrino", "Father", "Daughter", SpoilerTier.ChildrenOfDune),
            new("char_WensiciaCorrino", "char_FaradnCorrino", "Mother", "Son", SpoilerTier.ChildrenOfDune),
            new("char_Tyekanik", "char_WensiciaCorrino", "Bashar in her service", "Princess he served", SpoilerTier.ChildrenOfDune),
            new("char_PaulAtreides", "char_ShaddamIV", "Usurper of his throne", "The Emperor he broke at Arrakeen"),
            new("char_LietKynes", "char_PardotKynes", "Son and successor", "Father and first dreamer"),
            new("char_LietKynes", "char_Chani", "Father", "Daughter"),

            // ---- The conspiracy against Muad'Dib ----
            new("char_Scytale", "char_Edric", "Fellow conspirator", "Fellow conspirator", SpoilerTier.DuneMessiah),
            new("char_GaiusHelenMohiam", "char_Edric", "Fellow conspirator", "Fellow conspirator", SpoilerTier.DuneMessiah),
            new("char_Scytale", "char_PaulAtreides", "Face Dancer who plotted his fall", "Target of his conspiracy", SpoilerTier.DuneMessiah),
            new("char_Bijaz", "char_DuncanIdaho", "Carried the trigger for his compulsion", "The ghola he tried to turn", SpoilerTier.DuneMessiah),
            new("char_Otheym", "char_PaulAtreides", "Fedaykin who exposed the plot", "His Muad'Dib", SpoilerTier.DuneMessiah),
            new("char_Korba", "char_PaulAtreides", "Priest who turned conspirator", "The god he betrayed", SpoilerTier.DuneMessiah),

            // ---- The Atreides twins' era ----
            new("char_AliaAtreides", "char_DuncanIdaho", "Wife", "Husband", SpoilerTier.ChildrenOfDune),
            new("char_Javid", "char_AliaAtreides", "Courtier and paramour", "The Regent he beguiled", SpoilerTier.ChildrenOfDune),
            new("char_LetoIIAtreides", "char_AliaAtreides", "Nephew", "Aunt lost to Abomination", SpoilerTier.ChildrenOfDune),
            new("char_LetoIIAtreides", "bio_Sandtrout", "Fused with them and left mankind behind", "The skin that made him a god", SpoilerTier.ChildrenOfDune),
            new("char_FaradnCorrino", "char_LetoIIAtreides", "Scribe bound to his court", "The God Emperor he served", SpoilerTier.ChildrenOfDune),

            // ---- The God Emperor's reign ----
            new("char_MoneoAtreides", "char_LetoIIAtreides", "Majordomo bred to serve", "God Emperor and master", SpoilerTier.GodEmperorOfDune),
            new("char_MoneoAtreides", "char_SionaAtreides", "Father", "Rebel daughter", SpoilerTier.GodEmperorOfDune),
            new("char_SionaAtreides", "char_LetoIIAtreides", "Engineered his fall at the Hidden Ford", "The God Emperor she toppled", SpoilerTier.GodEmperorOfDune),
            new("char_HwiNoree", "char_LetoIIAtreides", "Ixian bride who unmade his resolve", "Her betrothed God Emperor", SpoilerTier.GodEmperorOfDune),
            new("char_DuncanIdaho", "char_LetoIIAtreides", "Serial ghola in his service", "The God Emperor who kept remaking him", SpoilerTier.GodEmperorOfDune),
            new("char_DuncanIdaho", "char_SionaAtreides", "Partner in the God Emperor's fall", "Partner in rebellion", SpoilerTier.GodEmperorOfDune),

            // ---- Heretics and Chapterhouse ----
            new("char_MilesTeg", "char_DarwiOdrade", "Father", "Daughter", SpoilerTier.HereticsOfDune),
            new("char_DarwiOdrade", "char_Taraza", "Successor as Mother Superior", "Predecessor she obeyed to the end", SpoilerTier.HereticsOfDune),
            new("char_MilesTeg", "char_DuncanIdaho", "Bashar guarding his ghola", "The ghola in his charge", SpoilerTier.HereticsOfDune),
            new("char_Murbella", "char_DuncanIdaho", "Honored Matre bound to him", "The man who imprinted her back", SpoilerTier.HereticsOfDune),
            new("char_Sheeana", "bio_ShaiHulud", "Speaks to them, and they obey", "The worms that answer her", SpoilerTier.HereticsOfDune),

            // ---- The Expanded Universe ----
            new("char_AgamemnonTitan", "char_VorianAtreides", "Cymek father", "Son who turned against him", SpoilerTier.ExpandedUniverse),
            new("char_SerenaButler", "char_XavierHarkonnen", "His great love", "Her devoted champion", SpoilerTier.ExpandedUniverse),
            new("char_Erasmus", "char_SerenaButler", "Murdered her infant son", "Mother whose grief lit the Jihad", SpoilerTier.ExpandedUniverse),
            new("char_Omnius", "char_Erasmus", "The evermind he studied humans for", "Independent robot ally", SpoilerTier.ExpandedUniverse),
            new("char_VorianAtreides", "house_Atreides", "Founding forefather", "The House descended from him", SpoilerTier.ExpandedUniverse),
            new("char_XavierHarkonnen", "house_Harkonnen", "Wronged forefather", "The House that bears his name", SpoilerTier.ExpandedUniverse),
            new("char_NormaCenva", "org_SpacingGuild", "First Navigator and true founder", "The Guild built on her transformation", SpoilerTier.ExpandedUniverse),
            new("char_RaquellaBertoAnirul", "org_BeneGesserit", "Founder and first Reverend Mother", "The Sisterhood she founded", SpoilerTier.ExpandedUniverse),
            new("char_GilbertusAlbans", "char_Erasmus", "Human ward raised by the robot", "Robot mentor he called father", SpoilerTier.ExpandedUniverse),
            new("char_GilbertusAlbans", "disc_Mentat", "First of the Mentats", "The discipline he pioneered", SpoilerTier.ExpandedUniverse),
            new("char_DominicVernius", "char_RhomburVernius", "Father", "Son and heir in exile", SpoilerTier.ExpandedUniverse),
            new("char_DukePaulusAtreides", "char_DukeLetoAtreides", "Father", "Son thrust early into rule", SpoilerTier.ExpandedUniverse),
            new("char_HelenaAtreides", "char_DukeLetoAtreides", "Mother he exiled", "Son who uncovered her betrayal", SpoilerTier.ExpandedUniverse),
            new("char_DukePaulusAtreides", "char_HelenaAtreides", "Husband she let die", "Wife who knew of the plot", SpoilerTier.ExpandedUniverse),
            new("char_ShaddamIV", "char_ElroodIX", "Son who hastened his end", "Father and predecessor", SpoilerTier.ExpandedUniverse),
            new("char_HasimirFenring", "char_ElroodIX", "Poisoned him with chaumurky", "The Emperor he helped remove", SpoilerTier.ExpandedUniverse),

            // ---- The Arrakis smugglers ----
            new("char_EsmarTuek", "char_StabanTuek", "Father", "Son who took over the trade"),
            new("char_StabanTuek", "char_GurneyHalleck", "Smuggler chief who took him in", "Raider who worked out of his camps"),

            // ---- Across the categories ----
            new("org_BeneGesserit", "char_PaulAtreides", "The order that bred him into being", "Kwisatz Haderach ahead of schedule"),
            new("org_Fremen", "char_PaulAtreides", "The people who made him Muad'Dib", "Their Lisan al-Gaib"),
            new("house_Atreides", "house_Harkonnen", "Blood enemies across generations", "Blood enemies across generations"),
            new("char_PaulAtreides", "bio_MuadDibMouse", "Took its name as his own", "Namesake he chose"),
            new("char_LietKynes", "loc_Arrakis", "Planetologist who dreamed it green", "The world he served"),
            new("bio_ShaiHulud", "bio_Melange", "Maker of the spice", "The spice of its making"),
            new("bio_Sandtrout", "bio_ShaiHulud", "Larval form", "Adult form"),
        };

        /// <summary>
        /// Registers every labeled relationship. Call once, after all seeders. In debug builds
        /// an id that matches nothing registered throws, so a typo fails loudly in development
        /// instead of silently dropping a label in production.
        /// </summary>
        public static void Apply(EntityRegistry registry)
        {
#if DEBUG
            foreach (var rel in Relationships)
            {
                if (registry.GetEntity(rel.FromId) is null)
                {
                    throw new InvalidOperationException(
                        $"RelationshipMap references unknown entity id '{rel.FromId}'. Fix the id or remove the entry.");
                }
                if (registry.GetEntity(rel.ToId) is null)
                {
                    throw new InvalidOperationException(
                        $"RelationshipMap references unknown entity id '{rel.ToId}'. Fix the id or remove the entry.");
                }
            }
#endif
            registry.RegisterRelationships(Relationships);
        }
    }
}
