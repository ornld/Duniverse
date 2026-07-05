using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class PersonaSeeder
    {
        public static List<Persona> GetPersonas()
        {
            return new List<Persona>
            {
                /* -- COPY THIS BLOCK FOR EACH NEW PERSONA --
                new Persona
                {
                    Id = "char_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    Affiliation = "",
                    Role = "",
                    NotableQuotes = new List<string>()
                },
                */
                new Persona
                {
                    Id = "char_PaulAtreides",
                    Name = "Paul Atreides",
                    ShortDescription = "The prophesied Kwisatz Haderach and Emperor of the Known Universe.",
                    DetailedHistory = "Son of Duke Leto and Lady Jessica. He fled into the deep desert after the fall of House Atreides, united the Fremen under the name Muad'Dib, and overthrew the Padishah Emperor, sparking a universe-wide jihad.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LadyJessica", "char_DukeLetoAtreides", "char_Chani", "char_Stilgar", "char_GurneyHalleck", "char_ThufirHawat", "char_DuncanIdaho", "char_AliaAtreides", "char_PrincessIrulan", "char_FeydRautha" },
                    Affiliation = "House Atreides",
                    Role = "Emperor",
                    NotableQuotes = new List<string> { "Fear is the mind-killer. Fear is the little-death that brings total obliteration." }
                },
                new Persona
                {
                    Id = "char_LadyJessica",
                    Name = "Lady Jessica",
                    ShortDescription = "Bene Gesserit sister, concubine to Duke Leto, and mother to Paul and Alia.",
                    DetailedHistory = "Trained by the Bene Gesserit, she defied their breeding program by bearing a son instead of a daughter. She later became a Reverend Mother of the Fremen and played a critical role in her son's rise to power.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_DukeLetoAtreides", "char_AliaAtreides", "char_GaiusHelenMohiam", "char_FaradnCorrino" },
                    Affiliation = "Bene Gesserit",
                    Role = "Reverend Mother",
                    NotableQuotes = new List<string> { "I must not fear." }
                },
                new Persona
                {
                    Id = "char_DukeLetoAtreides",
                    Name = "Duke Leto Atreides",
                    ShortDescription = "The honorable head of House Atreides.",
                    DetailedHistory = "Known as 'Leto the Just', he accepted the Emperor's mandate to rule Arrakis, knowing it was a trap. He was betrayed by his Suk doctor and died attempting to assassinate Baron Harkonnen.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LadyJessica", "char_PaulAtreides", "char_ThufirHawat", "char_GurneyHalleck", "char_DuncanIdaho", "char_WellingtonYueh" },
                    Affiliation = "House Atreides",
                    Role = "Duke",
                    NotableQuotes = new List<string> { "A person needs new experiences. They jar something deep inside, allowing him to grow." }
                },
                new Persona
                {
                    Id = "char_BaronHarkonnen",
                    Name = "Vladimir Harkonnen",
                    ShortDescription = "The ruthless and cunning head of House Harkonnen.",
                    DetailedHistory = "He orchestrated the downfall of House Atreides with the secret backing of the Emperor's Sardaukar. He was eventually killed by his granddaughter, Alia Atreides, during the Battle of Arrakeen.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_FeydRautha", "char_GlossuRabban", "char_PiterDeVries", "char_ShaddamIV", "char_AliaAtreides" },
                    Affiliation = "House Harkonnen",
                    Role = "Baron",
                    NotableQuotes = new List<string> { "Observe the plans within plans within plans." }
                },
                new Persona
                {
                    Id = "char_Chani",
                    Name = "Chani",
                    ShortDescription = "Fremen warrior and Paul Atreides's concubine.",
                    DetailedHistory = "Daughter of Liet-Kynes. She guided Paul in the ways of the Fremen, became his deeply devoted partner, and died giving birth to the twins Leto II and Ghanima.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_LietKynes", "char_LetoIIAtreides", "char_GhanimaAtreides", "char_Stilgar" },
                    Affiliation = "Fremen",
                    Role = "Fedaykin",
                    NotableQuotes = new List<string> { "Tell me of your homeworld, Usul." }
                },
                new Persona
                {
                    Id = "char_Stilgar",
                    Name = "Stilgar",
                    ShortDescription = "Naib of Sietch Tabr and a fiercely loyal Fremen leader.",
                    DetailedHistory = "He took Paul and Jessica in after their escape. He became one of Paul's most trusted generals during the jihad and later served as a guardian to Paul's children.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_Chani", "char_Otheym", "char_Korba", "char_GaiusHelenMohiam", "char_Edric" },
                    Affiliation = "Fremen",
                    Role = "Naib",
                    NotableQuotes = new List<string> { "Siridar, I am a simple man. I know only the desert." }
                },
                new Persona
                {
                    Id = "char_DuncanIdaho",
                    Name = "Duncan Idaho",
                    ShortDescription = "Swordmaster of the Ginaz and fiercely loyal retainer to House Atreides.",
                    DetailedHistory = "He died defending Paul and Jessica from Sardaukar on Arrakis. His body was recovered by the Tleilaxu and resurrected as the ghola 'Hayt', eventually regaining his original memories.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_PaulAtreides", "char_LadyJessica", "char_Scytale" },
                    Affiliation = "House Atreides",
                    Role = "Swordmaster",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_GurneyHalleck",
                    Name = "Gurney Halleck",
                    ShortDescription = "Warmaster for House Atreides and skilled troubadour.",
                    DetailedHistory = "A scarred veteran who trained Paul in combat. After the fall of Arrakis, he fell in with smugglers before reuniting with Paul and serving in his empire.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_PaulAtreides", "char_ThufirHawat" },
                    Affiliation = "House Atreides",
                    Role = "Warmaster",
                    NotableQuotes = new List<string> { "Mood's a thing for cattle or making love or playing the baliset. It's not for fighting." }
                },
                new Persona
                {
                    Id = "char_ThufirHawat",
                    Name = "Thufir Hawat",
                    ShortDescription = "Mentat and Master of Assassins for House Atreides.",
                    DetailedHistory = "Served three generations of Atreides dukes. Captured by the Harkonnens, he was tricked into serving them while secretly plotting their downfall, ultimately choosing death over harming Paul.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_PaulAtreides", "char_PiterDeVries", "char_BaronHarkonnen" },
                    Affiliation = "House Atreides",
                    Role = "Mentat",
                    NotableQuotes = new List<string> { "A popular man arouses the jealousy of the powerful." }
                },
                new Persona
                {
                    Id = "char_WellingtonYueh",
                    Name = "Dr. Wellington Yueh",
                    ShortDescription = "Suk doctor who betrayed House Atreides.",
                    DetailedHistory = "His Imperial Conditioning was broken by the Baron Harkonnen, who held his wife hostage. He betrayed Leto to save her but provided Leto with a poisoned tooth to strike back.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_BaronHarkonnen", "char_PiterDeVries" },
                    Affiliation = "Suk School",
                    Role = "Physician",
                    NotableQuotes = new List<string> { "I am sorry, my Duke. But there is a thing I must do." }
                },
                new Persona
                {
                    Id = "char_AliaAtreides",
                    Name = "Alia Atreides",
                    ShortDescription = "Sister to Paul, known as St. Alia of the Knife, born a pre-born Abomination.",
                    DetailedHistory = "Exposed to the Water of Life in the womb, she possessed ancestral memories at birth. She killed the Baron, later ruled as Regent, and was eventually possessed by his ego-memory.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_LadyJessica", "char_BaronHarkonnen", "char_LetoIIAtreides", "char_GhanimaAtreides" },
                    Affiliation = "House Atreides",
                    Role = "Regent",
                    NotableQuotes = new List<string> { "I am a messenger from Muad'Dib." }
                },
                new Persona
                {
                    Id = "char_ShaddamIV",
                    Name = "Shaddam IV",
                    ShortDescription = "The 81st Padishah Emperor of House Corrino.",
                    DetailedHistory = "Fearing the rising popularity of Duke Leto, he allied with House Harkonnen to destroy the Atreides. He was deposed by Paul and exiled to Salusa Secundus.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PrincessIrulan", "char_BaronHarkonnen", "char_PaulAtreides", "char_FaradnCorrino" },
                    Affiliation = "House Corrino",
                    Role = "Padishah Emperor",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_PrincessIrulan",
                    Name = "Princess Irulan",
                    ShortDescription = "Eldest daughter of Shaddam IV, chronicler of the Atreides Empire.",
                    DetailedHistory = "She became Paul's wife in name only to secure his claim to the throne. Though she conspired against him in Messiah, she ultimately became fiercely loyal to his children.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_PaulAtreides", "char_GaiusHelenMohiam" },
                    Affiliation = "House Corrino",
                    Role = "Princess / Historian",
                    NotableQuotes = new List<string> { "A beginning is the time for taking the most delicate care that the balances are correct." }
                },
                new Persona
                {
                    Id = "char_GaiusHelenMohiam",
                    Name = "Gaius Helen Mohiam",
                    ShortDescription = "Bene Gesserit Reverend Mother and Imperial Truthsayer.",
                    DetailedHistory = "Tested young Paul with the gom jabbar. She constantly maneuvered to preserve the Bene Gesserit breeding program and was executed by Stilgar during the events of Dune Messiah.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LadyJessica", "char_PaulAtreides", "char_Stilgar", "char_PrincessIrulan" },
                    Affiliation = "Bene Gesserit",
                    Role = "Truthsayer",
                    NotableQuotes = new List<string> { "You've proven you're human. Now we must see if you are more than human." }
                },
                new Persona
                {
                    Id = "char_FeydRautha",
                    Name = "Feyd-Rautha Harkonnen",
                    ShortDescription = "The cunning nephew and intended heir of the Baron.",
                    DetailedHistory = "Groomed to take over Arrakis as a savior after his brother Rabban's brutal rule. He was killed by Paul Atreides in a duel for the Imperial throne.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen", "char_GlossuRabban", "char_PaulAtreides" },
                    Affiliation = "House Harkonnen",
                    Role = "Na-Baron",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_GlossuRabban",
                    Name = "Glossu Rabban",
                    ShortDescription = "Known as 'Beast Rabban', the tyrannical nephew of the Baron.",
                    DetailedHistory = "Placed in charge of Arrakis to squeeze the population for spice and instil hatred, making way for Feyd-Rautha to arrive later as a hero. He was killed by the Fremen.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen", "char_FeydRautha" },
                    Affiliation = "House Harkonnen",
                    Role = "Count",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_PiterDeVries",
                    Name = "Piter De Vries",
                    ShortDescription = "A twisted Mentat serving House Harkonnen.",
                    DetailedHistory = "Engineered the plan to break Dr. Yueh's Imperial Conditioning. He was killed by the poison gas Duke Leto exhaled from his false tooth.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen", "char_WellingtonYueh", "char_DukeLetoAtreides", "char_ThufirHawat" },
                    Affiliation = "House Harkonnen",
                    Role = "Twisted Mentat",
                    NotableQuotes = new List<string> { "It is by will alone I set my mind in motion." }
                },
                new Persona
                {
                    Id = "char_LietKynes",
                    Name = "Liet-Kynes",
                    ShortDescription = "Imperial Planetologist and secret leader of the Fremen.",
                    DetailedHistory = "Father of Chani. He shared the Fremen dream of terraforming Arrakis. He allied with Duke Leto but was abandoned by the Harkonnens to die in a spice blow.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Chani", "char_DukeLetoAtreides", "char_PaulAtreides" },
                    Affiliation = "Imperial Court / Fremen",
                    Role = "Planetologist",
                    NotableQuotes = new List<string> { "The highest function of ecology is understanding consequences." }
                },
                new Persona
                {
                    Id = "char_Scytale",
                    Name = "Scytale",
                    ShortDescription = "A Tleilaxu Face Dancer involved in the conspiracy against Paul.",
                    DetailedHistory = "Possessing the ability to change his appearance, he orchestrated the delivery of the ghola Hayt to Paul and attempted to extort him into surrendering his empire.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DuncanIdaho", "char_PaulAtreides", "char_Edric" },
                    Affiliation = "Bene Tleilax",
                    Role = "Face Dancer",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Edric",
                    Name = "Edric",
                    ShortDescription = "A Spacing Guild Steersman who plotted against Muad'Dib.",
                    DetailedHistory = "Used his prescience to hide the conspirators from Paul's own prescient vision. He was eventually executed by Stilgar upon the conspiracy's failure.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_GaiusHelenMohiam", "char_Scytale", "char_Stilgar" },
                    Affiliation = "Spacing Guild",
                    Role = "Steersman",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Korba",
                    Name = "Korba",
                    ShortDescription = "Former Fedaykin who became a high priest of the Qizarate.",
                    DetailedHistory = "Turned the Fremen religion into a vast bureaucratic empire. He plotted to assassinate Paul to martyr him, but was exposed and executed.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_Stilgar" },
                    Affiliation = "Qizarate",
                    Role = "Panegyrist",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Otheym",
                    Name = "Otheym",
                    ShortDescription = "A trusted Fremen Fedaykin.",
                    DetailedHistory = "Served Paul faithfully during the desert years and the jihad. In Dune Messiah, he contracted a Tleilaxu disease and provided Paul with his dwarf Bijaz to expose the conspiracy.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Stilgar", "char_PaulAtreides" },
                    Affiliation = "Fremen",
                    Role = "Fedaykin",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_LetoIIAtreides",
                    Name = "Leto II Atreides",
                    ShortDescription = "Son of Paul and Chani, the God Emperor.",
                    DetailedHistory = "Recognizing the flaw in his father's prescience, Leto merged his body with sandtrout to gain immortality and enforce the Golden Path, ruling humanity for millennia.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_Chani", "char_GhanimaAtreides", "char_AliaAtreides" },
                    Affiliation = "House Atreides",
                    Role = "God Emperor",
                    NotableQuotes = new List<string> { "I am a collection of obsolete memories." }
                },
                new Persona
                {
                    Id = "char_GhanimaAtreides",
                    Name = "Ghanima Atreides",
                    ShortDescription = "Daughter of Paul and Chani, twin sister to Leto II.",
                    DetailedHistory = "Like her brother, she was pre-born. She resisted possession by her ancestors and formed a political marriage with Farad'n Corrino to continue the Atreides bloodline.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_PaulAtreides", "char_Chani", "char_FaradnCorrino" },
                    Affiliation = "House Atreides",
                    Role = "Princess",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_FaradnCorrino",
                    Name = "Farad'n Corrino",
                    ShortDescription = "Grandson of Shaddam IV and the last Corrino claimant to the throne.",
                    DetailedHistory = "Trained in the Bene Gesserit ways by Lady Jessica. He ultimately surrendered his Sardaukar to Leto II and became the mate of Ghanima, taking the name Harq al-Ada.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_GhanimaAtreides", "char_LadyJessica", "char_LetoIIAtreides" },
                    Affiliation = "House Corrino",
                    Role = "Prince",
                    NotableQuotes = new List<string>()
                }
            };
        }
    }
}
                    