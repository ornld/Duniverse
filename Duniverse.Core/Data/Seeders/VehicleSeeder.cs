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
                    ShortDescription = "An aircraft that flies the way a bird does, on flapping wings rather than fixed lift surfaces.",
                    DetailedHistory = "The ornithopter borrows its flight from birds and insects, not from the jets and fixed-wing craft of other worlds, and that borrowed motion is exactly what lets it hold steady in the vicious, shifting air currents over Arrakis. A conventional aircraft would be torn apart there. Every noble House with holdings on the planet keeps a sizable fleet of them, flying routine cargo runs and spice-field surveys one day and combat escort the next, especially once Harkonnen and Atreides forces started trading blows. Pilots prized the craft's tight maneuverability for more than dogfighting, though: spotting a sandworm's telltale sand-wave near a harvesting operation and radioing a warning could buy a crew the handful of seconds needed to get clear. Piloting one stopped being a specialist's trick and became something close to a survival requirement, noble and commoner alike, for anyone who meant to last on Arrakis.",
                    ImagePath = "images/vehicles/ornithopter.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "house_Atreides", "house_Harkonnen" },
                    OperatingEnvironment = "Atmospheric, especially turbulent desert air",
                    Capacity = "Typically 6-8 passengers; military variants configured for troops or weapons"
                },
                new Vehicle
                {
                    Id = "vehicle_SpiceHarvester",
                    Name = "Spice Harvester",
                    ShortDescription = "A hulking, slow-crawling machine built to strip melange straight out of the desert sand.",
                    DetailedHistory = "Spice harvesters keep Arrakis solvent. These lumbering machines work rich spice blows out on the open dunes, their vibrating scoops chewing raw melange out of the sand in one long, continuous pull. That same vibration doubles as a death knell: it is the exact signal that summons a sandworm, so every harvest run turns into a race between how much spice a crew can pull and how fast they can get out. Spotter aircraft and carryall transports do the watching and the lifting, hauling the machine clear the moment a worm turns toward the surface; when that coordination breaks down, a House loses the harvester and, often, the crew inside it. The risk never went away, and neither did the calculus behind it: a House's fleet of working harvesters said more about its real grip on Arrakis than any title or writ ever could.",
                    ImagePath = "images/vehicles/harvester.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "org_Fremen", "bio_Melange", "bio_ShaiHulud" },
                    OperatingEnvironment = "Open desert sand",
                    Capacity = "Several hundred tons of spice-laden sand per shift"
                },
                new Vehicle
                {
                    Id = "vehicle_SpiceCrawler",
                    Name = "Spice Crawler",
                    ShortDescription = "A compact, self-propelled harvesting rig that works the dunes alongside the big machines.",
                    DetailedHistory = "Spice crawlers trade scale for agility. Smaller and quicker to reposition than a full harvester, a crawler can profitably work a marginal spice blow that would waste a bigger machine's time. It still runs the same dangerous playbook as its larger cousin, leaning on spotter ornithopters and carryall lifts to snatch melange out of the sand before a worm forces everyone out. Its smaller crew and lighter yield come with a real upside: crawlers can chase a freshly spotted deposit faster than the industrial rigs ever could. Smugglers and independent operators running spice outside Harkonnen or Atreides channels favored crawlers for exactly this reason. A small crawler working a remote blow drew far less attention than a full harvester crew ever would.",
                    ImagePath = "images/vehicles/crawler.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "vehicle_SpiceHarvester" },
                    OperatingEnvironment = "Open desert sand",
                    Capacity = "Smaller crew and yield than a full harvester"
                },
                new Vehicle
                {
                    Id = "vehicle_Carryall",
                    Name = "Carryall",
                    ShortDescription = "A heavy suspensor-lifted aircraft that snatches spice harvesters off the sand before a worm arrives.",
                    DetailedHistory = "Held aloft by banks of suspensor-field generators, the carryall hangs above an active harvester ready to hoist the entire machine clear of the sand the moment a worm's approach is confirmed. Lifting a fully loaded harvester, crew included, in a matter of seconds is what turns spice mining from a near-certain death sentence into a calculated industrial gamble. The margin for error is thin: a carryall pilot and the ground crew below have to move in near-perfect sync, and a few seconds of hesitation can cost a whole harvester and everyone riding it. Rivals knew this too well. Pulling carryall support at the wrong moment, whether through outright sabotage or a convenient lapse in judgment, became a quiet and much-feared way to wreck a competitor's spice operation without ever firing a shot.",
                    ImagePath = "images/vehicles/carryall.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "vehicle_SpiceHarvester", "bio_ShaiHulud" },
                    OperatingEnvironment = "Low-altitude atmospheric flight over desert",
                    Capacity = "Capable of lifting a fully-loaded spice harvester"
                },
                new Vehicle
                {
                    Id = "vehicle_Groundcar",
                    Name = "Groundcar",
                    ShortDescription = "A suspensor-cushioned surface vehicle, common on nearly every Imperial world.",
                    DetailedHistory = "The groundcar rides a cushion thrown up by onboard suspensor units instead of wheels, gliding over the ground wherever atmospheric flight would be overkill, off limits, or just impractical for a short errand. Settled worlds from the mild lowlands of Caladan to the polished boulevards of Kaitain are full of them, and their sheer ubiquity is precisely why nobody looks twice: this is Imperial technology so ordinary it has become invisible. Build quality swings wildly depending on world and status, stretching from bare-bones haulers for laborers to gilded models built for nobles and high officials. The Imperium has faster, grander ways to move people and cargo across the stars, but for the millions of short trips that fill an ordinary day, the groundcar stayed the default choice.",
                    ImagePath = "images/vehicles/groundcar.jpg",
                    RelatedEntityIds = new List<string> { "loc_Caladan", "loc_Kaitain" },
                    OperatingEnvironment = "Planetary surface roadways",
                    Capacity = "Typically 2-6 passengers"
                },
                new Vehicle
                {
                    Id = "vehicle_Heighliner",
                    Name = "Heighliner",
                    ShortDescription = "The colossal Spacing Guild vessels that carry travelers and cargo between star systems.",
                    DetailedHistory = "Guild Navigators, awash in melange and gifted with the prescience it grants, fold space and steer these ships across distances no conventional engine could cross. A single Heighliner is large enough to swallow entire fleets of smaller vessels, frigates, cargo holds, and thousands of passengers, all in one voyage. Moving people, goods, or armies between star systems means booking passage on one, full stop, and that dependency hands the Spacing Guild leverage over every House, Emperor, and organization with cargo to move. The ships themselves touch no planet's surface; lighters and shuttles handle the last leg, ferrying passengers and freight down from orbit. Guild Navigation has refined this system since the years following the Butlerian Jihad, and it now sits so deep in the bones of Imperial civilization that cutting a House or world off from Heighliner access amounts to sealing it away from the rest of known space.",
                    ImagePath = "images/vehicles/heighliner.jpg",
                    RelatedEntityIds = new List<string> { "org_SpacingGuild", "disc_GuildNavigation", "bio_Melange", "char_NormaCenva" },
                    OperatingEnvironment = "Deep space, folded-space transit",
                    Capacity = "Entire fleets, cargo holds, and thousands of passengers per voyage"
                },
                new Vehicle
                {
                    Id = "vehicle_Frigate",
                    Name = "Frigate",
                    ShortDescription = "A military transport ship built to move troops and war material between worlds.",
                    DetailedHistory = "Frigates ride within a Heighliner's holds for the interstellar stretch of any deployment, then handle the actual work of moving troops, war material, and equipment once a military force reaches its target system. Capacity and armor matter more to their design than speed or independent range ever could; the Guild's Heighliners already cover the long haul between stars. Frigates loaded with Sardaukar legions dressed as ordinary Harkonnen reinforcements carried out one of the more consequential deceptions in recent Imperial history, their true cargo hidden until the attack on House Atreides was already underway. Sharp-eyed observers learned to watch for one telltale sign of coming trouble: an unusually large frigate booking through the Spacing Guild, often the only early hint that a major strike was being staged somewhere in the Imperium.",
                    ImagePath = "images/vehicles/frigate.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "org_Sardaukar", "house_Harkonnen" },
                    OperatingEnvironment = "Space transit and atmospheric entry",
                    Capacity = "Several legions of troops and their equipment"
                },
                new Vehicle
                {
                    Id = "vehicle_Lighter",
                    Name = "Lighter",
                    ShortDescription = "A shuttle craft that ferries cargo and passengers between orbiting ships and a planet's surface.",
                    DetailedHistory = "Heighliners never touch a planet's atmosphere, so lighters carry the last, crucial leg of nearly every interstellar journey, moving cargo, spice, and dignitaries between an orbiting ship and the ground. On Arrakis, where spice production lives or dies on fast, high-volume transport off-world, the steady traffic of lighters climbing to meet Heighliners in orbit forms one of the basic rhythms of Imperial commerce. Their size, modest next to a Heighliner or frigate, makes them handy for almost anything: bulk cargo hauls one run, the ceremonial arrival of a noble delegation the next. The Spacing Guild oversees lighter traffic and scheduling with a quiet hand, and that oversight gave the Guild one more lever, subtle but real, over how goods and people moved through the Imperium.",
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
                    DetailedHistory = "House Corrino built this thing to announce itself as much as to carry anyone anywhere, and it did exactly that when it brought Emperor Shaddam IV and his full ceremonial retinue down to Arrakis for what turned into his final, humiliating meeting with Paul Atreides. Every line of the barge's construction, every ornamental flourish, existed to remind onlookers of the Golden Lion Throne's wealth and reach, a declaration of power meant to land before the Emperor spoke a single word. Ringed by Sardaukar honor guards and watched by the assembled Great Houses, its touchdown on Arrakis was staged to project unshakeable Corrino dominance at the precise moment that dominance was already crumbling. All that opulence had worked as political theater for generations. It could not, in the end, hide the plain fact of Shaddam's defeat once Paul's Fremen legions had already broken his army on the ground below.",
                    ImagePath = "images/vehicles/imperial_barge.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "char_ShaddamIV", "loc_Arrakis" },
                    OperatingEnvironment = "Orbit-to-surface transit, ceremonial",
                    Capacity = "The Emperor's retinue and honor guard"
                },
                new Vehicle
                {
                    Id = "vehicle_TroopCarrier",
                    Name = "Sardaukar Troop Carrier",
                    ShortDescription = "A landing craft built to drop Sardaukar shock troops into a planetary assault.",
                    DetailedHistory = "Launched straight out of frigates holding orbit, Sardaukar troop carriers exist for one purpose: put a full company of the Emperor's elite soldiers on the ground fast, with as little warning as possible. The Arrakis invasion turned this into something far uglier, since the Sardaukar legions rode down in Harkonnen livery, a disguise that let Shaddam IV break the Great Convention's ban on turning Imperial troops against a Great House and still keep his hands clean on paper. Overwhelming force paired with that calculated lie let the combined Harkonnen-Sardaukar assault crush House Atreides' defenses faster than any honestly declared war could have managed. Investigators looking back at the invasion pointed to the troop carriers themselves as some of the clearest proof that the Emperor had been in on House Atreides' destruction from the start.",
                    ImagePath = "images/vehicles/troop_carrier.jpg",
                    RelatedEntityIds = new List<string> { "org_Sardaukar", "house_Corrino", "house_Harkonnen", "event_FallOfHouseAtreides" },
                    OperatingEnvironment = "Orbit-to-surface assault deployment",
                    Capacity = "A full company of Sardaukar troops"
                },
                new Vehicle
                {
                    Id = "vehicle_NoShip",
                    Name = "No-Ship",
                    ShortDescription = "A vessel wrapped in no-field technology, invisible to prescient sight itself.",
                    DetailedHistory = "Ixian engineers built the first no-ships; the Bene Gesserit later took the design and pushed it further. The no-field at the heart of the technology blinds every known form of detection, prescient sight included, the same sight Guild Navigators and figures like Paul Atreides use to read the future. That immunity to prescient detection turned no-ships into something close to irreplaceable during the long, dangerous stretch after the Scattering, when the Sisterhood needed to move people, gholas, and sensitive cargo past rivals who could otherwise read the currents of fate. Their existence punched real blind spots into a galaxy of power structures built on prescience, a rare pocket of genuine privacy in a universe where so many major players could glimpse pieces of what was coming. No-ships carried the Bene Gesserit through their long struggle against the Honored Matres, moving key personnel and irreplaceable genetic material where no far-seeing enemy could follow.",
                    ImagePath = "images/vehicles/no_ship.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "loc_Ix", "org_HonoredMatres", "org_SpacingGuild" },
                    OperatingEnvironment = "Deep space, undetectable by prescience or conventional sensors",
                    Capacity = "Varies; used for covert transport of key Bene Gesserit personnel and ghola cargo"
                },
                new Vehicle
                {
                    Id = "vehicle_CymekWalker",
                    Name = "Cymek Walker",
                    ShortDescription = "A mechanical combat body piloted by a preserved human brain.",
                    DetailedHistory = "Cymek walkers served as the war machines of the Titans, giving figures like Agamemnon a way to graft their preserved brains, kept alive and alert long after their original bodies had died or been discarded, onto mechanical combat frames that dwarfed ordinary human strength and endurance. That grim pairing of human consciousness and machine power handed the Titans near-total control during their early conquest of the Old Empire; conventional resistance simply could not stand against walkers built on that scale. Their reign did not last, measured against the sweep of history. The machine intelligence Omnius and its networked thinking machines soon outgrew even the Titans' cymek-driven might, and the cyborg tyrants who had ruled unchallenged found themselves subordinated in turn. The cymek walker remained one of the starkest warnings behind the Butlerian Jihad, proof of how far the fusion of human ambition and machine power could run before humanity rose up against both.",
                    ImagePath = "images/vehicles/cymek_walker.jpg",
                    RelatedEntityIds = new List<string> { "char_AgamemnonTitan", "org_SynchronizedWorlds", "event_ButlerianJihad" },
                    OperatingEnvironment = "Ground combat, adaptable to hostile and vacuum environments",
                    Capacity = "Single pilot (a preserved human brain integrated into the mechanical frame)"
                }
            };
        }
    }
}
