using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class WorldSeeder
    {
        public static List<World> GetWorlds()
        {
            return new List<World>
            {
                new World
                {
                    Id = "loc_Arrakis",
                    Name = "Arrakis",
                    // Its later name belongs to the world's own record for that era, not here.
                    Aliases = new List<string> { "Dune" },
                    ShortDescription = "Dune itself: a scoured desert planet and the only known source of the spice melange.",
                    DetailedHistory = "Arrakis is the third planet out from the star Canopus. It offers almost nothing in the way of open water. What it has instead are dune seas without end and sandworms of terrifying size. The life cycle of those worms manufactures the geriatric spice found on no other world in the universe. That aridity pushed the native Fremen toward a culture built around hoarding moisture. Stillsuits reclaim sweat and breath. Sietch cisterns collect water drop by drop across generations, all aimed at a dream of turning the planet green. Melange underwrites Guild navigation, extends human life, and threads through commerce across the Imperium. So whoever held Arrakis as a fief inherited both staggering wealth and a target on their back. That combination pulled House Atreides, House Harkonnen, and eventually Paul Atreides into a fight over the planet that rewrote galactic history. Paul's Fremen legions took it by force in the end. After that, Arrakis stopped being a fief any Emperor could hand out or revoke. It became the throne from which the Atreides Imperium, and later Leto II's Golden Path, governed everything.",
                    ImagePath = "images/worlds/arrakis.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "house_Atreides", "house_Harkonnen", "char_PaulAtreides", "bio_ShaiHulud", "bio_Melange", "art_Stillsuit" },
                    EnvironmentalData = "Arid desert with less than 1% surface moisture, extreme daytime heat, cold nights, and violent Coriolis storms.",
                    RulingHouse = "House Atreides (formerly House Harkonnen, under Imperial fief)",
                    LocalCustoms = new List<string> { "Water discipline and the sanctity of body moisture", "Worm-riding as a rite of passage", "Sietch communal living" }
                },
                new World
                {
                    Id = "loc_Caladan",
                    Name = "Caladan",
                    ShortDescription = "The green, ocean-covered home of House Atreides.",
                    DetailedHistory = "Caladan was the ancestral seat of House Atreides across twenty-six generations. Seas, mountains, and fertile lowlands gave the world over to fishing fleets and pundi rice paddies. Its mild climate bred a Ducal court that prized cultured restraint over brute military display. Duke Leto Atreides governed with the easy, personal affection that comes from knowing one's subjects by name. That same warmth made House Atreides beloved at home and dangerously conspicuous to an Emperor who trusted no one. Accepting the Arrakis fief meant Leto likely traded Caladan's safety away for good. He took the deal anyway. The sacrifice set the destruction of his House in motion, along with his son's eventual rise. The Atreides would come to rule an Imperium far larger than one ocean world. Even so, Caladan stayed the emotional core of who they were for the length of the saga.",
                    ImagePath = "images/worlds/caladan.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "char_PaulAtreides", "char_DukeLetoAtreides", "char_LadyJessica", "bio_PundiRice" },
                    EnvironmentalData = "Temperate oceanic climate with abundant rainfall, mountain ranges, and fertile lowlands.",
                    RulingHouse = "House Atreides",
                    LocalCustoms = new List<string> { "Weather-working traditions among fisherfolk", "Formal Ducal court etiquette", "Cultivation of pundi rice paddies" }
                },
                new World
                {
                    Id = "loc_GiediPrime",
                    Name = "Giedi Prime",
                    ShortDescription = "The bleak, factory-choked homeworld of House Harkonnen.",
                    DetailedHistory = "Centuries of unrestrained industry left Giedi Prime's skies permanently grey. Its factories ran without pause for so long that the pollution became the planet's defining feature. The result is bleak and merciless, every bit as unforgiving as the House that rules it. The largest city holds the Baron's keep, opulent on the surface and rotting underneath. Riches pulled from Arrakis and elsewhere fund private indulgence there rather than any real care for a population kept in line through fear. Ordinary subjects live inside a rigid hierarchy. Even minor defiance tends to draw brutal punishment. Caladan's more paternal style of rule has no equivalent here. Giedi Prime's grim character mirrored House Harkonnen's own reputation so precisely that the planet's name outlived the family's fall. It became Imperial shorthand for cruelty wearing the mask of civilization.",
                    ImagePath = "images/worlds/giedi_prime.jpg",
                    RelatedEntityIds = new List<string> { "house_Harkonnen", "char_BaronHarkonnen", "char_FeydRautha", "char_GlossuRabban" },
                    EnvironmentalData = "Heavily industrialized, polluted atmosphere with little remaining natural wilderness.",
                    RulingHouse = "House Harkonnen",
                    LocalCustoms = new List<string> { "Gladiatorial slave combat for the Baron's entertainment", "Rigid, fear-based social hierarchy" }
                },
                new World
                {
                    Id = "loc_Kaitain",
                    Name = "Kaitain",
                    ShortDescription = "The opulent Imperial capital, seat of House Corrino for ten thousand years.",
                    DetailedHistory = "Ten thousand years of Padishah Emperors sat on Kaitain, and the planet shows every century of it. It was the single most lavish world in the Imperium. The gardens were manicured to the last leaf. The palaces stood tall enough to overwhelm any visitor with Corrino wealth on purpose. Even the climate had been terraformed and tended purely for Imperial comfort. The whole world was a monument, arguing without a word that the Corrinos alone deserved the Golden Lion Throne. Landsraad diplomacy and Imperial court ceremony played out here in their most intricate form. The court games ran so precise that one wrong gesture could end a House as thoroughly as a lost battle. Shaddam IV's gamble on Arrakis cost House Corrino the throne in the end. Kaitain's long run as the undisputed heart of Imperial power ended with it.",
                    ImagePath = "images/worlds/kaitain.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "char_ShaddamIV", "char_PrincessIrulan", "art_GoldenLionThrone" },
                    EnvironmentalData = "Temperate, meticulously terraformed climate maintained for Imperial comfort.",
                    RulingHouse = "House Corrino",
                    LocalCustoms = new List<string> { "Elaborate court ceremony and Landsraad diplomacy", "Ostentatious displays of Imperial wealth" }
                },
                new World
                {
                    Id = "loc_SalusaSecundus",
                    Name = "Salusa Secundus",
                    ShortDescription = "The brutal prison world where the Sardaukar are made.",
                    DetailedHistory = "Salusa Secundus was the original Imperial capital until some still-debated cataclysm tore its surface apart. The Corrino throne later turned the wreckage into a secret training ground. Its radiation-scarred terrain and forced-labor prison population fed the machine that produces the galaxy's most feared soldiers. Brutality here was policy, not accident. The reasoning held that only conditions crueler than any real battlefield could produce warriors able to overwhelm ordinary Imperial or House troops. Generation after generation of Sardaukar recruits survived that ordeal before ritual induction into the legions. What emerged was a fanatical loyalty to the Emperor who had deliberately chosen to torment them into greatness. The planet's real purpose stayed one of the Corrino throne's most tightly held secrets for thousands of years. It propped up the whole myth of Sardaukar invincibility, a myth that finally broke apart on Arrakis.",
                    ImagePath = "images/worlds/salusa_secundus.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "disc_SardaukarWarfare", "org_Sardaukar", "char_ShaddamIV" },
                    EnvironmentalData = "Harsh, radiation-scarred wasteland with extreme climate swings.",
                    RulingHouse = "House Corrino",
                    LocalCustoms = new List<string> { "Survival-of-the-fittest prison culture", "Ritual induction into the Sardaukar legions" }
                },
                new World
                {
                    Id = "loc_Ix",
                    Name = "Ix",
                    ShortDescription = "A subterranean technological powerhouse that tests the limits of the Butlerian Jihad's edicts.",
                    DetailedHistory = "Ix hides its cities in artificial caverns carved deep beneath a cold, forbidding surface. Out of that hidden industry came real wealth and influence. It built the massive Heighliners that carry the Spacing Guild's cargo, along with a whole catalog of devices that creep uncomfortably close to the Butlerian Jihad's ban on thinking machines. Ixian engineers kept up a careful public fiction, insisting nothing built underground counted as a true thinking machine. The line between permitted computation and forbidden artificial intelligence got thinner with every new invention. That balancing act made Ix indispensable across the Imperium. Houses and organizations everywhere leaned on Ixian technology, all of them publicly upholding the very taboo Ix quietly tested. House Vernius eventually grew too independent for the Imperial throne's comfort. A Tleilaxu-engineered coup, sanctioned in secret from above, swapped out the planet's rulers. The flow of Ixian technology the rest of the galaxy had come to need never slowed.",
                    ImagePath = "images/worlds/ix.jpg",
                    RelatedEntityIds = new List<string> { "house_Vernius", "theo_ButlerianDoctrine", "org_SpacingGuild" },
                    EnvironmentalData = "Underground cavern cities beneath a cold, unwelcoming surface.",
                    RulingHouse = "House Vernius",
                    LocalCustoms = new List<string> { "Guild-like secrecy around technological research", "Closely guarded export contracts for manufactured machinery" }
                },
                new World
                {
                    Id = "loc_Tleilax",
                    Name = "Tleilax",
                    ShortDescription = "The secretive homeworld of the Bene Tleilax.",
                    DetailedHistory = "Strict religious and political decree keeps outsiders off Tleilax. That leaves the planet one of the least understood worlds in the Imperium. Its geography and true capabilities are guarded as jealously as the axlotl tanks where its people culture gholas, Face Dancers, and other bio-engineered products. The Tleilaxu hold to a religious philosophy few outsiders ever glimpse, let alone comprehend. That professed piety works as sincere belief and convenient cover in equal measure, serving whatever scheme the planet's long game requires. The rare visitor who sets foot on Tleilax meets a culture that plays itself as harmless, even humble. The performance is calculated. Generations of Tleilaxu leaders have used it to run circles around powerful factions who underestimate them. Millennia of this secrecy have let Tleilax punch well above its formal political weight, trading in biological services no other world in the Imperium can match.",
                    ImagePath = "images/worlds/tleilax.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneTleilax", "theo_TleilaxuFaith", "char_Scytale" },
                    EnvironmentalData = "Arid world with tightly restricted access; surface details closely guarded.",
                    RulingHouse = "Bene Tleilax",
                    LocalCustoms = new List<string> { "Axlotl tank cultivation of gholas", "Strict religious secrecy toward outsiders" }
                },
                new World
                {
                    Id = "loc_WallachIX",
                    Name = "Wallach IX",
                    ShortDescription = "The secluded Mother School of the Bene Gesserit.",
                    DetailedHistory = "Wallach IX was picked for exactly how little attention it draws. A quiet, unassuming planet, it hides the true seat of Bene Gesserit power behind a facade of pastoral insignificance. The Mother School stays shielded from the scrutiny a more conspicuous headquarters would invite. Acolytes inside its cloistered halls undergo the Sisterhood's punishing mental and physical conditioning. The training strips away weakness, fear, and involuntary reaction until nothing remains but disciplined, purposeful control. The isolation serves a second, more practical purpose. It keeps the Bene Gesserit's centuries-spanning breeding program hidden, a project so sprawling that most Sisters know only their own small piece of it. Outsiders rarely grasp how much this modest, overlooked world actually shapes bloodlines and belief across the entire Imperium.",
                    ImagePath = "images/worlds/wallach_ix.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "disc_BeneGesseritTraining", "char_GaiusHelenMohiam" },
                    EnvironmentalData = "Temperate and unremarkable by design, chosen to avoid drawing attention to the Sisterhood's activities.",
                    RulingHouse = "Bene Gesserit",
                    LocalCustoms = new List<string> { "Cloistered acolyte training", "Strict secrecy regarding the breeding program" }
                },
                new World
                {
                    Id = "loc_Ecaz",
                    Name = "Ecaz",
                    ShortDescription = "A forested world famed for its woodcarvers and its long blood feud with House Moritani.",
                    DetailedHistory = "Ecaz's master woodcarvers are famous across the Imperium. Their finished work fetches prices among the highest of any luxury good the Landsraad trades in. The planet's dense forests supply hardwoods rare enough to exist nowhere else in known space. That cultured, peaceable reputation sits right beside a much bloodier one. House Ecaz carried a generations-old feud with House Moritani of Grumman, a conflict worked out through formal duels of honor about as often as through open warfare. The feud eventually reached into House Atreides affairs during the years of Paul's children, pulling Ecaz's fortunes into currents far beyond its own borders. Grumman's threat never really went away. Ecaz endured regardless, one of the Landsraad's more diplomatically respected worlds. Its artistry stayed a genuine point of pride under constant danger.",
                    ImagePath = "images/worlds/ecaz.jpg",
                    RelatedEntityIds = new List<string> { "house_Ecaz", "house_Moritani", "bio_ElaccaWood" },
                    EnvironmentalData = "Dense forests providing rare hardwoods prized throughout the Landsraad.",
                    RulingHouse = "House Ecaz",
                    LocalCustoms = new List<string> { "Master woodcarving traditions", "Formal duels of honor to settle House disputes" }
                },
                new World
                {
                    Id = "loc_Arrakeen",
                    Name = "Arrakeen",
                    ShortDescription = "The administrative capital city of Arrakis.",
                    DetailedHistory = "Harkonnen governors built Arrakeen first. They set it against the natural windbreak of the Shield Wall so its architecture could shelter the ruling House from the planet's ferocious Coriolis storms. When House Atreides took the fief, Duke Leto inherited a capital soaked in Harkonnen extraction and neglect. He moved fast to govern it with a steadier, more humane hand, though only for a short time. The Harkonnen-Sardaukar assault soon took it back. The city changed hands once more when Paul Atreides' Fremen legions broke through the Shield Wall and stormed in. From Arrakeen's palace, Paul went on to rule not just Arrakis but the entire Known Universe as Emperor. Its later years fused Fremen custom with the trappings of Imperial court life, a physical record of how completely desert culture and galactic power had merged under Muad'Dib.",
                    ImagePath = "images/worlds/arrakeen.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "house_Atreides", "char_PaulAtreides", "char_DukeLetoAtreides" },
                    EnvironmentalData = "A shielded desert city built against the natural windbreak of the Shield Wall.",
                    RulingHouse = "House Atreides",
                    LocalCustoms = new List<string> { "Blending of Fremen and off-world Imperial customs", "Seat of the Ducal Residency" }
                },
                new World
                {
                    Id = "loc_Onn",
                    Name = "Onn",
                    ShortDescription = "A ceremonial city on Arrakis, site of grand Imperial spectacles.",
                    DetailedHistory = "Onn is not Arrakeen. Where Arrakeen governs, Onn performs. Vast plazas and processional avenues were built to hold crowds gathered for the pageantry of Muad'Dib's empire, at a scale no ordinary city could manage. Paul Atreides staged his massed convocations and state ceremonies here. These occasions were meant to cement religious authority alongside political rule, folding Imperial tradition together with the fervent devotion of the Church of Muad'Dib. The city's design gave shape to the uneasy marriage at the center of Paul's reign. His government needed both the machinery of Imperial administration and the theater of religious spectacle to hold an empire won by holy war together. Onn's grand ceremonies kept running under Paul's successors, a stage built for a religion that had long since outgrown the man who started it.",
                    ImagePath = "images/worlds/onn.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "char_PaulAtreides", "theo_ChurchOfMuadDib" },
                    EnvironmentalData = "A desert city engineered for mass public gatherings and processions.",
                    RulingHouse = "House Atreides",
                    LocalCustoms = new List<string> { "State ceremonies and religious convocations of the Church of Muad'Dib" }
                },
                new World
                {
                    Id = "loc_SietchTabr",
                    Name = "Sietch Tabr",
                    ShortDescription = "One of the largest Fremen sietch communities on Arrakis, led by Stilgar.",
                    DetailedHistory = "Sietch Tabr was carved deep into the rock of the Shield Wall and hidden from any casual eye. It ranked among the largest and most influential Fremen communities on Arrakis. Its concealed cavern reservoirs held water reclaimed one drop at a time across generations. Naib Stilgar led it, pragmatic and fiercely loyal. His sietch sheltered Paul and Jessica Atreides after their escape into the desert. That protection and training turned a hunted noble's son into the Fremen war leader Muad'Dib. Strict water discipline and communal governance under a Naib-led council defined the place. These were the same values that had carried the Fremen through Arrakis's harshest terrain for generations before any outsider set foot there. Sietch Tabr's fortunes climbed with Paul's own. It became a symbolic stronghold of Fremen resistance, and later of the loyalty that carried Paul's jihad out across the stars.",
                    ImagePath = "images/worlds/sietch_tabr.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "org_Fremen", "char_Stilgar", "char_PaulAtreides", "char_Chani" },
                    EnvironmentalData = "A concealed rock warren with cavern reservoirs for reclaimed water.",
                    RulingHouse = "Naib Stilgar (nominally under House Atreides)",
                    LocalCustoms = new List<string> { "Strict water discipline and communal cisterns", "Naib-led tribal council" }
                },

                // ---- God Emperor of Dune / Heretics of Dune / Chapterhouse: Dune ----
                new World
                {
                    Id = "loc_Rakis",
                    Name = "Rakis",
                    ShortDescription = "The desert-reverted name for Arrakis following the death of the God Emperor.",
                    DetailedHistory = "Leto II died at the Hidden Ford, and billions of dormant sandtrout flooded back into the wild. The elaborate ecological engineering that had held Arrakis's deserts in check for thirty-five hundred years soon began coming apart. Sand and worms and eventually spice returned to the world now renamed Rakis. Nothing about the change happened cleanly or fast. The Bene Gesserit took up quiet oversight of the reborn desert ecology. Along the way they managed a renewed worm-worship that grew up around Sheeana, a young woman able to command the returned sandworms outright. Rakis's rebirth as a desert world brought back the old balance of scarcity and struggle that had produced the Fremen generations earlier. The people living there now answered to very different political masters than their ancestors ever had. The planet's central place in galactic history closed for good when the Honored Matres destroyed it outright, cutting the last confirmed natural link between spice and its Arrakeen origins.",
                    ImagePath = "images/worlds/rakis.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "char_Sheeana", "bio_ShaiHulud", "event_DestructionOfRakis" },
                    EnvironmentalData = "A reverting desert world, its dunes and worm cycles restored after millennia of engineered greenery.",
                    RulingHouse = "Bene Gesserit stewardship",
                    LocalCustoms = new List<string> { "Renewed worm-worship centered on Sheeana", "Bene Gesserit oversight of the reborn desert ecology" }
                },
                new World
                {
                    Id = "loc_Gammu",
                    Name = "Gammu",
                    ShortDescription = "The renamed Giedi Prime, later used as a Bene Gesserit training and archival world.",
                    DetailedHistory = "House Harkonnen fell from power. Long afterward its grim industrial homeworld got a new name, Gammu, and a new owner. The Bene Gesserit turned it quietly into a training ground and archival vault. Its polluted skies and severe architecture suited the discipline the Sisterhood wanted to instill in trainees rather better than anyone might have guessed. Vast troves of historical records sat safeguarded here, some predating the Scattering itself. That handed the Bene Gesserit a store of knowledge few other factions in the Imperium could rival. A symbol of Harkonnen cruelty became an instrument of Bene Gesserit strategy. The shift said plenty about how willingly the Sisterhood repurposed the wreckage fallen Houses left behind for its own long game. Gammu's harsh legacy stayed etched into the landscape long after its new purpose had turned entirely away from the excesses that once defined it.",
                    ImagePath = "images/worlds/gammu.jpg",
                    RelatedEntityIds = new List<string> { "loc_GiediPrime", "house_Harkonnen", "org_BeneGesserit" },
                    EnvironmentalData = "Heavily industrialized terrain inherited from its Harkonnen past, gradually repurposed by its new stewards.",
                    RulingHouse = "Bene Gesserit",
                    LocalCustoms = new List<string> { "Bene Gesserit training cadres", "Archival preservation of pre-Scattering records" }
                },
                new World
                {
                    Id = "loc_Chapterhouse",
                    Name = "Chapterhouse",
                    ShortDescription = "The secret backup homeworld of the Bene Gesserit, later terraformed to host transplanted sandworms.",
                    DetailedHistory = "Chapterhouse stayed hidden for centuries as insurance against catastrophe. Its real purpose as the Bene Gesserit's secret backup homeworld snapped into urgent focus the moment the Honored Matres destroyed Rakis and wiped out its sandworm population. The Sisterhood now faced the loss of their only reliable link to the spice cycle. They gambled on something they had never tried before. They deliberately pushed sections of Chapterhouse into artificial desertification so transplanted sandworms could take hold and rebuild a source of melange from nothing. Darwi Odrade led the effort, and later the once-Honored-Matre Murbella carried it forward. Secrecy at this scale had rarely been attempted even by the Bene Gesserit, and failure meant the effective extinction of both the Sisterhood's power and independent spice production. Chapterhouse's fate hung between patient ecological engineering and outright existential risk, a fair measure of just how fragile the galaxy's oldest and most patient organization had grown by the end of the Scattering era.",
                    ImagePath = "images/worlds/chapterhouse.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "bio_ShaiHulud", "event_DestructionOfRakis", "char_DarwiOdrade", "char_Murbella" },
                    EnvironmentalData = "A temperate world undergoing deliberate, accelerated desertification to sustain transplanted sandworms.",
                    RulingHouse = "Bene Gesserit",
                    LocalCustoms = new List<string> { "Strict secrecy regarding the planet's true purpose", "Careful ecological engineering to cultivate a new spice cycle" }
                },

                // ---- Prelude to Dune (House trilogy) ----
                new World
                {
                    Id = "loc_Lankiveil",
                    Name = "Lankiveil",
                    ShortDescription = "A cold, ocean-covered world tied to House Harkonnen's origins, known for whale-fur trading.",
                    DetailedHistory = "Cold water covers most of Lankiveil, and its modest whale-fur trade stands nothing like the industrial excess later built on Giedi Prime. This was the ancestral holding Abulurd Harkonnen got exiled to, judged unfit to lead House Harkonnen by the rest of the family. Life there revolved around the local whale-fur trade rather than the ruthless extraction and cruelty that would come to define the Harkonnen name elsewhere. Abulurd's branch of the family settled into an unusually humble, unpretentious way of living. History turned that into a lasting irony. Abulurd's son, Vladimir, grew up to embody everything Lankiveil's quiet culture was not, and he chose Giedi Prime instead as the seat for his infamous rule. The planet stayed a minor holding the whole time. It is worth more for what it reveals about the contradictions in the Harkonnen bloodline than for any wealth or strategic value of its own.",
                    ImagePath = "images/worlds/lankiveil.jpg",
                    RelatedEntityIds = new List<string> { "char_AbulurdHarkonnen", "house_Harkonnen" },
                    EnvironmentalData = "Cold, ocean-dominated world with a modest whale-fur trading economy.",
                    RulingHouse = "House Harkonnen (minor holding)",
                    LocalCustoms = new List<string> { "Whale-fur harvesting traditions", "A modest, unpretentious way of life atypical of House Harkonnen's later reputation" }
                },
                new World
                {
                    Id = "loc_Richese",
                    Name = "Richese",
                    ShortDescription = "A Great House world renowned for miniaturized technology and clever devices.",
                    DetailedHistory = "Richese spent generations as a commercial and technological rival to Ix. It built its fortunes on intricate gadgets, probes, and precision mechanisms. The niche was profitable, too small-scale for the industrial giants of Ix to bother with and too clever for most other Houses to copy. Its inventive culture ran on constant competitive innovation and closely guarded trade secrets. Still it kept finding itself outmaneuvered, and occasionally rescued, by the shifting fortunes of House Vernius and the wider Landsraad. Richese's engineers pushed hard and often against the boundaries the Butlerian Jihad had set for permissible technology. They turned out devices that skirted the line separating clever machinery from forbidden thinking machines without quite crossing it. Political power on the scale of the true military Houses never came its way. Even so, Richese's technological ingenuity kept it a fixture of Imperial commerce for generations.",
                    ImagePath = "images/worlds/richese.jpg",
                    RelatedEntityIds = new List<string> { "house_Richese", "loc_Ix" },
                    EnvironmentalData = "A world whose economy centers on precision manufacturing and technological invention.",
                    RulingHouse = "House Richese",
                    LocalCustoms = new List<string> { "Competitive innovation culture", "Guarded trade secrets in gadgetry and probes" }
                }
            };
        }
    }
}
