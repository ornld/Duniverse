using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class TheologicalSystemSeeder
    {
        public static List<TheologicalSystem> GetTheologicalSystems()
        {
            return new List<TheologicalSystem>
            {
                new TheologicalSystem
                {
                    Id = "theo_OrangeCatholicBible",
                    Name = "Orange Catholic Bible",
                    ShortDescription = "The composite religious text uniting the surviving faiths of the Known Universe.",
                    DetailedHistory = "Compiled after the Butlerian Jihad by the Commission of Ecumenical Translators, the Orange Catholic Bible fuses elements of every major surviving faith into a single scripture, forming the religious bedrock of Imperial society.",
                    ImagePath = "images/theology/ocb.jpg",
                    RelatedEntityIds = new List<string> { "event_ButlerianJihad", "theo_ButlerianDoctrine" },
                    CoreTenets = "Reverence for a singular divine truth expressed through many inherited traditions; suspicion of machine-worship",
                    FoundationalTexts = new List<string> { "The Orange Catholic Bible", "The Azhar Book" }
                },
                new TheologicalSystem
                {
                    Id = "theo_ZensunniWanderers",
                    Name = "Zensunni Wanderers",
                    ShortDescription = "The ancestral faith of the Fremen, blending Zen and Sunni Islamic traditions.",
                    DetailedHistory = "Carried across generations of enslavement and migration, the Zensunni faith shaped Fremen values of discipline, endurance, and communal survival long before their arrival on Arrakis.",
                    ImagePath = "images/theology/zensunni.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "theo_CultOfShaiHulud" },
                    CoreTenets = "Endurance through hardship, communal discipline, and spiritual purification through struggle",
                    FoundationalTexts = new List<string> { "Commentaries of the Zensunni Wanderers" }
                },
                new TheologicalSystem
                {
                    Id = "theo_CultOfShaiHulud",
                    Name = "Cult of Shai-Hulud",
                    ShortDescription = "The Fremen veneration of the sandworm as a divine manifestation.",
                    DetailedHistory = "Central to Fremen religious life, the worship of Shai-Hulud ties directly into the Water of Life ritual, the transformation of Reverend Mothers, and the eventual recognition of Paul Atreides as the prophesied Lisan al-Gaib.",
                    ImagePath = "images/theology/shai_hulud.jpg",
                    RelatedEntityIds = new List<string> { "bio_ShaiHulud", "org_Fremen", "art_WaterOfLife", "theo_MahdiProphecy" },
                    CoreTenets = "The sandworm as the physical embodiment of the divine on Arrakis",
                    FoundationalTexts = new List<string> { "Oral Fremen liturgy passed through the sietches" }
                },
                new TheologicalSystem
                {
                    Id = "theo_MahdiProphecy",
                    Name = "Lisan al-Gaib Prophecy",
                    ShortDescription = "The messianic Mahdi prophecy planted among the Fremen by the Missionaria Protectiva.",
                    DetailedHistory = "Seeded generations earlier by the Bene Gesserit's Missionaria Protectiva as a survival contingency, the prophecy of an off-world messiah was ultimately fulfilled - and exploited - by Paul Atreides during his rise among the Fremen.",
                    ImagePath = "images/theology/mahdi.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "org_Fremen", "char_PaulAtreides" },
                    CoreTenets = "The coming of a Lisan al-Gaib who will lead the Fremen to paradise",
                    FoundationalTexts = new List<string> { "Panoplia Propheticus of the Missionaria Protectiva" }
                },
                new TheologicalSystem
                {
                    Id = "theo_ChurchOfMuadDib",
                    Name = "Church of Muad'Dib",
                    ShortDescription = "The state religion built around Paul Atreides following his jihad.",
                    DetailedHistory = "Institutionalized through the Qizarate after Paul's conquest of the Imperial throne, the Church of Muad'Dib spread his image and doctrine across the galaxy, often through the same jihad it claimed to sanctify.",
                    ImagePath = "images/theology/muaddib_church.jpg",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "org_Qizarate", "loc_Onn", "event_MuadDibJihad" },
                    CoreTenets = "Paul Atreides as messiah and emperor whose rule is divinely ordained",
                    FoundationalTexts = new List<string> { "The sermons and proclamations of Muad'Dib" }
                },
                new TheologicalSystem
                {
                    Id = "theo_OtherMemoryPhilosophy",
                    Name = "Litany Against Fear",
                    ShortDescription = "The Bene Gesserit philosophical and meditative framework for mastering fear and accessing ancestral memory.",
                    DetailedHistory = "Underpinning both the Sisterhood's mental discipline and the perilous Spice Agony, this philosophy treats fear as the great obstacle to clear thought, and ancestral memory as a resource to be carefully controlled rather than feared.",
                    ImagePath = "images/theology/litany.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "disc_BeneGesseritTraining", "char_LadyJessica" },
                    CoreTenets = "Fear is the mind-killer; mastery of self grants access to Other Memory",
                    FoundationalTexts = new List<string> { "The Litany Against Fear" }
                },
                new TheologicalSystem
                {
                    Id = "theo_ButlerianDoctrine",
                    Name = "Butlerian Doctrine",
                    ShortDescription = "The universal commandment against thinking machines, born of the Butlerian Jihad.",
                    DetailedHistory = "Enshrined after the Great Revolt against thinking machines, this doctrine forbids the creation of any machine in the likeness of a human mind, shaping every subsequent institution - Mentats, Guild Navigators, and the Bene Gesserit alike - built to replace the computers humanity destroyed.",
                    ImagePath = "images/theology/butlerian.jpg",
                    RelatedEntityIds = new List<string> { "event_ButlerianJihad", "disc_Mentat", "loc_Ix" },
                    CoreTenets = "Thou shalt not make a machine in the likeness of a human mind",
                    FoundationalTexts = new List<string> { "The Great Convention's prohibitions on computers" }
                },
                new TheologicalSystem
                {
                    Id = "theo_TleilaxuFaith",
                    Name = "Tleilaxu Faith",
                    ShortDescription = "The insular religious philosophy guiding the Bene Tleilax.",
                    DetailedHistory = "Rooted in a heterodox offshoot of Zensunni belief, Tleilaxu religious conviction frames their genetic manipulation and long-term schemes as a path toward eventual Tleilaxu ascendance, a purpose kept deliberately opaque to outsiders.",
                    ImagePath = "images/theology/tleilaxu_faith.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneTleilax", "loc_Tleilax", "char_Scytale" },
                    CoreTenets = "Secretive devotion combining genetic mastery with a belief in eventual Tleilaxu supremacy",
                    FoundationalTexts = new List<string> { "Undisclosed Tleilaxu religious texts" }
                },
                new TheologicalSystem
                {
                    Id = "theo_GoldenPath",
                    Name = "The Golden Path",
                    ShortDescription = "Leto II's millennia-long philosophy of enforced peace to save humanity from extinction.",
                    DetailedHistory = "Foreseeing humanity's stagnation and eventual annihilation, Leto II merged with sandtrout to become the God Emperor, ruling for thousands of years under a doctrine designed to scatter humanity beyond any single threat's reach.",
                    ImagePath = "images/theology/golden_path.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "event_GoldenPathBegins", "bio_Sandtrout" },
                    CoreTenets = "Enforced peace and stagnation now to guarantee humanity's long-term survival and dispersal",
                    FoundationalTexts = new List<string> { "The Stolen Journals of Leto II" }
                },
                new TheologicalSystem
                {
                    Id = "theo_FedaykinCreed",
                    Name = "Fedaykin Creed",
                    ShortDescription = "The death-commando devotion of Paul's Fremen shock troops.",
                    DetailedHistory = "Fedaykin warriors embraced death in Muad'Dib's service as a religious act guaranteeing paradise, a fatalistic devotion that made them among the most feared soldiers of the jihad.",
                    ImagePath = "images/theology/fedaykin.jpg",
                    RelatedEntityIds = new List<string> { "char_Stilgar", "char_Chani", "char_Otheym", "event_MuadDibJihad" },
                    CoreTenets = "Death in service to Muad'Dib is sacred and guarantees paradise",
                    FoundationalTexts = new List<string> { "Oral Fedaykin death-vows" }
                }
            };
        }
    }
}
