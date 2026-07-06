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
                    ShortDescription = "A Great House built on honor and the fierce loyalty of its subjects, undone by the very Imperium it served so faithfully.",
                    DetailedHistory = "House Atreides ruled the ocean world of Caladan for twenty-six generations, and its standing never came from wealth or numbers. It came from the personal loyalty its Dukes could earn from the people under them, a tradition Duke Leto Atreides carried further than most. His popularity, paired with an elite fighting corps, made him a man Emperor Shaddam IV watched with real unease. That same popularity, tangled up with the ancient blood-feud against House Harkonnen, turned the Atreides into an easy mark once the family received the lucrative, treacherous fief of Arrakis. What followed nearly wiped the House from history: Duke Leto was killed, his household scattered to the winds. His son Paul lived on among the Fremen, though, and rose among them as Muad'Dib before seizing the Golden Lion Throne outright. Atreides blood held the Imperium for millennia afterward, stretching through Paul's children and into Leto II's strange God Emperor dynasty, in ways none of the House's early nobles could have pictured.",
                    ImagePath = "images/houses/atreides.jpg",
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
                    DetailedHistory = "House Harkonnen ruled from the industrial squalor of Giedi Prime, where its fortune grew out of ruthless exploitation and a governing philosophy of pure indirection: 'plans within plans within plans.' Baron Vladimir Harkonnen orchestrated the fall of House Atreides on Arrakis with covert backing from the Imperial throne, his brutish nephew Glossu Rabban and cunning heir Feyd-Rautha both playing their parts, and reclaimed the planet's spice fief for the family that had held it before the Atreides ever arrived. The victory did not last. Within two years Paul Atreides, son of the Duke the Harkonnens had betrayed, returned at the head of a Fremen army, toppled the Baron's rule, and killed Feyd-Rautha in single combat. Harkonnen became a name synonymous with casual cruelty and decadence across the Imperium, and the feud against House Atreides stood among the defining rivalries of Imperial history.",
                    ImagePath = "images/houses/harkonnen.jpg",
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
                    DetailedHistory = "House Corrino governed from the sumptuous capital of Kaitain and held the Golden Lion Throne for more than ten thousand years, a longer reign than any other dynasty in recorded Imperial history can claim. Their grip on power rested on a delicate three-way balance: the Landsraad's Great Houses on one side, the commercial machinery of CHOAM on another, and, backing it all, the ferocious loyalty of the Emperor's own Sardaukar legions, forged on the prison world of Salusa Secundus. Shaddam IV's covert scheme against House Atreides, Sardaukar troops disguised as Harkonnen soldiers seizing Arrakis by stealth, aimed to remove a rising rival and lock in his dynasty's hold on the throne. It backfired spectacularly, delivering Paul Atreides, soon to marry Shaddam's own daughter Irulan, into a position to claim the throne for himself. Corrino's fall from open Imperial rule closed out humanity's longest continuous dynasty and opened the door to the Atreides Imperium.",
                    ImagePath = "images/houses/corrino.jpg",
                    RelatedEntityIds = new List<string> { "loc_Kaitain", "loc_SalusaSecundus", "char_ShaddamIV", "char_PrincessIrulan", "org_Sardaukar", "char_ElroodIX" },
                    Sigil = "The golden lion",
                    Motto = "By right of the Golden Lion Throne",
                    HistoricalRivalries = new List<string> { "house_Atreides" }
                },
                new House
                {
                    Id = "house_Ecaz",
                    Name = "House Ecaz",
                    ShortDescription = "A Great House celebrated for its master woodcarvers, worn down by a long, bitter feud with House Moritani.",
                    DetailedHistory = "House Ecaz earned its name throughout the Imperium through artistry, not arms: its master woodcarvers produced work prized across the Landsraad as the mark of refined taste. That peaceful reputation sat oddly alongside the House's generations-long feud with House Moritani of Grumman, a blood rivalry rooted in old slights neither side could let go, and one that turned brutally violent more than once. Matters grew far more dangerous during the reign of Paul Atreides' children, when the conflict escalated and drew the Atreides themselves into Ecaz's affairs, marriage alliances brokered in hopes of finally securing peace. Grumman's threat never really let up, yet House Ecaz endured, and it remained one of the Imperium's more cultured and diplomatically respected Great Houses.",
                    ImagePath = "images/houses/ecaz.jpg",
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
                    DetailedHistory = "House Moritani ruled the harsh world of Grumman and built a reputation across the Landsraad for a temper that ran hot and a preference for poison, assassination, and open war over the diplomatic channels most Great Houses favored. Their generations-long feud with the far more refined House Ecaz grew into one of the most dangerous, closely watched disputes of its era, testing again and again just how far the Great Convention would let two Great Houses go. Moritani's readiness to skirt Imperial law made the House both feared and quietly useful: other factions turned to them when violence needed to happen at arm's length, away from their own hands. The conflict with Ecaz dragged on for generations, outlasting individual Emperors and shaping Landsraad politics long after most had forgotten how it started.",
                    ImagePath = "images/houses/moritani.jpg",
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
                    DetailedHistory = "House Richese stood as a perennial commercial and technological rival to Ix, and its fortune came from miniaturized devices, probes, and mechanisms: clever engineering that pushed right up against the boundaries the Butlerian Jihad had set against thinking machines, careful never to cross them outright. Ix specialized in large-scale industrial technology; Richese, instead, carved out a niche in delicate, precision instruments that nobles, Mentats, and spies across the Imperium all coveted. The rivalry between the two Houses ran on markets and patents as much as politics, each side accusing the other of lifting designs or undercutting prices in the lucrative gadget trade. Richese's fortunes rose and fell with the Imperium's appetite for its inventions, and the House settled into life as a wealthy but politically secondary player next to the Great Houses that commanded real military muscle.",
                    ImagePath = "images/houses/richese.jpg",
                    RelatedEntityIds = new List<string> { "loc_Ix", "theo_ButlerianDoctrine", "loc_Richese" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string> { "house_Vernius" }
                },
                new House
                {
                    Id = "house_Vernius",
                    Name = "House Vernius",
                    ShortDescription = "The ruling House of Ix, the Imperium's most technologically advanced world.",
                    DetailedHistory = "House Vernius governed the subterranean machine-city of Ix and walked a careful, profitable line between raw innovation and the Butlerian taboo against thinking machines, manufacturing devices, some legitimate, some illicit, that no other House in the Imperium could match. Under Earl Dominic Vernius, Ix flourished as a hub of hidden technological progress. The House's growing independence made it a target eventually, and a Tleilaxu-engineered coup, quietly sanctioned by the Imperial throne, drove Dominic into exile and scattered his family to the winds. His son Rhombur escaped to Caladan, where he found refuge and a lifelong friendship with House Atreides; Ix itself kept producing forbidden technology, now under new, secretive management. The fall of House Vernius showed just how easily a wealthy, technologically vital House could be tossed aside once it grew inconvenient for the Corrino throne.",
                    ImagePath = "images/houses/vernius.jpg",
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
                    DetailedHistory = "House Fenring never rose to Great House status and held no significant fief of its own, yet it wielded influence far beyond its formal rank through the singular figure of Count Hasimir Fenring: Shaddam IV's closest confidant, most trusted spy, and, when the need arose, quiet executioner. Fenring's standing as a Bene Gesserit-trained near-Kwisatz Haderach, a genetic near-miss thrown up by the Sisterhood's breeding program, made him one of the very few men in the Imperium capable of matching wits with Paul Atreides. His wife, Lady Margot Fenring, a Bene Gesserit Reverend Mother in her own right, pushed the House's reach deep into the Sisterhood's own schemes. Between them, the Fenrings served as the Corrino throne's sharpest instrument of soft power, gathering secrets and settling scores that no open military action could ever touch.",
                    ImagePath = "images/houses/fenring.jpg",
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
                    DetailedHistory = "House Wayku held, for generations, the solemn honor of tending House Atreides' ancestral burial grounds on Caladan, a position built on quiet trust rather than any real political power within the Landsraad. That trust frayed over time. The House's loyalty to the Atreides name grew shakier as circumstances shifted around it, and its story survives in Atreides history less as a record of great deeds than as a cautionary tale: proof that even a bond sealed by tradition and ceremonial duty can rot when nobody tends to it. Wayku's modest holdings and thin military strength meant its drift from Atreides loyalty carried consequences that were more symbolic than strategic. Symbolism counted for a great deal with a House like the Atreides, though, whose entire rule rested on honor.",
                    ImagePath = "images/houses/wayku.jpg",
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
                    DetailedHistory = "House Tuek operated entirely outside official Landsraad recognition, running a smuggling dynasty on Arrakis from hidden bases scattered through the deep desert, well beyond the reach of Imperial authority or Harkonnen patrols. Esmar Tuek led the family for years, his son Staban after him, and the profits came from quietly trading illicitly harvested spice and ferrying it off-world without handing over the Emperor's or CHOAM's cut. Their networks and hidden shelters turned invaluable after the fall of House Atreides: Tuek smugglers sheltered fugitives like the loyal Atreides warmaster Gurney Halleck, keeping contacts and knowledge alive that would later serve Paul's cause. The Landsraad never acknowledged the Tueks as a true House, yet their independence and mastery of the desert made them a quiet, essential power on Arrakis all the same.",
                    ImagePath = "images/houses/tuek.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "char_GurneyHalleck" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string>()
                }
            };
        }
    }
}
