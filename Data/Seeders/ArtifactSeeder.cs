using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class ArtifactSeeder
    {
        public static List<Artifact> GetArtifacts()
        {
            return new List<Artifact>
            {
                new Artifact
                {
                    Id = "art_GomJabbar",
                    Name = "Gom Jabbar",
                    ShortDescription = "A lethal, poisoned needle used by the Bene Gesserit.",
                    DetailedHistory = "Known as the 'high-handed enemy', this needle is tipped with a metabolic poison. It is used during the pain-box test to assess human awareness and control over animal instincts.",
                    ImagePath = "images/artifacts/gom_jabbar.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_PaulAtreides", "char_GaiusHelenMohiam" },
                    PrimaryMaterial = "Metal needle, poison",
                    Functionality = "Lethal execution/Test of humanity"
                },
                new Artifact
                {
                    Id = "art_Crysknife",
                    Name = "Crysknife",
                    ShortDescription = "The sacred blade of the Fremen, fashioned from the tooth of a sandworm.",
                    DetailedHistory = "Formed from the tooth of Shai-Hulud, these knives are considered holy by the Fremen. Tradition dictates that once drawn, a crysknife must draw blood before being sheathed.",
                    ImagePath = "images/artifacts/crysknife.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "loc_Arrakis", "char_Stilgar" },
                    PrimaryMaterial = "Sandworm tooth",
                    Functionality = "Ritual combat weapon"
                },
                new Artifact
                {
                    Id = "art_Stillsuit",
                    Name = "Stillsuit",
                    ShortDescription = "A complex suit designed to recycle the wearer's bodily moisture.",
                    DetailedHistory = "Developed by Kynes and perfected by Fremen craftsmanship, these suits are essential for survival on the open sands of Arrakis, allowing a person to lose only a thimbleful of water per day.",
                    ImagePath = "images/artifacts/stillsuit.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "loc_Arrakis", "char_LietKynes" },
                    PrimaryMaterial = "Poly-weave fabric",
                    Functionality = "Water reclamation/Environmental protection"
                },
                new Artifact
                {
                    Id = "art_PainBox",
                    Name = "The Pain Box",
                    ShortDescription = "A small, black cube used by the Bene Gesserit for neural pain induction.",
                    DetailedHistory = "Used in conjunction with the Gom Jabbar, the box creates the illusion of intense burning to test a student's ability to remain calm and ignore pain.",
                    ImagePath = "images/artifacts/pain_box.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_GaiusHelenMohiam" },
                    PrimaryMaterial = "Unknown neural-active materials",
                    Functionality = "Neural pain induction"
                },
                new Artifact
                {
                    Id = "art_SignetRing",
                    Name = "Atreides Signet Ring",
                    ShortDescription = "The official ring denoting the Duke of House Atreides.",
                    DetailedHistory = "Carries the seal of the house. It is the symbol of authority passed from Leto to Paul, confirming the legitimacy of his rule.",
                    ImagePath = "images/artifacts/signet_ring.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "char_DukeLetoAtreides", "char_PaulAtreides" },
                    PrimaryMaterial = "Gold, House Crest seal",
                    Functionality = "Seal of authority/Identity"
                },
                new Artifact
                {
                    Id = "art_Thumper",
                    Name = "Thumper",
                    ShortDescription = "A device used to call sandworms.",
                    DetailedHistory = "A small mechanical stake that vibrates against the sand, creating a rhythmic sound that mimics the movement of sand-prey, drawing Shai-Hulud to the surface.",
                    ImagePath = "images/artifacts/thumper.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "loc_Arrakis" },
                    PrimaryMaterial = "Metal, mechanical striker",
                    Functionality = "Sandworm summoning"
                },
                new Artifact
                {
                    Id = "art_WaterOfLife",
                    Name = "Water of Life",
                    ShortDescription = "The poisonous liquid excreted by a drowning sandworm.",
                    DetailedHistory = "Only a Reverend Mother can transmute this lethal substance into a safe form, allowing her to gain access to Other Memory.",
                    ImagePath = "images/artifacts/water_of_life.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "org_Fremen", "char_LadyJessica" },
                    PrimaryMaterial = "Sandworm secretion",
                    Functionality = "Psychoactive catalyst/Rite of passage"
                },
                new Artifact
                {
                    Id = "art_Lasgun",
                    Name = "Lasgun",
                    ShortDescription = "A directed-energy weapon utilizing a high-energy laser.",
                    DetailedHistory = "Extremely lethal, but dangerous to use against personal shields, as the interaction between a laser and a shield creates a nuclear-level explosion.",
                    ImagePath = "images/artifacts/lasgun.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen" },
                    PrimaryMaterial = "Las-crystal, energy cell",
                    Functionality = "Ranged combat weapon"
                },
                new Artifact
                {
                    Id = "art_ShieldGenerator",
                    Name = "Personal Shield Generator",
                    ShortDescription = "A protective device creating a suspensor-field.",
                    DetailedHistory = "Deflects fast-moving projectiles, forcing combatants to use slow-motion knife fighting techniques to bypass the barrier.",
                    ImagePath = "images/artifacts/shield.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen", "char_NormaCenva" },
                    PrimaryMaterial = "Suspensor film",
                    Functionality = "Personal defense"
                },
                new Artifact
                {
                    Id = "art_Distrans",
                    Name = "Distrans",
                    ShortDescription = "A tool for recording and playback of messages.",
                    DetailedHistory = "Commonly used for non-electronic communication that can be easily concealed.",
                    ImagePath = "images/artifacts/distrans.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides" },
                    PrimaryMaterial = "Biological recording medium",
                    Functionality = "Data storage/Communication"
                },
                new Artifact
                {
                    Id = "art_HunterSeeker",
                    Name = "Hunter-Seeker",
                    ShortDescription = "A remote-controlled assassination drone.",
                    DetailedHistory = "A small, needle-thin device operated by a nearby controller, capable of tracking movement through a room to eliminate a target.",
                    ImagePath = "images/artifacts/hunter_seeker.jpg",
                    RelatedEntityIds = new List<string> { "house_Harkonnen", "char_PaulAtreides" },
                    PrimaryMaterial = "Metal",
                    Functionality = "Assassination"
                },
                new Artifact
                {
                    Id = "art_MentatChart",
                    Name = "Mentat Data Chart",
                    ShortDescription = "Portable diagnostic data pads.",
                    DetailedHistory = "Used by Mentats to record vast amounts of data for logical processing.",
                    ImagePath = "images/artifacts/chart.jpg",
                    RelatedEntityIds = new List<string> { "char_ThufirHawat", "char_PiterDeVries" },
                    PrimaryMaterial = "Synthetic substrate",
                    Functionality = "Data computation support"
                },
                new Artifact
                {
                    Id = "art_GoldenLionThrone",
                    Name = "Golden Lion Throne",
                    ShortDescription = "The throne of the Padishah Emperor.",
                    DetailedHistory = "The ultimate symbol of power in the Known Universe, located on Kaitain, representing the Corrino dynasty's rule.",
                    ImagePath = "images/artifacts/throne.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino" },
                    PrimaryMaterial = "Gold, precious gems",
                    Functionality = "Imperial seat of power"
                },
                new Artifact
                {
                    Id = "art_StoneBurner",
                    Name = "Stone Burner",
                    ShortDescription = "A tactical nuclear weapon disguised as a rock.",
                    DetailedHistory = "A weapon of mass destruction used to cause localized nuclear devastation and permanent blinding radiation.",
                    ImagePath = "images/artifacts/stone_burner.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino" },
                    PrimaryMaterial = "Nuclear fissile material",
                    Functionality = "Strategic destruction"
                },
                new Artifact
                {
                    Id = "art_SuspensorBelt",
                    Name = "Suspensor Belt",
                    ShortDescription = "A belt used to negate gravity.",
                    DetailedHistory = "Widely used by the Baron Harkonnen to reduce his immense body weight and move about freely.",
                    ImagePath = "images/artifacts/suspensor.jpg",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen" },
                    PrimaryMaterial = "Suspensor field generator",
                    Functionality = "Gravity negation"
                },
                new Artifact
                {
                    Id = "art_ResearchJournal",
                    Name = "Imperial Planetologist Journal",
                    ShortDescription = "Records by Liet Kynes regarding Arrakis ecology.",
                    DetailedHistory = "Contains the blueprint for the transformation of Arrakis into a lush, water-rich planet.",
                    ImagePath = "images/artifacts/journal.jpg",
                    RelatedEntityIds = new List<string> { "char_LietKynes", "loc_Arrakis" },
                    PrimaryMaterial = "Paper, data crystal",
                    Functionality = "Ecological planning"
                },
                new Artifact
                {
                    Id = "art_CoffinShield",
                    Name = "Death-Guard Shield",
                    ShortDescription = "Specialized protective field for high-value funerary goods.",
                    DetailedHistory = "Protects the remains of great leaders during transit, ensuring honor is maintained.",
                    ImagePath = "images/artifacts/coffin_shield.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Corrino" },
                    PrimaryMaterial = "Energy field",
                    Functionality = "Post-mortem preservation"
                }
            };
        }
    }
}