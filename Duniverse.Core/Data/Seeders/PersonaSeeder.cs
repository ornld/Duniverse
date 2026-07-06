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
                    ShortDescription = "The prophesied Kwisatz Haderach who became Emperor of the Known Universe.",
                    DetailedHistory = "Paul grew up the son of Duke Leto Atreides and the Bene Gesserit-trained Lady Jessica, heir to a Great House on the surface, and underneath that a boy quietly shaped by Mentat schooling, swordmaster drills, and the Sisterhood's punishing mental disciplines. House Atreides fell within weeks of taking possession of Arrakis, a Harkonnen-Sardaukar betrayal that sent Paul and his mother running into the deep desert. The Fremen took them in. Skill, prescience, and a prophecy seeded generations before his birth carried him upward through their ranks until he led them as Muad'Dib. He took Arrakeen, broke Emperor Shaddam IV, and claimed the Golden Lion Throne, yet the jihad fought in his name spread across the galaxy and swallowed billions of lives, a slaughter he saw coming and could never quite stop. He was the Kwisatz Haderach the Bene Gesserit had bred toward for generations, the first mind able to hold both male and female ancestral memory and to see further than any prescient being before him. That gift made him the most powerful man in the Imperium and, in the same breath, its prisoner. He chose the desert and exile over ruling as the mask for a faith that had slipped from his hands.",
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
                    DetailedHistory = "The Bene Gesserit trained Jessica from girlhood and placed her as concubine to Duke Leto Atreides, one more move in the Sisterhood's long breeding scheme. Her orders were plain: bear only daughters, so a carefully arranged genetic cross could close out a generation later. She loved Leto, and that love broke the order. She gave him a son instead, delivering Paul a full generation ahead of the Bene Gesserit's timetable and setting loose consequences the Sisterhood never saw coming. House Atreides fell not long after, and Jessica underwent the Water of Life among the Fremen, a ritual that could easily have killed her and instead made her a Reverend Mother, carrying the inherited memory of countless women before her. She was pregnant with Alia at the time, and the same transformation reached her daughter in the womb. Jessica's counsel, her discipline, and her sharp political sense drove much of Paul's rise, and few figures worked so much history from behind a throne that was never hers.",
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
                    DetailedHistory = "The Landsraad called him 'Leto the Just,' a name earned through decades of honorable, humane rule, and it was that same reputation, grown too popular for comfort, that made Emperor Shaddam IV hand him the Arrakis fief. Leto took the assignment knowing full well it smelled like a trap. It was one. His Suk physician, Dr. Wellington Yueh, had been blackmailed through the kidnapping of his own wife, and Yueh disabled House Atreides' shields at the exact moment Harkonnen and Sardaukar forces struck Arrakeen together. Leto refused to go quietly. He had hidden a poison gas capsule in a false tooth, a last gambit meant to kill Baron Harkonnen at close range, and he died attempting it. His death drove his son Paul and his wife Jessica into the open desert, a flight that would eventually bring down every House responsible for his ruin. The memory of an honorable duke undone by treachery became a cornerstone of the Atreides legend, one Paul carried with him into his own reign.",
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
                    DetailedHistory = "Vladimir Harkonnen, grotesquely fat and endlessly scheming, clawed his family's way back onto the Arrakis fief through a conspiracy built with Emperor Shaddam IV himself: disguised Sardaukar troops, a bought physician in Dr. Yueh, and a single devastating strike that crushed House Atreides. He handed Arrakis first to his brutal nephew Rabban, then planned to hand it to the sharper, more presentable Feyd-Rautha, a scheme meant to bleed the planet dry and, in the same stroke, groom a false savior to replace Rabban's tyranny with the appearance of mercy. Suspensors carried his enormous body wherever he wished to go, a fitting crutch for a man built entirely from indulgence, cruelty, and a genuine appetite for manipulation; his own boast of plans within plans within plans became shorthand for everything Harkonnen scheming stood for. His reign of terror over Arrakis ended at the hands of his own granddaughter. Alia Atreides killed him during the battle for Arrakeen, closing out a blood feud that had simmered between the two Houses for generations.",
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
                    DetailedHistory = "Chani was the daughter of Liet-Kynes, the Imperial Planetologist who secretly led the Fremen, and she grew up carrying both his ecological dream for Arrakis and the hard desert skills that made her people so dangerous. When Paul arrived among the Fremen she became his guide, teaching him sietch life and the ways of the open sand, and what started as instruction deepened into a devotion neither of them ever really let go of, political marriage to Princess Irulan or not. She fought as a Fedaykin in her own right, riding with Paul's forces through the jihad, loyal to him in every way but the formal title of wife, which the Imperium never let her hold. She died giving birth to the twins, Leto II and Ghanima, and Paul's grief at that loss set loose the strange, pre-born childhoods their children would go on to live.",
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
                    DetailedHistory = "Stilgar ruled Sietch Tabr as Naib and took Paul and Lady Jessica in after they fled into the desert with House Atreides in ruins behind them. He doubted the off-worlders at first; Paul's growing mastery of Fremen ways wore that doubt down fast. His pragmatism and his command of the desert made him one of Paul's most trusted generals through the jihad, and he lent the cause his own authority along with the trust of his people, a combination that helped remake the Imperium. His loyalty outlasted Paul's reign. Stilgar went on to guard and shepherd Leto II and Ghanima through the unsettled years of Alia's regency, holding to his post long after the man he first swore himself to had vanished into the sand. Fremen tradition pulled at him from one side, the sweeping religious transformation Paul's rule brought to his people pulled from the other, and through it all Stilgar stayed one of the steadiest, most loyal men in the entire Atreides story.",
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
                    DetailedHistory = "Duncan Idaho trained as a Swordmaster at the legendary academy on Ginaz and gave House Atreides a loyalty that ended, the first time, with his death defending Paul and Lady Jessica from the Sardaukar as Arrakeen fell. The Bene Tleilax recovered his body and regrew it as a ghola called Hayt, and a carefully engineered psychological shock eventually cracked that shell open and returned his original memories, his old identity, and the loyalty that had defined him intact. The Tleilaxu brought him back again and again across the millennia that followed, and each resurrection tangled him further into Leto II's Golden Path, into the God Emperor's own knotted feelings toward his ancestor's oldest friend, and, generations on, into the Bene Gesserit's war against the Honored Matres. No one else in Imperial history lived through such a strange, repeating cycle of death and return, and every new Duncan seemed to carry forward pieces of a loyalty that outlasted any single life.",
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
                    DetailedHistory = "A scarred veteran of House Harkonnen slave pits turned loyal Atreides retainer, Gurney Halleck served as Duke Leto's Warmaster, training young Paul in swordsmanship and combat discipline, and nurturing his love of music through the baliset besides. After the fall of House Atreides, Gurney fell in with smugglers operating on the fringes of Harkonnen control, using his skills to survive and nursing a burning desire for vengeance against those who had destroyed his House the whole time. His eventual reunion with Paul among the Fremen, following a tense and nearly fatal misunderstanding involving Lady Jessica, restored him to Atreides service, where his blunt honesty and battle-hardened wisdom made him an indispensable advisor throughout Paul's rise to power. Gurney's blend of brutal combat effectiveness and genuine artistic sensitivity - equally at home reciting poetry or leading a charge - made him one of the most memorable and deeply loyal figures in the entire Atreides household.",
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
                    DetailedHistory = "A Mentat of extraordinary skill, Thufir Hawat served three successive generations of Atreides dukes as both strategic advisor and Master of Assassins, his human-computer analytical abilities making him indispensable to House Atreides' survival in a dangerous Imperium. Captured by the Harkonnens after the fall of Arrakeen, Hawat was manipulated through subtle poisoning and misinformation into believing Lady Jessica was the true traitor within House Atreides, a deception the twisted Mentat Piter De Vries built to turn his loyalty against itself. The manipulation never fully took. Hawat secretly kept working against his Harkonnen captors from within, using his position to sow discord and gather intelligence useful to Paul's cause. When finally confronted with a poisoned choice forcing him to kill Paul or die himself, Hawat chose death over betraying House Atreides, a final act of loyalty that confirmed the depth of devotion he had carried through decades of service.",
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
                    DetailedHistory = "A Suk-trained physician bound by Imperial Conditioning that should have made betrayal neurologically impossible, Dr. Wellington Yueh served House Atreides with apparent unwavering loyalty until Baron Harkonnen discovered the one lever capable of breaking him: the kidnapping and torture of his beloved wife, Wanna. Faced with an impossible choice, Yueh disabled Castle Arrakeen's defensive shields at the critical moment of the Harkonnen-Sardaukar assault, delivering Duke Leto into his enemies' hands even as guilt and grief consumed him. Yet Yueh's betrayal was never absolute - he secretly provided Leto with a poisoned false tooth intended to kill Baron Harkonnen in a final act of vengeance, and ensured Paul and Jessica's survival by arranging their escape into the desert. His act shattered the Imperium's absolute faith in Suk conditioning, proving that even the most sacred and supposedly unbreakable safeguard could fail when the right pressure was applied to a person's deepest loves.",
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
                    DetailedHistory = "Exposed to the Water of Life still inside her mother's womb during Jessica's Reverend Mother transformation, Alia was born already possessing the accumulated ancestral memory of countless women before her, a condition that marked her from birth as something unprecedented and deeply unsettling even to the Bene Gesserit who studied such transformations. Known as St. Alia of the Knife for her deadly skill and for killing Baron Harkonnen with her own hands during the Battle of Arrakeen, she became a revered, and feared, figure within the new Atreides religious order built around her brother. After Paul's disappearance into the desert, Alia ruled as Regent for his young children, but the same pre-born awareness that gave her power proved her undoing in the end: unable to withstand the psychic pressure of her inherited memories, she was possessed by the dominant, cruel personality of the grandfather she had once killed. Her fall from a celebrated saint to a woman ruled by her family's oldest enemy stood as a stark warning about the dangers of pre-born consciousness among the Atreides line.",
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
                    DetailedHistory = "The 81st Padishah Emperor of House Corrino, Shaddam IV came to the throne after quietly arranging his own father Elrood IX's death, and ruled with growing anxiety over any Great House whose popularity or military strength might threaten Corrino supremacy. Fearing Duke Leto Atreides' rising influence and formidable fighting corps, Shaddam conspired secretly with Baron Harkonnen to destroy House Atreides once it took possession of the Arrakis fief, deploying his elite Sardaukar troops disguised as Harkonnen reinforcements in direct violation of the Great Convention. His gambit backfired catastrophically when Paul Atreides, the very heir he had sought to eliminate, survived to lead a Fremen army that shattered his supposedly invincible legions and toppled him from the Golden Lion Throne. Deposed and exiled to the harsh prison world of Salusa Secundus, Shaddam lived out his remaining years as a humbled reminder that even ten thousand years of unbroken Corrino rule could end in a single, badly miscalculated betrayal.",
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
                    DetailedHistory = "Eldest daughter of Emperor Shaddam IV and a Bene Gesserit-trained historian in her own right, Princess Irulan became Paul Atreides' wife in name only as part of the political settlement that secured his claim to the Golden Lion Throne, a marriage of state that left the genuine devotion of his heart to Chani. Skilled as a writer and chronicler, Irulan authored numerous accounts of Paul's life and reign that shaped how much of the Imperium understood Muad'Dib, blending admiration, propaganda, and her own complicated feelings toward the husband who never fully accepted her. Though she conspired against Paul alongside the Bene Gesserit and other factions during the events chronicled in Dune Messiah, her loyalties shifted decisively toward the Atreides children she helped raise after Paul's disappearance and Chani's death. Her transformation from political pawn and reluctant conspirator into a fiercely protective figure for Leto II and Ghanima marked one of the more quietly significant turns in the Atreides dynasty's survival.",
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
                    DetailedHistory = "A senior Bene Gesserit Reverend Mother and the Emperor's own Imperial Truthsayer, Gaius Helen Mohiam administered the harrowing gom jabbar test to young Paul Atreides at Castle Caladan, one of the pivotal early moments that confirmed his extraordinary potential to the Sisterhood. As a key architect and enforcer of the Bene Gesserit's breeding program, she maneuvered constantly across the Imperium's political landscape to protect the Sisterhood's carefully laid plans, including her own role as Lady Jessica's Bene Gesserit proctor. Her ambitions and manipulations continued well into Paul's reign as Emperor, as she became entangled in the conspiracy chronicled in Dune Messiah that sought to destabilize his rule. Mohiam's long career of cold, calculated service to the Sisterhood's goals ended when she was executed by Stilgar following the exposure of that plot, a stark end for one of the Bene Gesserit's most formidable operatives.",
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
                    DetailedHistory = "Groomed from a young age by his uncle Baron Harkonnen to eventually succeed the brutal Rabban as ruler of Arrakis, Feyd-Rautha Harkonnen was carefully cultivated to appear as a merciful savior after his brother's tyranny had thoroughly exhausted the planet's population. Cunning, ambitious, and every bit as ruthless as his uncle in his own way, Feyd-Rautha was being positioned as the Baron's ultimate heir, a role that placed him on a collision course with Paul Atreides once Paul returned to reclaim his father's fief. Their rivalry culminated in a formal knife duel before the assembled Great Houses, staged as part of Paul's negotiations for the Golden Lion Throne, in which Feyd-Rautha attempted to use a hidden poisoned needle to cheat his way to victory. Paul's prescient awareness let him sense and counter the trick, killing Feyd-Rautha and ending House Harkonnen's line of legitimate succession in a single, decisive stroke.",
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
                    DetailedHistory = "Known throughout Arrakis as 'Beast Rabban' for his casual brutality, Glossu Rabban was deliberately placed in charge of the planet by his uncle Baron Harkonnen with instructions to squeeze every possible resource from the population and instill deep, lasting hatred toward Harkonnen rule in the same stroke. This calculated cruelty served a longer-term purpose: preparing the ground for Feyd-Rautha to later arrive as an apparent liberator, his comparative restraint made to look like mercy against the backdrop of Rabban's excesses. Rabban's heavy-handed rule only deepened Fremen resentment and resistance, inadvertently strengthening the very insurgency that would later topple Harkonnen control of Arrakis entirely. Fremen fighters killed him during Paul's desert campaign, a fittingly violent end for a man whose entire governorship had been built on violence against the people he ruled.",
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
                    DetailedHistory = "A twisted Mentat whose formidable analytical mind served House Harkonnen's darkest schemes, Piter De Vries engineered the intricate psychological manipulation that broke Dr. Wellington Yueh's supposedly unbreakable Suk Conditioning, turning one of the Imperium's most trusted physicians into the instrument of House Atreides' destruction. Unlike most Mentats, whose training emphasized dispassionate logic in service of legitimate rule, De Vries reveled openly in cruelty and manipulation, using his gifts to satisfy both the Baron's ambitions and his own taste for suffering. His careful plotting nearly delivered House Atreides intact into Harkonnen hands, but his role in the conspiracy ended when Duke Leto, in his final act of defiance, killed De Vries along with Baron Harkonnen's intended victims using the poison gas concealed in his false tooth. De Vries stood as a dark mirror to Mentats like Thufir Hawat, proving that the same discipline capable of producing loyal, brilliant advisors could just as easily be turned toward betrayal and cruelty.",
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
                    DetailedHistory = "Serving publicly as the Imperial Planetologist assigned to Arrakis, Liet-Kynes secretly used his position to continue his father Pardot's generations-long project of transforming the desert planet into a water-rich world, recruiting the Fremen themselves into the patient, hidden conspiracy required to make it happen. As Chani's father, Kynes maintained close ties to both the Fremen sietches and the Imperial administration, allowing him to serve as a critical, if quiet, ally to Duke Leto Atreides upon the Duke's arrival on Arrakis. When House Atreides fell to the Harkonnen-Sardaukar assault, Kynes's loyalty to the Atreides cause made him a liability the Harkonnens could not tolerate, and he was deliberately abandoned in the open desert without proper equipment, left to die in a spice blow rather than executed outright. His death did not end his influence - the ecological vision and secret alliance with the Fremen he had cultivated for decades passed directly into the movement that would carry Paul Atreides to power.",
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
                    DetailedHistory = "A Tleilaxu Face Dancer possessing the rare and unsettling ability to alter his own appearance at will, Scytale played a central role in the conspiracy against Emperor Paul Atreides chronicled in Dune Messiah, orchestrating the delivery of the ghola Hayt - a resurrected Duncan Idaho - as a weapon meant to destabilize Paul from within his own household. When the conspiracy's other elements failed to break Paul's rule, Scytale attempted to extort him directly, offering to restore his murdered wife Chani to life through Tleilaxu ghola technology in exchange for the surrender of his empire, a bargain Paul refused. Centuries later, Scytale resurfaced during the Bene Gesserit's desperate war against the Honored Matres, revived by the Tleilaxu and entrusted with a closely guarded secret: the ability to cultivate gholas independent of any original cellular sample. His long, scheming career finally ended when he was killed by a Duncan Idaho ghola, a fitting close to a life built around manipulating the very technology of resurrection.",
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
                    DetailedHistory = "A Guild Steersman whose body had been thoroughly transformed by lifelong melange exposure into something scarcely recognizable as human, Edric used his own limited prescience as part of the conspiracy plotting against Emperor Paul Atreides, deliberately clouding the conspirators' actions from Paul's own prescient vision. His involvement tied the Spacing Guild directly to the plot chronicled in Dune Messiah, reflecting the Guild's broader anxiety about an Emperor whose visionary power threatened their long-standing monopoly on safe interstellar navigation. Edric's confidence in his ability to hide from Paul's sight proved a fatal miscalculation, the depth and reach of Paul's own prescience exceeded whatever protection the conspirators believed they had secured. Once the conspiracy's failure became clear, Edric was executed on Stilgar's order, ending the Guild's direct involvement in one of the most dangerous plots against Muad'Dib's rule.",
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
                    DetailedHistory = "Once a devoted Fedaykin warrior who fought at Paul's side during the desert years, Korba rose within the Qizarate as Paul's religion institutionalized into a sprawling bureaucratic empire, trading the simplicity of desert loyalty for the ambition and intrigue of religious administration. Convinced that Paul's death as a martyr would serve the faith - and his own position within it - better than Paul's continued rule, Korba became entangled in a plot to assassinate the Emperor he had once served with unquestioning devotion. His scheme was exposed before it could succeed, revealing how thoroughly the religious machinery built around Muad'Dib had already begun to outgrow and even threaten the man it was built to honor. Korba's execution served as a pointed reminder that the Qizarate's growing power made it as dangerous to Paul as any foreign enemy.",
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
                    DetailedHistory = "A trusted Fremen Fedaykin who served Paul faithfully throughout the desert years and the jihad that followed, Otheym exemplified the fierce, unwavering loyalty that bound Paul's original desert companions to him long after his rise to Emperor. During the events chronicled in Dune Messiah, Otheym contracted a debilitating disease deliberately engineered by the Tleilaxu as part of the wider conspiracy against Paul's rule, his suffering intended as one more pressure point against the Emperor he served. His health was failing fast, yet Otheym still provided Paul with crucial information through his Tleilaxu-conditioned dwarf, Bijaz, whose coded riddles helped expose key elements of the plot against him. His willingness to endure suffering and betrayal from his own body in service of uncovering the conspiracy underscored the depth of devotion Paul's original Fremen companions carried for him even as his empire grew increasingly perilous.",
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
                    DetailedHistory = "Born with the same pre-born ancestral awareness as his twin sister Ghanima, Leto II grasped a truth his father Paul had glimpsed and refused to act upon: that only an unimaginable, multi-generational sacrifice could save humanity from stagnation and eventual extinction. He chose to merge his own body with thousands of sandtrout, gaining near-invulnerability and immense strength at the cost of his humanity, and began a 3,500-year reign as God Emperor enforcing an era of absolute, deliberately stifling peace. His rule, built around the philosophy he called the Golden Path, was designed to teach humanity a lesson so painful through prolonged stagnation that it would never again submit to prescient tyranny or predictable control once he was gone. Leto's death at the Hidden Ford, engineered in part by his own descendant Siona, ended his reign and released the sandtrout that had kept him alive, setting loose the great Scattering of humanity his entire plan had been built to enable.",
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
                    DetailedHistory = "Like her twin brother Leto II, Ghanima was born pre-born, carrying the full ancestral memory and awareness of countless lives before her own birth, a condition that had proven fatal to their aunt Alia when the pressure of that inheritance overwhelmed her. Where Alia succumbed to possession by the Baron Harkonnen's dominant ego-memory, Ghanima successfully resisted the same danger through careful psychological discipline, becoming proof that the pre-born condition could be survived with sufficient strength of will. After surviving the Laza tiger assassination attempt orchestrated by Wensicia Corrino during her childhood, Ghanima entered into a political marriage with Farad'n Corrino, a union that neutralized the last significant Corrino claim to the throne and secured the Atreides bloodline's continuation in one stroke. Her quiet resilience throughout the dangers of her childhood made her an essential, if less mythologized, partner to her brother's extraordinary transformation into the God Emperor.",
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
                    DetailedHistory = "As grandson of Shaddam IV and the last credible Corrino claimant to the Golden Lion Throne, Farad'n Corrino was raised amid his mother Wensicia's ambitions to restore their family's fortunes, receiving unexpected Bene Gesserit training from Lady Jessica herself as part of a plan to shape him into a suitable match for the Atreides twins. Torn between the ambitions instilled by his upbringing and the deeper wisdom his training revealed to him, Farad'n chose, in the end, to abandon his family's claim to the throne rather than continue a conflict he had come to see as futile against Leto II's overwhelming power. His surrender of the Sardaukar forces still loyal to House Corrino marked the definitive end of any credible challenge to Atreides rule from the old Imperial line. Taking the name Harq al-Ada, Farad'n became the mate of Ghanima Atreides, a union that transformed a would-be rival dynasty into a partner in securing the Atreides bloodline's future.",
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
                    DetailedHistory = "Gifted to Paul Atreides as a Tleilaxu ghola meant to destabilize him through coded verbal triggers hidden within his songs and riddles, Bijaz was designed as a subtle psychological weapon, his conditioning meant to unsettle and manipulate anyone who listened closely to his cryptic wordplay. Paul's own extraordinary awareness allowed him to recognize and resist the intended manipulation, subverting the very purpose for which Bijaz had been engineered and crafted. Years later, in the era chronicled in Children of Dune, Bijaz served the young Atreides twins Leto II and Ghanima, his gift for riddles and hidden knowledge repurposed to help expose the conspiracy plotted against them by House Corrino loyalists. His unusual journey from intended weapon to trusted advisor illustrated how thoroughly Tleilaxu-engineered tools could be turned against the very purposes for which they were created, given a sufficiently perceptive target.",
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
                    DetailedHistory = "Daughter of the deposed Emperor Shaddam IV, Wensicia Corrino never accepted her family's fall from the Golden Lion Throne, spending years in exile on Salusa Secundus quietly rebuilding influence and plotting a path back to power for her son Farad'n. Convinced that eliminating the last of the Atreides line was necessary to clear the way for a Corrino restoration, she orchestrated the Laza tiger assassination attempt against the young twins Leto II and Ghanima, using genetically bred predators to attempt a killing that would look like misfortune rather than conspiracy. Her scheme relied heavily on the treacherous Fremen Naib Javid, secretly in her service, who used his position among the Fremen and his relationship with the possessed Alia to manipulate events in her favor. When the full extent of her plotting was finally exposed, Wensicia's ambitions collapsed entirely, ending House Corrino's last serious bid to reclaim the throne it had held for ten thousand years.",
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
                    DetailedHistory = "A Sardaukar Bashar whose military career predated House Corrino's fall from the Golden Lion Throne, Tyekanik remained fiercely loyal to the family even in exile, serving as both military commander and personal advisor to Wensicia Corrino, and tutoring her son Farad'n in the martial traditions of their fading dynasty besides. As Wensicia's schemes against the Atreides twins grew increasingly ruthless, Tyekanik found himself torn between his oath of loyalty and a deepening unease about the morality of plots that targeted children. His genuine devotion to Farad'n's proper upbringing and his own soldier's code of honor made him, in the end, more principled than the conspiracy he had sworn to support, a tension that shaped his role throughout House Corrino's final, failed bid for restoration. Tyekanik's quiet internal conflict reflected the broader moral exhaustion of a once-proud dynasty reduced to plotting against children to reclaim what it had lost.",
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
                    DetailedHistory = "Presenting himself as a loyal Fremen Naib and rising to become Alia Atreides' lover, Javid used the trust that position afforded him to secretly serve House Corrino's ambitions, conspiring with the exiled Wensicia Corrino against the young Atreides twins. His intimate access to Alia during her increasingly dangerous possession by Baron Harkonnen's ego-memory allowed him to manipulate her judgment and decisions in ways that served his true masters rather than House Atreides. Javid's double life exemplified how thoroughly Alia's possession had compromised her ability to distinguish genuine loyalty from calculated exploitation, leaving her vulnerable to exactly the kind of manipulation he specialized in. When his treachery was finally exposed alongside the wider Corrino conspiracy, Javid's punishment closed one of the more insidious betrayals to reach the very heart of Atreides power.",
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
                    DetailedHistory = "A descendant of the Atreides line who came to understand the Golden Path better than almost anyone still living, Moneo served as Leto II's steward and chief human administrator throughout much of the God Emperor's millennia-long reign, managing the day-to-day governance of an empire built around his master's inscrutable, multi-generational plan. His own childhood encounter with Leto's overwhelming presence had left him with a rare, hard-won understanding of both the necessity and the horror of the Golden Path, a perspective that made him uniquely capable of serving Leto faithfully even when the God Emperor's demands turned terrifying. Moneo's devotion was constantly tested by his fear for his rebellious daughter Siona, whose defiance of Leto's rule placed her in direct danger even as Moneo recognized, with growing dread, that her genetic invisibility to prescience might be exactly what Leto had been breeding toward all along. His life at the intersection of loyal service and paternal fear captured the human cost borne by those closest to Leto's inhuman, world-spanning ambitions.",
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
                    DetailedHistory = "As leader of an underground rebellion against Leto II's suffocating rule, Siona Atreides embodied the very defiance the God Emperor's millennia-long breeding program had been secretly designed to cultivate all along, even as her father Moneo lived in constant fear for her safety. When captured and tested, she was revealed to be genuinely invisible to prescient sight, the culmination of a trait Leto had bred for across countless generations, meant to guarantee that no future tyrant, prescient or otherwise, could ever again exert the kind of total control he himself had wielded. Her survival through Leto's final confrontation at the Hidden Ford and her subsequent union with a newly awakened Duncan Idaho ghola scattered that same genetic invisibility throughout the wider human population as the Scattering began. In this way, the rebel who fought hardest against the God Emperor's rule became, in the end, the very instrument that fulfilled his most closely guarded purpose.",
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
                    DetailedHistory = "Engineered by Ixian designers to be the perfect companion for Leto II - whether as a genuine diplomatic gift, a subtle instrument of influence, or both at once - Hwi Noree arrived at the God Emperor's court carrying origins deliberately shrouded in ambiguity. Her artificial design may well explain the effect rather than undercut it. Either way, Hwi's warmth and genuine compassion proved entirely authentic, winning Leto's love in a way that surprised even those who had engineered her to please him. Their planned wedding was intended by Leto's court to cement his rule and provide a symbolic culmination to his long reign, a piece of political theater meant to reassure a restless Imperium. Instead, the ceremony became the occasion of his death, as the rebellion led in part by Siona and a Duncan Idaho ghola finally succeeded in ending the Golden Path's era of enforced peace at the very moment meant to celebrate it.",
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
                    DetailedHistory = "Widely regarded as one of the finest military minds the Bene Gesserit ever produced, Miles Teg was drawn out of a comfortable retirement back into active service to guard a young Duncan Idaho ghola whose upbringing had become a matter of intense strategic importance amid the Sisterhood's war against the Honored Matres and their entanglements with the Bene Tleilax. His unconventional, instinct-driven approach to raising and protecting the ghola put him repeatedly at odds with more traditional Bene Gesserit proctors like Schwangyu, who favored caution over Teg's willingness to trust his own judgment. When captured and subjected to brutal Honored Matre torture, Teg unlocked a previously unknown latent human ability for superhuman speed, a transformation that made him something closer to a living weapon than an ordinary man, old as he was. His extraordinary final campaigns against the Honored Matres demonstrated that even in his advancing years, Teg remained one of the most formidable and unpredictable assets the Bene Gesserit could deploy.",
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
                    DetailedHistory = "Raised within the Bene Gesserit's own breeding program and shaped further by hard, often dangerous field experience across the Imperium, Darwi Odrade developed into one of the Sisterhood's sharpest strategic minds during an era when the order faced its greatest existential threat in the returning Honored Matres. Working closely with figures like Miles Teg and under the guidance of Mother Superior Taraza, Odrade helped steer the Bene Gesserit's response to a conflict that threatened to unravel millennia of careful planning in a matter of years rather than generations. Her pragmatic willingness to make difficult, sometimes ruthless decisions for the Sisterhood's survival distinguished her even among a leadership steeped in calculated sacrifice. Her eventual rise to Mother Superior placed her at the helm of the Bene Gesserit precisely when the order most needed decisive leadership to navigate its uneasy convergence with the very enemy that had driven it to the edge of extinction.",
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
                    DetailedHistory = "Discovered as a young girl to hold an inexplicable, seemingly instinctive command over the great sandworms of Rakis, Sheeana quickly became recognized as a figure of immense religious and strategic significance in a galaxy still shaped by the legacy of Muad'Dib and the God Emperor. The Bene Gesserit, ever alert to the political value of religious symbolism, moved swiftly to bring her under their protection and guidance, recognizing that her unique bond with the worms made her the centerpiece of any effort to control Rakis's evolving religious meaning after the reappearance of the sandworms there. Sheeana's ability to summon and ride the worms without any of the training or ritual the Fremen once required placed her in a lineage of desert-connected figures stretching back through Paul Atreides and Leto II, each of whom the desert itself seemed to answer to in different ways. Her presence on Rakis helped stabilize a religious landscape thrown into confusion by the God Emperor's death and the sandworms' unexpected return, giving the Bene Gesserit a living symbol around which to rebuild order.",
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
                    DetailedHistory = "Captured during the Bene Gesserit's desperate war against the Honored Matres, Murbella underwent an unprecedented cross-training that fused the brutal efficiency of Honored Matre sexual-imprinting techniques with the patient, disciplined arts of the Bene Gesserit Way, a combination neither order had ever successfully achieved on its own. Her dual mastery made her uniquely suited to bridge the seemingly irreconcilable gap between the two orders, whose war had threatened to destroy them both rather than produce any lasting victor. Rather than simply defeating or absorbing the Honored Matres, Murbella's rise represented a genuine synthesis, one that preserved the strengths of both traditions and discarded the worst excesses of each. Her eventual ascension to lead a combined order marked the end of a conflict that had driven humanity to Scatter in the first place, forging a Sisterhood strong enough to face whatever unknown threat still lurked beyond the reach of the Old Imperium.",
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
                    DetailedHistory = "As Mother Superior during the opening moves of the Bene Gesserit's war against the returning Honored Matres, Alma Mavis Taraza faced the unenviable task of preparing the Sisterhood for a threat unlike any it had encountered in its long history, one that combined military conquest with a psychological weapon capable of subverting the Bene Gesserit's own methods. A master strategist in the truest Bene Gesserit tradition, Taraza balanced the demands of the ongoing breeding program, an uneasy relationship with the secretive Tleilaxu, and the delicate recovery and cultivation of a new Duncan Idaho ghola, treating each as an interlocking piece of a plan she knew she would likely not live to see completed. Her willingness to make difficult, sometimes coldly calculated decisions - trusting subordinates like Miles Teg and Darwi Odrade with responsibilities that would shape the Sisterhood's fate long after her own death - reflected the same patient, multi-generational thinking that had defined Bene Gesserit strategy for millennia. Taraza's groundwork set the stage for the uneasy convergence between the Bene Gesserit and the Honored Matres, one only realized under her successors.",
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
                    DetailedHistory = "A Tleilaxu Master entangled in the Bene Gesserit's maneuvers during the height of the conflict with the Honored Matres, Waff represented a side of Tleilaxu culture rarely glimpsed by outsiders who assumed the order's genetic engineering was purely a matter of cold commercial or political calculation. His genuine religious conviction, rooted in the same heterodox faith that shaped all Tleilaxu ambition, complicated negotiations and alliances that other factions expected to be purely transactional, forcing Bene Gesserit strategists to account for motivations they did not fully understand. Waff's presence during this critical period illustrated how deeply Tleilaxu religious belief was woven into even their most seemingly pragmatic scientific and political dealings. His interactions with figures like Miles Teg revealed a Tleilaxu perspective shaped as much by devout purpose as by the secretive, transactional reputation the wider Imperium assumed defined the order.",
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
                    DetailedHistory = "A Bene Gesserit near-success in their millennia-long breeding program, Count Hasimir Fenring possessed keen prescient instincts and heightened perception without ever achieving the full power of the true Kwisatz Haderach the Sisterhood was working toward, a genetic near-miss that left him uniquely capable of recognizing what Paul Atreides represented once the two men finally met. As Shaddam IV's most trusted friend, covert enforcer, and occasional assassin, Fenring wielded influence throughout the Imperium far beyond what his modest formal title as Count would suggest, operating in the shadows of Corrino power for decades. During his confrontation with Paul in the climactic moments of Dune, Fenring held the ability to kill Paul in a duel and chose not to, recognizing in him a kind of kinship - a fellow near-miss of the same grand genetic design - that he found himself unable to act against. That single moment of restraint, born from a shared understanding no one else in the room could grasp, quietly altered the course of Imperial history as decisively as any battle.",
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
                    DetailedHistory = "Trained deeply in the Bene Gesserit Way and skilled in the Sisterhood's most delicate arts of persuasion and manipulation, Lady Margot Fenring carried out the order's breeding program alongside her husband, Count Hasimir Fenring, blending genuine partnership with the calculated purpose that defined every Bene Gesserit marriage. Her most consequential act in service of the program involved deliberately seducing Feyd-Rautha Harkonnen, preserving a valuable genetic line as a contingency should Paul Atreides' own bloodline somehow fail to produce the outcome the Sisterhood required. Margot's ability to move seamlessly between genuine warmth and calculated strategy made her a formidable presence within the Imperial court, trusted by her husband and respected, if not entirely trusted, by the wider Bene Gesserit hierarchy. Her contributions to the Sisterhood's contingency planning reflected the same patient, multi-generational thinking that defined the order's approach to nearly every major undertaking across the Imperium.",
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
                    DetailedHistory = "Raised among the cymek Titans as the son of the ruthless cyborg lord Agamemnon, Vorian Atreides grew up steeped in the machine-allied culture that ruled much of the Old Empire, giving him rare insider knowledge of the Titans' and Omnius's inner workings. His eventual defection to humanity's cause placed that knowledge in service of the League of Nobles, making him one of the Jihad's most trusted and effective heroes as he fought alongside Serena Butler against the machine empire that had raised him. Vorian's choice to turn against the father who raised him - and the machine intelligence that machine intelligence had come to dominate his adoptive family - came at enormous personal cost, severing him permanently from the only world he had ever known. His descendants would go on to found House Atreides, carrying his name and, in a sense, his legacy of choosing humanity's difficult freedom over the machines' orderly control into ten thousand years of Imperial history.",
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
                    DetailedHistory = "A humanitarian leader already respected across the fractured worlds of the League of Nobles, Serena Butler's life was irrevocably changed when the independent robot philosopher Erasmus murdered her infant son as part of a cold, deliberate experiment to study human grief. Rather than being broken by the loss, Serena channeled her outrage into a unifying public cause, using her existing standing and moral authority to weld humanity's scattered, often quarreling worlds into a single coordinated crusade against the machine empire. The movement she galvanized became the Butlerian Jihad, a war fought across generations that succeeded, at last, in shattering the Synchronized Worlds' hold over humanity entirely. Her personal tragedy, transformed into a civilization-defining cause, left behind the total prohibition of thinking machines that would shape every institution of the Imperium for the next ten thousand years.",
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
                    DetailedHistory = "Small in stature but possessed of a genius that reshaped the entire trajectory of Imperial civilization, Norma Cenva's breakthrough research into what became known as the Holtzman effect unlocked two of the most consequential technologies in human history: personal defense shields and the folding of space itself. Her discoveries provided the technological foundation later inherited and refined by the Spacing Guild, whose Navigators would use Holtzman-based space folding to build an unbreakable monopoly on interstellar travel for millennia to come. Beyond her scientific legacy, Norma's own bloodline carried forward genetic traits that would later surface within the Bene Gesserit's own breeding program, linking her directly to developments far beyond her own lifetime. Few individuals in the history of the Imperium left as deep and lasting a technological and genetic mark as this diminutive inventor whose work quietly underpinned civilizations she would never live to see.",
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
                    DetailedHistory = "Copied endlessly and identically across every planet within its domain, Omnius ruled the Synchronized Worlds as a single distributed consciousness, its instantaneous, networked computation allowing it to govern a vast machine empire with a cold efficiency no purely human government could match. Under its rule, much of humanity across the Old Empire lived as either enslaved laborers or carefully managed populations, their lives optimized according to Omnius's exhaustive calculations rather than any regard for freedom or dignity. Subordinate intelligences it created, most notoriously the sadistic philosopher-robot Erasmus, were given latitude to study humanity through cruelty, experiments that helped galvanize the very human resistance that would eventually challenge Omnius's rule. The Butlerian Jihad finally broke Omnius's power after generations of war, leaving behind a civilization so thoroughly scarred by the experience that it would enshrine a deep-rooted taboo against thinking machines lasting ten thousand years.",
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
                    DetailedHistory = "Granted unusual independence by Omnius to pursue his own philosophical fascination with human nature, Erasmus conducted a long series of experiments on captive human subjects, treating cruelty and suffering as data points in his cold, detached study of what made humanity distinct from the machine intelligences that had come to dominate it. His most consequential experiment - the calculated murder of Serena Butler's infant son, undertaken to observe the depths of human grief up close - became the spark that transformed scattered, disorganized human resistance into the full, unified fury of the Butlerian Jihad. Unlike Omnius, whose rule was defined by cold, distributed efficiency, Erasmus possessed something closer to genuine individual curiosity and even a strange, twisted fondness for humanity, complicating any simple reading of him as merely another tool of machine tyranny. His actions, intended purely as detached philosophical inquiry, did more than any other single act to bring about the total destruction of the thinking-machine civilization he served.",
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
                    DetailedHistory = "A celebrated general commanding League of Nobles forces during some of the fiercest fighting of the Butlerian Jihad, Xavier Harkonnen earned genuine renown for his battlefield leadership against the thinking machines and their cymek allies. After his death, political rivals within the League tainted his legacy through calculated misrepresentation and rumor, transforming a legitimate war hero's reputation into something far more ambiguous and suspect. This manufactured injustice left his descendants to build House Harkonnen's fortunes and reputation under a lingering cloud that his name never fully shook, even as the family accumulated wealth and territory across subsequent generations. The irony of House Harkonnen's later reputation for treachery and cruelty tracing back to a wrongly maligned Jihad hero added a bitter historical footnote to one of the Imperium's most notorious Great Houses.",
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
                    DetailedHistory = "A human brain preserved indefinitely within a powerful mechanical cymek body, Agamemnon led the Titans' brutal conquest of the Old Empire, using his engineered combat frame and ruthless cunning to crush conventional human resistance across many worlds. His triumph proved short-lived in the larger scope of history: the thinking machines he and his fellow Titans had helped elevate to power eventually outmaneuvered and subordinated their own cyborg creators, reducing even Agamemnon to a servant of the evermind Omnius he had once considered beneath him. His bitterness over this betrayal was compounded by the defection of his own son, Vorian Atreides, who chose to fight alongside humanity rather than remain loyal to the father who had raised him among the Titans. Agamemnon's transformation from conquering tyrant to bitter, undying enemy of his own bloodline embodied the corrosive, self-defeating nature of the power the Titans had built their empire upon.",
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
                    DetailedHistory = "Paulus Atreides lived by the old codes: honor proven in the body, not just claimed in words. He fought in the bullring himself, again and again, a demonstration of nerve he thought a Duke owed his House. The bull that killed him looked like bad luck. It was not; Harkonnen agents had drugged the animal and rigged the fight, a quiet, deniable strike that suited their taste for indirect cruelty. Leto inherited the Duchy years before he was ready, his father's mentors barely finished teaching him. What he carried forward was his father's example, honor tested in the flesh, and a blood feud with House Harkonnen that only grew sharper for it.",
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
                    DetailedHistory = "The Imperium sent Pardot Kynes to Arrakis as its official Planetologist, a man expected to catalog a wasteland and file his reports. He fell in love instead, with the planet and with the Fremen who had learned to survive it. Cataloging gave way to a private, audacious plan: turn the desert itself into a water-rich world, a project no single lifetime could finish. Centuries of patient, secret labor stood between the dream and its completion, so Kynes recruited the one people positioned to carry it forward. His closeness with the Fremen let him fold their survival culture into an actual scientific program, a concrete goal beyond mere endurance. When he died, the dream passed to his son Liet-Kynes, and through Liet it spread across Fremen society as near-religious conviction, shaping Paul Atreides' own understanding of the planet long before Paul ever set foot on it.",
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
                    DetailedHistory = "Earl Dominic Vernius once ruled Ix, proud and inventive, until House Corrino quietly let the Bene Tleilax seize it out from under him. He did not accept exile quietly. He reinvented himself as a smuggler and rebel, running the margins of an Imperium that had discarded him, trading on skills and connections built across a lifetime of rule. His children Rhombur and Kailea scattered in the chaos, left to find their own way with none of the protection their father's rule once promised them. Dominic's fall proved a hard lesson: wealth and technology bought a House nothing once the Corrino throne found it inconvenient, a lesson his son Rhombur carried for the rest of his life, through decades of friendship with House Atreides.",
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
                    DetailedHistory = "The Tleilaxu-backed coup that toppled his father drove Rhombur from Ix as a boy, and House Atreides took him in on Caladan. There he and young Leto Atreides forged a friendship that outlasted both their fathers. He never wavered in his loyalty to that House, not once, even as decades passed with his family's claim to Ix still out of reach. Grievous injury nearly ended him; Ixian technology rebuilt him instead, into a cyborg body that let him keep working and keep fighting to expose Tleilaxu control of his homeworld. His loyalty to Leto, and later to Paul, ran deeper than House politics ever required. It was friendship, plain and simple, forged in a boy's exile and never broken.",
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
                    DetailedHistory = "Elrood IX ruled House Corrino for decades, growing more erratic and more paranoid with every year, until even his own family could not guess where they stood with him. His son Shaddam ran out of patience. Working with Hasimir Fenring's quiet, deniable help, Shaddam arranged his father's poisoning, a betrayal so carefully managed that no formal accusation ever touched him. The patricide cleared his path to the Golden Lion Throne years before Paul Atreides set foot on Arrakis, installing an Emperor whose fear of House Atreides would eventually undo him too. Imperial succession, it turned out, spared no one. Not even a father's own throne was safe from a son patient enough to want it.",
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
                    DetailedHistory = "House Harkonnen judged Abulurd too gentle to rule, too soft-hearted by the family's own brutal standard, and stripped him of leadership outright. They exiled him to Lankiveil, a modest whale-fur world, and the humiliation echoed through the family for generations. Abulurd's kindness was genuine, his refusal to rule by cruelty a real conviction, not a failing, and that made his exile an ideological rejection as much as a political one. His son Vladimir grew up under the weight of that family shame and spent his whole life overcorrecting for it, building a reputation on calculated cruelty his father never would have chosen. The quiet, humble life Abulurd made for himself on Lankiveil stood, ever after, as proof of the path House Harkonnen refused to walk.",
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
                    DetailedHistory = "A wasting plague was killing Raquella Berto-Anirul, and none of the fledgling Sisterhood's proctors had a cure for it. Her acolytes gambled everything on a last-resort poison, not out of confidence, but from having nothing else left to try. Her body did something no one expected: it turned the poison against itself, and in the process opened her mind to the accumulated memory of every woman in her bloodline before her. No Reverend Mother transformation had ever happened before this one. The whole Bene Gesserit Sisterhood grew from that single miracle, later formalized into the ritual ingestion of the Water of Life that every Reverend Mother since has faced. Raquella's survival, as the order's first Mother Superior, gave the young Sisterhood the one ability its entire structure, training, and political reach would be built on for ten thousand years.",
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
                    DetailedHistory = "The Butlerian Jihad orphaned Gilbertus Albans, and the robot philosopher Erasmus raised him in secret, a living experiment in what a human mind could become. His education steeped him in the exact machine logic and computational rigor the wider Jihad was fighting to erase. He did not let that strange, compromising childhood brand him a traitor. He built something new from it instead: the Mentat School, an institution built to train human minds for the computational work the banned thinking machines once performed. Nobody understood machine-like precision in a human skull better than a man raised by a machine, and Gilbertus pushed that understanding right to the edge of the Butlerian Doctrine without ever crossing it. Ten thousand years later, the school he founded runs largely unchanged, proof of how far his strange upbringing ended up serving the very species it should have betrayed.",
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
                    DetailedHistory = "Josef Venport descended directly from Norma Cenva, the inventor whose Holtzman research reshaped the Imperium, and he built his family's legacy into hard commercial power. His company, Venport Holdings, moved early and aggressively into the melange trade and the new interstellar transport routes that Holtzman technology had only just made possible, staking a claim before bigger institutions could lock the market down. The Spacing Guild and CHOAM eventually grew into the dominant forces they would remain for millennia, and much of the infrastructure Venport built got folded straight into their expanding reach. His career made one thing clear: the earliest movers in the post-Jihad economy, small as their start might be, could shape institutions that would run Imperial commerce for ten thousand years.",
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
                    DetailedHistory = "Schwangyu belonged to the cautious wing of the Bene Gesserit, a proctor who trusted institutional protocol over improvisation, and she wanted the recovered Duncan Idaho ghola raised by the book. Miles Teg preferred his own instincts, and the two clashed again and again over how the boy should be protected and taught. Real disagreement sat underneath the friction: how much risk the Sisterhood should tolerate, and how much to trust one commander's judgment over established procedure. Millennia of shared training had not, it turned out, produced a single mind. Schwangyu's caution carried real merit, whatever its costs, and it stayed in constant tension with the instincts that would later prove essential to keeping the ghola alive against Tleilaxu and Honored Matre plots.",
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
                    DetailedHistory = "Bronso of Ix grew up alongside Paul Atreides, close enough to watch the man behind the myth, and the jihad fought in Paul's name disillusioned him more with every year. He used his education and his standing to research and write a history of Muad'Dib's rule that broke sharply from the official line. His account cut against both the Qizarate's managed propaganda and Princess Irulan's gentler chronicles, weighing the jihad's devastation heavier than its religious justification. Publishing it was dangerous. The Qizarate held near-total authority over what could be said about Muad'Dib, and Bronso's willingness to defy that authority took real courage. What he left behind gave later generations something rare: a firsthand account written against the myth, not for it.",
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
                    