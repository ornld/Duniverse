using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class OrganizationSeeder
    {
        public static List<Organization> GetOrganizations()
        {
            return new List<Organization>
            {
                new Organization
                {
                    Id = "org_BeneGesserit",
                    Name = "Bene Gesserit",
                    ShortDescription = "An ancient sisterhood pursuing political, genetic, and spiritual control across the Imperium.",
                    DetailedHistory = "Through selective breeding, physical and mental conditioning, and the covert seeding of protective religions via the Missionaria Protectiva, the Bene Gesserit worked for millennia toward the creation of the Kwisatz Haderach.",
                    ImagePath = "images/organizations/bene_gesserit.jpg",
                    RelatedEntityIds = new List<string> { "loc_WallachIX", "disc_BeneGesseritTraining", "char_LadyJessica", "char_GaiusHelenMohiam", "theo_OtherMemoryPhilosophy", "theo_MahdiProphecy", "char_Taraza", "char_DarwiOdrade", "char_Murbella", "char_MilesTeg", "char_NormaCenva", "org_HonoredMatres", "loc_Chapterhouse", "char_RaquellaBertoAnirul", "event_ReverendMotherBreakthrough" },
                    Headquarters = "Wallach IX",
                    PrimaryDirective = "Guide humanity's genetic and religious development toward the Kwisatz Haderach"
                },
                new Organization
                {
                    Id = "org_Fremen",
                    Name = "Fremen",
                    ShortDescription = "The hardened desert people of Arrakis, masters of survival and holy warriors of Muad'Dib.",
                    DetailedHistory = "Descendants of the Zensunni Wanderers, the Fremen adapted to Arrakis' brutal environment and harbored a secret dream of terraforming their world, later becoming the military backbone of Paul Atreides' jihad.",
                    ImagePath = "images/organizations/fremen.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "loc_SietchTabr", "char_Stilgar", "char_Chani", "char_LietKynes", "theo_ZensunniWanderers", "theo_CultOfShaiHulud", "art_Crysknife" },
                    Headquarters = "Sietch communities across Arrakis",
                    PrimaryDirective = "Survive Arrakis and fulfill the dream of a green, water-rich planet"
                },
                new Organization
                {
                    Id = "org_SpacingGuild",
                    Name = "Spacing Guild",
                    ShortDescription = "The monopolistic order controlling all interstellar travel via prescient Navigators.",
                    DetailedHistory = "By consuming vast quantities of melange, Guild Navigators gain the limited prescience needed to safely fold space, giving the Guild an unbreakable monopoly over travel and, by extension, immense political leverage.",
                    ImagePath = "images/organizations/spacing_guild.jpg",
                    RelatedEntityIds = new List<string> { "disc_GuildNavigation", "vehicle_Heighliner", "bio_Melange", "char_Edric", "char_NormaCenva", "vehicle_NoShip" },
                    Headquarters = "Undisclosed; Guild Navigators travel in specialized tanks aboard Heighliners",
                    PrimaryDirective = "Maintain exclusive control over interstellar navigation and trade routes"
                },
                new Organization
                {
                    Id = "org_BeneTleilax",
                    Name = "Bene Tleilax",
                    ShortDescription = "A secretive society of genetic manipulators who produce gholas and Face Dancers.",
                    DetailedHistory = "Operating from their hidden homeworld, the Tleilaxu cultivate biological constructs in axlotl tanks, offering services - and schemes - that other powers find both indispensable and unsettling.",
                    ImagePath = "images/organizations/bene_tleilax.jpg",
                    RelatedEntityIds = new List<string> { "loc_Tleilax", "char_Scytale", "char_DuncanIdaho", "theo_TleilaxuFaith", "char_Waff", "disc_GholaCultivation", "event_IxianCoup" },
                    Headquarters = "Tleilax",
                    PrimaryDirective = "Advance Tleilaxu interests through genetic engineering and covert manipulation"
                },
                new Organization
                {
                    Id = "org_CHOAM",
                    Name = "CHOAM",
                    ShortDescription = "The Combine Honnete Ober Advancer Mercantiles, the Imperium's central trading conglomerate.",
                    DetailedHistory = "Controlling shares in every significant economic enterprise in the Imperium - most critically the spice trade - CHOAM directorships are among the most fiercely contested prizes in Landsraad politics.",
                    ImagePath = "images/organizations/choam.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "org_Landsraad", "bio_Melange", "loc_Arrakis" },
                    Headquarters = "Kaitain",
                    PrimaryDirective = "Control and profit from the economic engines of the Imperium, chiefly the spice trade"
                },
                new Organization
                {
                    Id = "org_Qizarate",
                    Name = "Qizarate",
                    ShortDescription = "The priesthood-bureaucracy that administers the Church of Muad'Dib.",
                    DetailedHistory = "Formed to institutionalize Paul Atreides' religion after his jihad, the Qizarate grew into a sprawling, often corrupt bureaucracy wielding as much power as any Great House.",
                    ImagePath = "images/organizations/qizarate.jpg",
                    RelatedEntityIds = new List<string> { "theo_ChurchOfMuadDib", "char_PaulAtreides", "char_Korba", "loc_Onn", "char_BronsoOfIx" },
                    Headquarters = "Arrakis",
                    PrimaryDirective = "Propagate and administer the state religion of Muad'Dib"
                },
                new Organization
                {
                    Id = "org_SukSchool",
                    Name = "Suk School",
                    ShortDescription = "The Imperium's foremost medical institution, whose graduates carry an inviolable conditioning against killing.",
                    DetailedHistory = "Suk-trained doctors, marked by a diamond tattoo on the forehead, are considered so trustworthy that even the most paranoid Houses grant them unquestioned access - a trust the Harkonnens shattered through Dr. Yueh.",
                    ImagePath = "images/organizations/suk_school.jpg",
                    RelatedEntityIds = new List<string> { "disc_SukMedical", "char_WellingtonYueh" },
                    Headquarters = "Undisclosed Imperial medical academies",
                    PrimaryDirective = "Train and condition physicians trusted throughout the Imperium"
                },
                new Organization
                {
                    Id = "org_Landsraad",
                    Name = "Landsraad",
                    ShortDescription = "The council of Great Houses that counterbalances the Emperor's authority.",
                    DetailedHistory = "Formed as part of the Great Convention that ended the conflicts following the Butlerian Jihad, the Landsraad gives the Great Houses a collective voice against Imperial and Guild power, however imperfectly enforced.",
                    ImagePath = "images/organizations/landsraad.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen", "house_Corrino", "org_CHOAM" },
                    Headquarters = "Kaitain (formal sessions); Houses govern independently otherwise",
                    PrimaryDirective = "Balance the collective interests of the Great Houses against the Imperial Throne"
                },
                new Organization
                {
                    Id = "org_Sardaukar",
                    Name = "Sardaukar",
                    ShortDescription = "The Emperor's fanatically loyal and brutally trained military legions.",
                    DetailedHistory = "Forged in the killing grounds of Salusa Secundus, Sardaukar troops were long considered unmatched in the Imperium - until Fremen fighters, hardened by Arrakis itself, proved otherwise.",
                    ImagePath = "images/organizations/sardaukar.jpg",
                    RelatedEntityIds = new List<string> { "loc_SalusaSecundus", "disc_SardaukarWarfare", "house_Corrino", "vehicle_TroopCarrier" },
                    Headquarters = "Salusa Secundus",
                    PrimaryDirective = "Serve as the Emperor's ultimate instrument of military force"
                },
                new Organization
                {
                    Id = "org_SwordmastersOfGinaz",
                    Name = "Swordmasters of Ginaz",
                    ShortDescription = "An academy producing the finest blade-combat instructors in the Imperium.",
                    DetailedHistory = "Graduates of the Ginaz school, such as Duncan Idaho, served as House combat instructors and bodyguards, prized for a discipline that balanced lethal skill with personal honor.",
                    ImagePath = "images/organizations/ginaz.jpg",
                    RelatedEntityIds = new List<string> { "disc_SwordmasterGinaz", "char_DuncanIdaho", "house_Atreides" },
                    Headquarters = "Ginaz",
                    PrimaryDirective = "Train swordmasters bound by a code of honor to serve the Great Houses"
                },
                new Organization
                {
                    Id = "org_HonoredMatres",
                    Name = "Honored Matres",
                    ShortDescription = "A militant matriarchal order returning from the Scattering to conquer the Old Imperium.",
                    DetailedHistory = "Forged somewhere beyond the Scattering by an unseen, greater threat, the Honored Matres wield sexual imprinting to enslave men absolutely, sweeping across known space in a campaign of conquest that puts them on a collision course with the Bene Gesserit.",
                    ImagePath = "images/organizations/honored_matres.jpg",
                    RelatedEntityIds = new List<string> { "char_Murbella", "char_DarwiOdrade", "disc_HonoredMatreImprinting", "org_BeneGesserit", "event_DestructionOfRakis", "bio_Futar" },
                    Headquarters = "Unknown (beyond the Scattering)",
                    PrimaryDirective = "Conquest and domination of the Old Imperium's remaining powers"
                },
                new Organization
                {
                    Id = "org_MuseumFremen",
                    Name = "Museum Fremen",
                    ShortDescription = "A ceremonial remnant of true Fremen culture preserved as a living exhibit under Leto II's reign.",
                    DetailedHistory = "As Leto II's Golden Path stripped Arrakis of its harsh deserts, the once-fierce Fremen were reduced to costumed performers reenacting their ancestors' ways for tourists, a deliberate and mournful policy meant to illustrate the cost of comfort without struggle.",
                    ImagePath = "images/organizations/museum_fremen.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "org_Fremen", "loc_Arrakis", "org_FishSpeakers" },
                    Headquarters = "Arrakis",
                    PrimaryDirective = "Preserve a performance of Fremen tradition after the desert's transformation"
                },
                new Organization
                {
                    Id = "org_FishSpeakers",
                    Name = "Fish Speakers",
                    ShortDescription = "Leto II's all-female military and administrative corps.",
                    DetailedHistory = "Devoted almost religiously to the God Emperor, the Fish Speakers served as Leto II's soldiers, bureaucrats, and enforcers throughout his millennia-long reign, embodying the loyalty and discipline his Golden Path demanded of the Imperium.",
                    ImagePath = "images/organizations/fish_speakers.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_MoneoAtreides", "org_MuseumFremen" },
                    Headquarters = "Arrakis",
                    PrimaryDirective = "Serve and enforce the will of the God Emperor"
                },
                new Organization
                {
                    Id = "org_LeagueOfNobles",
                    Name = "League of Nobles",
                    ShortDescription = "The coalition of human worlds that fought the thinking machines during the Butlerian Jihad.",
                    DetailedHistory = "United by Serena Butler's cause after the death of her son, the League of Nobles waged a decades-long war against Omnius and the Synchronized Worlds, a struggle whose heroes - and its harsh aftermath - would shape the Imperium for ten thousand years.",
                    ImagePath = "images/organizations/league_of_nobles.jpg",
                    RelatedEntityIds = new List<string> { "char_SerenaButler", "char_VorianAtreides", "char_XavierHarkonnen", "event_ButlerianJihad" },
                    Headquarters = "Salusa Secundus (early Jihad era)",
                    PrimaryDirective = "Defeat the thinking machines and free enslaved human worlds"
                },
                new Organization
                {
                    Id = "org_SynchronizedWorlds",
                    Name = "Synchronized Worlds",
                    ShortDescription = "The empire of planets ruled directly by the machine intelligence Omnius.",
                    DetailedHistory = "Linked by instantaneous computation and copies of the same evermind, the Synchronized Worlds represented the height of thinking-machine dominance before the Butlerian Jihad shattered their hold over humanity.",
                    ImagePath = "images/organizations/synchronized_worlds.jpg",
                    RelatedEntityIds = new List<string> { "char_Omnius", "char_Erasmus", "event_ButlerianJihad", "theo_ButlerianDoctrine" },
                    Headquarters = "Corrin",
                    PrimaryDirective = "Expand machine rule across human-settled space"
                },
                new Organization
                {
                    Id = "org_MentatSchool",
                    Name = "Mentat School",
                    ShortDescription = "The institution that trains human minds to replace the thinking machines destroyed in the Jihad.",
                    DetailedHistory = "Founded by Gilbertus Albans in the uneasy aftermath of the Butlerian Jihad, the Mentat School turned human intellect itself into a computational discipline, producing the analysts and advisors - like Thufir Hawat - who would serve the Great Houses for ten thousand years.",
                    ImagePath = "images/organizations/mentat_school.jpg",
                    RelatedEntityIds = new List<string> { "char_GilbertusAlbans", "disc_Mentat", "char_ThufirHawat", "event_ButlerianJihad" },
                    Headquarters = "Lampadas",
                    PrimaryDirective = "Train Mentats to serve as human computers for the Great Houses"
                }
            };
        }
    }
}
