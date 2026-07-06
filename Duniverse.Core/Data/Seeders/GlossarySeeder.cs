using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    /// <summary>
    /// The Terminology of the Imperium: a field dictionary in the spirit of the appendix Frank
    /// Herbert bound into Dune. Entries are short on purpose. A term that deserves a full
    /// record has one in the archive proper, and SeeEntityId points the reader there.
    /// </summary>
    public static class GlossarySeeder
    {
        public static List<GlossaryTerm> GetTerms()
        {
            return new List<GlossaryTerm>
            {
                new() { Term = "Aba", Definition = "A loose robe worn by Fremen women, cut full and commonly black. It shields the wearer from sun and blowing sand." },
                new() { Term = "Abomination", Definition = "The Bene Gesserit name for a pre-born child, one wakened in the womb to the crowding memories of every ancestor. The Sisterhood dreads what may rise up out of that inner multitude and take the child for its own." },
                new() { Term = "Amtal Rule", Definition = "The common rule on primitive worlds for testing a thing to destruction. You learn what a person or tool is made of by finding the point where it breaks." },
                new() { Term = "Axlotl Tank", Definition = "The Tleilaxu vessel of flesh in which gholas grow from the cells of the dead. What an axlotl tank actually is remains one of the Bene Tleilax's most closely guarded secrets, and the truth is grimmer than the name.", Tier = SpoilerTier.HereticsOfDune, SeeEntityId = "disc_GholaCultivation" },
                new() { Term = "Baliset", Definition = "A nine-stringed instrument, descendant of the zithra, tuned to the Chusuk scale. The favored instrument of Imperial troubadours, Gurney Halleck among them.", SeeEntityId = "bio_ChusukWood" },
                new() { Term = "Bindu", Definition = "The human nervous system, in Bene Gesserit usage. Bindu suspension lets a trained body hang at the edge of death, spending almost nothing." },
                new() { Term = "Chaumas", Definition = "Poison placed in solid food, as distinct from poison given by other paths. The Imperium's long habit of assassination made the distinction worth a word." },
                new() { Term = "Chaumurky", Definition = "Poison given in a drink. Great Houses keep poison snoopers over their dining tables for exactly this reason." },
                new() { Term = "Cone of Silence", Definition = "A damping field that kills sound within a small radius. Conversations held inside one leave nothing for eavesdroppers or recording devices." },
                new() { Term = "Crysknife", Definition = "The sacred blade of the Fremen, ground from the tooth of a dead sandworm. A drawn crysknife must taste blood before it is sheathed.", SeeEntityId = "art_Crysknife" },
                new() { Term = "Deathstill", Definition = "The Fremen apparatus that reclaims water from the dead. On Arrakis a body's moisture belongs to the tribe; the flesh was only ever borrowing it." },
                new() { Term = "Dew Collectors", Definition = "Small planted devices that chill through the night and shed condensed moisture to the roots below. Fremen palmaries survived on them long before outsiders noticed the desert turning green at the edges." },
                new() { Term = "Distrans", Definition = "A device for imprinting a message on the nerve patterns of a bird or bat. The animal's own cry carries the hidden waveform to its destination.", SeeEntityId = "art_Distrans" },
                new() { Term = "Dune Tarot", Definition = "A card oracle that swept the Imperium during Muad'Dib's reign. Millions consulting the cards muddied the currents of prescience itself, and not by accident.", Tier = SpoilerTier.DuneMessiah },
                new() { Term = "Face Dancer", Definition = "A Tleilaxu servant bred to reshape face, body, and voice at will. A Face Dancer can replace a person so completely that friends and family suspect nothing.", Tier = SpoilerTier.DuneMessiah },
                new() { Term = "Faufreluches", Definition = "The rigid class system holding the Imperium in shape. Its creed: a place for every man, and every man in his place." },
                new() { Term = "Fedaykin", Definition = "The Fremen death commandos sworn to Muad'Dib. The name reaches back to men who pledged their lives to setting a wrong right.", SeeEntityId = "theo_FedaykinCreed" },
                new() { Term = "Filmbook", Definition = "A shigawire imprint used for training and record-keeping, played with a pulse-synchronized viewer. Most Imperial schooling arrives this way." },
                new() { Term = "Fremkit", Definition = "A Fremen survival pack: stilltent, paracompass, maker hooks, thumper, water rations, and the manual of the friendly desert. Everything a body needs to live where nothing should." },
                new() { Term = "Ghanima", Definition = "Something taken in battle or single combat. In common Fremen use, an object no longer employed for its original purpose; a trophy kept to remember." },
                new() { Term = "Ghola", Definition = "A being grown by the Bene Tleilax from the cells of the dead. The flesh returns perfectly. What returns with it, and what it remembers, is the question that haunts every ghola ever made.", Tier = SpoilerTier.DuneMessiah, SeeEntityId = "disc_GholaCultivation" },
                new() { Term = "Golden Path", Definition = "The single thread of survivable future that Leto II followed through millennia. Its price and its purpose take a full record to explain.", Tier = SpoilerTier.ChildrenOfDune, SeeEntityId = "theo_GoldenPath" },
                new() { Term = "Gom Jabbar", Definition = "The high-handed enemy: a needle tipped with meta-cyanide. The Bene Gesserit hold it at a candidate's neck during the test of human awareness.", SeeEntityId = "art_GomJabbar" },
                new() { Term = "Hajra", Definition = "A journey of seeking. Fremen speech is thick with the vocabulary of pilgrimage; this word covers the search itself." },
                new() { Term = "Holtzman Effect", Definition = "The phenomenon underneath half the Imperium's machinery. It suspends shields around fighting men, lifts glowglobes and suspensor chairs, and folds space beneath the Guild's Heighliners.", SeeEntityId = "art_ShieldGenerator" },
                new() { Term = "Ichwan Bedwine", Definition = "The brotherhood binding all Fremen on Arrakis. Tribe may quarrel with tribe; against the outsider, the desert speaks with one voice." },
                new() { Term = "Kanly", Definition = "Formal vendetta between Great Houses, conducted under the strictest rules of the Great Convention. The forms keep bystanders out of the blood. The blood still flows." },
                new() { Term = "Karama", Definition = "A miracle. An action begun by the spirit world, in Fremen belief, and owed respect wherever it appears." },
                new() { Term = "Kindjal", Definition = "A double-edged short blade with a slight curve, worn at the belt of aristocrats and soldiers alike. In shield fighting the slow kindjal thrust kills where a fast one bounces." },
                new() { Term = "Kull Wahad", Definition = "An exclamation of profound awe. Literal renderings miss it; the sense is closer to being stirred past speech." },
                new() { Term = "Kwisatz Haderach", Definition = "The Shortening of the Way: the Bene Gesserit name for the male who could look where the Sisterhood cannot, into both lines of ancestral memory at once. Ninety generations of breeding chased him.", SeeEntityId = "disc_KwisatzHaderachProcess" },
                new() { Term = "Lisan al-Gaib", Definition = "The Voice from the Outer World. In Fremen messianic legend, an off-world prophet who will lead them to paradise. The legend did not grow wild; it was planted.", SeeEntityId = "theo_MahdiProphecy" },
                new() { Term = "Literjon", Definition = "A one-liter container for carrying water on Arrakis, built of high-density plastic with a positive seal. On most worlds a jug. On Arrakis, a treasury." },
                new() { Term = "Mahdi", Definition = "The One Who Will Lead Us to Paradise, in the Fremen messianic tradition. The crowds of Arrakeen shouted it at Paul Atreides before he ever claimed it." },
                new() { Term = "Maker Hooks", Definition = "The hooked gaffs a sandrider drives into a worm's ring segments to mount and steer it. An open segment cannot submerge, so the worm runs on and the rider rules it." },
                new() { Term = "Maula Pistol", Definition = "A spring-loaded gun throwing poisoned darts, effective to about forty meters. A quiet weapon for quiet work." },
                new() { Term = "Mentat", Definition = "A human trained to the ordered logic once surrendered to machines. Great Houses prize their Mentats above treasure.", SeeEntityId = "disc_Mentat" },
                new() { Term = "Missionaria Protectiva", Definition = "The Bene Gesserit arm that seeds frontier worlds with engineered prophecy and superstition. Generations later, a sister in danger finds the legends waiting, shaped to protect her. On Arrakis, the planted story was the Lisan al-Gaib.", SeeEntityId = "org_BeneGesserit" },
                new() { Term = "Muad'Dib", Definition = "The kangaroo mouse of Arrakis, admired by the Fremen for making its own water and hiding from the sun. The name Paul Atreides chose, and the name the universe learned.", SeeEntityId = "bio_MuadDibMouse" },
                new() { Term = "Naib", Definition = "A sietch leader, sworn never to be taken alive. Stilgar of Sietch Tabr held the title when the Atreides came to the desert." },
                new() { Term = "No-ship", Definition = "A vessel wrapped in a field that hides it from instruments and from prescient sight alike. Against enemies who see the future, invisibility of this order changes everything.", Tier = SpoilerTier.HereticsOfDune, SeeEntityId = "vehicle_NoShip" },
                new() { Term = "Panoplia Propheticus", Definition = "The Missionaria Protectiva's full arsenal of infectious superstition. A catalog of legends, omens, and ritual phrases ready for planting wherever the Sisterhood may one day need them." },
                new() { Term = "Poison Snooper", Definition = "A field-scanner tuned to detect poisonous substances, hung over the tables of anyone rich enough to be worth killing." },
                new() { Term = "Prana-bindu", Definition = "The Bene Gesserit discipline of nerve and muscle brought under full conscious command. A trained sister can bend her body around a blade or still it to a corpse's calm." },
                new() { Term = "Pre-born", Definition = "One wakened to full ancestral memory before birth, as Alia Atreides was. The gift arrives without defenses, and the Sisterhood has an ugly word for what it fears follows." },
                new() { Term = "Qanat", Definition = "An open canal carrying irrigation water across the desert under controlled conditions. On Arrakis, open water is a proclamation." },
                new() { Term = "Razzia", Definition = "A semipiratical raid, struck fast and gone before an answer forms. The style of warfare the deep desert teaches." },
                new() { Term = "Sayyadina", Definition = "A priestess of the Fremen religious hierarchy, keeper of rites and of the tribe's memory. The rank stands one step below Reverend Mother." },
                new() { Term = "Semuta", Definition = "A narcotic drawn from the burned residue of elacca wood, taken with the atonal music that unlocks its trance. Expensive, addictive, and fashionable in the wrong houses.", SeeEntityId = "bio_ElaccaWood" },
                new() { Term = "Shield Wall", Definition = "The mountain rampart shielding the northern settlements of Arrakis from the full force of coriolis storms and from the worms. Paul Atreides opened it with atomics, and the Imperium followed him through the gap." },
                new() { Term = "Shigawire", Definition = "A metallic filament grown as a vine on Salusa Secundus and III Delta Kaising. Its tensile strength and fineness suit it to recording media and to garrotes." },
                new() { Term = "Sietch", Definition = "A Fremen cave community. The old tongue renders it as the place of assembly in time of danger. Generations of danger made the assembly permanent." },
                new() { Term = "Solari", Definition = "The official currency of the Imperium, its value fixed by quiet agreement among the throne, the Guild, and the Landsraad." },
                new() { Term = "Stilltent", Definition = "A sealed micro-shelter that condenses the breath of those sleeping inside back into drinkable water. Desert nights on Arrakis are spent in one or not survived." },
                new() { Term = "Suspensor", Definition = "A Holtzman-field device that cancels a measure of gravity. It floats glowglobes, lightens cargo, and carried the Baron Harkonnen's bulk for years." },
                new() { Term = "Tau", Definition = "The felt oneness of a sietch community, sharpened by the spice diet and sealed in the tau orgy's shared awareness. An outsider can watch it and still never touch it." },
                new() { Term = "Truthsayer", Definition = "A Reverend Mother trained to read the involuntary signatures of a lie. Emperors keep one beside the throne and dread her holidays." },
                new() { Term = "Usul", Definition = "Fremen: the strength at the base of the pillar. Paul's private sietch name, given by Stilgar's troop, kept among those who knew him first." },
                new() { Term = "Water Burden", Definition = "The Fremen reckoning of mortal obligation. Save a life in the desert and that life owes you its water; the debt weighs more than any oath." },
                new() { Term = "Water Counters", Definition = "Metal rings of graded sizes, each standing for a measure of water held in tribal stores. Among Fremen they pass as currency, dowry, and debt." },
                new() { Term = "Weirding Way", Definition = "The Fremen name for the Bene Gesserit combat method Jessica and Paul taught the tribes. Speed at the edge of sight, delivered by nerve and muscle control.", SeeEntityId = "disc_WeirdingWay" },
                new() { Term = "Windtrap", Definition = "A device set to catch the wind and chill it past its dewpoint, harvesting water from thin desert air. The quiet engine of every Fremen settlement." },

                // ---- Expanded Universe terms ----
                new() { Term = "Cymek", Definition = "A human brain carried in an armored machine body, from the age of the thinking machines. The Titans wore these shells for a thousand years and called it improvement.", Tier = SpoilerTier.ExpandedUniverse, SeeEntityId = "vehicle_CymekWalker" },
                new() { Term = "Evermind", Definition = "The distributed machine intelligence Omnius, one mind copied across every Synchronized World. Humanity's war against it consumed three generations.", Tier = SpoilerTier.ExpandedUniverse, SeeEntityId = "char_Omnius" },
                new() { Term = "Titans", Definition = "The twenty human tyrants who conquered the old empire and traded their bodies for cymek immortality. Their machine servants later did to them what they had done to everyone else.", Tier = SpoilerTier.ExpandedUniverse, SeeEntityId = "char_AgamemnonTitan" },
            };
        }
    }
}
