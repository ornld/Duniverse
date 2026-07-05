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
                    ShortDescription = "The colossal, near-immortal sandworms of Arrakis, source of the spice cycle and objects of Fremen worship.",
                    DetailedHistory = "Reaching lengths of hundreds of meters, these territorial creatures are drawn by rhythmic vibration and are both the deadliest hazard on Arrakis and the sacred heart of Fremen religion, their pre-spice mass excretions forming melange itself.",
                    ImagePath = "images/biology/shai_hulud.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "org_Fremen", "bio_Melange", "bio_Sandtrout", "theo_CultOfShaiHulud", "art_Thumper", "art_Crysknife", "loc_Rakis", "loc_Chapterhouse" },
                    BiologicalClassification = "Giant subterranean annelid-like organism (fauna)",
                    DerivedProducts = "Pre-spice mass and melange; crysknife teeth"
                },
                new FloraFauna
                {
                    Id = "bio_Sandtrout",
                    Name = "Sandtrout",
                    ShortDescription = "The juvenile, water-hoarding form of the sandworm.",
                    DetailedHistory = "Sandtrout encapsulate all the free water on Arrakis to protect the sandworm's vulnerable larval stage, a biological fact central both to Arrakis' aridity and to Leto II's transformation into the God Emperor.",
                    ImagePath = "images/biology/sandtrout.jpg",
                    RelatedEntityIds = new List<string> { "bio_ShaiHulud", "loc_Arrakis", "char_LetoIIAtreides", "event_GoldenPathBegins" },
                    BiologicalClassification = "Larval stage of the sandworm (fauna)",
                    DerivedProducts = "Consumes and locks away planetary water; source of the God Emperor's transformed skin"
                },
                new FloraFauna
                {
                    Id = "bio_Sandplankton",
                    Name = "Sand Plankton",
                    ShortDescription = "Microscopic desert organisms that sandtrout feed upon early in the sandworm life cycle.",
                    DetailedHistory = "An essential but easily overlooked link in Arrakis' ecology, sand plankton sustain sandtrout populations before they mature, sustaining the entire spice-producing cycle.",
                    ImagePath = "images/biology/sandplankton.jpg",
                    RelatedEntityIds = new List<string> { "bio_Sandtrout", "loc_Arrakis" },
                    BiologicalClassification = "Microscopic desert organism (flora/fauna boundary)",
                    DerivedProducts = "Sustains sandtrout populations; indirect precursor to melange"
                },
                new FloraFauna
                {
                    Id = "bio_Melange",
                    Name = "Melange (Geriatric Spice)",
                    ShortDescription = "The 'geriatric spice' - a life-extending, consciousness-expanding substance found only on Arrakis.",
                    DetailedHistory = "Produced through the sandworm life cycle, melange extends human lifespan, heightens awareness, and grants limited prescience in sufficient doses - making it the single most valuable substance in the Imperium and the cause of endless conflict over Arrakis.",
                    ImagePath = "images/biology/melange.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "bio_ShaiHulud", "org_SpacingGuild", "org_BeneGesserit", "art_WaterOfLife", "disc_GuildNavigation" },
                    BiologicalClassification = "Bio-chemical compound derived from the sandworm life cycle",
                    DerivedProducts = "Life extension, expanded awareness, limited prescience; refined into spice beer and other products"
                },
                new FloraFauna
                {
                    Id = "bio_MuadDibMouse",
                    Name = "Muad'Dib (Kangaroo Mouse)",
                    ShortDescription = "The small desert mouse from which Paul Atreides took his Fremen name.",
                    DetailedHistory = "Revered by the Fremen as a creature perfectly adapted to survive on Arrakis, the desert mouse Muad'Dib lent its name to Paul Atreides upon his adoption into Fremen society, symbolizing adaptability and endurance.",
                    ImagePath = "images/biology/muaddib_mouse.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "char_PaulAtreides", "org_Fremen" },
                    BiologicalClassification = "Small desert-adapted rodent (fauna)",
                    DerivedProducts = "None; culturally significant as a namesake rather than a resource"
                },
                new FloraFauna
                {
                    Id = "bio_LazaTiger",
                    Name = "Laza Tiger",
                    ShortDescription = "Genetically modified predators trained to hunt and assassinate specific targets.",
                    DetailedHistory = "Bred and conditioned by House Corrino's remaining loyalists, Laza tigers were unleashed on the young Leto II and Ghanima Atreides in an assassination attempt during their childhood on Arrakis.",
                    ImagePath = "images/biology/laza_tiger.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_GhanimaAtreides", "house_Corrino" },
                    BiologicalClassification = "Genetically engineered predatory fauna",
                    DerivedProducts = "None; bred exclusively for assassination purposes"
                },
                new FloraFauna
                {
                    Id = "bio_PundiRice",
                    Name = "Pundi Rice",
                    ShortDescription = "A staple grain crop cultivated in the fertile lowlands of Caladan.",
                    DetailedHistory = "A dietary staple for the population of Caladan, pundi rice cultivation reflects the abundant, water-rich lifestyle of House Atreides' homeworld, a sharp contrast to the scarcity of Arrakis.",
                    ImagePath = "images/biology/pundi_rice.jpg",
                    RelatedEntityIds = new List<string> { "loc_Caladan", "house_Atreides" },
                    BiologicalClassification = "Cultivated cereal grain (flora)",
                    DerivedProducts = "Staple food crop for Caladan's population"
                },
                new FloraFauna
                {
                    Id = "bio_ElaccaWood",
                    Name = "Elacca Wood",
                    ShortDescription = "A dense wood from Ecaz whose smoke is a potent, addictive narcotic when burned.",
                    DetailedHistory = "Prized both for woodcarving and for the dangerously addictive smoke it releases when burned, elacca wood ties House Ecaz's artistry to a substance regulated carefully across the Imperium.",
                    ImagePath = "images/biology/elacca_wood.jpg",
                    RelatedEntityIds = new List<string> { "loc_Ecaz", "house_Ecaz" },
                    BiologicalClassification = "Hardwood tree (flora)",
                    DerivedProducts = "Carved goods; addictive narcotic smoke when burned"
                },
                new FloraFauna
                {
                    Id = "bio_DesertHawk",
                    Name = "Desert Hawk",
                    ShortDescription = "Carrion birds that circle the deep desert of Arrakis, often seen as an omen of death.",
                    DetailedHistory = "Scavengers perfectly suited to Arrakis' harsh skies, desert hawks are frequently spotted circling sites of death in the open sand, their presence unnerving newcomers unfamiliar with the planet's rhythms.",
                    ImagePath = "images/biology/desert_hawk.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis" },
                    BiologicalClassification = "Scavenging bird of prey (fauna)",
                    DerivedProducts = "None; purely an ecological scavenger"
                },
                new FloraFauna
                {
                    Id = "bio_ChusukWood",
                    Name = "Chusuk Tonewood",
                    ShortDescription = "The prized tonewood used to craft balisets and other stringed instruments.",
                    DetailedHistory = "Harvested on the musical world of Chusuk, this tonewood is favored by instrument-makers across the Imperium, including the crafters of the baliset favored by troubadour-warriors like Gurney Halleck.",
                    ImagePath = "images/biology/chusuk_wood.jpg",
                    RelatedEntityIds = new List<string> { "char_GurneyHalleck" },
                    BiologicalClassification = "Tonewood tree (flora)",
                    DerivedProducts = "Soundboards and bodies for balisets and other stringed instruments"
                }
            };
        }
    }
}
