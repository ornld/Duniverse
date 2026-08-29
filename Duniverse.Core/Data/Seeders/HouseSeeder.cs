using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class HouseSeeder
    {
        public static List<House> GetHouses()
        {
            return new List<House>
            {
                new House
                {
                    Id = "house_Atreides",
                    Name = "House Atreides",
                    ShortDescription = "A Great House built on honor and the fierce loyalty of its subjects. The Imperium it served so faithfully was the thing that undid it.",
                    DetailedHistory = "House Atreides ruled the ocean world of Caladan for twenty-six generations. Its standing never came from wealth or numbers. It came from the personal loyalty its Dukes earned from the people under them. Duke Leto Atreides carried that tradition further than most. His popularity and his elite fighting corps made Emperor Shaddam IV watch him with real unease. Then came the old blood-feud against House Harkonnen. Together these things turned the Atreides into an easy mark once the family received the lucrative, treacherous fief of Arrakis. What followed nearly wiped the House from history. Duke Leto was killed and his household scattered. His son Paul lived on among the Fremen. He rose among them as Muad'Dib, and took the Golden Lion Throne from the Emperor who had arranged his father's ruin. A House that had held one ocean world for twenty-six generations finished the year holding the Imperium.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.ChildrenOfDune, "Holding it turned out to be the harder problem. The throne Paul left behind came braided to a religion nobody could switch off, and it passed to his twins through a regency that nearly destroyed them. His son Leto II took it in a direction no Atreides before him would have recognised as rule at all."),
                        new(SpoilerTier.GodEmperorOfDune, "Leto II kept it for thirty-five centuries, by which point he was no longer meaningfully a man and the House was no longer meaningfully a family. It was one reign, one body, and one road he had chosen for the whole species and called the Golden Path."),
                        new(SpoilerTier.HereticsOfDune, "Long after that reign ended, the blood was still moving. It ran thin and unremarked through the descendants his rule had scattered across a galaxy that had mostly stopped noticing the name, which was, in the end, precisely what he had built the road for."),
                    },
                    RelatedEntityIds = new List<string> { "loc_Caladan", "loc_Arrakis", "char_DukeLetoAtreides", "char_PaulAtreides", "char_LadyJessica", "char_DukePaulusAtreides", "char_VorianAtreides", "event_DeathOfDukePaulus" },
                    Sigil = "A red hawk",
                    Motto = "The sleeper must awaken",
                    HistoricalRivalries = new List<string> { "house_Harkonnen" }
                },
                new House
                {
                    Id = "house_Harkonnen",
                    Name = "House Harkonnen",
                    ShortDescription = "A Great House built on cruelty and cunning, locked for generations in a blood-feud with House Atreides.",
                    DetailedHistory = "House Harkonnen ruled from the industrial squalor of Giedi Prime. Its fortune grew out of ruthless exploitation and a governing philosophy of pure indirection: 'plans within plans within plans.' Baron Vladimir Harkonnen orchestrated the fall of House Atreides on Arrakis with covert backing from the Imperial throne. His brutish nephew Glossu Rabban and cunning heir Feyd-Rautha both played their parts. The victory reclaimed the planet's spice fief for the family that had held it before the Atreides ever arrived. It did not last. Within two years Paul Atreides returned at the head of a Fremen army. He was the son of the Duke the Harkonnens had betrayed. He toppled the Baron's rule and killed Feyd-Rautha in single combat. Harkonnen became a name synonymous with casual cruelty and decadence across the Imperium. The feud against House Atreides stood among the defining rivalries of Imperial history.",
                    RelatedEntityIds = new List<string> { "loc_GiediPrime", "char_BaronHarkonnen", "char_FeydRautha", "char_GlossuRabban", "char_AbulurdHarkonnen", "char_XavierHarkonnen", "loc_Lankiveil" },
                    Sigil = "A griffin",
                    Motto = "Plans within plans within plans",
                    HistoricalRivalries = new List<string> { "house_Atreides" }
                },
                new House
                {
                    Id = "house_Corrino",
                    Name = "House Corrino",
                    ShortDescription = "The Imperial dynasty that has occupied the Golden Lion Throne for ten thousand years.",
                    DetailedHistory = "House Corrino governed from the sumptuous capital of Kaitain. It held the Golden Lion Throne for more than ten thousand years, longer than any other dynasty in recorded Imperial history. Their grip on power rested on a delicate three-way balance. The Landsraad's Great Houses stood on one side and the commercial machinery of CHOAM on another. Backing it all were the Emperor's own Sardaukar legions, forged on the prison world of Salusa Secundus, and ferociously loyal. Shaddam IV built a covert scheme against House Atreides. Sardaukar troops disguised as Harkonnen soldiers seized Arrakis by stealth. The plan aimed to remove a rising rival and lock in his dynasty's hold on the throne. It backfired spectacularly. Paul Atreides, soon to marry Shaddam's own daughter Irulan, ended up in a position to claim the throne for himself. Corrino's fall from open Imperial rule closed out humanity's longest continuous dynasty. It opened the door to the Atreides Imperium.",
                    RelatedEntityIds = new List<string> { "loc_Kaitain", "loc_SalusaSecundus", "char_ShaddamIV", "char_PrincessIrulan", "org_Sardaukar", "char_ElroodIX" },
                    Sigil = "The golden lion",
                    Motto = "By right of the Golden Lion Throne",
                    HistoricalRivalries = new List<string> { "house_Atreides" }
                },
                new House
                {
                    Id = "house_Ecaz",
                    Name = "House Ecaz",
                    ShortDescription = "A Great House that earned its standing through artistry rather than arms.",
                    DetailedHistory = "House Ecaz earned its name throughout the Imperium through artistry, not arms. Its master woodcarvers produced work prized across the Landsraad as the mark of refined taste, and the elacca wood its forests grow reaches courts that would trade for nothing else the House offers. That bought Ecaz a standing among the Great Houses its own strength could never have won, which is a rarer position than it sounds and a more precarious one. A House respected for what it makes rather than feared for what it can do keeps its seat only so long as the Landsraad's appetite for beauty holds, and only so long as nobody with more soldiers decides the forests are worth the trouble of taking. Ecaz held that seat for generations regardless, and stayed one of the more cultured and diplomatically respected names in the Imperium.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.ExpandedUniverse, "The prequel chronicles give the House its enemy. In those accounts Ecaz spent generations locked against House Moritani of Grumman in a feud grown out of slights neither side would put down, settled by formal duels of honour about as often as by open war. It reached into Atreides affairs more than once, and the marriage alliances brokered to end it mostly did not. Grumman's threat never really let up, which is the sort of thing a House built on woodcarving learns to live beside rather than answer."),
                    },
                    RelatedEntityIds = new List<string> { "loc_Ecaz", "house_Moritani" },
                    Sigil = "A carved wooden emblem",
                    Motto = "Artistry endures where arms fail",
                    HistoricalRivalries = new List<string> { "house_Moritani" }
                },
                new House
                {
                    Id = "house_Moritani",
                    Name = "House Moritani",
                    ShortDescription = "The volatile ruling House of Grumman, locked in bitter rivalry with House Ecaz.",
                    DetailedHistory = "House Moritani ruled the harsh world of Grumman. Across the Landsraad it was known for a temper that ran hot. It preferred poison, assassination, and open war to the diplomatic channels most Great Houses favored. Its generations-long feud with the far more refined House Ecaz grew into one of the most dangerous, closely watched disputes of its era. The rivalry tested again and again just how far the Great Convention would let two Great Houses go. Moritani's readiness to skirt Imperial law made the House both feared and quietly useful. Other factions turned to them when violence needed to happen at arm's length, away from their own hands. The conflict with Ecaz dragged on for generations. It outlasted individual Emperors and shaped Landsraad politics long after most had forgotten how it started.",
                    RelatedEntityIds = new List<string> { "house_Ecaz" },
                    Sigil = "Not widely recorded outside Grumman",
                    Motto = "Not widely recorded outside Grumman",
                    HistoricalRivalries = new List<string> { "house_Ecaz" }
                },
                new House
                {
                    Id = "house_Richese",
                    Name = "House Richese",
                    ShortDescription = "A Great House whose fortune comes from miniaturized technology and inventive, borderline engineering.",
                    DetailedHistory = "House Richese stood as a perennial commercial and technological rival to Ix. Its fortune came from miniaturized devices, probes, and mechanisms. This clever engineering pushed right up against the boundaries the Butlerian Jihad had set against thinking machines, careful never to cross them outright. Ix specialized in large-scale industrial technology. Richese carved out a niche in delicate, precision instruments that nobles, Mentats, and spies across the Imperium all coveted. The rivalry between the two Houses ran on markets and patents as much as politics. Each side accused the other of lifting designs or undercutting prices in the lucrative gadget trade. Richese's fortunes rose and fell with the Imperium's appetite for its inventions. The House settled into life as a wealthy but politically secondary player next to the Great Houses that commanded real military muscle.",
                    RelatedEntityIds = new List<string> { "loc_Ix", "theo_ButlerianDoctrine", "loc_Richese", "char_HelenaAtreides" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string> { "house_Vernius" }
                },
                new House
                {
                    Id = "house_Vernius",
                    Name = "House Vernius",
                    ShortDescription = "The ruling House of Ix, the Imperium's most technologically advanced world.",
                    DetailedHistory = "House Vernius governed the subterranean machine-city of Ix. It walked a careful, profitable line between raw innovation and the Butlerian taboo against thinking machines. Its devices, some legitimate and some illicit, went beyond anything another House in the Imperium could match. Under Earl Dominic Vernius, Ix flourished as a hub of hidden technological progress. The House's growing independence eventually made it a target. A Tleilaxu-engineered coup, quietly sanctioned by the Imperial throne, drove Dominic into exile and scattered his family. His son Rhombur escaped to Caladan, where he found refuge and a lifelong friendship with House Atreides. Ix itself kept producing forbidden technology, now under new, secretive management. The fall showed how easily a wealthy, technologically vital House could be tossed aside once it grew inconvenient for the Corrino throne. It did not prove permanent. Rhombur spent his exile working to undo it, and House Vernius held Ix again before the end.",
                    RelatedEntityIds = new List<string> { "loc_Ix", "house_Richese", "char_DominicVernius", "char_RhomburVernius", "event_IxianCoup" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string> { "house_Richese" }
                },
                new House
                {
                    Id = "house_Fenring",
                    Name = "House Fenring",
                    ShortDescription = "A minor House whose real power came from one man: Count Hasimir Fenring, the Emperor's closest confidant.",
                    DetailedHistory = "House Fenring never rose to Great House status and held no significant fief of its own. Even so, it wielded influence far beyond its formal rank through one singular figure: Count Hasimir Fenring. He was Shaddam IV's closest confidant, most trusted spy, and, when the need arose, quiet executioner. Fenring was a Bene Gesserit-trained near-Kwisatz Haderach, a genetic near-miss thrown up by the Sisterhood's breeding program. That made him one of the very few men in the Imperium capable of matching wits with Paul Atreides. His wife, Lady Margot Fenring, was a Bene Gesserit Reverend Mother in her own right. She pushed the House's reach deep into the Sisterhood's own schemes. Between them, the Fenrings served as the Corrino throne's sharpest instrument of soft power. They gathered secrets and settled scores that no open military action could ever touch.",
                    RelatedEntityIds = new List<string> { "house_Corrino", "char_ShaddamIV", "org_BeneGesserit", "char_HasimirFenring", "char_MargotFenring" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string>()
                },
                new House
                {
                    Id = "house_Wayku",
                    Name = "House Wayku",
                    ShortDescription = "A minor House once entrusted with guarding the Atreides ancestral crypts on Caladan.",
                    DetailedHistory = "For generations, House Wayku held the solemn honor of tending House Atreides' ancestral burial grounds on Caladan. The position rested on quiet trust rather than any real political power within the Landsraad. That trust frayed over time. The House's loyalty to the Atreides name grew shakier as circumstances shifted around it. Its story survives in Atreides history less as a record of great deeds than as a cautionary tale. It stands as proof that even a bond sealed by tradition and ceremonial duty can rot when nobody tends to it. Wayku's modest holdings and thin military strength meant its drift from Atreides loyalty carried consequences that were more symbolic than strategic. Symbolism counted for a great deal with a House like the Atreides, though, whose entire rule rested on honor.",
                    RelatedEntityIds = new List<string> { "house_Atreides", "loc_Caladan" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string> { "house_Atreides" }
                },
                new House
                {
                    Id = "house_Tuek",
                    Name = "House Tuek",
                    ShortDescription = "A smuggling dynasty operating outside official Landsraad recognition, based on Arrakis.",
                    DetailedHistory = "House Tuek operated entirely outside official Landsraad recognition. It ran a smuggling dynasty on Arrakis from hidden bases scattered through the deep desert, well beyond the reach of Imperial authority or Harkonnen patrols. Esmar Tuek led the family for years, and his son Staban after him. The profits came from quietly trading illicitly harvested spice and ferrying it off-world without handing over the Emperor's or CHOAM's cut. Their networks and hidden shelters turned invaluable after the fall of House Atreides. Tuek smugglers sheltered fugitives like the loyal Atreides warmaster Gurney Halleck. They kept contacts and knowledge alive that would later serve Paul's cause. The Landsraad never acknowledged the Tueks as a true House. Their independence and mastery of the desert made them a quiet, essential power on Arrakis all the same.",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "char_GurneyHalleck", "char_EsmarTuek", "char_StabanTuek" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string>()
                }
            };
        }
    }
}
