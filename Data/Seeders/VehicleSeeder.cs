using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class VehicleSeeder
    {
        public static List<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle
                {
                    Id = "vehicle_Ornithopter",
                    Name = "Ornithopter",
                    ShortDescription = "An aircraft that achieves flight by flapping its wings like a bird.",
                    DetailedHistory = "The primary means of aerial transportation on Arrakis, prized for its maneuverability in violent air currents where fixed-wing or purely jet aircraft would fail. Every noble House on Arrakis maintains a fleet for both transport and combat escort.",
                    ImagePath = "images/vehicles/ornithopter.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "house_Atreides", "house_Harkonnen" },
                    OperatingEnvironment = "Atmospheric, especially turbulent desert air",
                    Capacity = "Typically 6-8 passengers; military variants configured for troops or weapons"
                },
                new Vehicle
                {
                    Id = "vehicle_SpiceHarvester",
                    Name = "Spice Harvester",
                    ShortDescription = "Massive industrial vehicles used to strip melange from the desert sands.",
                    DetailedHistory = "The backbone of Arrakis' economy, these lumbering machines scour rich spice blows for the precious mélange, constantly at risk of being destroyed by the sandworms their vibrations attract.",
                    ImagePath = "images/vehicles/harvester.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "org_Fremen", "bio_Melange", "bio_ShaiHulud" },
                    OperatingEnvironment = "Open desert sand",
                    Capacity = "Several hundred tons of spice-laden sand per shift"
                },
                new Vehicle
                {
                    Id = "vehicle_SpiceCrawler",
                    Name = "Spice Crawler",
                    ShortDescription = "A smaller, self-propelled harvesting unit used alongside larger harvesters.",
                    DetailedHistory = "Designed for efficiency on the dune seas, spice crawlers work in coordination with carryalls and spotter ornithopters to extract melange before a worm arrives.",
                    ImagePath = "images/vehicles/crawler.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "vehicle_SpiceHarvester" },
                    OperatingEnvironment = "Open desert sand",
                    Capacity = "Smaller crew and yield than a full harvester"
                },
                new Vehicle
                {
                    Id = "vehicle_Carryall",
                    Name = "Carryall",
                    ShortDescription = "A large suspensor-driven aircraft that lifts spice harvesters to safety.",
                    DetailedHistory = "Essential to spice operations, carryalls hover above active harvesters and airlift them off the sand the instant a sandworm's approach is detected, saving both crew and equipment.",
                    ImagePath = "images/vehicles/carryall.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "vehicle_SpiceHarvester", "bio_ShaiHulud" },
                    OperatingEnvironment = "Low-altitude atmospheric flight over desert",
                    Capacity = "Capable of lifting a fully-loaded spice harvester"
                },
                new Vehicle
                {
                    Id = "vehicle_Groundcar",
                    Name = "Groundcar",
                    ShortDescription = "A common suspensor-assisted surface vehicle used across the Imperium.",
                    DetailedHistory = "Used for short-range surface travel on worlds where atmospheric flight is unnecessary or restricted, groundcars are a staple of everyday Imperial transportation.",
                    ImagePath = "images/vehicles/groundcar.jpg",
                    RelatedEntityIds = new List<string> { "loc_Caladan", "loc_Kaitain" },
                    OperatingEnvironment = "Planetary surface roadways",
                    Capacity = "Typically 2-6 passengers"
                },
                new Vehicle
                {
                    Id = "vehicle_Heighliner",
                    Name = "Heighliner",
                    ShortDescription = "The colossal Spacing Guild vessels that ferry travelers and cargo between the stars.",
                    DetailedHistory = "Piloted by prescient Guild Navigators who fold space after consuming vast quantities of melange, Heighliners are so large they carry entire fleets of smaller ships, frigates, and cargo within their holds.",
                    ImagePath = "images/vehicles/heighliner.jpg",
                    RelatedEntityIds = new List<string> { "org_SpacingGuild", "disc_GuildNavigation", "bio_Melange" },
                    OperatingEnvironment = "Deep space, folded-space transit",
                    Capacity = "Entire fleets, cargo holds, and thousands of passengers per voyage"
                },
                new Vehicle
                {
                    Id = "vehicle_Frigate",
                    Name = "Frigate",
                    ShortDescription = "A military transport ship used to move troops and equipment between worlds.",
                    DetailedHistory = "Carried within Heighliner holds, frigates ferried the Emperor's Sardaukar and House armies to Arrakis during the invasion that toppled House Atreides.",
                    ImagePath = "images/vehicles/frigate.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "org_Sardaukar", "house_Harkonnen" },
                    OperatingEnvironment = "Space transit and atmospheric entry",
                    Capacity = "Several legions of troops and their equipment"
                },
                new Vehicle
                {
                    Id = "vehicle_Lighter",
                    Name = "Lighter",
                    ShortDescription = "A shuttle craft used to ferry cargo and passengers from orbiting ships to a planet's surface.",
                    DetailedHistory = "Since Heighliners never land, lighters handle the final leg of any journey, moving spice, goods, and dignitaries between orbit and the surface of Arrakis.",
                    ImagePath = "images/vehicles/lighter.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "org_SpacingGuild" },
                    OperatingEnvironment = "Orbit-to-surface transit",
                    Capacity = "Bulk cargo or moderate passenger loads"
                },
                new Vehicle
                {
                    Id = "vehicle_ImperialBarge",
                    Name = "Imperial Barge",
                    ShortDescription = "The Padishah Emperor's opulent personal landing craft.",
                    DetailedHistory = "Used to transport Shaddam IV to the surface of Arrakis for his final confrontation with Paul Atreides, the barge is as much a statement of Imperial grandeur as a mode of transport.",
                    ImagePath = "images/vehicles/imperial_barge.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "char_ShaddamIV", "loc_Arrakis" },
                    OperatingEnvironment = "Orbit-to-surface transit, ceremonial",
                    Capacity = "The Emperor's retinue and honor guard"
                },
                new Vehicle
                {
                    Id = "vehicle_TroopCarrier",
                    Name = "Sardaukar Troop Carrier",
                    ShortDescription = "A landing craft used to deploy Sardaukar shock troops during planetary assaults.",
                    DetailedHistory = "Launched from frigates in orbit, these carriers dropped Sardaukar legions onto Arrakis disguised as Harkonnen reinforcements during the surprise attack on House Atreides.",
                    ImagePath = "images/vehicles/troop_carrier.jpg",
                    RelatedEntityIds = new List<string> { "org_Sardaukar", "house_Corrino", "house_Harkonnen", "event_FallOfHouseAtreides" },
                    OperatingEnvironment = "Orbit-to-surface assault deployment",
                    Capacity = "A full company of Sardaukar troops"
                }
            };
        }
    }
}
