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
                    ShortDescription = "The desert planet Dune, sole source of the spice melange in the known universe.",
                    DetailedHistory = "Third planet of Canopus, Arrakis is a near-waterless world of endless dune seas patrolled by colossal sandworms. Its melange deposits make it the most valuable planet in the Imperium, fought over by House Atreides and House Harkonnen before being conquered outright by Paul Atreides and the Fremen.",
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
                    ShortDescription = "The lush ocean homeworld of House Atreides.",
                    DetailedHistory = "A temperate world of seas, mountains, and rice paddies that served as the ancestral seat of House Atreides for twenty-six generations before Duke Leto accepted the Emperor's fief on Arrakis.",
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
                    ShortDescription = "The bleak, industrial homeworld of House Harkonnen.",
                    DetailedHistory = "A world scarred by centuries of unrestrained industry, its skies choked with pollution. It is the seat of House Harkonnen's power and the site of the Baron's opulent, decaying keep.",
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
                    ShortDescription = "The opulent Imperial capital and seat of House Corrino.",
                    DetailedHistory = "For ten thousand years the throne world of the Padishah Emperors, Kaitain is a planet of manicured gardens and towering palaces, showcasing the wealth of the Golden Lion Throne.",
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
                    ShortDescription = "The brutal prison-world where the Sardaukar are forged.",
                    DetailedHistory = "Once the original Imperial capital, it was devastated and repurposed as a secret training ground where harsh conditions and a forced-labor prison population produce the Emperor's elite Sardaukar troops.",
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
                    ShortDescription = "A subterranean technological powerhouse that skirts the edicts of the Butlerian Jihad.",
                    DetailedHistory = "Hidden within artificial caverns, the Ixians manufacture advanced technology - from Heighliners to secret computers - while publicly denying anything that resembles a thinking machine.",
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
                    DetailedHistory = "Closed to outsiders, Tleilax is where the Tleilaxu culture gholas, Face Dancers, and other bio-engineered products in their axlotl tanks, guided by a religious philosophy few outsiders understand.",
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
                    DetailedHistory = "A quiet, unassuming planet that hides the true seat of Bene Gesserit power, where acolytes undergo the Sisterhood's rigorous mental and physical conditioning.",
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
                    ShortDescription = "A forested world famed for its woodcarvers and long-standing feud with House Moritani.",
                    DetailedHistory = "Renowned across the Imperium for the artistry of its woodcarvers, House Ecaz's fortunes were long entangled in a blood feud with House Moritani of Grumman, a conflict that spilled into the affairs of House Atreides.",
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
                    DetailedHistory = "Originally the Harkonnen seat of governance, Arrakeen became House Atreides' capital upon their arrival on Arrakis and later the throne city from which Paul Atreides ruled the Known Universe.",
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
                    DetailedHistory = "Distinct from Arrakeen, Onn is where Paul Atreides staged massed convocations and state ceremonies during his reign, its plazas built to hold crowds gathered to witness the pageantry of Muad'Dib's empire.",
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
                    DetailedHistory = "A hidden warren carved into the rock, Sietch Tabr sheltered Paul and Jessica after their escape into the desert and became a stronghold of Fremen resistance against the Harkonnens.",
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
                    DetailedHistory = "After Leto II's death released the sandtrout back into the wild, the planet's terraforming unraveled and the deserts - along with the sandworms and spice - returned, restoring the world once known as Arrakis to something closer to its ancient, harsher self, now renamed Rakis.",
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
                    DetailedHistory = "Long after House Harkonnen's fall, its industrial homeworld was renamed Gammu and repurposed by the Bene Gesserit as a base for training and for safeguarding troves of historical records, its grim Harkonnen architecture repurposed for the Sisterhood's own ends.",
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
                    DetailedHistory = "Kept hidden as insurance against catastrophe, Chapterhouse became essential after the destruction of Rakis, as the Sisterhood raced to establish a new spice cycle by introducing sandworms to its soil - a desperate gamble to preserve melange production and their own survival.",
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
                    DetailedHistory = "The ancestral world where Abulurd Harkonnen was exiled after being deemed unfit to lead, Lankiveil's harsh, whale-fur economy stood in stark contrast to the industrial excess his son Vladimir would later build on Giedi Prime.",
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
                    DetailedHistory = "Long a commercial and technological rival to Ix, Richese built its fortunes on intricate gadgets and probes, its inventive culture repeatedly outmaneuvered - and occasionally rescued - by the shifting fortunes of House Vernius and the wider Landsraad.",
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
