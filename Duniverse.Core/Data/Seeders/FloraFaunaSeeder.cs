using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class FloraFaunaSeeder
    {
        public static List<FloraFauna> GetFloraFaunas()
        {
            return new List<FloraFauna>
            {
                new FloraFauna
                {
                    Id = "bio_ShaiHulud",
                    Name = "Shai-Hulud (Sandworm)",
                    Aliases = new List<string> { "Maker", "Old Man of the Desert", "Old Father Eternity", "Grandfather of the Desert" },
                    ShortDescription = "Colossal, near-immortal, and worshipped as a god. The sandworms of Arrakis sit at the center of both the spice cycle and Fremen faith.",
                    DetailedHistory = "Sandworms grow to hundreds of meters and live for centuries. They guard their territory with a temper close to rage. Any rhythmic vibration on open sand pulls one straight toward the source. Their biology alone explains why Arrakis matters to the Imperium. The worm takes the deep-buried, water-poisoned sandtrout stage and turns it into pre-spice mass. That mass surfaces, gets processed, and becomes melange. The worm is danger and fortune wearing the same skin. Fremen religion treats Shai-Hulud as far more than a threat to survive. He is the 'Old Man of the Desert,' a divine presence whose favor decides whether a tribe lives through the season. His teeth, pulled after death, become the crysknives every Fremen carries at the hip. Riding a captured worm calls for hooks that force its sensitive segments up, away from the abrasive sand. Fremen learned this trick generations ago. It became both their standard way to cross the desert and the rite that marks a boy's passage into manhood.",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "org_Fremen", "bio_Melange", "bio_Sandtrout", "theo_CultOfShaiHulud", "art_Thumper", "art_Crysknife", "loc_Rakis", "loc_Chapterhouse" },
                    BiologicalClassification = "Giant subterranean annelid-like organism (fauna)",
                    DerivedProducts = "Pre-spice mass and melange; crysknife teeth"
                },
                new FloraFauna
                {
                    Id = "bio_Sandtrout",
                    Name = "Sandtrout",
                    ShortDescription = "The juvenile form of the sandworm, and the reason Arrakis stays a desert.",
                    DetailedHistory = "Sandtrout are the sandworm's larval stage, soft and vulnerable in a way the adult never is. One habit defines them: they take in every trace of free water they touch and seal it away in reservoirs deep beneath the sand. Water is poison to a maturing worm, so the behavior is self-preservation rather than malice, but the effect on Arrakis is absolute. Nothing reaches the surface for ordinary plant life to live on, and the desert stays a desert. Pardot and Liet Kynes understood that greening the planet meant breaking this cycle first. The Fremen had found their own use for the creature long before any planetologist arrived: drowning one yields the bitter liquid their Reverend Mothers take as the Water of Life.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.ChildrenOfDune, "Leto II found the use nobody else had been willing to consider. He let thousands of them fasten onto his skin and stay there, and what he got for it was a living membrane no blade or projectile could reach through, strength past any human measure, and centuries where a lifetime should have been. What he gave up was the shape of a man, and every ordinary thing that came with it."),
                        new(SpoilerTier.HereticsOfDune, "When his body finally came apart, the sandtrout he had carried scattered back into the sand and resumed hoarding water as though nothing had interrupted them. The desert closed over the gardens again, the worms came back with it, and the world took a new name."),
                    },
                    RelatedEntityIds = new List<string> { "bio_ShaiHulud", "loc_Arrakis", "char_LetoIIAtreides", "event_GoldenPathBegins" },
                    BiologicalClassification = "Larval stage of the sandworm (fauna)",
                    DerivedProducts = "Consumes and locks away planetary water; drowned to yield the Water of Life"
                },
                new FloraFauna
                {
                    Id = "bio_Sandplankton",
                    Name = "Sand Plankton",
                    ShortDescription = "Microscopic desert organisms that young sandtrout feed on. Easy to overlook, impossible to do without.",
                    DetailedHistory = "Sand plankton sit at the very bottom of Arrakis's food web, straddling the line between microscopic flora and fauna. They feed the youngest sandtrout before those mature into the larger, more dangerous stages of the sandworm life cycle. Strip away a healthy plankton population and the entire spice cycle loses its foundation. No plankton means no sandtrout, no pre-spice mass, and eventually no worms. These nearly invisible organisms matter to Arrakis's economy as much as the giants they support. Imperial planetologists such as Pardot and Liet Kynes tracked plankton populations for years. It was part of a secret, generations-long project to understand the planet's fragile desert ecology and eventually remake it. Their size is nothing to speak of. Their place in the chain, connecting the harshest terrain in the Imperium to its most valuable substance, is everything.",
                    RelatedEntityIds = new List<string> { "bio_Sandtrout", "loc_Arrakis" },
                    BiologicalClassification = "Microscopic desert organism (flora/fauna boundary)",
                    DerivedProducts = "Sustains sandtrout populations; indirect precursor to melange"
                },
                new FloraFauna
                {
                    Id = "bio_Melange",
                    Name = "Melange (Geriatric Spice)",
                    Aliases = new List<string> { "The Spice" },
                    ShortDescription = "The 'geriatric spice,' a life-extending, mind-opening substance that exists nowhere else in the universe.",
                    DetailedHistory = "The sandworm life cycle produces it start to finish. Sandtrout give way to pre-spice mass, and that mass eventually erupts as raw melange onto the surface. Nothing else like it exists anywhere in known space. Regular use stretches the human lifespan and sharpens the mind and body well past normal limits. Sustained, concentrated doses can even unlock a limited form of prescience. That is the same trait that lets Guild Navigators fold space without killing everyone aboard. Its grip is total. Withdrawal after long-term use can kill. That dependence has bound entire populations and institutions, the Spacing Guild chief among them, to a supply chain only the ruler of Arrakis can turn on or off. Necessity, scarcity, and addiction combined to make melange the real engine of Imperial politics. Houses fell, religions rose, and wars got fought, all over who controlled its flow.",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "bio_ShaiHulud", "org_SpacingGuild", "org_BeneGesserit", "art_WaterOfLife", "disc_GuildNavigation" },
                    BiologicalClassification = "Bio-chemical compound derived from the sandworm life cycle",
                    DerivedProducts = "Life extension, expanded awareness, limited prescience; refined into spice beer and other products"
                },
                new FloraFauna
                {
                    Id = "bio_MuadDibMouse",
                    Name = "Muad'Dib (Kangaroo Mouse)",
                    ShortDescription = "The small desert mouse whose name Paul Atreides took as his own among the Fremen.",
                    DetailedHistory = "Fremen culture revered the kangaroo mouse called Muad'Dib long before Paul Atreides set foot on Arrakis. The creature survives the open desert on resourcefulness and endurance rather than brute strength. Those are exactly the qualities the Fremen prize in themselves. Paul took the mouse's name at his formal adoption into Fremen society. The choice tied his identity to those same desert virtues: adaptability, patience, a resilience that never announces itself. The name carried weight beyond the practical, too. It echoed existing Fremen legend closely enough to feed the messianic expectations the Bene Gesserit's Missionaria Protectiva had already planted among the tribes. By the time Paul's jihad tore across the Imperium, a small desert mouse's name had fused to one of history's most consequential religious and political movements.",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "char_PaulAtreides", "org_Fremen" },
                    BiologicalClassification = "Small desert-adapted rodent (fauna)",
                    DerivedProducts = "None; culturally significant as a namesake rather than a resource"
                },
                new FloraFauna
                {
                    Id = "bio_LazaTiger",
                    Name = "Laza Tiger",
                    ShortDescription = "Genetically engineered predators, bred and trained to hunt down specific targets and kill them.",
                    DetailedHistory = "Loyalists still chasing a restoration of House Corrino bred and conditioned the Laza tiger for one purpose: assassination. Careful genetic work sharpened the animal's natural predatory instinct and pointed it squarely at human targets. Wensicia Corrino and Javid, her man inside Alia's court, set a pair of these tigers loose on the young twins Leto II and Ghanima during their childhood on Arrakis. The aim was to wipe out the last of the Atreides line without staging anything so obvious as open war. It failed. The twins carried reflexes and awareness no ordinary child could match, inherited from the same pre-born ancestral memory that had made them targets in the first place. Exposure of the conspiracy followed the failed attack. The episode became one of several formative dangers that hardened Leto II's resolve about what fate awaited his family and the Imperium.",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_GhanimaAtreides", "house_Corrino" },
                    BiologicalClassification = "Genetically engineered predatory fauna",
                    DerivedProducts = "None; bred exclusively for assassination purposes"
                },
                new FloraFauna
                {
                    Id = "bio_PundiRice",
                    Name = "Pundi Rice",
                    ShortDescription = "A staple grain grown across Caladan's fertile lowlands.",
                    DetailedHistory = "Nearly every settlement on Caladan eats pundi rice as a matter of course. It thrives in the planet's fertile, well-watered lowlands. That picture of abundance would look like fantasy to anyone raised on Arrakis, where one wasted drop of moisture can decide who lives and who does not. Growing it reflects House Atreides' entirely different relationship with plenty: careful stewardship rather than desperate rationing. Under Atreides rule the crop stood for a style of governance built on prosperity and a kind of gentleness. Duke Leto carried those values with him into his harsher new fief on Arrakis, not always with success. Pundi rice paddies stayed a quiet, lasting image of Caladan throughout the saga. They are a reminder of the world, and the way of life, the Atreides family left behind.",
                    RelatedEntityIds = new List<string> { "loc_Caladan", "house_Atreides" },
                    BiologicalClassification = "Cultivated cereal grain (flora)",
                    DerivedProducts = "Staple food crop for Caladan's population"
                },
                new FloraFauna
                {
                    Id = "bio_ElaccaWood",
                    Name = "Elacca Wood",
                    ShortDescription = "A dense wood from Ecaz, prized by carvers and dangerous to burn. Its smoke is a potent narcotic.",
                    DetailedHistory = "The Landsraad prizes elacca wood on two fronts at once. There is its rich, workable grain, and there is the dangerously addictive smoke it gives off when burned. That double nature ties House Ecaz's celebrated woodcarving tradition to a substance the Imperium watches closely for its recreational and narcotic uses. Master carvers on Ecaz treat the wood the way any fine artist treats a rare material. The objects they produce earn admiration for their beauty as much as for the subtle intoxicating qualities locked inside the grain. Artistic medium and regulated narcotic at once, elacca wood gave House Ecaz a strange kind of leverage. Its reputation rests on craftsmanship rather than the military or political muscle most Great Houses lean on. The trade demands careful oversight. Left uncontrolled, elacca smoke's addictive pull turns into a real danger for any world where it circulates freely.",
                    RelatedEntityIds = new List<string> { "loc_Ecaz", "house_Ecaz" },
                    BiologicalClassification = "Hardwood tree (flora)",
                    DerivedProducts = "Carved goods; addictive narcotic smoke when burned"
                },
                new FloraFauna
                {
                    Id = "bio_DesertHawk",
                    Name = "Desert Hawk",
                    ShortDescription = "Carrion birds circling the deep desert of Arrakis, read by most as a sign that death has passed nearby.",
                    DetailedHistory = "Desert hawks scrape a living from skies that offer almost nothing in the way of conventional prey. They feed instead on whatever the desert's steady, quiet violence leaves behind. They circle wherever death has recently come: heat, dehydration, a worm attack, a skirmish between rival factions. That habit has turned their presence into a grim but dependable omen for anyone who spends real time in the open sand. Newcomers find the sight unsettling, a gut-level reminder of how thin the margin for survival runs on Arrakis. Lifelong Fremen read the same circling birds as nothing more than a practical signal, one more piece of information about the desert's current dangers. Desert hawks play a small ecological role next to the sandworm. Even so, they hold a distinct, unmistakable place in the planet's visual and cultural landscape.",
                    RelatedEntityIds = new List<string> { "loc_Arrakis" },
                    BiologicalClassification = "Scavenging bird of prey (fauna)",
                    DerivedProducts = "None; purely an ecological scavenger"
                },
                new FloraFauna
                {
                    Id = "bio_ChusukWood",
                    Name = "Chusuk Tonewood",
                    ShortDescription = "The prized tonewood behind balisets and other stringed instruments.",
                    DetailedHistory = "Chusuk grows this tonewood, and the planet's culture and economy turn almost entirely around the making and playing of music. So it is no surprise that instrument-makers across the Imperium favor the wood for its rich resonance and durability. Balisets built from Chusuk tonewood rank among the finest in known space. Traveling minstrels and noble troubadours alike prize them for a warmth and clarity of tone few other woods can match. Gurney Halleck, the Atreides warmaster as devoted to music as to combat, favored an instrument built from this wood. He used it to compose and perform even through war and exile. The tonewood trade gave Chusuk an identity, and an export value, entirely apart from the military, religious, or industrial concerns that defined most other worlds in the Imperium.",
                    RelatedEntityIds = new List<string> { "char_GurneyHalleck" },
                    BiologicalClassification = "Tonewood tree (flora)",
                    DerivedProducts = "Soundboards and bodies for balisets and other stringed instruments"
                },
                new FloraFauna
                {
                    Id = "bio_Futar",
                    Name = "Futar",
                    ShortDescription = "A bred human-feline hybrid, made somewhere in the Scattering to hunt Honored Matres.",
                    DetailedHistory = "Tleilaxu genetic science built the futar to hunt Honored Matres. It combines heightened feline senses and physical power with trained cunning, sharp enough to make it a uniquely effective hunter of otherwise elusive prey. Its creators had one quarry in mind, and that quarry was trained well enough to slip past ordinary human pursuers without much trouble. A futar hunts on a chilling mix of raw instinct and calculated purpose, savage in ways you can predict and tactical in ways you cannot. That combination made it feared even among factions well used to genetically engineered threats. Its existence says a great deal about what the far Scattering had been breeding to meet the Honored Matres, and about how little of that the Old Imperium saw coming.",
                    RelatedEntityIds = new List<string> { "org_HonoredMatres", "org_BeneTleilax" },
                    BiologicalClassification = "Genetically engineered human-feline hybrid (fauna)",
                    DerivedProducts = "None; bred exclusively as trackers and hunters"
                }
            };
        }
    }
}
