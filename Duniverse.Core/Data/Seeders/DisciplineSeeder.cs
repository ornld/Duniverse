using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class DisciplineSeeder
    {
        public static List<Discipline> GetDisciplines()
        {
            return new List<Discipline>
            {
                new Discipline
                {
                    Id = "disc_BeneGesseritTraining",
                    Name = "Bene Gesserit Way",
                    ShortDescription = "Mental and physical conditioning aimed at total command of one's own body.",
                    DetailedHistory = "Ninety generations of refinement built the Bene Gesserit Way into something closer to a science than a discipline: practitioners learn to slow a racing heart, wall off pain, burn a poison out of their own bloodstream, and read the flicker of a muscle or the catch in a voice that gives a liar away. The Sisterhood calls this prana-bindu awareness, and in its fullest expression it turns outward as well as inward. The Voice belongs to this same lineage, a set of vocal tones pitched and timed to force compliance out of a listener who never sees it coming. Girls enter training young, often at schools such as the one on Wallach IX, and the years that follow strip the class down to a handful of acolytes tough enough to be trusted with what the order actually protects. Pushed to its limits, the method becomes the killing art outsiders would later call the Weirding Way; in a vanishingly rare case like Paul Atreides, it fuses with prescience into something the Sisterhood itself never planned for and could not fully control.",
                    ImagePath = "images/disciplines/bg_training.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_LadyJessica", "char_PaulAtreides" },
                    Requirements = "Genetic predisposition, years of rigorous mental conditioning",
                    Mechanics = "Prana-bindu awareness, Voice modulation, Truth-sense"
                },
                new Discipline
                {
                    Id = "disc_Mentat",
                    Name = "Mentat",
                    ShortDescription = "Human minds trained as living computers, prized for cold logic and analysis.",
                    DetailedHistory = "The Butlerian Jihad wiped thinking machines from the Imperium and left a void the Mentat discipline was built to fill. Gilbertus Albans founded the school, and ten thousand years of refinement turned it into a method for reshaping a gifted human mind into something close to a calculating engine, able to hold a mountain of data in view and squeeze out a clean strategic answer. The training asks for natural brilliance to start with, then years of narrow, exhausting focus, until the Mentat can drop into a trance of pure projection at will. Great Houses leaned on men like Thufir Hawat for exactly this: a mind whose verdict on war, trade, or succession carried the weight of certainty few other advisors could offer. Loyalty was never guaranteed, though. Piter De Vries served the Harkonnens with the same gifts turned toward cruelty, proof that the discipline sharpens a mind without choosing its master.",
                    ImagePath = "images/disciplines/mentat_training.jpg",
                    RelatedEntityIds = new List<string> { "char_ThufirHawat", "char_PiterDeVries", "char_GilbertusAlbans", "org_MentatSchool" },
                    Requirements = "Exceptional intellect, focus training",
                    Mechanics = "Super-logic, data synthesis, probability calculation"
                },
                new Discipline
                {
                    Id = "disc_WeirdingWay",
                    Name = "Weirding Way",
                    ShortDescription = "A martial art built on extreme speed and total muscle control.",
                    DetailedHistory = "Outsiders who watched the Weirding Way in action swore they were seeing magic. What they were really seeing was Bene Gesserit prana-bindu conditioning applied to unarmed combat, letting a trained fighter move and strike faster than an ordinary nervous system can track or answer. Paul Atreides and Lady Jessica taught the method to Fremen fighters, and the edge it gave them showed up almost immediately in the humiliations the supposedly unbeatable Sardaukar suffered across Arrakis. Strength has little to do with it; the style runs on command over one's own muscles and reflexes, turning an opponent's force back on him and striking inside reaction windows a normal fighter never even registers. Grafted onto Fremen fighters already hardened by the desert, it helped forge Paul's army into perhaps the most feared infantry the Imperium saw during the entire jihad.",
                    ImagePath = "images/disciplines/weirding_way.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "org_Fremen", "char_PaulAtreides" },
                    Requirements = "Prana-bindu mastery",
                    Mechanics = "High-speed strikes, kinetic redirection"
                },
                new Discipline
                {
                    Id = "disc_FremenDesertSurvival",
                    Name = "Desert Survival",
                    ShortDescription = "Skill in surviving and thriving amid the harsh conditions of Arrakis.",
                    DetailedHistory = "Centuries of brutal trial and error against the harshest environment in the Imperium produced Fremen desert survival skill, a body of knowledge that lets a properly trained person last where an unprepared outsider would drop dead within hours. Water discipline sits at its center: a near-religious refusal to waste a single drop of moisture, upheld by the stillsuit and by sietch customs so strict they govern what happens to a person's water after death. Reading the desert itself matters just as much, spotting the telltale signs of a sandworm on approach, crossing dunes with no fixed landmark in sight, and walking in the broken, arrhythmic gait Fremen call the sand-walk, built for one purpose: never draw a worm's attention. Sietch communities drill these skills into children from birth, and that same inheritance is what carried Paul and Jessica Atreides through their flight into the desert and, in time, earned them a place among the Fremen as more than outsiders wearing the name.",
                    ImagePath = "images/disciplines/survival.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "loc_Arrakis" },
                    Requirements = "Total reliance on recycled moisture",
                    Mechanics = "Water discipline, sand-walking, worm-riding"
                },
                new Discipline
                {
                    Id = "disc_SpiceMining",
                    Name = "Spice Mining",
                    ShortDescription = "The industrial-scale, high-risk extraction of melange from the open desert.",
                    DetailedHistory = "Call it a hazardous trade and you're understating it: spice mining depends on split-second coordination between lumbering crawler harvesters raking the surface for pre-spice masses, spotter aircraft scanning for the first signs of a worm on the move, and ornithopter carryalls poised to snatch the crawler off the sand before the worm reaches it. Every run is a countdown. The harvester's own vibration calls worms up from below, and a crew slow to pull out loses the machine, and often themselves, to the creature closing in. The risk never scared off the money; a single successful haul was worth enough to make spice mining one of the most profitable and jealously guarded industries any House could hold on Arrakis. Harkonnen crews ran the operation before Atreides administrations inherited it, and both depended on workers willing to gamble their lives on a trade that, without exaggeration, kept the Imperium's economy and its ships moving at all.",
                    ImagePath = "images/disciplines/mining.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis" },
                    Requirements = "Technical aptitude, courage against worms",
                    Mechanics = "Heavy vehicle operation, hazard detection"
                },
                new Discipline
                {
                    Id = "disc_GuildNavigation",
                    Name = "Guild Navigation",
                    ShortDescription = "The prescient art of steering ships safely through folded space.",
                    DetailedHistory = "A Guild Navigator earns limited, essential prescience by swallowing melange at concentrations no ordinary human body could survive, and a lifetime of that exposure remakes the body along with the mind. What emerges is an altered awareness sharp enough to pick a safe route through folded space, a place that would otherwise tear a Heighliner apart, and guide the ship across light-years in what feels, to everyone aboard, like the blink of an eye. Few humans carry the genetic tolerance the process demands, and fewer still would accept the price: a life sealed inside a customized tank, the outside world reduced to whatever the Guild's instruments choose to show. No one has ever found another way to travel faster than light, and that single fact makes Guild Navigation the most closely guarded, most economically vital skill anywhere in the Imperium.",
                    ImagePath = "images/disciplines/navigation.jpg",
                    RelatedEntityIds = new List<string> { "org_SpacingGuild" },
                    Requirements = "High spice tolerance, genetic mutation",
                    Mechanics = "Prescient path-finding, space folding"
                },
                new Discipline
                {
                    Id = "disc_SukMedical",
                    Name = "Suk Medical Conditioning",
                    ShortDescription = "The Imperium's finest medical training, made absolutely trustworthy through conditioning.",
                    DetailedHistory = "Suk conditioning sits at the top of Imperial medicine for good reason: it pairs a punishing, comprehensive medical education with psychological conditioning so deep it renders a graduate neurologically incapable of killing a human being. Graduates wear a diamond tattoo on the forehead, a mark so trusted that even the most suspicious Great Houses hand Suk doctors access they would deny any other outsider. That trust rested on one assumption, that the conditioning could never be broken, not by threat, not by bribery, not by anything. House Harkonnen shattered the assumption anyway, kidnapping and torturing Dr. Wellington Yueh's wife until he turned his conditioning inside out and betrayed House Atreides. The shock that followed rippled across the Imperium for a simple reason: the one safeguard everyone treated as unbreakable had just broken.",
                    ImagePath = "images/disciplines/suk_med.jpg",
                    RelatedEntityIds = new List<string> { "char_WellingtonYueh" },
                    Requirements = "Imperial medical degree, intensive psychological conditioning",
                    Mechanics = "Advanced surgery, bio-toxin analysis"
                },
                new Discipline
                {
                    Id = "disc_SardaukarWarfare",
                    Name = "Sardaukar Training",
                    ShortDescription = "Brutal combat training bred on the prison planet Salusa Secundus.",
                    DetailedHistory = "Salusa Secundus was built to be merciless, a prison world deliberately kept that way, and Sardaukar training is what that cruelty produced: soldiers whose physical conditioning, appetite for terror tactics, and fanatical devotion to the Emperor made them the most feared fighters in the Imperium for thousands of years. Children who lived through adolescence there arrived at formal training already harder than most soldiers ever become, needing only discipline and drill to finish the transformation. Sardaukar doctrine valued psychological dominance as highly as raw skill with a blade, breaking an enemy's nerve through calculated brutality before the fighting had properly begun. The reputation for invincibility held for generations. It cracked on Arrakis, where Fremen fighters, shaped by a desert crueler than Salusa Secundus itself, proved in open combat that Sardaukar supremacy had never been quite as absolute as the Imperium wanted to believe.",
                    ImagePath = "images/disciplines/sardaukar.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino" },
                    Requirements = "Survival on Salusa Secundus, peak physical conditioning",
                    Mechanics = "Terror-tactics, lethal efficiency"
                },
                new Discipline
                {
                    Id = "disc_SwordmasterGinaz",
                    Name = "Ginaz Swordmastery",
                    ShortDescription = "The finest blade-fighting technique taught anywhere in the Imperium.",
                    DetailedHistory = "No school of blade combat in the Imperium matched the Swordmasters of Ginaz, whose students spent years in grueling master-apprentice duels learning to value speed, precision, and clean efficiency over sheer force. A strict code of honor came bound to the technique itself: a true Swordmaster would not lend his skill to a cause he judged unjust, and that refusal made his loyalty worth as much to a House as his swordsmanship. Duncan Idaho stands as the clearest example of what the discipline was built to produce, a fighter who held off impossible odds on skill alone and chose death over abandoning his post. Ginaz masters stayed rare across the Imperium for one reason: the school asked as much of a student's character as of his blade arm, and few managed to satisfy both demands.",
                    ImagePath = "images/disciplines/ginaz_blade.jpg",
                    RelatedEntityIds = new List<string> { "char_DuncanIdaho" },
                    Requirements = "Years of master-apprentice dueling",
                    Mechanics = "Blade precision, defensive reflexes"
                },
                new Discipline
                {
                    Id = "disc_KwisatzHaderachProcess",
                    Name = "Kwisatz Haderach Breeding",
                    ShortDescription = "The Bene Gesserit's secret, generations-long genetic breeding project.",
                    DetailedHistory = "Ninety generations deep and threaded through nearly every Great House in the Imperium, the Kwisatz Haderach breeding program stands as the Bene Gesserit's most ambitious and most closely guarded genetic scheme: a slow concentration of chosen bloodlines aimed at producing a man who could reach both male and female ancestral memory, a feat otherwise reserved for Reverend Mothers alone. Sisters carried out their assigned pairings across the centuries with no real view of the larger pattern, kept in the dark to protect the project from rival factions or a single leak. Count Hasimir Fenring shows how exact the calculation had to be: he carried nearly every trait the program needed and still fell short by one missing piece. Lady Jessica broke ranks and had a son instead of the ordered daughter, and Paul Atreides arrived a generation early, delivering the program its goal and slipping free of the Sisterhood's control in the same breath, a paradox that shaped everything left of his life.",
                    ImagePath = "images/disciplines/breeding.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_PaulAtreides", "char_HasimirFenring" },
                    Requirements = "Strict lineage control, genetic manipulation",
                    Mechanics = "Genetic synthesis, prescient awakening"
                },
                new Discipline
                {
                    Id = "disc_HonoredMatreImprinting",
                    Name = "Honored Matre Imprinting",
                    ShortDescription = "A sexual-conditioning technique the Honored Matres use to lock men into absolute loyalty.",
                    DetailedHistory = "Set beside the Bene Gesserit's own subtle arts of persuasion, Honored Matre imprinting looks crude, almost brutal by comparison: it uses intense sexual conditioning to plant a devotion in its subject so deep the man rarely recognizes it as manipulation at all, let alone something done to him on purpose. The Sisterhood builds trust over years, layering patience and misdirection until control feels earned. The Honored Matres skip all of that and get comparable results in one encounter, a brutal shortcut that let them subjugate men and whole populations at terrifying speed during their conquest of the Old Imperium. Bene Gesserit sisters first dismissed the technique as their own arts stripped of restraint, domination with none of the ethical or strategic discipline the Sisterhood valued. Results are hard to argue with, though, and pieces of the method were eventually studied, absorbed, uneasily folded into Bene Gesserit practice as the two orders' futures tangled together through figures like Murbella.",
                    ImagePath = "images/disciplines/honored_matre_imprinting.jpg",
                    RelatedEntityIds = new List<string> { "org_HonoredMatres", "char_Murbella", "org_BeneGesserit" },
                    Requirements = "Training within the Honored Matre order; willingness to use intimacy as a weapon",
                    Mechanics = "Neurological/hormonal conditioning delivered through sexual contact"
                },
                new Discipline
                {
                    Id = "disc_GholaCultivation",
                    Name = "Ghola Cultivation",
                    ShortDescription = "The Tleilaxu practice of regrowing the dead from a single preserved cell.",
                    DetailedHistory = "The axlotl tank does the real work here, and its biology remains one of the Bene Tleilax's best-kept secrets: feed it a preserved cell from someone dead, and it grows back a body identical to the original, though blank, a person with no memory of who they were. The right shock, psychological or emotional and usually timed with precision, can pull fragments of the old memories back, sometimes the whole identity, restoring someone everyone assumed gone for good. Duncan Idaho came back this way more than once across the centuries, and every return raised the same question: how much of that was the original man, and how much was rebuilt from scratch? Only the Tleilaxu hold the knowledge to make the process work reliably, and that monopoly handed the order enormous leverage over anyone desperate enough to want a lost ally, lover, or weapon walking again.",
                    ImagePath = "images/disciplines/ghola_cultivation.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneTleilax", "char_DuncanIdaho", "char_MilesTeg", "char_Scytale" },
                    Requirements = "A viable cell sample from the deceased; Tleilaxu axlotl tank technology",
                    Mechanics = "Cellular regrowth followed by a triggering process to recover original memories"
                }
            };
        }
    }
}