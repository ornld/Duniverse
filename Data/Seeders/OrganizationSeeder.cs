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
                    RelatedEntityIds = new List<string> { "loc_WallachIX", "disc_BeneGesseritTraining", "char_LadyJessica", "char_GaiusHelenMohiam", "theo_OtherMemoryPhilosophy", "theo_MahdiProphecy" },
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
                    RelatedEntityIds = new List<string> { "disc_GuildNavigation", "vehicle_Heighliner", "bio_Melange", "char_Edric" },
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
                    RelatedEntityIds = new List<string> { "loc_Tleilax", "char_Scytale", "char_DuncanIdaho", "theo_TleilaxuFaith" },
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
                    RelatedEntityIds = new List<string> { "theo_ChurchOfMuadDib", "char_PaulAtreides", "char_Korba", "loc_Onn" },
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
                }
            };
        }
    }
}
