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
                    RelatedEntityIds = new List<string> { "char_LadyJessica", "char_DukeLetoAtreides", "char_Chani", "char_Stilgar", "char_GurneyHalleck", "char_ThufirHawat", "char_DuncanIdaho", "char_AliaAtreides", "char_PrincessIrulan", "char_FeydRautha", "char_HasimirFenring" },
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
                    RelatedEntityIds = new List<string> { "char_LadyJessica", "char_PaulAtreides", "char_ThufirHawat", "char_GurneyHalleck", "char_DuncanIdaho", "char_WellingtonYueh", "char_DukePaulusAtreides", "char_RhomburVernius" },
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
                    RelatedEntityIds = new List<string> { "char_FeydRautha", "char_GlossuRabban", "char_PiterDeVries", "char_ShaddamIV", "char_AliaAtreides", "char_AbulurdHarkonnen" },
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
                    DetailedHistory = "He died defending Paul and Jessica from Sardaukar on Arrakis. His body was recovered by the Tleilaxu and resurrected as the ghola 'Hayt', eventually regaining his original memories. Over the millennia that followed, the Tleilaxu would regrow him again and again, entangling his many lives with Leto II's Golden Path and, generations later, the Bene Gesserit's war against the Honored Matres.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_PaulAtreides", "char_LadyJessica", "char_Scytale", "char_MilesTeg", "char_DarwiOdrade", "char_Murbella", "char_SionaAtreides", "disc_GholaCultivation", "bio_Futar" },
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
                    RelatedEntityIds = new List<string> { "char_PrincessIrulan", "char_BaronHarkonnen", "char_PaulAtreides", "char_FaradnCorrino", "char_HasimirFenring", "char_ElroodIX" },
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
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_PaulAtreides", "char_GaiusHelenMohiam", "char_BronsoOfIx" },
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
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen", "char_GlossuRabban", "char_PaulAtreides", "char_MargotFenring" },
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
                    RelatedEntityIds = new List<string> { "char_Chani", "char_DukeLetoAtreides", "char_PaulAtreides", "char_PardotKynes" },
                    Affiliation = "Imperial Court / Fremen",
                    Role = "Planetologist",
                    NotableQuotes = new List<string> { "The highest function of ecology is understanding consequences." }
                },
                new Persona
                {
                    Id = "char_Scytale",
                    Name = "Scytale",
                    ShortDescription = "A Tleilaxu Face Dancer involved in the conspiracy against Paul.",
                    DetailedHistory = "Possessing the ability to change his appearance, he orchestrated the delivery of the ghola Hayt to Paul and attempted to extort him into surrendering his empire. Centuries later he resurfaced in the Bene Gesserit's war against the Honored Matres, revived by the Tleilaxu with the secret of cultivating gholas independent of the original cells, before being killed by Duncan Idaho.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DuncanIdaho", "char_PaulAtreides", "char_Edric", "disc_GholaCultivation" },
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
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_Chani", "char_GhanimaAtreides", "char_AliaAtreides", "char_MoneoAtreides", "char_SionaAtreides", "char_HwiNoree", "org_FishSpeakers" },
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
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_PaulAtreides", "char_Chani", "char_FaradnCorrino", "event_TigerAssassinationAttempt" },
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
                },

                // ---- Dune Messiah / Children of Dune ----
                new Persona
                {
                    Id = "char_Bijaz",
                    Name = "Bijaz",
                    ShortDescription = "A Tleilaxu-conditioned dwarf whose songs and riddles conceal a deadly hypnotic trigger.",
                    DetailedHistory = "Gifted to Paul Atreides as a Tleilaxu ghola meant to destabilize him with coded verbal triggers, Bijaz was instead subverted by Paul's own awareness. Years later he served the Atreides twins in Children of Dune, using his gift for riddles and hidden knowledge to help expose the conspiracy against them.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_LetoIIAtreides", "char_GhanimaAtreides", "org_BeneTleilax" },
                    Affiliation = "Bene Tleilax",
                    Role = "Conditioned Ghola / Advisor",
                    NotableQuotes = new List<string> { "A little knowledge, properly injected, can be more paralyzing than a shock to the reflex ganglia." }
                },
                new Persona
                {
                    Id = "char_WensiciaCorrino",
                    Name = "Wensicia Corrino",
                    ShortDescription = "Shaddam IV's daughter, who plotted from Salusa Secundus to restore House Corrino to the throne.",
                    DetailedHistory = "Mother of Farad'n and fiercely devoted to reclaiming the Golden Lion Throne, Wensicia orchestrated the Laza tiger assassination attempt against the young Atreides twins and conspired with the Fremen traitor Javid, only to be undone when her schemes were exposed.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_FaradnCorrino", "char_Tyekanik", "char_Javid", "bio_LazaTiger", "event_TigerAssassinationAttempt" },
                    Affiliation = "House Corrino",
                    Role = "Princess / Conspirator",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Tyekanik",
                    Name = "Tyekanik",
                    ShortDescription = "Sardaukar Bashar loyal to House Corrino, torn between duty and conscience.",
                    DetailedHistory = "Serving as military commander and advisor to Wensicia Corrino and tutor to Farad'n, Tyekanik struggled with the morality of her plots against the Atreides twins, ultimately proving more honorable than the schemes he was asked to carry out.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_WensiciaCorrino", "char_FaradnCorrino", "org_Sardaukar" },
                    Affiliation = "House Corrino",
                    Role = "Bashar",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Javid",
                    Name = "Javid",
                    ShortDescription = "A treacherous Fremen Naib secretly in service to House Corrino.",
                    DetailedHistory = "Outwardly a loyal Fremen leader and Alia's lover, Javid secretly conspired with Wensicia Corrino against the Atreides twins, using his position to manipulate Alia during her possession by the Baron's ego-memory before his treachery was exposed and punished.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_AliaAtreides", "char_WensiciaCorrino", "org_Fremen" },
                    Affiliation = "Fremen (secretly House Corrino)",
                    Role = "Naib / Conspirator",
                    NotableQuotes = new List<string>()
                },

                // ---- God Emperor of Dune ----
                new Persona
                {
                    Id = "char_MoneoAtreides",
                    Name = "Moneo Atreides",
                    ShortDescription = "Leto II's devoted majordomo and most trusted human servant during his millennia-long reign.",
                    DetailedHistory = "A descendant of the Atreides line who came to understand the Golden Path better than almost anyone, Moneo served as Leto II's steward and chief administrator, torn between his loyalty to the God Emperor and his fear for his rebellious daughter Siona.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_SionaAtreides", "org_FishSpeakers" },
                    Affiliation = "House Atreides",
                    Role = "Majordomo",
                    NotableQuotes = new List<string> { "The worm is God's mind, and it needs the freedom to wander in the wilderness." }
                },
                new Persona
                {
                    Id = "char_SionaAtreides",
                    Name = "Siona Atreides",
                    ShortDescription = "Moneo's rebellious daughter, proven immune to prescient sight and key to the Golden Path's fulfillment.",
                    DetailedHistory = "Leader of an underground rebellion against Leto II's rule, Siona was revealed to be invisible to prescience, the trait Leto II had bred for across millennia. Her survival and union with a Duncan Idaho ghola scattered that immunity through humanity, securing the Golden Path against any future tyrant.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_MoneoAtreides", "char_LetoIIAtreides", "char_DuncanIdaho", "theo_GoldenPath" },
                    Affiliation = "House Atreides",
                    Role = "Rebel Leader",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_HwiNoree",
                    Name = "Hwi Noree",
                    ShortDescription = "An Ixian-designed companion crafted to be the perfect match for the God Emperor.",
                    DetailedHistory = "Engineered by Ix as an act of goodwill (or a subtle weapon), Hwi Noree's genuine warmth won Leto II's love regardless of her origins. Their wedding, meant to cement his rule, instead became the occasion of his death at the hands of the rebellion.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "house_Vernius", "event_DeathOfTheGodEmperor" },
                    Affiliation = "Ix",
                    Role = "Ambassador / Companion",
                    NotableQuotes = new List<string>()
                },

                // ---- Heretics of Dune / Chapterhouse: Dune ----
                new Persona
                {
                    Id = "char_MilesTeg",
                    Name = "Miles Teg",
                    ShortDescription = "A retired Bene Gesserit Bashar recalled to protect a new Duncan Idaho ghola from the Honored Matres.",
                    DetailedHistory = "One of the finest military minds the Sisterhood ever produced, Teg was drawn out of retirement to guard a young Duncan Idaho ghola from Tleilaxu and Honored Matre schemes. Captured and tortured, he unlocked a latent ability for superhuman speed, becoming something closer to a living weapon than a man.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DarwiOdrade", "char_DuncanIdaho", "org_BeneGesserit", "org_HonoredMatres", "char_Schwangyu" },
                    Affiliation = "Bene Gesserit",
                    Role = "Bashar",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_DarwiOdrade",
                    Name = "Darwi Odrade",
                    ShortDescription = "A Bene Gesserit Reverend Mother who rises to Mother Superior amid the war with the Honored Matres.",
                    DetailedHistory = "Raised within the Sisterhood's breeding program and shaped by hard field experience, Odrade became one of the key strategists guiding the Bene Gesserit through their desperate conflict with the Honored Matres, ultimately assuming leadership of the order as Mother Superior.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_MilesTeg", "char_Taraza", "char_Murbella", "org_BeneGesserit", "org_HonoredMatres" },
                    Affiliation = "Bene Gesserit",
                    Role = "Mother Superior",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Sheeana",
                    Name = "Sheeana",
                    ShortDescription = "A young girl able to command sandworms, becoming a living prophet on Rakis.",
                    DetailedHistory = "Discovered to hold an inexplicable command over the great worms of Rakis, Sheeana became the centerpiece of Bene Gesserit strategy to control the planet's religious meaning, inheriting the mantle once carried by Paul Atreides and Leto II as a figure the desert itself seemed to answer to.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "bio_ShaiHulud", "loc_Rakis", "theo_CultOfShaiHulud", "org_BeneGesserit" },
                    Affiliation = "Bene Gesserit",
                    Role = "Worm-Rider / Prophet",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Murbella",
                    Name = "Murbella",
                    ShortDescription = "A former Honored Matre who merges with the Bene Gesserit to forge a new Sisterhood.",
                    DetailedHistory = "Captured and cross-trained by the Bene Gesserit, Murbella fused the Honored Matres' sexual-imprinting techniques with the Sisterhood's own disciplines, eventually rising to lead a combined order strong enough to survive the enemy that had driven humanity to Scatter.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DarwiOdrade", "char_DuncanIdaho", "org_HonoredMatres", "org_BeneGesserit", "disc_HonoredMatreImprinting" },
                    Affiliation = "Honored Matres (later Bene Gesserit)",
                    Role = "Mother Superior",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Taraza",
                    Name = "Alma Mavis Taraza",
                    ShortDescription = "Mother Superior of the Bene Gesserit during the opening of the war against the Honored Matres.",
                    DetailedHistory = "A master strategist who orchestrated the Sisterhood's long game against the returning Honored Matres, Taraza balanced the breeding program, the Tleilaxu, and the recovery of a new Duncan Idaho ghola as pieces in a plan meant to outlast her own lifetime.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_MilesTeg", "char_DarwiOdrade" },
                    Affiliation = "Bene Gesserit",
                    Role = "Mother Superior",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Waff",
                    Name = "Waff",
                    ShortDescription = "A Tleilaxu Master whose religious convictions complicate his people's schemes.",
                    DetailedHistory = "A Tleilaxu Master entangled in the Bene Gesserit's maneuvers during the Honored Matre conflict, Waff embodied the deeper, unexpectedly devout religious core beneath the Tleilaxu's reputation for cold genetic manipulation.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "org_BeneTleilax", "theo_TleilaxuFaith", "char_MilesTeg" },
                    Affiliation = "Bene Tleilax",
                    Role = "Tleilaxu Master",
                    NotableQuotes = new List<string>()
                },

                // ---- Fenring (Dune / Dune Messiah) ----
                new Persona
                {
                    Id = "char_HasimirFenring",
                    Name = "Hasimir Fenring",
                    ShortDescription = "The Emperor's closest confidant, a failed Kwisatz Haderach, and one of the deadliest men in the Imperium.",
                    DetailedHistory = "A Bene Gesserit near-success in their breeding program, Fenring possessed keen prescient instincts without the full power of the Kwisatz Haderach. As Shaddam IV's most trusted friend and covert enforcer, he could have killed Paul Atreides in a duel but chose not to, recognizing in him a kinship he couldn't act against.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_MargotFenring", "char_PaulAtreides", "house_Fenring", "org_BeneGesserit" },
                    Affiliation = "House Corrino",
                    Role = "Count / Imperial Confidant",
                    NotableQuotes = new List<string> { "He is one of us, Mohiam." }
                },
                new Persona
                {
                    Id = "char_MargotFenring",
                    Name = "Lady Margot Fenring",
                    ShortDescription = "A Bene Gesserit Reverend Mother and wife to Count Fenring, skilled in the Sisterhood's most delicate maneuvers.",
                    DetailedHistory = "Trained deeply in the Bene Gesserit way, Lady Margot carried out the Sisterhood's breeding program alongside her husband, including seducing Feyd-Rautha Harkonnen to preserve a valuable bloodline should Paul Atreides' line fail.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_HasimirFenring", "char_FeydRautha", "org_BeneGesserit", "house_Fenring" },
                    Affiliation = "Bene Gesserit",
                    Role = "Reverend Mother",
                    NotableQuotes = new List<string>()
                },

                // ---- Legends of Dune (Butlerian Jihad era) ----
                new Persona
                {
                    Id = "char_VorianAtreides",
                    Name = "Vorian Atreides",
                    ShortDescription = "A hero of the Butlerian Jihad and the human ancestor from whom House Atreides takes its name.",
                    DetailedHistory = "Raised among the cymek Titans as the son of Agamemnon, Vorian defected to humanity's cause and became one of the Jihad's most trusted heroes, fighting alongside Serena Butler against Omnius. His descendants would found House Atreides.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_AgamemnonTitan", "char_SerenaButler", "org_LeagueOfNobles", "house_Atreides" },
                    Affiliation = "League of Nobles",
                    Role = "Jihad Hero",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_SerenaButler",
                    Name = "Serena Butler",
                    ShortDescription = "The humanitarian leader whose grief ignited the Butlerian Jihad against thinking machines.",
                    DetailedHistory = "After the robot Erasmus murdered her infant son to study human grief, Serena Butler's outrage galvanized humanity's fractured worlds into the unified crusade that would end in the total prohibition of thinking machines.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Erasmus", "char_Omnius", "char_VorianAtreides", "event_ButlerianJihad", "theo_ButlerianDoctrine" },
                    Affiliation = "League of Nobles",
                    Role = "Jihad Leader",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_NormaCenva",
                    Name = "Norma Cenva",
                    ShortDescription = "A diminutive genius whose discovery of the Holtzman effect reshaped the Imperium.",
                    DetailedHistory = "Norma Cenva's breakthrough into what became known as the Holtzman effect made possible both personal defense shields and the folding of space, laying the technological foundation later inherited by the Spacing Guild and, through her own bloodline, the Bene Gesserit.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "art_ShieldGenerator", "vehicle_Heighliner", "org_SpacingGuild", "org_BeneGesserit", "char_JosefVenport" },
                    Affiliation = "League of Nobles",
                    Role = "Inventor / Mystic",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Omnius",
                    Name = "Omnius",
                    ShortDescription = "The evermind, a distributed machine intelligence ruling the Synchronized Worlds.",
                    DetailedHistory = "Copied endlessly across the Synchronized Worlds, Omnius ruled a vast machine empire that enslaved much of humanity before the Butlerian Jihad broke its power, leaving behind the deep-rooted taboo against thinking machines that would define the Imperium for ten thousand years.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Erasmus", "org_SynchronizedWorlds", "event_ButlerianJihad", "theo_ButlerianDoctrine" },
                    Affiliation = "Synchronized Worlds",
                    Role = "Evermind",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Erasmus",
                    Name = "Erasmus",
                    ShortDescription = "An independent robot philosopher who studied humanity through cruelty.",
                    DetailedHistory = "Granted unusual independence by Omnius to pursue his fascination with human nature, Erasmus's experiments - including the murder of Serena Butler's infant son - became the spark that turned scattered resistance into the full Butlerian Jihad.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Omnius", "char_SerenaButler", "org_SynchronizedWorlds", "event_ButlerianJihad" },
                    Affiliation = "Synchronized Worlds",
                    Role = "Independent Robot",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_XavierHarkonnen",
                    Name = "Xavier Harkonnen",
                    ShortDescription = "A celebrated Jihad hero and ancestor of House Harkonnen, later erased from honorable memory.",
                    DetailedHistory = "A general of the League of Nobles' forces against the thinking machines, Xavier Harkonnen's legacy was deliberately tainted by political rivals after his death, an injustice that left his descendants to build House Harkonnen's fortunes under a cloud his name never fully shook.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "house_Harkonnen", "org_LeagueOfNobles", "event_ButlerianJihad" },
                    Affiliation = "League of Nobles",
                    Role = "General",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_AgamemnonTitan",
                    Name = "Agamemnon",
                    ShortDescription = "The ruthless leader of the Titans, cymek tyrants who ruled before the machines usurped them.",
                    DetailedHistory = "A human brain preserved in a mechanical body, Agamemnon led the Titans' conquest of the Old Empire, only to be outmaneuvered by the very thinking machines he helped create, becoming a bitter, undying enemy of his own son Vorian Atreides.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_VorianAtreides", "char_Omnius", "vehicle_CymekWalker", "event_ButlerianJihad" },
                    Affiliation = "Titans",
                    Role = "Cymek Lord",
                    NotableQuotes = new List<string>()
                },

                // ---- Prelude to Dune (House trilogy) ----
                new Persona
                {
                    Id = "char_DukePaulusAtreides",
                    Name = "Duke Paulus Atreides",
                    ShortDescription = "Leto Atreides's father, whose death in the bullring shaped his son's sense of honor.",
                    DetailedHistory = "A Duke devoted to the old codes of honor and physical courage, Paulus died in a bull-fighting arena in an accident secretly engineered by House Harkonnen, leaving young Leto to inherit both the Duchy and a determination to rule with the same honesty his father had.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "house_Atreides", "house_Harkonnen", "event_DeathOfDukePaulus" },
                    Affiliation = "House Atreides",
                    Role = "Duke",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_PardotKynes",
                    Name = "Pardot Kynes",
                    ShortDescription = "The first Imperial Planetologist on Arrakis, father to Liet-Kynes and originator of the dream to green the desert.",
                    DetailedHistory = "Sent to study Arrakis for the Empire, Pardot Kynes instead fell in love with the planet and its people, conceiving the generations-long project to transform Arrakis into a water-rich world - a vision his son Liet would inherit and the Fremen would adopt as an article of faith.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LietKynes", "loc_Arrakis", "org_Fremen" },
                    Affiliation = "Imperial Court / Fremen",
                    Role = "Planetologist",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_DominicVernius",
                    Name = "Dominic Vernius",
                    ShortDescription = "The exiled Earl of Ix, overthrown in a Tleilaxu-backed coup.",
                    DetailedHistory = "Once the proud ruler of Ix, Dominic Vernius was driven into hiding after House Corrino allowed the Tleilaxu to seize his world, becoming a rebel and smuggler while his children Rhombur and Kailea were left to find their own paths in exile.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "house_Vernius", "loc_Ix", "char_RhomburVernius", "event_IxianCoup" },
                    Affiliation = "House Vernius",
                    Role = "Earl (exiled)",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_RhomburVernius",
                    Name = "Rhombur Vernius",
                    ShortDescription = "The exiled prince of Ix and lifelong friend of Duke Leto Atreides.",
                    DetailedHistory = "Driven from his homeworld as a boy, Rhombur found refuge with House Atreides and remained devoted to Leto throughout his life, eventually being restored to a cyborg body after grievous injury and working to reclaim Ix from Tleilaxu control.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DominicVernius", "char_DukeLetoAtreides", "house_Vernius", "event_IxianCoup" },
                    Affiliation = "House Vernius / House Atreides",
                    Role = "Prince (exiled)",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_ElroodIX",
                    Name = "Elrood IX",
                    ShortDescription = "Shaddam's father and predecessor on the Golden Lion Throne.",
                    DetailedHistory = "An aging, manipulative Padishah Emperor, Elrood IX was quietly poisoned by his own son Shaddam, with Hasimir Fenring's discreet assistance, clearing Shaddam's path to the throne years before the events of Dune.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_HasimirFenring", "house_Corrino" },
                    Affiliation = "House Corrino",
                    Role = "Padishah Emperor",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_AbulurdHarkonnen",
                    Name = "Abulurd Harkonnen",
                    ShortDescription = "The gentle, ineffectual father of Baron Vladimir Harkonnen, exiled for his perceived weakness.",
                    DetailedHistory = "Considered too soft-hearted to properly rule, Abulurd was stripped of House leadership and exiled to the whale-fur world of Lankiveil, a humiliation his son Vladimir would spend his life overcompensating for through calculated cruelty.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen", "house_Harkonnen", "loc_Lankiveil" },
                    Affiliation = "House Harkonnen",
                    Role = "Exiled Patriarch",
                    NotableQuotes = new List<string>()
                },

                // ---- Great Schools of Dune (post-Jihad founding era) ----
                new Persona
                {
                    Id = "char_RaquellaBertoAnirul",
                    Name = "Raquella Berto-Anirul",
                    ShortDescription = "The first Mother Superior of the Bene Gesserit and originator of the Reverend Mother transformation.",
                    DetailedHistory = "Facing death from a plague her proctors could not cure, Raquella's desperate acolytes forced upon her a poison distillation that, against all odds, she transmuted rather than died from - the first true Reverend Mother transformation, and the founding miracle upon which the entire Bene Gesserit Sisterhood was built.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "art_WaterOfLife", "event_ReverendMotherBreakthrough", "disc_BeneGesseritTraining" },
                    Affiliation = "Bene Gesserit",
                    Role = "Mother Superior (Founding)",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_GilbertusAlbans",
                    Name = "Gilbertus Albans",
                    ShortDescription = "Founder of the Mentat School, raised and tutored in logic by the robot Erasmus.",
                    DetailedHistory = "Orphaned during the Jihad and secretly raised by Erasmus as a living experiment, Gilbertus Albans turned that unlikely education into the foundation of the Mentat School, training human minds to replace the very thinking machines that shaped his own childhood.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "org_MentatSchool", "disc_Mentat", "char_Erasmus", "event_ButlerianJihad" },
                    Affiliation = "Mentat School",
                    Role = "Founder / Headmaster",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_JosefVenport",
                    Name = "Josef Venport",
                    ShortDescription = "A descendant of Norma Cenva who built a commercial empire trading melange and Holtzman technology.",
                    DetailedHistory = "Leveraging his family's foundational role in Holtzman research, Josef Venport expanded a private trading concern into a commercial power that shaped the melange trade and interstellar transport routes later folded into the Spacing Guild and CHOAM's spheres of influence.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_NormaCenva", "org_SpacingGuild", "org_CHOAM", "bio_Melange" },
                    Affiliation = "Venport Holdings",
                    Role = "Director",
                    NotableQuotes = new List<string>()
                },

                // ---- Heretics of Dune / Chapterhouse: Dune (deeper cuts) ----
                new Persona
                {
                    Id = "char_Schwangyu",
                    Name = "Schwangyu",
                    ShortDescription = "A reactionary Bene Gesserit proctor who opposed Miles Teg's unconventional upbringing of a new Duncan Idaho ghola.",
                    DetailedHistory = "Convinced that tradition and caution should govern the Sisterhood's handling of the recovered Duncan Idaho ghola, Schwangyu clashed repeatedly with Miles Teg's more instinctive methods, embodying the internal factionalism that persisted even within the disciplined Bene Gesserit order.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_MilesTeg", "char_DuncanIdaho", "org_BeneGesserit" },
                    Affiliation = "Bene Gesserit",
                    Role = "Proctor",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_BronsoOfIx",
                    Name = "Bronso of Ix",
                    ShortDescription = "A rival historian who challenged the official legend of Muad'Dib.",
                    DetailedHistory = "Raised alongside Paul Atreides but disillusioned by the jihad waged in his name, Bronso wrote a dissenting history of Muad'Dib's rule, defying the Qizarate's sanctioned narrative and Princess Irulan's own chronicles at considerable personal risk.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_PrincessIrulan", "theo_ChurchOfMuadDib", "org_Qizarate" },
                    Affiliation = "Ix",
                    Role = "Dissident Historian",
                    NotableQuotes = new List<string>()
                }
            };
        }
    }
}
                    