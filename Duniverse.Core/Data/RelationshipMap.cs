using System;
using System.Collections.Generic;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Data
{
    /// <summary>
    /// The one place connections get their meaning. RelatedEntityIds says two entries touch, this
    /// says how: mother and son, slayer and slain. A pair no seeder linked becomes a real
    /// connection here, so I can add canon links in one file.
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

            // ---- Arrakis: every thread into the desert ----
            // The most linked record in the archive. I put the world first in each pair, so the
            // second phrase is the one its own page prints.
            new("loc_Arrakis", "org_Fremen", "The desert that made them what they are", "The desert people who hold its interior"),
            new("loc_Arrakis", "house_Atreides", "The fief that was a baited trap", "Ruled it for a matter of weeks"),
            new("loc_Arrakis", "house_Harkonnen", "The fief they bled for eighty years", "Eighty years of quota and cruelty"),
            new("loc_Arrakis", "char_PaulAtreides", "The desert that made him Muad'Dib", "Took it, then the Imperium that wanted it"),
            new("loc_Arrakis", "bio_ShaiHulud", "The one world where they still live", "Makers of its desert and its spice"),
            new("loc_Arrakis", "bio_Melange", "Its only source in the universe", "The one substance that makes it priceless"),
            new("loc_Arrakis", "bio_Sandtrout", "The desert they keep dry", "The reason its water stays locked away"),
            new("loc_Arrakis", "bio_Sandplankton", "The sand that feeds them", "Where its melange cycle begins"),
            new("loc_Arrakis", "bio_MuadDibMouse", "The desert it lives on without drinking", "A small survivor the sietches learned from"),
            new("loc_Arrakis", "bio_DesertHawk", "The deep desert it circles", "Circles the far reaches where something has died"),
            new("loc_Arrakis", "art_Stillsuit", "The world that made it necessary", "Holds a body's moisture against its heat"),
            new("loc_Arrakis", "art_Crysknife", "The world whose worms supply the tooth", "Its sacred blade, cut from a worm's tooth"),
            new("loc_Arrakis", "art_Thumper", "The sand it is driven into", "Calls its worms up out of the deep"),
            new("loc_Arrakis", "art_ResearchJournal", "The world it maps and means to change", "The blueprint for turning it green"),
            new("loc_Arrakis", "disc_FremenDesertSurvival", "The desert this craft answers", "What the deep demands of anyone crossing it"),
            new("loc_Arrakis", "disc_SpiceMining", "The only sand worth working", "The industry that justifies holding it"),
            new("loc_Arrakis", "char_PardotKynes", "The world he came to study and stayed to change", "Sold its Fremen the dream of open water"),
            new("loc_Arrakis", "char_EsmarTuek", "The world he built his trade on", "Built the Tuek trade out of its harvest"),
            new("loc_Arrakis", "char_StabanTuek", "The desert his crews work", "Kept a trade running past the Imperial count"),
            new("loc_Arrakis", "house_Tuek", "The world their trade runs on", "Smugglers who never declared what they lifted"),
            new("loc_Arrakis", "org_CHOAM", "The single world its fortunes rest on", "The combine that banks everything it yields"),
            new("loc_Arrakis", "loc_Arrakeen", "The world it governs", "Its seat of government"),
            new("loc_Arrakis", "loc_SietchTabr", "The desert that hides it", "One of the largest sietches cut into its rock"),
            new("loc_Arrakis", "vehicle_Ornithopter", "The desert it crosses on flapping wings", "How anyone crosses it at speed"),
            new("loc_Arrakis", "vehicle_SpiceHarvester", "The sand it strips", "Tears the melange straight out of its dunes"),
            new("loc_Arrakis", "vehicle_SpiceCrawler", "The dunes it works", "The smaller rig that works beside the giants"),
            new("loc_Arrakis", "vehicle_Carryall", "The desert it lifts machines out of", "Plucks harvesters off it ahead of a worm"),
            new("loc_Arrakis", "vehicle_Lighter", "The world whose spice it ferries to orbit", "Carries the harvest up to waiting heighliners"),
            new("loc_Arrakis", "vehicle_ImperialBarge", "The world it carried Shaddam down to", "Brought the Emperor down onto its sand"),
            new("loc_Arrakis", "loc_Onn", "The world it was raised on", "The festival city of its God Emperor", SpoilerTier.GodEmperorOfDune),
            new("loc_Arrakis", "org_MuseumFremen", "The desert they no longer read", "Its Fremen, kept as performance", SpoilerTier.GodEmperorOfDune),
            new("loc_Arrakis", "loc_Rakis", "The same world, under its older name", "What it becomes long after Muad'Dib", SpoilerTier.HereticsOfDune),

            // ---- The Bene Gesserit: what the Sisterhood touches ----
            new("org_BeneGesserit", "loc_WallachIX", "The order whose school sits here", "Their Mother School, deliberately remote"),
            new("org_BeneGesserit", "disc_BeneGesseritTraining", "The order that teaches it", "The conditioning drilled into every acolyte"),
            new("org_BeneGesserit", "char_LadyJessica", "The order she disobeyed over one child", "Sister who broke the breeding order for a son"),
            new("org_BeneGesserit", "char_GaiusHelenMohiam", "The order she speaks for at court", "Their Reverend Mother inside the Imperial court"),
            new("org_BeneGesserit", "theo_OtherMemoryPhilosophy", "The order that drills it into every acolyte", "The words said aloud when fear arrives"),
            new("org_BeneGesserit", "theo_MahdiProphecy", "The order that planted it centuries early", "A legend they seeded on Arrakis for later use"),
            new("org_BeneGesserit", "art_GomJabbar", "The order that decides who is human with it", "The needle they hold at a candidate's neck"),
            new("org_BeneGesserit", "art_PainBox", "The order that administers it", "What they make a candidate put a hand into"),
            new("org_BeneGesserit", "art_WaterOfLife", "The order whose Reverend Mothers convert it", "The poison a sister must change inside her"),
            new("org_BeneGesserit", "disc_WeirdingWay", "The order that perfected it", "The fighting art they keep to themselves"),
            new("org_BeneGesserit", "disc_KwisatzHaderachProcess", "The order running it", "The breeding program they ran for ninety generations"),
            new("org_BeneGesserit", "char_HasimirFenring", "The order that almost finished with him", "A Kwisatz Haderach they nearly made"),
            new("org_BeneGesserit", "char_MargotFenring", "The order she serves inside the court", "Their sister placed beside Count Fenring"),
            new("org_BeneGesserit", "house_Fenring", "The order that placed Lady Margot here", "A minor House they kept a hand inside"),
            new("org_BeneGesserit", "event_ButlerianJihad", "The order that rose in its aftermath", "The war that cleared the way for their kind of mind"),
            new("org_BeneGesserit", "event_KwisatzHaderachBirth", "The order whose scheme it completes", "The payoff, and out of their control"),
            new("org_BeneGesserit", "bio_Melange", "The order that turns it inward", "The spice their sight and their agony both run on"),
            new("org_BeneGesserit", "event_MessiahConspiracy", "The order that sat in on it", "A plot they joined against their own creation", SpoilerTier.DuneMessiah),
            new("org_BeneGesserit", "char_Taraza", "The order she led as Mother Superior", "Mother Superior when the Honored Matre war opened", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "char_DarwiOdrade", "The order she rose to lead", "Took the seat after Taraza and finished it", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "char_Murbella", "The order she crossed into", "Honored Matre who crossed over and stayed", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "char_MilesTeg", "The order that called him back", "Their Bashar, recalled out of retirement", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "org_HonoredMatres", "The order they broke from and now hunt", "The lost daughters who came back to conquer", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "loc_Chapterhouse", "The order that hid its seat here", "The world they kept in reserve", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "disc_HonoredMatreImprinting", "The order it was turned against", "A binding they will not use and cannot answer", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "char_Sheeana", "The order that took her in", "The child the worms obeyed, taken in", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "char_Schwangyu", "The order she served against its own plan", "The proctor who wanted the ghola dead", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "loc_Gammu", "The order that made it a training world", "Their keep and archive on old Giedi Prime", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "vehicle_NoShip", "The order that came to depend on one", "A hull that hides from prescient sight", SpoilerTier.HereticsOfDune),
            new("org_BeneGesserit", "char_NormaCenva", "The order that followed the Rossak sorceresses", "Of Rossak, whose sorceresses came before them", SpoilerTier.ExpandedUniverse),
            new("org_BeneGesserit", "event_ReverendMotherBreakthrough", "The order that begins with it", "The night the first of them survived the poison", SpoilerTier.ExpandedUniverse),

            // ---- House Atreides: the House and its holdings ----
            new("house_Atreides", "loc_Caladan", "The House that held it for twenty-six generations", "Their home for twenty-six generations"),
            new("house_Atreides", "char_DukeLetoAtreides", "The House he led", "The Duke who took it to Arrakis"),
            new("house_Atreides", "char_PaulAtreides", "The House he was born to", "The heir who outgrew the House entirely"),
            new("house_Atreides", "char_LadyJessica", "The House she served as bound concubine", "Bound to the House without a wedding"),
            new("house_Atreides", "art_SignetRing", "The House whose Duke wears it", "The ring that proves which man is Duke"),
            new("house_Atreides", "art_Lasgun", "One of many Houses that fielded it", "In their arsenal, and in everyone else's"),
            new("house_Atreides", "art_ShieldGenerator", "The House whose swordsmen trained around it", "What their troops learned to fight inside"),
            new("house_Atreides", "art_Distrans", "The House that used it on Arrakis", "A trick their agents used in the desert"),
            new("house_Atreides", "art_CoffinShield", "The House whose funerary goods it guarded", "Guarded what they carried of their dead"),
            new("house_Atreides", "loc_Arrakeen", "The House that took its residency", "The residency they barely had time to occupy"),
            new("house_Atreides", "org_Landsraad", "One of the Great Houses in its council", "The council where they held a seat"),
            new("house_Atreides", "org_SwordmastersOfGinaz", "The House that sent Duncan Idaho to train", "Where Duncan learned the blade"),
            new("house_Atreides", "vehicle_Ornithopter", "The House whose Duke flew his own", "What Leto flew to see a harvest for himself"),
            new("house_Atreides", "event_FallOfHouseAtreides", "The House it destroyed", "The night the House came apart"),
            new("house_Atreides", "event_ThroneDuel", "The House whose heir won it", "The knife fight that ended the feud"),
            new("house_Atreides", "bio_PundiRice", "The House whose world grows it", "The grain of their home lowlands"),
            new("house_Atreides", "event_AliaRegency", "The House it governed for", "A regency held in the family name", SpoilerTier.ChildrenOfDune),
            new("house_Atreides", "event_GoldenPathBegins", "The House it changed forever", "The moment the line stopped being human", SpoilerTier.ChildrenOfDune),
            new("house_Atreides", "char_DukePaulusAtreides", "The House he ruled before Leto", "The Duke before Leto, killed by a bull", SpoilerTier.ExpandedUniverse),
            new("house_Atreides", "event_DeathOfDukePaulus", "The House it left to a young Duke", "The bullring death that put Leto in charge early", SpoilerTier.ExpandedUniverse),
            new("house_Atreides", "char_HelenaAtreides", "The House she married into and betrayed", "The Lady exiled for her husband's death", SpoilerTier.ExpandedUniverse),
            new("house_Atreides", "house_Wayku", "The House whose dead they guarded", "Keepers of their crypts on Caladan", SpoilerTier.ExpandedUniverse),

            // ---- The Fremen: the desert people and their world ----
            new("org_Fremen", "loc_SietchTabr", "The people who dug it", "Stilgar's sietch, and one of their greatest"),
            new("org_Fremen", "char_Stilgar", "The people he leads", "The Naib who spoke for them longest"),
            new("org_Fremen", "char_Chani", "The people she was born to", "Sayyadina and desert-born fighter"),
            new("org_Fremen", "char_LietKynes", "The people he led in secret", "Their planetologist, and secretly their leader"),
            new("org_Fremen", "char_PardotKynes", "The people who took his dream on", "The offworlder who gave them the dream"),
            new("org_Fremen", "theo_ZensunniWanderers", "The people who kept it", "The faith they carried across the migrations"),
            new("org_Fremen", "theo_CultOfShaiHulud", "The people who hold it", "Their worm-worship, older than any offworld faith"),
            new("org_Fremen", "theo_MahdiProphecy", "The people it was planted among", "The legend waiting in them for Paul to fill"),
            new("org_Fremen", "art_Crysknife", "The people who cut it from a worm", "The blade every one of them carries"),
            new("org_Fremen", "art_Stillsuit", "The people who perfected it", "What they put on before anything else"),
            new("org_Fremen", "art_Thumper", "The people who use it to ride", "How they call a worm when they need one"),
            new("org_Fremen", "art_WaterOfLife", "The people whose Sayyadina change it", "The poison at the center of their rite"),
            new("org_Fremen", "disc_WeirdingWay", "The people Jessica taught it to", "The fighting they learned from Jessica"),
            new("org_Fremen", "disc_FremenDesertSurvival", "The people who wrote its rules", "Everything their children learn first"),
            new("org_Fremen", "vehicle_SpiceHarvester", "The desert people who raid them", "Offworld machines they raid and leave to the worms"),
            new("org_Fremen", "event_BattleOfArrakeen", "The people who won it", "Their legions taking the city"),
            new("org_Fremen", "bio_ShaiHulud", "The people who ride them", "Their god, their transport, their proof"),
            new("org_Fremen", "bio_MuadDibMouse", "The people who named Paul for it", "The creature they read as a lesson"),
            new("org_Fremen", "event_MuadDibJihad", "The people who carried it", "The war fought in their name across the stars", SpoilerTier.DuneMessiah),
            new("org_Fremen", "char_Javid", "The people he came from and sold", "A Naib of theirs who served Corrino instead", SpoilerTier.ChildrenOfDune),
            new("org_Fremen", "org_MuseumFremen", "The people they only imitate", "What is left of them under Leto II", SpoilerTier.GodEmperorOfDune),

            // ---- House Harkonnen: the House and its instruments ----
            new("house_Harkonnen", "loc_GiediPrime", "The House that made it a factory", "Their homeworld, worked to soot"),
            new("house_Harkonnen", "char_BaronHarkonnen", "The House he ran", "The Baron who ran it at its worst"),
            new("house_Harkonnen", "char_FeydRautha", "The House he was to inherit", "The nephew groomed to inherit it"),
            new("house_Harkonnen", "char_GlossuRabban", "The House that spent him on Arrakis", "The nephew sent to be hated"),
            new("house_Harkonnen", "art_Lasgun", "Fielded it too, with fewer scruples", "Standard in their armories"),
            new("house_Harkonnen", "art_ShieldGenerator", "The House whose troops fought behind them", "What their soldiers hid behind"),
            new("house_Harkonnen", "art_HunterSeeker", "The House that sent one after Paul", "The drone they slipped into Paul's room"),
            new("house_Harkonnen", "org_Landsraad", "A Great House it could rarely restrain", "The council that held them to account, barely"),
            new("house_Harkonnen", "vehicle_Ornithopter", "The House whose patrols flew them over Arrakis", "How their patrols crossed the dunes"),
            new("house_Harkonnen", "vehicle_Frigate", "The House that landed with them", "How they moved legions to Arrakis"),
            new("house_Harkonnen", "vehicle_TroopCarrier", "The House that hid Sardaukar aboard them", "Carried the Sardaukar dressed in their colors"),
            new("house_Harkonnen", "event_FallOfHouseAtreides", "The House that sprang it", "The ambush they spent a fortune to spring"),
            new("house_Harkonnen", "event_BattleOfArrakeen", "The House that lost the planet there", "The day the desert took it all back"),
            new("house_Harkonnen", "event_ThroneDuel", "The House whose heir died in it", "Feyd's knife against Paul's, and the end of it"),
            new("house_Harkonnen", "loc_Gammu", "The House that ruined it first", "What Giedi Prime is called long after them", SpoilerTier.HereticsOfDune),
            new("house_Harkonnen", "char_AbulurdHarkonnen", "The House that discarded him", "The Baron's father, put aside as too soft", SpoilerTier.ExpandedUniverse),
            new("house_Harkonnen", "loc_Lankiveil", "The House whose origins sit here", "The cold world their name comes out of", SpoilerTier.ExpandedUniverse),
            new("house_Harkonnen", "char_DukePaulusAtreides", "The House behind his death", "Leto's father, removed on their orders", SpoilerTier.ExpandedUniverse),
            new("house_Harkonnen", "event_DeathOfDukePaulus", "The House that arranged it", "Their quiet work in an Atreides bullring", SpoilerTier.ExpandedUniverse),

            // ---- House Corrino: the throne and what holds it up ----
            new("house_Corrino", "loc_Kaitain", "The dynasty seated here", "Their capital, and their vanity"),
            new("house_Corrino", "loc_SalusaSecundus", "The dynasty that keeps it cruel", "The prison world that makes their soldiers"),
            new("house_Corrino", "char_ShaddamIV", "The dynasty he inherited", "The eighty-first of their line"),
            new("house_Corrino", "char_PrincessIrulan", "The dynasty she was born into", "The daughter married off to keep the name"),
            new("house_Corrino", "char_ElroodIX", "The dynasty he held before his son", "The Emperor before Shaddam"),
            new("house_Corrino", "org_Sardaukar", "The dynasty they serve", "The legions that keep them on the throne"),
            new("house_Corrino", "disc_SardaukarWarfare", "The dynasty it was built to serve", "The training that makes their terror troops"),
            new("house_Corrino", "art_GoldenLionThrone", "The dynasty that has sat it for ten thousand years", "The seat their whole claim rests on"),
            new("house_Corrino", "art_CoffinShield", "Used at Imperial funerals too", "What shielded their dead in transit"),
            new("house_Corrino", "house_Fenring", "The dynasty Count Fenring served", "The minor House that gave them their best knife"),
            new("house_Corrino", "org_CHOAM", "The dynasty holding the largest block of its shares", "The combine where their directorships sit"),
            new("house_Corrino", "org_Landsraad", "The dynasty its Houses exist to balance", "The council that checks them"),
            new("house_Corrino", "vehicle_Frigate", "The dynasty whose legions ride them", "What carries their soldiers between stars"),
            new("house_Corrino", "vehicle_ImperialBarge", "The dynasty it carries", "The Emperor's own landing craft"),
            new("house_Corrino", "vehicle_TroopCarrier", "The dynasty whose shock troops ride them", "Drops their Sardaukar onto a world"),
            new("house_Corrino", "event_FallOfHouseAtreides", "The dynasty that lent the Sardaukar", "Their legions in another House's colors"),
            new("house_Corrino", "event_BattleOfArrakeen", "The dynasty broken there", "The day ten thousand years ended"),
            new("house_Corrino", "art_StoneBurner", "The fallen dynasty it was used for", "Turned against Muad'Dib once the throne was lost", SpoilerTier.DuneMessiah),
            new("house_Corrino", "bio_LazaTiger", "The dynasty that had them trained", "Bred by their exiles to kill two children", SpoilerTier.ChildrenOfDune),

            // ---- The Butlerian Jihad: the war and what it left ----
            new("event_ButlerianJihad", "disc_Mentat", "The war that made them necessary", "The human answer to what it banned"),
            new("event_ButlerianJihad", "org_SpacingGuild", "The war that cleared the way for it", "Rose to move ships once machines could not"),
            new("event_ButlerianJihad", "theo_ButlerianDoctrine", "The war that wrote it", "The law it left behind"),
            new("event_ButlerianJihad", "theo_OrangeCatholicBible", "The war that scattered the faiths it gathers", "The scripture assembled after it"),
            new("event_ButlerianJihad", "event_GuildFounding", "The war that had to end first", "What became possible once it ended"),
            new("event_ButlerianJihad", "char_VorianAtreides", "The war he fought and outlived", "Its hero, and an Atreides forefather", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "char_SerenaButler", "The war her grief began", "The woman whose grief named it", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "char_Omnius", "The war fought to end it", "The intelligence it was raised against", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "char_Erasmus", "The war he provoked", "The robot whose cruelty set it off", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "char_XavierHarkonnen", "The war he fought before his name turned", "A hero of it, later written out", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "char_AgamemnonTitan", "The war that ended the Titans", "A cymek tyrant it swept away", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "org_LeagueOfNobles", "The war it was formed to fight", "The human coalition that fought it", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "org_SynchronizedWorlds", "The war that broke them", "The machine empire it brought down", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "char_GilbertusAlbans", "The war whose ban shaped his work", "Trained the first minds to replace the machines", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "org_MentatSchool", "The war that created the need", "The institution built on its prohibition", SpoilerTier.ExpandedUniverse),
            new("event_ButlerianJihad", "vehicle_CymekWalker", "The war that hunted them down", "The bodies its enemies wore", SpoilerTier.ExpandedUniverse),

            // ---- The Spacing Guild: the monopoly and its machinery ----
            new("org_SpacingGuild", "disc_GuildNavigation", "The monopoly it belongs to", "The art only their Navigators hold"),
            new("org_SpacingGuild", "vehicle_Heighliner", "The monopoly that owns them", "The ships they alone fold"),
            new("org_SpacingGuild", "bio_Melange", "The monopoly built on needing it", "What a Navigator can neither live nor steer without"),
            new("org_SpacingGuild", "loc_Ix", "The monopoly that buys everything it makes", "The world that builds their hulls"),
            new("org_SpacingGuild", "vehicle_Lighter", "The monopoly whose ships it serves", "How cargo leaves their holds for a surface"),
            new("org_SpacingGuild", "event_GuildFounding", "The monopoly it created", "The day they became unavoidable"),
            new("org_SpacingGuild", "char_Edric", "The monopoly he steered for", "Their Steersman in the plot against Paul", SpoilerTier.DuneMessiah),
            new("org_SpacingGuild", "event_MessiahConspiracy", "The monopoly that hid it from prescience", "A plot they joined against the Emperor", SpoilerTier.DuneMessiah),
            new("org_SpacingGuild", "event_TheScattering", "The monopoly it left behind", "Humanity leaving faster than they could carry it", SpoilerTier.GodEmperorOfDune),
            new("org_SpacingGuild", "vehicle_NoShip", "The monopoly it makes obsolete", "A hull even their sight cannot follow", SpoilerTier.HereticsOfDune),
            new("org_SpacingGuild", "char_JosefVenport", "The monopoly his company became", "Built the shipping empire they grew from", SpoilerTier.ExpandedUniverse),

            // ---- The Sardaukar, the Landsraad, CHOAM and the throne ----
            new("org_Sardaukar", "loc_SalusaSecundus", "The legions its cruelty produces", "The prison world they are bred out of"),
            new("org_Sardaukar", "disc_SardaukarWarfare", "The legions it turns out", "The brutal course every one of them survives"),
            new("org_Sardaukar", "vehicle_TroopCarrier", "The legions it carries down", "What drops them onto a world"),
            new("org_Sardaukar", "vehicle_Frigate", "The legions it moves", "How they cross between worlds"),
            new("org_Sardaukar", "char_Tyekanik", "The legions he commanded", "Their Bashar, loyal past the fall", SpoilerTier.ChildrenOfDune),
            new("org_Landsraad", "org_CHOAM", "The council whose Houses hold its shares", "The combine whose shares give its Houses their teeth"),
            new("org_CHOAM", "bio_Melange", "The combine that sets its price", "The single commodity that moves its markets"),
            new("org_CHOAM", "char_JosefVenport", "The combine that came out of his trade", "Built the trading empire it grew out of", SpoilerTier.ExpandedUniverse),
            new("art_GoldenLionThrone", "loc_Kaitain", "The seat of empire kept here", "The capital that houses it"),
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
