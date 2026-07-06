using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class HistoricalEventSeeder
    {
        public static List<HistoricalEvent> GetHistoricalEvents()
        {
            return new List<HistoricalEvent>
            {
                new HistoricalEvent
                {
                    Id = "event_ButlerianJihad",
                    Name = "The Butlerian Jihad",
                    ShortDescription = "The generations-long crusade that destroyed all thinking machines.",
                    DetailedHistory = "A galaxy-spanning revolt against computers and robots that had come to dominate humanity, the Butlerian Jihad ended with the total prohibition of thinking machines, giving rise to Mentats, Guild Navigators, and the Bene Gesserit as human replacements for computation and prescience.",
                    ImagePath = "images/events/butlerian_jihad.jpg",
                    RelatedEntityIds = new List<string> { "disc_Mentat", "org_SpacingGuild", "org_BeneGesserit", "theo_ButlerianDoctrine", "char_VorianAtreides", "char_SerenaButler", "char_Omnius", "char_Erasmus", "char_XavierHarkonnen", "char_AgamemnonTitan", "org_LeagueOfNobles", "org_SynchronizedWorlds" },
                    Timeframe = "Roughly 10,000 years before the birth of Paul Atreides",
                    SortOrder = 10,
                    LastingImpact = "Permanent ban on thinking machines; rise of Mentats, Guild Navigators, and the Bene Gesserit"
                },
                new HistoricalEvent
                {
                    Id = "event_KwisatzHaderachBirth",
                    Name = "Birth of the Kwisatz Haderach",
                    ShortDescription = "The birth of Paul Atreides, culmination of the Bene Gesserit's millennia-long breeding program.",
                    DetailedHistory = "Lady Jessica's decision to bear a son instead of the daughter ordered by the Bene Gesserit brought the Sisterhood's breeding program to fruition one generation early, in the person of Paul Atreides - a variable the Sisterhood had not planned to control.",
                    ImagePath = "images/events/kwisatz_haderach_birth.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_LadyJessica", "char_PaulAtreides", "disc_KwisatzHaderachProcess" },
                    Timeframe = "Approximately 15 years before the fall of House Atreides",
                    SortOrder = 60,
                    LastingImpact = "Produced a male capable of prescience and access to both male and female ancestral memory, disrupting Bene Gesserit control"
                },
                new HistoricalEvent
                {
                    Id = "event_FallOfHouseAtreides",
                    Name = "The Fall of House Atreides",
                    ShortDescription = "The Harkonnen-Sardaukar surprise attack that destroyed Duke Leto's rule on Arrakis.",
                    DetailedHistory = "Betrayed from within by Dr. Yueh, House Atreides was overwhelmed by a joint Harkonnen-Sardaukar assault shortly after taking possession of Arrakis, killing Duke Leto and forcing Paul and Jessica into the deep desert.",
                    ImagePath = "images/events/fall_of_atreides.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen", "house_Corrino", "char_WellingtonYueh" },
                    Timeframe = "Year of the Atreides' arrival on Arrakis",
                    SortOrder = 70,
                    LastingImpact = "Ended House Atreides' open rule of Arrakis and drove Paul into the Fremen, setting his rise into motion"
                },
                new HistoricalEvent
                {
                    Id = "event_BattleOfArrakeen",
                    Name = "The Battle of Arrakeen",
                    ShortDescription = "Paul Atreides' Fremen forces retake Arrakeen and topple the Emperor's forces.",
                    DetailedHistory = "Combining sandworm-mounted Fremen legions with a well-timed atomic breach of the Shield Wall, Paul's forces crushed the combined Harkonnen and Sardaukar garrison, forcing Shaddam IV's personal surrender.",
                    ImagePath = "images/events/battle_of_arrakeen.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "house_Corrino", "house_Harkonnen", "char_PaulAtreides" },
                    Timeframe = "Culmination of Paul's desert campaign",
                    SortOrder = 80,
                    LastingImpact = "Overthrew Shaddam IV, installed Paul Atreides as Emperor, and began the Jihad of Muad'Dib"
                },
                new HistoricalEvent
                {
                    Id = "event_ThroneDuel",
                    Name = "Duel for the Throne",
                    ShortDescription = "Paul Atreides' formal knife duel against Feyd-Rautha Harkonnen.",
                    DetailedHistory = "To settle rival claims and cement his legitimacy before the Great Houses, Paul fought Feyd-Rautha in ritual combat, killing him and finalizing his claim to the Golden Lion Throne.",
                    ImagePath = "images/events/throne_duel.jpg",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_FeydRautha", "house_Harkonnen", "house_Atreides" },
                    Timeframe = "Immediately following the Battle of Arrakeen",
                    SortOrder = 90,
                    LastingImpact = "Ended the Harkonnen line of succession and secured Paul's ascension to Emperor"
                },
                new HistoricalEvent
                {
                    Id = "event_MuadDibJihad",
                    Name = "The Jihad of Muad'Dib",
                    ShortDescription = "The galaxy-spanning holy war waged in Paul Atreides' name.",
                    DetailedHistory = "Following his ascension, Fremen legions carried Paul's religion and rule across the Imperium by force, a jihad that, despite his attempts to control it, claimed billions of lives and reshaped the political and religious landscape of known space.",
                    ImagePath = "images/events/muaddib_jihad.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "theo_ChurchOfMuadDib", "char_PaulAtreides" },
                    Timeframe = "The first decade of Paul Atreides' reign",
                    SortOrder = 100,
                    LastingImpact = "Spread the Church of Muad'Dib across the Imperium at immense human cost; cemented Fremen military dominance"
                },
                new HistoricalEvent
                {
                    Id = "event_MessiahConspiracy",
                    Name = "The Conspiracy Against Muad'Dib",
                    ShortDescription = "A coordinated Bene Gesserit, Guild, and Tleilaxu plot to unseat Emperor Paul Atreides.",
                    DetailedHistory = "Uniting Reverend Mother Mohiam, the Guild Steersman Edric, and the Tleilaxu Face Dancer Scytale, the conspirators used the ghola Hayt and a stolen Guild secret to strike at Paul's rule, ultimately costing him his eyesight and driving him into the desert.",
                    ImagePath = "images/events/messiah_conspiracy.jpg",
                    RelatedEntityIds = new List<string> { "char_GaiusHelenMohiam", "char_Edric", "char_Scytale", "char_DuncanIdaho", "org_BeneTleilax", "org_BeneGesserit", "org_SpacingGuild" },
                    Timeframe = "Roughly twelve years into Paul's reign",
                    SortOrder = 110,
                    LastingImpact = "Blinded Paul Atreides and precipitated his eventual disappearance into the desert, paving the way for Alia's regency"
                },
                new HistoricalEvent
                {
                    Id = "event_AliaRegency",
                    Name = "Alia's Regency",
                    ShortDescription = "Alia Atreides' rule as Regent, and her eventual possession by the Baron's ego-memory.",
                    DetailedHistory = "Ruling in place of her missing brother and later her young nephew and niece, Alia succumbed to Abomination - possession by the Baron Harkonnen's ancestral memory - destabilizing the Imperium until Leto II's rise.",
                    ImagePath = "images/events/alia_regency.jpg",
                    RelatedEntityIds = new List<string> { "char_AliaAtreides", "char_BaronHarkonnen", "char_LetoIIAtreides", "char_GhanimaAtreides", "house_Atreides" },
                    Timeframe = "The years following Paul Atreides' disappearance",
                    SortOrder = 120,
                    LastingImpact = "Exposed the danger of Abomination among pre-born Atreides children and set the stage for Leto II's transformation"
                },
                new HistoricalEvent
                {
                    Id = "event_GoldenPathBegins",
                    Name = "The Golden Path Begins",
                    ShortDescription = "Leto II's merger with sandtrout and his ascension as God Emperor.",
                    DetailedHistory = "Recognizing the fatal flaw in his father's prescient vision, young Leto II underwent an irreversible transformation, fusing his body with sandtrout skin to gain near-invulnerability and begin a 3,500-year reign in pursuit of the Golden Path.",
                    ImagePath = "images/events/golden_path_begins.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "bio_Sandtrout", "theo_GoldenPath", "house_Atreides" },
                    Timeframe = "Following Alia's regency",
                    SortOrder = 140,
                    LastingImpact = "Began the millennia-long reign of the God Emperor and the eventual Scattering of humanity"
                },
                new HistoricalEvent
                {
                    Id = "event_GuildFounding",
                    Name = "Founding of the Spacing Guild",
                    ShortDescription = "The establishment of the Guild's monopoly on interstellar travel through spice-enabled prescience.",
                    DetailedHistory = "Discovering that sufficient doses of melange granted limited prescience capable of safely navigating folded space, the earliest Guild Navigators established a monopoly on interstellar travel that would endure for millennia.",
                    ImagePath = "images/events/guild_founding.jpg",
                    RelatedEntityIds = new List<string> { "org_SpacingGuild", "bio_Melange", "event_ButlerianJihad" },
                    Timeframe = "In the aftermath of the Butlerian Jihad",
                    SortOrder = 30,
                    LastingImpact = "Created the Spacing Guild's enduring monopoly on space travel and cemented melange as the most valuable substance in the universe"
                },

                // ---- Children of Dune / God Emperor of Dune / Heretics & Chapterhouse ----
                new HistoricalEvent
                {
                    Id = "event_TigerAssassinationAttempt",
                    Name = "The Tiger Assassination Attempt",
                    ShortDescription = "An attempt on the lives of the Atreides twins using genetically bred Laza tigers.",
                    DetailedHistory = "Orchestrated by Wensicia Corrino and the traitor Javid, trained Laza tigers were set loose on young Leto II and Ghanima in a bid to end the Atreides line and clear the way for a Corrino restoration. The plot failed and exposed the conspiracy.",
                    ImagePath = "images/events/tiger_assassination.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_GhanimaAtreides", "bio_LazaTiger", "char_WensiciaCorrino", "char_Javid" },
                    Timeframe = "During the Atreides twins' childhood",
                    SortOrder = 130,
                    LastingImpact = "Exposed the Corrino restoration conspiracy and hardened Leto II's resolve toward the Golden Path"
                },
                new HistoricalEvent
                {
                    Id = "event_DeathOfTheGodEmperor",
                    Name = "Death of the God Emperor",
                    ShortDescription = "Leto II's death at the Hidden Ford, releasing the sandtrout and ending his 3,500-year reign.",
                    DetailedHistory = "Drawn into a confrontation orchestrated in part by Siona and a Duncan Idaho ghola, Leto II's worm-bound body was destroyed, scattering sandtrout back into the wild and beginning Arrakis's slow reversion into the desert world later known as Rakis.",
                    ImagePath = "images/events/death_of_god_emperor.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_SionaAtreides", "char_DuncanIdaho", "bio_Sandtrout", "loc_Rakis" },
                    Timeframe = "The end of the God Emperor's reign",
                    SortOrder = 150,
                    LastingImpact = "Ended the Golden Path's enforced peace, triggered the desert's return, and set the stage for the Scattering"
                },
                new HistoricalEvent
                {
                    Id = "event_TheScattering",
                    Name = "The Scattering",
                    ShortDescription = "Humanity's mass exodus beyond the reach of any single power following the God Emperor's death.",
                    DetailedHistory = "Freed from Leto II's rigid control, uncounted numbers of humans fled into unknown space, founding hidden civilizations beyond Imperial or Guild oversight - among them, eventually, the Honored Matres, whose return would upend the Old Imperium generations later.",
                    ImagePath = "images/events/the_scattering.jpg",
                    RelatedEntityIds = new List<string> { "event_DeathOfTheGodEmperor", "org_HonoredMatres", "org_SpacingGuild" },
                    Timeframe = "Following the death of the God Emperor",
                    SortOrder = 160,
                    LastingImpact = "Seeded the unknown civilizations - including the Honored Matres - that would return to threaten the Old Imperium"
                },
                new HistoricalEvent
                {
                    Id = "event_DestructionOfRakis",
                    Name = "Destruction of Rakis",
                    ShortDescription = "The Honored Matres' annihilation of the former Arrakis, ending its role as the source of spice.",
                    DetailedHistory = "In their war against the Bene Gesserit, the Honored Matres destroyed Rakis outright, wiping out its sandworms and its spice production and forcing the Sisterhood to gamble everything on transplanting the ecology to their hidden world of Chapterhouse.",
                    ImagePath = "images/events/destruction_of_rakis.jpg",
                    RelatedEntityIds = new List<string> { "loc_Rakis", "org_HonoredMatres", "loc_Chapterhouse", "char_Sheeana", "bio_ShaiHulud" },
                    Timeframe = "During the Bene Gesserit-Honored Matre war",
                    SortOrder = 170,
                    LastingImpact = "Ended Rakis as the source of melange and forced the transplantation of sandworms to Chapterhouse"
                },

                // ---- Prelude to Dune (House trilogy) ----
                new HistoricalEvent
                {
                    Id = "event_IxianCoup",
                    Name = "The Ixian Coup",
                    ShortDescription = "The Tleilaxu-backed overthrow of House Vernius's rule on Ix.",
                    DetailedHistory = "With covert Imperial approval, the Tleilaxu seized control of Ix, driving Earl Dominic Vernius into exile and scattering his family - his son Rhombur finding refuge with House Atreides while the technological heart of Ix fell under new, secretive management.",
                    ImagePath = "images/events/ixian_coup.jpg",
                    RelatedEntityIds = new List<string> { "house_Vernius", "loc_Ix", "char_DominicVernius", "char_RhomburVernius", "org_BeneTleilax" },
                    Timeframe = "Prior to the events of Dune",
                    SortOrder = 40,
                    LastingImpact = "Exiled House Vernius, placed Ix under Tleilaxu-linked control, and forged Rhombur's lifelong bond with House Atreides"
                },
                new HistoricalEvent
                {
                    Id = "event_DeathOfDukePaulus",
                    Name = "Death of Duke Paulus Atreides",
                    ShortDescription = "The bullring accident, secretly engineered by House Harkonnen, that killed Leto's father.",
                    DetailedHistory = "Duke Paulus Atreides was killed by a bull deliberately drugged and sabotaged at Harkonnen instigation, a quiet act of sabotage that placed young Leto in power years before his own fateful acceptance of the Arrakis fief.",
                    ImagePath = "images/events/death_of_duke_paulus.jpg",
                    RelatedEntityIds = new List<string> { "char_DukePaulusAtreides", "char_DukeLetoAtreides", "house_Harkonnen", "house_Atreides" },
                    Timeframe = "Years before Duke Leto's arrival on Arrakis",
                    SortOrder = 50,
                    LastingImpact = "Placed Leto Atreides in command of House Atreides and deepened the Atreides-Harkonnen blood feud"
                },
                new HistoricalEvent
                {
                    Id = "event_ReverendMotherBreakthrough",
                    Name = "The First Reverend Mother Transformation",
                    ShortDescription = "The crisis in which Raquella Berto-Anirul's proctors first achieved the Reverend Mother transformation.",
                    DetailedHistory = "Dying of a plague no medicine could cure, Raquella Berto-Anirul was given a last-resort poison distillation by her acolytes. Against all expectation, she transmuted it rather than died, becoming the first true Reverend Mother and giving the fledgling Bene Gesserit Sisterhood the defining ability upon which its entire order would be built.",
                    ImagePath = "images/events/reverend_mother_breakthrough.jpg",
                    RelatedEntityIds = new List<string> { "char_RaquellaBertoAnirul", "org_BeneGesserit", "art_WaterOfLife", "disc_BeneGesseritTraining" },
                    Timeframe = "In the founding decades of the Bene Gesserit, following the Butlerian Jihad",
                    SortOrder = 20,
                    LastingImpact = "Established the Reverend Mother transformation as the core rite of the Bene Gesserit Sisterhood"
                }
            };
        }
    }
}
