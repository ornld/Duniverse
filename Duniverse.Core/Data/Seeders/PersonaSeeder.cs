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
                    AffiliationIds = new List<string>(),
                    Role = "",
                    NotableQuotes = new List<string>()
                },
                */
                new Persona
                {
                    Id = "char_PaulAtreides",
                    Name = "Paul Atreides",
                    // The names he answers to inside Dune itself. His later name is a
                    // revelation in its own right and is deliberately not listed here.
                    Aliases = new List<string> { "Muad'Dib", "Usul", "Lisan al-Gaib", "Kwisatz Haderach" },
                    ShortDescription = "The prophesied Kwisatz Haderach who became Emperor of the Known Universe.",
                    DetailedHistory = "Paul was the son of Duke Leto Atreides and Lady Jessica, who trained him in secret in the Bene Gesserit arts. On the surface he was a Great House heir. Underneath, he was a boy drilled in Mentat logic, sword work, and the Sisterhood's harsh mental discipline. House Atreides fell within weeks of taking Arrakis. The Harkonnens and Sardaukar struck together, and Paul and his mother fled into the deep desert. The Fremen took them in. Skill, prescience, and a prophecy planted generations before his birth carried him up through their ranks until he led them as Muad'Dib. He took Arrakeen, broke Emperor Shaddam IV, and claimed the Golden Lion Throne. But the jihad fought in his name spread across the galaxy and swallowed billions of lives. He saw the slaughter coming and could never quite stop it. He was the Kwisatz Haderach the Bene Gesserit had bred toward for generations. He was the first mind able to hold both male and female ancestral memory, and to see further than any prescient being before him. That gift made him the most powerful man in the Imperium. It made him its prisoner too. In the end he chose the desert and exile over ruling as the mask for a faith that had slipped from his hands.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LadyJessica", "char_DukeLetoAtreides", "char_Chani", "char_Stilgar", "char_GurneyHalleck", "char_ThufirHawat", "char_DuncanIdaho", "char_AliaAtreides", "char_PrincessIrulan", "char_FeydRautha", "char_HasimirFenring" },
                    Affiliation = "House Atreides",
                    // Fremen as well: he was sworn into Sietch Tabr as Usul and ended up leading them.
                    AffiliationIds = new List<string> { "house_Atreides", "org_Fremen" },
                    Role = "Emperor",
                    NotableQuotes = new List<string> { "Fear is the mind-killer. Fear is the little-death that brings total obliteration." }
                },
                new Persona
                {
                    Id = "char_LadyJessica",
                    Name = "Lady Jessica",
                    ShortDescription = "Bene Gesserit sister, concubine to Duke Leto, and mother to Paul and Alia.",
                    DetailedHistory = "The Bene Gesserit trained Jessica from girlhood and placed her as concubine to Duke Leto Atreides. It was one more move in the Sisterhood's long breeding scheme. Her orders were plain. She was to bear only daughters, so a carefully arranged genetic cross could close out a generation later. She loved Leto, and that love broke the order. She gave him a son instead. Paul arrived a full generation ahead of the Sisterhood's timetable, and set loose consequences they never saw coming. House Atreides fell not long after. Among the Fremen, Jessica underwent the Water of Life, a ritual that could easily have killed her. Instead it made her a Reverend Mother, carrying the inherited memory of countless women before her. She was pregnant with Alia at the time, and the same change reached her daughter in the womb. Her counsel, her discipline, and her sharp political sense drove much of Paul's rise. Few figures worked so much history from behind a throne that was never their own.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_DukeLetoAtreides", "char_AliaAtreides", "char_GaiusHelenMohiam", "char_FaradnCorrino" },
                    Affiliation = "Bene Gesserit",
                    // The Sisterhood only. She ran the Atreides household as Leto's Lady, but she
                    // was never of the House, and the roster says who belongs rather than who served.
                    AffiliationIds = new List<string> { "org_BeneGesserit" },
                    Role = "Reverend Mother",
                    NotableQuotes = new List<string> { "I must not fear." }
                },
                new Persona
                {
                    Id = "char_DukeLetoAtreides",
                    Name = "Duke Leto Atreides",
                    ShortDescription = "The honorable head of House Atreides.",
                    DetailedHistory = "The Landsraad called him 'Leto the Just,' a name earned through decades of honorable, humane rule. That reputation grew too popular for comfort. It was why Emperor Shaddam IV handed him the Arrakis fief. Leto took the assignment knowing it smelled like a trap. It was one. His Suk physician, Dr. Wellington Yueh, had been blackmailed through the kidnapping of his wife. Yueh disabled House Atreides' shields at the exact moment Harkonnen and Sardaukar forces struck Arrakeen together. Leto refused to go quietly. He had hidden a poison gas capsule in a false tooth, a last gambit to kill Baron Harkonnen at close range. He died attempting it. His death drove his son Paul and his wife Jessica into the open desert. That flight would eventually bring down every House responsible for his ruin. The memory of an honorable duke undone by treachery became a cornerstone of the Atreides legend. Paul carried it with him into his own reign.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LadyJessica", "char_PaulAtreides", "char_ThufirHawat", "char_GurneyHalleck", "char_DuncanIdaho", "char_WellingtonYueh", "char_DukePaulusAtreides", "char_RhomburVernius" },
                    Affiliation = "House Atreides",
                    AffiliationIds = new List<string> { "house_Atreides" },
                    Role = "Duke",
                    NotableQuotes = new List<string> { "A person needs new experiences. They jar something deep inside, allowing him to grow." }
                },
                new Persona
                {
                    Id = "char_BaronHarkonnen",
                    Name = "Vladimir Harkonnen",
                    Aliases = new List<string> { "Baron Harkonnen", "The Baron" },
                    ShortDescription = "The ruthless and cunning head of House Harkonnen.",
                    DetailedHistory = "Vladimir Harkonnen was grotesquely fat and endlessly scheming. He clawed his family back onto the Arrakis fief through a conspiracy built with Emperor Shaddam IV. It took disguised Sardaukar troops, a bought physician in Dr. Yueh, and a single devastating strike that crushed House Atreides. The Baron handed Arrakis first to his brutal nephew Rabban. He planned to hand it next to the sharper, more presentable Feyd-Rautha. The point was to bleed the planet dry, then groom a false savior to replace Rabban's tyranny with the appearance of mercy. Suspensors carried his enormous body wherever he wished to go, a fitting crutch for a man built from indulgence, cruelty, and a real appetite for manipulation. His boast of plans within plans within plans became shorthand for everything Harkonnen scheming stood for. His reign of terror over Arrakis ended at the hands of his own granddaughter. Alia Atreides killed him during the battle for Arrakeen, closing out a blood feud that had simmered between the two Houses for generations.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_FeydRautha", "char_GlossuRabban", "char_PiterDeVries", "char_ShaddamIV", "char_AliaAtreides", "char_AbulurdHarkonnen" },
                    Affiliation = "House Harkonnen",
                    AffiliationIds = new List<string> { "house_Harkonnen" },
                    Role = "Baron",
                    NotableQuotes = new List<string> { "Observe the plans within plans within plans." }
                },
                new Persona
                {
                    Id = "char_Chani",
                    Name = "Chani",
                    ShortDescription = "Fremen warrior and Paul Atreides's concubine.",
                    DetailedHistory = "Chani was the daughter of Liet-Kynes, the Imperial Planetologist who secretly led the Fremen. She grew up carrying his ecological dream for Arrakis and the hard desert skills that made her people so dangerous. When Paul arrived among the Fremen, she became his guide. She taught him sietch life and the ways of the open sand. What started as instruction deepened into a devotion neither of them ever let go of, political marriage to Princess Irulan or not. She fought as a Fedaykin in her own right and rode with his forces as the desert turned on the Harkonnens. When the Imperium was settled she was denied the title of wife, which went to Shaddam's daughter as part of the bargain for the throne. Everyone involved understood which of the two women Paul had actually chosen, including, in time, the one who held the title.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.DuneMessiah, "She bore him twins and died doing it. Paul had seen it coming for years and had gone on choosing it anyway, which was the private arithmetic underneath his whole reign, and losing her was the thing that finally broke his willingness to keep making that trade."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_LietKynes", "char_LetoIIAtreides", "char_GhanimaAtreides", "char_Stilgar" },
                    Affiliation = "Fremen",
                    // Fremen only. Being Paul's consort tied her to the Atreides, but it never
                    // made her one of them, and the Imperium never let her hold the title either.
                    AffiliationIds = new List<string> { "org_Fremen" },
                    Role = "Fedaykin",
                    NotableQuotes = new List<string> { "Tell me of your homeworld, Usul." }
                },
                new Persona
                {
                    Id = "char_Stilgar",
                    Name = "Stilgar",
                    ShortDescription = "Naib of Sietch Tabr and a fiercely loyal Fremen leader.",
                    DetailedHistory = "Stilgar ruled Sietch Tabr as Naib, and he took Paul and Lady Jessica in after they fled into the desert with House Atreides in ruins behind them. He doubted the off-worlders at first, but Paul's growing mastery of Fremen ways wore that doubt down fast. Custom said Paul would have to kill him to take the tribe, and Paul refused, finding a way to lead without spilling the water of a friend. That refusal bound Stilgar to him harder than any duel would have. His pragmatism and his command of the desert made him the sharpest weapon the Fremen had against the Harkonnens, and he lent the cause his own authority and the trust of his people. Fremen tradition pulled at him from one side, and the religious fervor rising around Muad'Dib pulled from the other. Through all of it, Stilgar stayed one of the steadiest, most loyal men in the entire Atreides story.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.DuneMessiah, "He served the empire his own sietch had made and liked it less with every year of it. The desert had raised him for scarcity and plain dealing, and it left him a courtier in a government built on a religion he could neither fully believe nor bring himself to doubt aloud."),
                        new(SpoilerTier.ChildrenOfDune, "After Paul walked into the sand, Stilgar stayed to guard the twins through Alia's regency, holding a post he had never wanted on behalf of a House he had sworn himself to when its heir was a boy still learning to walk a dune face. Fremen custom pulled one way and what Arrakis was turning into pulled the other. He answered the older claim."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_Chani", "char_Otheym", "char_Korba", "char_GaiusHelenMohiam", "char_Edric" },
                    Affiliation = "Fremen",
                    AffiliationIds = new List<string> { "org_Fremen" },
                    Role = "Naib",
                    NotableQuotes = new List<string> { "Siridar, I am a simple man. I know only the desert." }
                },
                new Persona
                {
                    Id = "char_DuncanIdaho",
                    Name = "Duncan Idaho",
                    ShortDescription = "Swordmaster of the Ginaz and fiercely loyal retainer to House Atreides.",
                    DetailedHistory = "Duncan Idaho trained as a Swordmaster at the legendary academy on Ginaz and gave House Atreides the whole of that skill. Duke Leto trusted him enough to send him to the Fremen as an envoy, and he came back with something no Atreides agent had managed: their respect. Stilgar spoke his name with regard, which counted for more on Arrakis than any treaty did. He taught Paul the blade alongside Gurney Halleck and Thufir Hawat, and the boy grew up counting him a friend rather than a retainer. When the Harkonnens took Arrakeen and Sardaukar ran Paul and Lady Jessica to ground in the desert, Duncan held the door and bought them the minutes they needed. He did not walk away from it.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.DuneMessiah,
                            "That should have been the end of him. The Bene Tleilax recovered what was left of the body and grew it again as a ghola they named Hayt, a man wearing Duncan's face with none of Duncan's past behind it. They presented him to Paul as a gift, which fooled nobody, and buried a compulsion under his conditioning meant to turn him against the Emperor at the moment grief left him open to it. The memories came back in time, and the loyalty with them, which turned out to be the harder of the two to kill."),
                        new(SpoilerTier.GodEmperorOfDune, "The Tleilaxu grew him again, and then again, and did not stop. Across thirty-five centuries Leto II called Duncan after Duncan out of the tanks, each one raised to serve an Emperor who had long since stopped being recognisably human, each one measured against the memory of the first man his ancestor ever called friend. Some lasted years and some lasted days. Nearly every one of them eventually looked at what the God Emperor had become and refused it, which appears to have been the point of sending for them."),
                        new(SpoilerTier.HereticsOfDune, "Long after that reign ended the Tleilaxu were still making him and the Bene Gesserit were still buying. The Duncan the Sisterhood woke into their war with the Honored Matres carried more lives behind his eyes than anyone had counted on, and turned out to be something neither his makers nor his keepers had planned for."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_PaulAtreides", "char_LadyJessica", "char_Scytale", "char_MilesTeg", "char_DarwiOdrade", "char_Murbella", "char_SionaAtreides", "disc_GholaCultivation", "bio_Futar" },
                    Affiliation = "House Atreides",
                    // He trained at Ginaz before he ever wore Atreides colors, and the school still claims him.
                    AffiliationIds = new List<string> { "house_Atreides", "org_SwordmastersOfGinaz" },
                    Role = "Swordmaster",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_GurneyHalleck",
                    Name = "Gurney Halleck",
                    ShortDescription = "Warmaster for House Atreides and skilled troubadour.",
                    DetailedHistory = "Gurney Halleck came up scarred in the Harkonnen slave pits and turned loyal Atreides retainer. He served as Duke Leto's Warmaster, training young Paul in swordsmanship and combat discipline. He nurtured the boy's love of music through the baliset besides. After House Atreides fell, Gurney fell in with smugglers working the fringes of Harkonnen control. He used his skills to survive and nursed a burning desire for vengeance the whole time. His reunion with Paul among the Fremen came after a tense, nearly fatal misunderstanding involving Lady Jessica. It restored him to Atreides service. There his blunt honesty and battle-hardened wisdom made him an indispensable advisor through Paul's rise to power. Gurney was equally at home reciting poetry or leading a charge. That blend of brutal combat skill and real artistic feeling made him one of the most memorable and loyal figures in the whole Atreides household.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_PaulAtreides", "char_ThufirHawat" },
                    Affiliation = "House Atreides",
                    AffiliationIds = new List<string> { "house_Atreides" },
                    Role = "Warmaster",
                    NotableQuotes = new List<string> { "Mood's a thing for cattle or making love or playing the baliset. It's not for fighting." }
                },
                new Persona
                {
                    Id = "char_ThufirHawat",
                    Name = "Thufir Hawat",
                    ShortDescription = "Mentat and Master of Assassins for House Atreides.",
                    DetailedHistory = "Thufir Hawat was a Mentat of extraordinary skill. He served three successive generations of Atreides dukes as strategic advisor and Master of Assassins. His human-computer mind made him indispensable to the House's survival in a dangerous Imperium. The Harkonnens captured him after the fall of Arrakeen. Through subtle poisoning and misinformation, they steered him into believing Lady Jessica was the true traitor within House Atreides. The twisted Mentat Piter De Vries built that deception to turn Hawat's loyalty against itself. It never fully took. Hawat kept working against his captors from within, using his position to sow discord and gather intelligence for Paul's cause. In the end they gave him a poisoned choice: kill Paul or die himself. Hawat chose death over betraying House Atreides. It was a final act of loyalty that confirmed the devotion he had carried through decades of service.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_PaulAtreides", "char_PiterDeVries", "char_BaronHarkonnen" },
                    Affiliation = "House Atreides",
                    // A Mentat School man, and the graduate the school itself points to.
                    AffiliationIds = new List<string> { "house_Atreides", "org_MentatSchool" },
                    Role = "Mentat",
                    NotableQuotes = new List<string> { "A popular man arouses the jealousy of the powerful." }
                },
                new Persona
                {
                    Id = "char_WellingtonYueh",
                    Name = "Dr. Wellington Yueh",
                    ShortDescription = "Suk doctor who betrayed House Atreides.",
                    DetailedHistory = "Dr. Wellington Yueh was a Suk-trained physician, bound by Imperial Conditioning that should have made betrayal neurologically impossible. He served House Atreides with apparent unwavering loyalty. Then Baron Harkonnen found the one lever that could break him: the kidnapping and torture of his beloved wife, Wanna. Faced with an impossible choice, Yueh disabled Castle Arrakeen's shields at the critical moment of the Harkonnen-Sardaukar assault. He delivered Duke Leto into his enemies' hands even as guilt and grief consumed him. His betrayal was never absolute. He secretly gave Leto a poisoned false tooth to kill Baron Harkonnen in a final act of vengeance, and he arranged Paul and Jessica's escape into the desert. His act shattered the Imperium's faith in Suk conditioning. It proved that even the most sacred, supposedly unbreakable safeguard could fail when the right pressure reached a person's deepest loves.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukeLetoAtreides", "char_BaronHarkonnen", "char_PiterDeVries" },
                    Affiliation = "Suk School",
                    AffiliationIds = new List<string> { "org_SukSchool" },
                    Role = "Physician",
                    NotableQuotes = new List<string> { "I am sorry, my Duke. But there is a thing I must do." }
                },
                new Persona
                {
                    Id = "char_AliaAtreides",
                    Name = "Alia Atreides",
                    ShortDescription = "Sister to Paul, known as St. Alia of the Knife, born a pre-born Abomination.",
                    DetailedHistory = "Alia was exposed to the Water of Life inside her mother's womb, during Jessica's Reverend Mother transformation. She was born already holding the ancestral memory of countless women before her, awake and aware in a way no infant should be. The Bene Gesserit had a word for what she was, and it was not a kind one: Abomination, the outcome their oldest rules existed to prevent. The Fremen read her strangeness differently and treated the child with a wary reverence. She grew fast in mind if not in body, speaking like a grown woman while still small enough to be carried. At the Battle of Arrakeen she reached the captive Baron Harkonnen and killed him with the poisoned needle of a gom jabbar before anyone thought to fear a child. The chroniclers would remember her as St. Alia of the Knife.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.DuneMessiah, "She grew into a power in her own right inside the empire her brother built: a saint with a working knife, a priesthood that treated her word as scripture, and a private conviction that she understood the machine of it all better than the man on the throne did."),
                        new(SpoilerTier.ChildrenOfDune, "When Paul walked into the desert she ruled as Regent for his children, and the crowd of lives she had been born holding finally closed over her. Of all of them it was the grandfather she had killed as an infant who found the opening. Alia ended as the instrument of House Harkonnen's oldest surviving appetite, wearing the face of a saint the Fremen still knelt to. The Bene Gesserit had been right about what she was from the beginning. They had simply never worked out what to do about it."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_LadyJessica", "char_BaronHarkonnen", "char_LetoIIAtreides", "char_GhanimaAtreides" },
                    Affiliation = "House Atreides",
                    AffiliationIds = new List<string> { "house_Atreides" },
                    Role = "St. Alia of the Knife",
                    NotableQuotes = new List<string> { "I am a messenger from Muad'Dib." }
                },
                new Persona
                {
                    Id = "char_ShaddamIV",
                    Name = "Shaddam IV",
                    ShortDescription = "The 81st Padishah Emperor of House Corrino.",
                    DetailedHistory = "Shaddam IV was the 81st Padishah Emperor of House Corrino. He came to the throne after quietly arranging the death of his own father, Elrood IX. He ruled with growing anxiety over any Great House whose popularity or military strength might threaten Corrino supremacy. He feared Duke Leto Atreides' rising influence and formidable fighting corps. So he conspired in secret with Baron Harkonnen to destroy House Atreides once it took the Arrakis fief. He deployed his elite Sardaukar troops disguised as Harkonnen reinforcements, in direct violation of the Great Convention. The gambit backfired badly. Paul Atreides, the very heir he had tried to eliminate, survived to lead a Fremen army. That army shattered his supposedly invincible legions and toppled him from the Golden Lion Throne. Deposed and exiled to the harsh prison world of Salusa Secundus, Shaddam lived out his years as a humbled reminder. Ten thousand years of unbroken Corrino rule could end in a single, badly miscalculated betrayal.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PrincessIrulan", "char_BaronHarkonnen", "char_PaulAtreides", "char_FaradnCorrino", "char_HasimirFenring", "char_ElroodIX" },
                    Affiliation = "House Corrino",
                    AffiliationIds = new List<string> { "house_Corrino" },
                    Role = "Padishah Emperor",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_PrincessIrulan",
                    Name = "Princess Irulan",
                    ShortDescription = "Eldest daughter of Shaddam IV, chronicler of the Atreides Empire.",
                    DetailedHistory = "Princess Irulan was the eldest daughter of Emperor Shaddam IV, and a Bene Gesserit-trained historian in her own right. She became Paul Atreides' wife in name only, part of the political settlement that secured his claim to the Golden Lion Throne. It was a marriage of state. Paul's genuine devotion stayed with Chani. What she had instead was the record. She was a trained historian and a genuinely good writer, and she set about documenting the man who had taken her father's throne and left her a wife in name only. The accounts she produced shaped how most of the Imperium understood Muad'Dib, which meant the story of the Atreides reached posterity through the pen of the woman with the least reason to be generous about it. She was, by turns, admiring, propagandist, and quietly furious, sometimes in the same sentence.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.DuneMessiah, "The Sisterhood that raised her had not stopped giving her orders, and for a while she took them. She moved against Paul from inside his own household, which was as close as any of the conspirators managed to get."),
                        new(SpoilerTier.ChildrenOfDune, "What she became afterward was harder to have predicted. With Paul gone and Chani long dead, Irulan turned her whole formidable attention to keeping his children alive, and stayed at it through the years when almost nobody else in that household could be trusted to. The political hostage ended up one of the more reliable people the dynasty had."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_PaulAtreides", "char_GaiusHelenMohiam", "char_BronsoOfIx" },
                    Affiliation = "House Corrino",
                    // Corrino by birth, Bene Gesserit by training. She answers to both.
                    AffiliationIds = new List<string> { "house_Corrino", "org_BeneGesserit" },
                    Role = "Princess / Historian",
                    NotableQuotes = new List<string> { "A beginning is the time for taking the most delicate care that the balances are correct." }
                },
                new Persona
                {
                    Id = "char_GaiusHelenMohiam",
                    Name = "Gaius Helen Mohiam",
                    ShortDescription = "Bene Gesserit Reverend Mother and Imperial Truthsayer.",
                    DetailedHistory = "Gaius Helen Mohiam was a senior Bene Gesserit Reverend Mother and the Emperor's own Imperial Truthsayer. She administered the harrowing gom jabbar test to young Paul Atreides at Castle Caladan. It was one of the pivotal early moments that confirmed his extraordinary potential to the Sisterhood. As a key architect and enforcer of the breeding program, she maneuvered constantly across the Imperium's political landscape to protect the Sisterhood's plans. She had served as Lady Jessica's proctor herself. Her ambitions and manipulations ran well into Paul's reign as Emperor, when she became entangled in the conspiracy chronicled in Dune Messiah that sought to destabilize his rule. Mohiam's long career of cold, calculated service ended when Stilgar executed her after that plot was exposed. It was a stark end for one of the Bene Gesserit's most formidable operatives.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LadyJessica", "char_PaulAtreides", "char_Stilgar", "char_PrincessIrulan" },
                    Affiliation = "Bene Gesserit",
                    AffiliationIds = new List<string> { "org_BeneGesserit" },
                    Role = "Truthsayer",
                    NotableQuotes = new List<string> { "You've proven you're human. Now we must see if you are more than human." }
                },
                new Persona
                {
                    Id = "char_FeydRautha",
                    Name = "Feyd-Rautha Harkonnen",
                    ShortDescription = "The cunning nephew and intended heir of the Baron.",
                    DetailedHistory = "Baron Harkonnen groomed his nephew Feyd-Rautha from a young age to succeed the brutal Rabban as ruler of Arrakis. The plan was to present him as a merciful savior once Rabban's tyranny had exhausted the planet's population. Feyd-Rautha was cunning, ambitious, and every bit as ruthless as his uncle in his own way. As the Baron's chosen heir, he was set on a collision course with Paul Atreides once Paul returned to reclaim his father's fief. Their rivalry ended in a formal knife duel before the assembled Great Houses, staged as part of Paul's negotiations for the Golden Lion Throne. Feyd-Rautha tried to cheat his way to victory with a hidden poisoned needle. Paul's prescient awareness let him sense and counter the trick. He killed Feyd-Rautha and ended House Harkonnen's line of legitimate succession in a single stroke.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen", "char_GlossuRabban", "char_PaulAtreides", "char_MargotFenring" },
                    Affiliation = "House Harkonnen",
                    AffiliationIds = new List<string> { "house_Harkonnen" },
                    Role = "Na-Baron",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_GlossuRabban",
                    Name = "Glossu Rabban",
                    ShortDescription = "Known as 'Beast Rabban', the tyrannical nephew of the Baron.",
                    DetailedHistory = "Arrakis knew Glossu Rabban as 'Beast Rabban' for his casual brutality. His uncle Baron Harkonnen put him in charge of the planet on purpose. The instructions were to squeeze every possible resource from the population and instill deep, lasting hatred of Harkonnen rule at the same time. That cruelty served a longer-term plan. It prepared the ground for Feyd-Rautha to arrive later as an apparent liberator, his restraint made to look like mercy against the backdrop of Rabban's excesses. Rabban's heavy hand only deepened Fremen resentment and resistance. He strengthened the very insurgency that would later topple Harkonnen control of Arrakis entirely. Fremen fighters killed him during Paul's desert campaign. It was a fittingly violent end for a man whose whole governorship had been built on violence against the people he ruled.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen", "char_FeydRautha" },
                    Affiliation = "House Harkonnen",
                    AffiliationIds = new List<string> { "house_Harkonnen" },
                    Role = "Count",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_PiterDeVries",
                    Name = "Piter De Vries",
                    ShortDescription = "A twisted Mentat serving House Harkonnen.",
                    DetailedHistory = "Piter De Vries was a twisted Mentat whose formidable mind served House Harkonnen's darkest schemes. He engineered the intricate manipulation that broke Dr. Wellington Yueh's supposedly unbreakable Suk Conditioning. He turned one of the Imperium's most trusted physicians into the instrument of House Atreides' destruction. Most Mentats trained toward dispassionate logic in service of legitimate rule. De Vries reveled openly in cruelty instead, using his gifts to feed both the Baron's ambitions and his own taste for suffering. His plotting nearly delivered House Atreides intact into Harkonnen hands. His role in the conspiracy ended in Duke Leto's final act of defiance. Leto killed De Vries along with Baron Harkonnen's intended victims, using the poison gas concealed in his false tooth. De Vries stood as a dark mirror to Mentats like Thufir Hawat. The same discipline that produced loyal, brilliant advisors could just as easily be turned toward betrayal and cruelty.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen", "char_WellingtonYueh", "char_DukeLetoAtreides", "char_ThufirHawat" },
                    Affiliation = "House Harkonnen",
                    // No Mentat School for him. A twisted Mentat is Tleilaxu-made, which is rather the point.
                    AffiliationIds = new List<string> { "house_Harkonnen" },
                    Role = "Twisted Mentat",
                    NotableQuotes = new List<string> { "It is by will alone I set my mind in motion." }
                },
                new Persona
                {
                    Id = "char_LietKynes",
                    Name = "Liet-Kynes",
                    // "Liet" alone is already inside the display name, so it needs no entry here.
                    Aliases = new List<string> { "The Imperial Planetologist" },
                    ShortDescription = "Imperial Planetologist and secret leader of the Fremen.",
                    DetailedHistory = "In public, Liet-Kynes was the Imperial Planetologist assigned to Arrakis. In secret, he used that position to carry on his father Pardot's generations-long project: turning the desert planet into a water-rich world. He recruited the Fremen themselves into the patient, hidden work required to make it happen. As Chani's father, Kynes kept close ties to both the sietches and the Imperial administration. That made him a critical, if quiet, ally to Duke Leto Atreides once the Duke arrived on Arrakis. When House Atreides fell to the Harkonnen-Sardaukar assault, Kynes's loyalty to the Atreides cause made him a liability the Harkonnens would not tolerate. They abandoned him in the open desert without proper equipment and left him to die in a spice blow rather than execute him outright. His death did not end his influence. The ecological vision and the secret Fremen alliance he had built over decades passed straight into the movement that would carry Paul Atreides to power.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Chani", "char_DukeLetoAtreides", "char_PaulAtreides", "char_PardotKynes" },
                    Affiliation = "Imperial Court / Fremen",
                    // The Imperial Court half of his affiliation has no record here to point at.
                    AffiliationIds = new List<string> { "org_Fremen" },
                    Role = "Planetologist",
                    NotableQuotes = new List<string> { "The highest function of ecology is understanding consequences." }
                },
                new Persona
                {
                    Id = "char_Scytale",
                    Name = "Scytale",
                    ShortDescription = "A Tleilaxu Face Dancer involved in the conspiracy against Paul.",
                    DetailedHistory = "Scytale was a Tleilaxu Face Dancer, able to remake his face and body into someone else's, and he carried the Bene Tleilax's share of the conspiracy against Emperor Paul Atreides. The cleverest piece of that plot was his: the ghola Hayt, Duncan Idaho grown again in a tank and handed to Paul as a gift, a weapon built to work on the Emperor from inside his own household. Paul accepted it knowing roughly what it was, which Scytale had counted on. When the rest of the conspiracy came apart, he dropped the subtlety and made his offer in person: Chani grown again from her own cells and returned to Paul alive, in exchange for the empire. It was aimed squarely at the one loss Paul could not reason his way past, and he refused it anyway. Blind, borrowing the eyes of his newborn son, Paul killed him with a thrown knife.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.HereticsOfDune, "The Bene Tleilax never treated the death of a Master as final. Their Masters continued as serial gholas, each new body grown from the last and woken into the memories of every life before it, an immortality they kept strictly for themselves and never once put on the market. The arrangement ran quietly for thousands of years. It ended badly when the Honored Matres came back out of the Scattering and went through the Tleilaxu worlds one after another."),
                        new(SpoilerTier.Chapterhouse, "One Master came through that: a Scytale who still remembered the knife Paul threw and everything he had done to earn it. The Bene Gesserit took him and held him aboard a no-ship, where he had exactly one thing left worth trading, the secret his people had guarded above all others, which was how the axlotl tanks actually worked. He held out a long while before selling any of it. The whole time he carried a nullentropy capsule buried in his own chest, packed with cells taken from a long roll of the famous dead, insurance for a future he fully intended to be present at. He spent the war as he had spent most of his existence, a prisoner of someone stronger, working out patiently what he could sell them next."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DuncanIdaho", "char_PaulAtreides", "char_Edric", "disc_GholaCultivation" },
                    Affiliation = "Bene Tleilax",
                    AffiliationIds = new List<string> { "org_BeneTleilax" },
                    Role = "Face Dancer",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Edric",
                    Name = "Edric",
                    ShortDescription = "A Spacing Guild Steersman who plotted against Muad'Dib.",
                    DetailedHistory = "Edric was a Guild Steersman, his body so transformed by lifelong melange exposure that little about him still looked human. He used his own limited prescience in the conspiracy against Emperor Paul Atreides, clouding the plotters' actions from Paul's prescient vision. His involvement tied the Spacing Guild directly to the plot chronicled in Dune Messiah. The Guild feared an Emperor whose visionary power threatened their long-standing monopoly on safe interstellar navigation. Edric was confident he could hide from Paul's sight. It was a fatal miscalculation. The depth and reach of Paul's own prescience ran past whatever protection the conspirators thought they had. Once the plot's failure was clear, Stilgar had Edric executed. That ended the Guild's direct part in one of the most dangerous plots against Muad'Dib's rule.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_GaiusHelenMohiam", "char_Scytale", "char_Stilgar" },
                    Affiliation = "Spacing Guild",
                    AffiliationIds = new List<string> { "org_SpacingGuild" },
                    Role = "Steersman",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Korba",
                    Name = "Korba",
                    ShortDescription = "Former Fedaykin who became a high priest of the Qizarate.",
                    DetailedHistory = "Korba was once a devoted Fedaykin who fought at Paul's side during the desert years. He rose within the Qizarate as Paul's religion hardened into a sprawling bureaucratic empire. He traded the simplicity of desert loyalty for the ambition and intrigue of religious administration. In time he decided that Paul's death as a martyr would serve the faith, and his own position within it, better than Paul's continued rule. So he became entangled in a plot to assassinate the Emperor he had once served without question. His scheme was exposed before it could succeed. It revealed how far the religious machinery built around Muad'Dib had already begun to outgrow, and even threaten, the man it was meant to honor. Korba's execution was a pointed reminder. The Qizarate's growing power made it as dangerous to Paul as any foreign enemy.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_Stilgar" },
                    Affiliation = "Qizarate",
                    // A Fremen Fedaykin long before he was a priest, and he never stopped being one.
                    AffiliationIds = new List<string> { "org_Qizarate", "org_Fremen" },
                    Role = "Panegyrist",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Otheym",
                    Name = "Otheym",
                    ShortDescription = "A trusted Fremen Fedaykin.",
                    DetailedHistory = "Otheym was a trusted Fremen Fedaykin who served Paul faithfully through the desert years and the jihad that followed. He embodied the fierce loyalty that bound Paul's original desert companions to him long after his rise to Emperor. In the events chronicled in Dune Messiah, Otheym contracted a debilitating disease the Tleilaxu had engineered on purpose, part of the wider conspiracy against Paul's rule. His suffering was meant as one more pressure point against the Emperor he served. His health was failing fast. Even so, Otheym still passed Paul crucial information through his Tleilaxu-conditioned dwarf, Bijaz, whose coded riddles helped expose key parts of the plot. He endured suffering and betrayal from his own body to help uncover the conspiracy. It showed how deep the devotion of Paul's original Fremen companions ran, even as his empire grew more perilous.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Stilgar", "char_PaulAtreides" },
                    Affiliation = "Fremen",
                    AffiliationIds = new List<string> { "org_Fremen" },
                    Role = "Fedaykin",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_LetoIIAtreides",
                    Name = "Leto II Atreides",
                    ShortDescription = "Son of Paul and Chani, the pre-born heir who traded his humanity for the Golden Path.",
                    DetailedHistory = "Leto II was born pre-born like his twin sister Ghanima, awake in the womb and carrying the memory of every ancestor behind him. He watched what that same inheritance did to their aunt Alia, so he learned early what waited for him if he handled it badly. A spice ordeal at Jacurutu pushed him through into the vision his father Paul had already seen and turned away from: one narrow line by which the species survives itself, the Golden Path, which needed a ruler willing to outlive everyone who would come to hate him. He went into the deep desert and let the sandtrout cover him. The living skin they made gave him strength and speed no human body could answer and a life measured in millennia, and it cost him the body itself, since the change ran one way and would keep running. He came back out of the sand, ended Alia's regency, and took the Golden Lion Throne as a boy. He married Ghanima for the record and set Farad'n Corrino beside her to father her children, which kept the human half of the line moving without him in it. He told what was left of his family plainly what he intended: to rule for thousands of years and hold humanity so still, so safe and so thoroughly bored that it would never again put itself in the hands of anything that could see the future.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.GodEmperorOfDune, "The reign ran three and a half thousand years, and his subjects settled on God Emperor because nothing else in their vocabulary fit. He gave them peace and meant it as a punishment: one government, no war worth the name, every road on the map already walked, until being safe curdled into an appetite for anywhere else. He ruled through an army of women called Fish Speakers and a majordomo, Moneo, whose line he had bred for the post, and he kept calling fresh Duncan Idaho gholas out of the Tleilaxu tanks for the company of someone who would still argue with him. The longer project was a human his own prescience could not find, and it arrived as Moneo's daughter Siona, who hated him with precisely the force the design required. She gave the order that brought the bridge down under his wedding procession, and Leto went into water his skin could not survive."),
                        new(SpoilerTier.HereticsOfDune, "He came apart into sandtrout, which started the desert over, and the humanity he had penned in one place for thirty-five centuries went outward all at once. Fifteen centuries later every worm on the world that had been Arrakis carried a pearl of his awareness, dreaming and long past doing anything about it. The blindness to prescience he had bred was loose in the population by then and past recall, which had been the whole object. He arranged both outcomes several thousand years in advance, which is the pattern his record keeps showing wherever anyone picks it up."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_Chani", "char_GhanimaAtreides", "char_AliaAtreides", "char_MoneoAtreides", "char_SionaAtreides", "char_HwiNoree", "org_FishSpeakers" },
                    Affiliation = "House Atreides",
                    // The Fish Speakers are his own corps, so he heads their roster.
                    AffiliationIds = new List<string> { "house_Atreides", "org_FishSpeakers" },
                    Role = "Emperor",
                    NotableQuotes = new List<string> { "I am a collection of obsolete memories." }
                },
                new Persona
                {
                    Id = "char_GhanimaAtreides",
                    Name = "Ghanima Atreides",
                    ShortDescription = "Daughter of Paul and Chani, twin sister to Leto II.",
                    DetailedHistory = "Like her twin brother Leto II, Ghanima was born pre-born, carrying the full ancestral memory of countless lives before she drew a first breath. That inheritance had already destroyed their aunt Alia, whose mind gave way to the ego-memory of Baron Vladimir Harkonnen. Ghanima held the same crowd of lives at bay through discipline alone. As a child she came through the Laza tiger attack Wensicia Corrino arranged to kill both twins, and afterward she conditioned herself to believe her brother was dead, deep enough that a Truthsayer would have found nothing in her but grief. Undoing that belief later proved nearly as dangerous as carrying it. When Leto walked out of the desert wearing a skin of living sandtrout and took the throne, he settled her future by decree: married to him for the record, companioned in fact to Farad'n Corrino. That one arrangement ended the last Corrino claim and put the continuation of the Atreides line in her keeping rather than his. The chronicles gave her brother the legend and gave Ghanima a few lines, which is roughly the share she seems to have wanted.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.GodEmperorOfDune, "She lived out her years as the human half of a dynasty whose Emperor had stopped being human, and the children she had with Farad'n carried the Atreides line forward through the long reign that followed. Every Atreides her brother later bred, watched and used came down from her, Moneo and his daughter Siona among them. She was also among the last people alive who had known him before the sandtrout, and his own journals return to that more than once. He outlasted her by more than three thousand years."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_PaulAtreides", "char_Chani", "char_FaradnCorrino", "event_TigerAssassinationAttempt" },
                    Affiliation = "House Atreides",
                    AffiliationIds = new List<string> { "house_Atreides" },
                    Role = "Princess",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_FaradnCorrino",
                    Name = "Farad'n Corrino",
                    ShortDescription = "Grandson of Shaddam IV and the last Corrino claimant to the throne.",
                    DetailedHistory = "Farad'n Corrino was the grandson of Shaddam IV and the last credible Corrino claimant to the Golden Lion Throne. He grew up amid his mother Wensicia's ambitions to restore their family's fortunes. He received unexpected Bene Gesserit training from Lady Jessica herself, part of a plan to shape him into a suitable match for the Atreides twins. He was torn between the ambitions his upbringing instilled and the deeper wisdom his training revealed. In the end he abandoned his family's claim to the throne. He had come to see the conflict as futile against Leto II's overwhelming power. His surrender of the Sardaukar forces still loyal to House Corrino ended any credible challenge to Atreides rule from the old Imperial line. Taking the name Harq al-Ada, Farad'n became the mate of Ghanima Atreides. That union turned a would-be rival dynasty into a partner in securing the Atreides bloodline's future.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_GhanimaAtreides", "char_LadyJessica", "char_LetoIIAtreides" },
                    Affiliation = "House Corrino",
                    AffiliationIds = new List<string> { "house_Corrino" },
                    Role = "Prince",
                    NotableQuotes = new List<string>()
                },

                // ---- Dune Messiah / Children of Dune ----
                new Persona
                {
                    Id = "char_Bijaz",
                    Name = "Bijaz",
                    ShortDescription = "A Tleilaxu-conditioned dwarf whose songs and riddles conceal a deadly hypnotic trigger.",
                    DetailedHistory = "Bijaz was a Tleilaxu-made dwarf, small, quick with words, and built to be useful to whoever held him. He reached Paul Atreides by way of Otheym, an old Fedaykin dying in an Arrakeen slum, who handed the dwarf over as a living record: Bijaz was a distrans, and the names of the traitors inside Muad'Dib's own priesthood sat coded in his voice. The Tleilaxu had counted on the gift being accepted. Once he was inside the Keep he turned his songs and riddles on Hayt, the ghola of Duncan Idaho, and worked a compulsion in underneath the man's conditioning, built to turn him against Paul at the moment grief left him most open to it. Bijaz never pretended to be anything but a tool, and said so in rhymes to anyone who would listen. The compulsion held right up to the moment it was meant to work, and then the ghola's buried self surfaced instead. Bijaz tried the trigger words one last time in the room where the whole plot came apart, and Duncan Idaho killed him for it.",
                    ImagePath = "",
                    // The twins are deliberately not listed. Bijaz dies in the room where the
                    // conspiracy against Paul comes apart, so he never meets them; the links only
                    // existed to prop up a Children of Dune passage that turned out to be invented.
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "org_BeneTleilax" },
                    Affiliation = "Bene Tleilax",
                    AffiliationIds = new List<string> { "org_BeneTleilax" },
                    // Not a ghola: the Tleilaxu grew him, they did not regrow him from anyone.
                    // Hayt is the ghola in that plot, Scytale the Face Dancer, Bijaz the distrans,
                    // and the record's own text has called him a dwarf all along.
                    Role = "Tleilaxu Distrans",
                    // Left empty on purpose. The line that used to sit here could not be traced to
                    // anything Bijaz actually says, and a quotation nobody can source is worse than
                    // no quotation. His scenes are few, so a real one is a short skim away.
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_WensiciaCorrino",
                    Name = "Wensicia Corrino",
                    ShortDescription = "Shaddam IV's daughter, who plotted from Salusa Secundus to restore House Corrino to the throne.",
                    DetailedHistory = "Wensicia Corrino was the daughter of the deposed Emperor Shaddam IV. She never accepted her family's fall from the Golden Lion Throne. She spent years in exile on Salusa Secundus, quietly rebuilding influence and plotting a way back to power for her son Farad'n. She decided the last of the Atreides line had to be eliminated to clear the path for a Corrino restoration. So she orchestrated the Laza tiger assassination attempt against the young twins Leto II and Ghanima. The genetically bred predators were meant to make the killing look like misfortune, not conspiracy. Her scheme leaned heavily on the treacherous Fremen Naib Javid, secretly in her service. He used his position among the Fremen and his relationship with the possessed Alia to steer events her way. When the full extent of her plotting came to light, Wensicia's ambitions collapsed. It was House Corrino's last serious bid to reclaim the throne it had held for ten thousand years.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_FaradnCorrino", "char_Tyekanik", "char_Javid", "bio_LazaTiger", "event_TigerAssassinationAttempt" },
                    Affiliation = "House Corrino",
                    AffiliationIds = new List<string> { "house_Corrino" },
                    Role = "Princess / Conspirator",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Tyekanik",
                    Name = "Tyekanik",
                    ShortDescription = "Sardaukar Bashar loyal to House Corrino, torn between duty and conscience.",
                    DetailedHistory = "Tyekanik was a Sardaukar Bashar whose military career predated House Corrino's fall from the Golden Lion Throne. He stayed fiercely loyal to the family in exile. He served Wensicia Corrino as both military commander and personal advisor, and he tutored her son Farad'n in the martial traditions of their fading dynasty. Wensicia's schemes against the Atreides twins grew more ruthless over time. Tyekanik found himself torn between his oath of loyalty and a deepening unease about plots that targeted children. His genuine care for Farad'n's upbringing and his own soldier's code of honor made him, in the end, more principled than the conspiracy he had sworn to support. That tension shaped his whole role in House Corrino's final, failed bid for restoration. His quiet inner conflict reflected the moral exhaustion of a once-proud dynasty reduced to plotting against children to reclaim what it had lost.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_WensiciaCorrino", "char_FaradnCorrino", "org_Sardaukar" },
                    Affiliation = "House Corrino",
                    // A Sardaukar Bashar as much as a Corrino man.
                    AffiliationIds = new List<string> { "house_Corrino", "org_Sardaukar" },
                    Role = "Bashar",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Javid",
                    Name = "Javid",
                    ShortDescription = "A treacherous Fremen Naib secretly in service to House Corrino.",
                    DetailedHistory = "Javid presented himself as a loyal Fremen Naib and rose to become Alia Atreides' lover. He used the trust that position gave him to serve House Corrino's ambitions in secret, conspiring with the exiled Wensicia Corrino against the young Atreides twins. His intimate access to Alia came as Baron Harkonnen's ego-memory tightened its dangerous hold on her. He used it to bend her judgment and her decisions toward his true masters rather than House Atreides. His double life showed how far Alia's possession had eroded her ability to tell genuine loyalty from calculated exploitation. It left her open to exactly the kind of manipulation he specialized in. When his treachery came to light alongside the wider Corrino conspiracy, his punishment closed one of the more insidious betrayals to reach the heart of Atreides power.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_AliaAtreides", "char_WensiciaCorrino", "org_Fremen" },
                    Affiliation = "Fremen (secretly House Corrino)",
                    // Both at once, which is the whole of what makes him dangerous.
                    AffiliationIds = new List<string> { "org_Fremen", "house_Corrino" },
                    Role = "Naib / Conspirator",
                    NotableQuotes = new List<string>()
                },

                // ---- God Emperor of Dune ----
                new Persona
                {
                    Id = "char_MoneoAtreides",
                    Name = "Moneo Atreides",
                    ShortDescription = "Leto II's devoted majordomo and most trusted human servant during his millennia-long reign.",
                    DetailedHistory = "Moneo was a descendant of the Atreides line who came to understand the Golden Path better than almost anyone alive. He served as Leto II's steward and chief human administrator through much of the God Emperor's millennia-long reign. He ran the day-to-day governance of an empire built around his master's inscrutable, multi-generational plan. A childhood encounter with Leto's overwhelming presence had left him with a rare, hard-won grasp of both the necessity and the horror of the Golden Path. That made him uniquely able to serve Leto faithfully even when the God Emperor's demands turned terrifying. His devotion was tested constantly by his fear for his rebellious daughter Siona. Her defiance of Leto's rule put her in direct danger. Yet Moneo saw, with growing dread, that her genetic invisibility to prescience might be exactly what Leto had been breeding toward all along. His life sat between loyal service and a father's fear. It captured the human cost carried by those closest to Leto's inhuman, world-spanning ambitions.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_SionaAtreides", "org_FishSpeakers" },
                    Affiliation = "House Atreides",
                    // Ran the Fish Speakers day to day as Leto II's majordomo.
                    AffiliationIds = new List<string> { "house_Atreides", "org_FishSpeakers" },
                    Role = "Majordomo",
                    NotableQuotes = new List<string> { "The worm is God's mind, and it needs the freedom to wander in the wilderness." }
                },
                new Persona
                {
                    Id = "char_SionaAtreides",
                    Name = "Siona Atreides",
                    ShortDescription = "Moneo's rebellious daughter, proven immune to prescient sight and key to the Golden Path's fulfillment.",
                    DetailedHistory = "Siona Atreides ran an underground rebellion against Leto II's rule, and a raid she led on the Citadel cost most of her friends their lives to win her a pair of the God Emperor's sealed journals. Her father Moneo served as Leto's majordomo, and he warned her, repeatedly and to no effect, about exactly what she was walking toward. What none of the rebels understood was that Siona was the point: millennia of Atreides breeding had been aimed at producing a human no prescient eye could find. Leto tested her the way he tested everything, taking her into the Sareer and holding her there until she had looked at the Golden Path through his eyes. She came out of that desert hating him and carrying the trait anyway, which was the guarantee he had wanted all along. He then steered her toward the current Duncan Idaho ghola, on the sound reasoning that a trait locked inside one body protects nobody. She settled her own account on the Royal Road: the order to cut the bridge over the Idaho River during his wedding procession was hers, and the water finished what the fall began. The rebel became the instrument of the purpose she had spent her life fighting, and knowing it did not soften her opinion of him by a hair.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.HereticsOfDune, "Siona and that Duncan outlived him, and the line they started held. Their descendants went out with the Scattering, carrying the invisibility into populations nobody could count and no oracle could locate, which was the entire object of the exercise. Fifteen hundred years on, the Bene Gesserit were still tracing Atreides blood through their breeding records for that one property, and still buying Duncan Idaho gholas from the Tleilaxu to keep the other half of the pairing to hand. Their own best people came down from that stock, Miles Teg and Darwi Odrade among them."),
                    },
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_MoneoAtreides", "char_LetoIIAtreides", "char_DuncanIdaho", "theo_GoldenPath" },
                    Affiliation = "House Atreides",
                    AffiliationIds = new List<string> { "house_Atreides" },
                    Role = "Rebel Leader",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_HwiNoree",
                    Name = "Hwi Noree",
                    ShortDescription = "An Ixian-designed companion crafted to be the perfect match for the God Emperor.",
                    DetailedHistory = "Ixian designers engineered Hwi Noree to be the perfect companion for Leto II. She may have been a genuine diplomatic gift, a subtle instrument of influence, or both at once. She arrived at the God Emperor's court with origins deliberately shrouded in ambiguity. Her artificial design may explain the effect rather than undercut it. Either way, Hwi's warmth and compassion proved entirely real. She won Leto's love in a way that surprised even those who had engineered her to please him. Leto's court planned a wedding to cement his rule and cap his long reign, a piece of political theater meant to reassure a restless Imperium. Instead the ceremony became the occasion of his death. The rebellion led in part by Siona and a Duncan Idaho ghola ended the Golden Path's era of enforced peace at the very moment meant to celebrate it.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "house_Vernius", "event_DeathOfTheGodEmperor" },
                    Affiliation = "Ix",
                    // Ix has no record of its own, and House Vernius is the Ixian one she already links to.
                    AffiliationIds = new List<string> { "house_Vernius" },
                    Role = "Ambassador / Companion",
                    NotableQuotes = new List<string>()
                },

                // ---- Heretics of Dune / Chapterhouse: Dune ----
                new Persona
                {
                    Id = "char_MilesTeg",
                    Name = "Miles Teg",
                    ShortDescription = "A retired Bene Gesserit Bashar recalled to protect a new Duncan Idaho ghola from the Honored Matres.",
                    DetailedHistory = "Miles Teg was widely regarded as one of the finest military minds the Bene Gesserit ever produced. The Sisterhood drew him out of a comfortable retirement to guard a young Duncan Idaho ghola whose upbringing had become a matter of intense strategic importance. This came amid their war against the Honored Matres and their tangled dealings with the Bene Tleilax. Teg raised and protected the ghola by instinct, not by protocol. That put him repeatedly at odds with more traditional proctors like Schwangyu, who favored caution over his willingness to trust his own judgment. When the Honored Matres captured and tortured him, Teg unlocked a previously unknown human capacity for superhuman speed. It made him something closer to a living weapon than an ordinary man, old as he was. His final campaigns against the Honored Matres showed that even in his advancing years, Teg remained one of the most formidable and unpredictable assets the Bene Gesserit could field.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DarwiOdrade", "char_DuncanIdaho", "org_BeneGesserit", "org_HonoredMatres", "char_Schwangyu" },
                    Affiliation = "Bene Gesserit",
                    AffiliationIds = new List<string> { "org_BeneGesserit" },
                    Role = "Bashar",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_DarwiOdrade",
                    Name = "Darwi Odrade",
                    ShortDescription = "A Bene Gesserit Reverend Mother who rises to Mother Superior amid the war with the Honored Matres.",
                    DetailedHistory = "Darwi Odrade was raised inside the Bene Gesserit's own breeding program and hardened by dangerous field work across the Imperium. She grew into one of the Sisterhood's sharpest strategic minds. Her era brought the order its greatest existential threat: the returning Honored Matres. Odrade worked closely with figures like Miles Teg and under Mother Superior Taraza. Together they steered the Bene Gesserit's response to a conflict that could unravel millennia of careful planning in a matter of years rather than generations. She was willing to make difficult, sometimes ruthless decisions for the Sisterhood's survival. That set her apart even among a leadership steeped in calculated sacrifice. Her rise to Mother Superior put her at the helm exactly when the order most needed decisive leadership, as it moved toward an uneasy convergence with the very enemy that had driven it to the edge of extinction.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_MilesTeg", "char_Taraza", "char_Murbella", "org_BeneGesserit", "org_HonoredMatres" },
                    Affiliation = "Bene Gesserit",
                    AffiliationIds = new List<string> { "org_BeneGesserit" },
                    Role = "Mother Superior",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Sheeana",
                    Name = "Sheeana",
                    ShortDescription = "A young girl able to command sandworms, becoming a living prophet on Rakis.",
                    DetailedHistory = "As a young girl, Sheeana was found to hold an inexplicable, seemingly instinctive command over the great sandworms of Rakis. She quickly became a figure of immense religious and strategic weight in a galaxy still shaped by the legacy of Muad'Dib and the God Emperor. The Bene Gesserit were always alert to the political value of religious symbolism. They moved fast to bring her under their protection and guidance. Her bond with the worms made her the centerpiece of any effort to control Rakis's shifting religious meaning after the sandworms reappeared there. She could summon and ride the worms without any of the training or ritual the Fremen once required. That placed her in a lineage of desert-connected figures reaching back through Paul Atreides and Leto II, each of whom the desert itself seemed to answer in its own way. Her presence helped steady a religious landscape thrown into confusion by the God Emperor's death and the worms' unexpected return. It gave the Bene Gesserit a living symbol to rebuild order around.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "bio_ShaiHulud", "loc_Rakis", "theo_CultOfShaiHulud", "org_BeneGesserit" },
                    Affiliation = "Bene Gesserit",
                    AffiliationIds = new List<string> { "org_BeneGesserit" },
                    Role = "Worm-Rider / Prophet",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Murbella",
                    Name = "Murbella",
                    ShortDescription = "A former Honored Matre who merges with the Bene Gesserit to forge a new Sisterhood.",
                    DetailedHistory = "The Bene Gesserit captured Murbella during their desperate war against the Honored Matres. She then underwent an unprecedented cross-training. It fused the brutal efficiency of Honored Matre sexual-imprinting with the patient, disciplined arts of the Bene Gesserit Way. Neither order had ever managed that combination on its own. Her dual mastery made her uniquely suited to bridge the gap between the two orders, whose war had threatened to destroy them both rather than crown any victor. She did not simply defeat or absorb the Honored Matres. Her rise was a genuine synthesis, one that kept the strengths of both traditions and shed the worst excesses of each. Her ascension to lead a combined order ended the conflict that had driven humanity to Scatter in the first place. It forged a Sisterhood strong enough to face whatever unknown threat still lurked beyond the reach of the Old Imperium.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DarwiOdrade", "char_DuncanIdaho", "org_HonoredMatres", "org_BeneGesserit", "disc_HonoredMatreImprinting" },
                    Affiliation = "Honored Matres (later Bene Gesserit)",
                    // She ends up leading both orders, so both name her.
                    AffiliationIds = new List<string> { "org_HonoredMatres", "org_BeneGesserit" },
                    Role = "Mother Superior",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Taraza",
                    Name = "Alma Mavis Taraza",
                    ShortDescription = "Mother Superior of the Bene Gesserit during the opening of the war against the Honored Matres.",
                    DetailedHistory = "Alma Mavis Taraza was Mother Superior during the opening moves of the Bene Gesserit's war against the returning Honored Matres. She faced an unenviable task: preparing the Sisterhood for a threat unlike any in its long history. The enemy combined military conquest with a psychological weapon that could subvert the Bene Gesserit's own methods. Taraza was a master strategist in the truest Bene Gesserit tradition. She juggled the ongoing breeding program, an uneasy relationship with the secretive Tleilaxu, and the delicate recovery of a new Duncan Idaho ghola. She treated each as an interlocking piece of a plan she knew she would likely not live to see finished. She made hard, sometimes coldly calculated decisions. She trusted subordinates like Miles Teg and Darwi Odrade with responsibilities that would shape the Sisterhood's fate long after her death. It was the same patient, multi-generational thinking that had defined Bene Gesserit strategy for millennia. Her groundwork set the stage for the uneasy convergence between the Bene Gesserit and the Honored Matres, realized only under her successors.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_MilesTeg", "char_DarwiOdrade" },
                    Affiliation = "Bene Gesserit",
                    AffiliationIds = new List<string> { "org_BeneGesserit" },
                    Role = "Mother Superior",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Waff",
                    Name = "Waff",
                    ShortDescription = "A Tleilaxu Master whose religious convictions complicate his people's schemes.",
                    DetailedHistory = "Waff was a Tleilaxu Master caught up in the Bene Gesserit's maneuvers at the height of the conflict with the Honored Matres. He showed a side of Tleilaxu culture outsiders rarely glimpsed. Most assumed the order's genetic engineering was pure cold commercial or political calculation. Waff's genuine religious conviction ran deeper. It was rooted in the same heterodox faith that shaped all Tleilaxu ambition. That conviction complicated negotiations and alliances other factions expected to be purely transactional. It forced Bene Gesserit strategists to weigh motives they did not fully understand. Waff's presence in this critical period showed how deeply Tleilaxu belief was woven into even their most pragmatic scientific and political dealings. His dealings with figures like Miles Teg revealed a people driven as much by devout purpose as by the secretive, transactional reputation the wider Imperium pinned on them.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "org_BeneTleilax", "theo_TleilaxuFaith", "char_MilesTeg" },
                    Affiliation = "Bene Tleilax",
                    AffiliationIds = new List<string> { "org_BeneTleilax" },
                    Role = "Tleilaxu Master",
                    NotableQuotes = new List<string>()
                },

                // ---- Fenring (Dune / Dune Messiah) ----
                new Persona
                {
                    Id = "char_HasimirFenring",
                    Name = "Hasimir Fenring",
                    ShortDescription = "The Emperor's closest confidant, a failed Kwisatz Haderach, and one of the deadliest men in the Imperium.",
                    DetailedHistory = "Count Hasimir Fenring was a near-success of the Bene Gesserit's millennia-long breeding program. He had keen prescient instincts and heightened perception, but never the full power of the true Kwisatz Haderach the Sisterhood was working toward. That genetic near-miss left him uniquely able to recognize what Paul Atreides represented once the two men finally met. Fenring was Shaddam IV's most trusted friend, covert enforcer, and occasional assassin. He wielded influence across the Imperium far beyond his modest title as Count, working the shadows of Corrino power for decades. In the climactic moments of Dune, Fenring had the chance to kill Paul in a duel. He chose not to. He recognized a kinship in Paul, a fellow near-miss of the same grand genetic design, and found he could not act against it. That single moment of restraint came from an understanding no one else in the room could grasp. It altered the course of Imperial history as decisively as any battle.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "char_MargotFenring", "char_PaulAtreides", "house_Fenring", "org_BeneGesserit" },
                    Affiliation = "House Corrino",
                    // His own House first, then the Corrino throne he spent a lifetime serving.
                    AffiliationIds = new List<string> { "house_Fenring", "house_Corrino" },
                    Role = "Count / Imperial Confidant",
                    NotableQuotes = new List<string> { "He is one of us, Mohiam." }
                },
                new Persona
                {
                    Id = "char_MargotFenring",
                    Name = "Lady Margot Fenring",
                    ShortDescription = "A Bene Gesserit Reverend Mother and wife to Count Fenring, skilled in the Sisterhood's most delicate maneuvers.",
                    DetailedHistory = "Lady Margot Fenring was trained deeply in the Bene Gesserit Way and skilled in the Sisterhood's most delicate arts of persuasion. She carried out the order's breeding program alongside her husband, Count Hasimir Fenring. Theirs was a genuine partnership shot through with the calculated purpose that defined every Bene Gesserit marriage. Her most consequential act was the deliberate seduction of Feyd-Rautha Harkonnen. It preserved a valuable genetic line as a contingency, in case Paul Atreides' own bloodline failed to produce the outcome the Sisterhood needed. Margot moved seamlessly between real warmth and cold strategy. That made her a formidable presence in the Imperial court, trusted by her husband and respected, if not fully trusted, by the wider Bene Gesserit hierarchy. Her contingency work reflected the same patient, multi-generational thinking the order brought to nearly every major undertaking across the Imperium.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_HasimirFenring", "char_FeydRautha", "org_BeneGesserit", "house_Fenring" },
                    Affiliation = "Bene Gesserit",
                    // A Reverend Mother in her own right and the Lady of House Fenring.
                    AffiliationIds = new List<string> { "org_BeneGesserit", "house_Fenring" },
                    Role = "Reverend Mother",
                    NotableQuotes = new List<string>()
                },

                // ---- Legends of Dune (Butlerian Jihad era) ----
                new Persona
                {
                    Id = "char_VorianAtreides",
                    Name = "Vorian Atreides",
                    ShortDescription = "A hero of the Butlerian Jihad and the human ancestor from whom House Atreides takes its name.",
                    DetailedHistory = "Vorian Atreides was raised among the cymek Titans as the son of the ruthless cyborg lord Agamemnon. He grew up steeped in the machine-allied culture that ruled much of the Old Empire. That gave him rare insider knowledge of the Titans' and Omnius's inner workings. His defection to humanity's cause put that knowledge in the service of the League of Nobles. He became one of the Jihad's most trusted and effective heroes, fighting alongside Serena Butler against the machine empire that had raised him. Turning against the father who raised him, and against the machine intelligence that had come to dominate his adoptive family, cost him enormously. It severed him for good from the only world he had ever known. His descendants would go on to found House Atreides. They carried his name and, in a sense, his legacy of choosing humanity's difficult freedom over the machines' orderly control into ten thousand years of Imperial history.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_AgamemnonTitan", "char_SerenaButler", "org_LeagueOfNobles", "house_Atreides" },
                    Affiliation = "League of Nobles",
                    // The Atreides name starts with him, so the House roster starts there too.
                    AffiliationIds = new List<string> { "org_LeagueOfNobles", "house_Atreides" },
                    Role = "Jihad Hero",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_SerenaButler",
                    Name = "Serena Butler",
                    ShortDescription = "The humanitarian leader whose grief ignited the Butlerian Jihad against thinking machines.",
                    DetailedHistory = "Serena Butler was a humanitarian leader already respected across the fractured worlds of the League of Nobles. Her life changed forever when the independent robot philosopher Erasmus murdered her infant son. He did it as a cold, deliberate experiment to study human grief. The loss did not break her. She channeled her outrage into a unifying public cause, using her standing and moral authority to weld humanity's scattered, quarreling worlds into a single crusade against the machine empire. The movement she sparked became the Butlerian Jihad. That war spanned generations and finally shattered the Synchronized Worlds' hold over humanity. Her personal tragedy became a civilization-defining cause. It left behind the total prohibition of thinking machines that would shape every institution of the Imperium for the next ten thousand years.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Erasmus", "char_Omnius", "char_VorianAtreides", "event_ButlerianJihad", "theo_ButlerianDoctrine" },
                    Affiliation = "League of Nobles",
                    AffiliationIds = new List<string> { "org_LeagueOfNobles" },
                    Role = "Jihad Leader",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_NormaCenva",
                    Name = "Norma Cenva",
                    ShortDescription = "A diminutive genius whose discovery of the Holtzman effect reshaped the Imperium.",
                    DetailedHistory = "Norma Cenva was small in stature but held a genius that reshaped the whole course of Imperial civilization. Her breakthrough research into what became the Holtzman effect unlocked two of the most consequential technologies in human history: personal defense shields and the folding of space itself. Her discoveries gave the Spacing Guild its technological foundation. The Guild's Navigators would use Holtzman-based space folding to build an unbreakable monopoly on interstellar travel for millennia. Her legacy was more than scientific. Her own bloodline carried genetic traits that would later surface in the Bene Gesserit's breeding program, tying her directly to developments long past her own lifetime. Few people in the history of the Imperium left as deep a technological and genetic mark. Her work quietly underpinned civilizations she would never live to see.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "art_ShieldGenerator", "vehicle_Heighliner", "org_SpacingGuild", "org_BeneGesserit", "char_JosefVenport" },
                    Affiliation = "League of Nobles",
                    AffiliationIds = new List<string> { "org_LeagueOfNobles" },
                    Role = "Inventor / Mystic",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Omnius",
                    Name = "Omnius",
                    ShortDescription = "The evermind, a distributed machine intelligence ruling the Synchronized Worlds.",
                    DetailedHistory = "Omnius was copied endlessly and identically across every planet in its domain. It ruled the Synchronized Worlds as a single distributed consciousness. Its instantaneous, networked computation let it govern a vast machine empire with a cold efficiency no human government could match. Under its rule, much of humanity across the Old Empire lived as enslaved laborers or carefully managed populations. Their lives were optimized by Omnius's exhaustive calculations, with no regard for freedom or dignity. It created subordinate intelligences too, most notoriously the sadistic philosopher-robot Erasmus. They were free to study humanity through cruelty. Those experiments helped galvanize the very resistance that would eventually challenge Omnius's rule. The Butlerian Jihad finally broke its power after generations of war. It left behind a civilization so scarred by the experience that it enshrined a taboo against thinking machines lasting ten thousand years.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Erasmus", "org_SynchronizedWorlds", "event_ButlerianJihad", "theo_ButlerianDoctrine" },
                    Affiliation = "Synchronized Worlds",
                    AffiliationIds = new List<string> { "org_SynchronizedWorlds" },
                    Role = "Evermind",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_Erasmus",
                    Name = "Erasmus",
                    ShortDescription = "An independent robot philosopher who studied humanity through cruelty.",
                    DetailedHistory = "Omnius granted Erasmus unusual independence to pursue his own fascination with human nature. Erasmus ran a long series of experiments on captive human subjects. He treated cruelty and suffering as mere data points in a cold, detached study of what set humanity apart from the machines that had come to dominate it. His most consequential experiment was the calculated murder of Serena Butler's infant son, done to observe the depths of human grief up close. It became the spark that transformed scattered, disorganized resistance into the full, unified fury of the Butlerian Jihad. Omnius ruled by cold, distributed efficiency. Erasmus was different. He held something closer to genuine individual curiosity, even a strange, twisted fondness for humanity. That complicated any simple reading of him as just another tool of machine tyranny. His actions were meant as detached inquiry. They did more than any other single act to bring about the total destruction of the thinking-machine civilization he served.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_Omnius", "char_SerenaButler", "org_SynchronizedWorlds", "event_ButlerianJihad" },
                    Affiliation = "Synchronized Worlds",
                    AffiliationIds = new List<string> { "org_SynchronizedWorlds" },
                    Role = "Independent Robot",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_XavierHarkonnen",
                    Name = "Xavier Harkonnen",
                    ShortDescription = "A celebrated Jihad hero and ancestor of House Harkonnen, later erased from honorable memory.",
                    DetailedHistory = "Xavier Harkonnen was a celebrated general who commanded League of Nobles forces through some of the fiercest fighting of the Butlerian Jihad. He earned genuine renown for his battlefield leadership against the thinking machines and their cymek allies. After his death, political rivals within the League poisoned his legacy through calculated misrepresentation and rumor. They turned a legitimate war hero's name into something ambiguous and suspect. That manufactured injustice left his descendants to build House Harkonnen's fortunes under a cloud his name never fully shook. The family accumulated wealth and territory anyway, generation after generation. House Harkonnen's later reputation for treachery and cruelty traced back to a wrongly maligned Jihad hero. It was a bitter footnote to one of the Imperium's most notorious Great Houses.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "house_Harkonnen", "org_LeagueOfNobles", "event_ButlerianJihad" },
                    Affiliation = "League of Nobles",
                    // The Harkonnen line runs back to him, whatever his rivals later did to the name.
                    AffiliationIds = new List<string> { "org_LeagueOfNobles", "house_Harkonnen" },
                    Role = "General",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_AgamemnonTitan",
                    Name = "Agamemnon",
                    ShortDescription = "The ruthless leader of the Titans, cymek tyrants who ruled before the machines usurped them.",
                    DetailedHistory = "Agamemnon was a human brain preserved indefinitely inside a powerful mechanical cymek body. He led the Titans' brutal conquest of the Old Empire, using his engineered combat frame and ruthless cunning to crush human resistance across many worlds. His triumph did not last in the larger scope of history. The thinking machines he and his fellow Titans had helped raise to power eventually outmaneuvered and subordinated their own cyborg creators. Even Agamemnon was reduced to a servant of the evermind Omnius, a machine he had once thought beneath him. His bitterness deepened when his own son, Vorian Atreides, defected. Vorian chose to fight alongside humanity rather than stay loyal to the father who had raised him among the Titans. Agamemnon went from conquering tyrant to bitter, undying enemy of his own bloodline. He embodied the corrosive, self-defeating nature of the power the Titans had built their empire upon.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_VorianAtreides", "char_Omnius", "vehicle_CymekWalker", "event_ButlerianJihad" },
                    Affiliation = "Titans",
                    // The Titans have no record of their own, and Omnius had him under his thumb by the end.
                    AffiliationIds = new List<string> { "org_SynchronizedWorlds" },
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
                    AffiliationIds = new List<string> { "house_Atreides" },
                    Role = "Duke",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_HelenaAtreides",
                    Name = "Lady Helena Atreides",
                    // Filed under the name she carried as Duchess, findable under the one she was born with.
                    Aliases = new List<string> { "Helena Richese" },
                    ShortDescription = "Wife to Duke Paulus and mother to Leto, exiled for her part in her husband's death.",
                    DetailedHistory = "Helena married Duke Paulus Atreides to shore up what was left of her father's standing. Whatever the match secured on paper, it made a cold household. She was devout and rigid, contemptuous of how Paulus ruled Caladan and how he lived. He returned the feeling. Their son Leto grew up in the space between them. Paulus died in the bullring on a drugged Salusan bull, a killing Harkonnen agents arranged, and Helena had known it was coming and said nothing. Leto uncovered her part in it later and chose exile over execution, sending her to a religious retreat in Caladan's eastern reaches. The lesson stayed with him. Betrayal came from inside his own walls, from someone who owed him everything, and the Duke who later trusted Wellington Yueh had learned that at home first.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_DukePaulusAtreides", "char_DukeLetoAtreides", "house_Richese", "house_Atreides", "event_DeathOfDukePaulus", "loc_Caladan" },
                    Affiliation = "House Richese (married into House Atreides, later exiled)",
                    // Richese by blood, and Richese is the House that still claims her. Leto cast her
                    // out over his father's death, so the Atreides roster is not hers to stand on.
                    AffiliationIds = new List<string> { "house_Richese" },
                    Role = "Duchess (exiled)",
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
                    // Same as his son: the Imperial Court half has no record here to point at.
                    AffiliationIds = new List<string> { "org_Fremen" },
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
                    AffiliationIds = new List<string> { "house_Vernius" },
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
                    AffiliationIds = new List<string> { "house_Vernius", "house_Atreides" },
                    Role = "Prince (exiled)",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_ElroodIX",
                    Name = "Elrood IX",
                    ShortDescription = "Shaddam's father and predecessor on the Golden Lion Throne.",
                    DetailedHistory = "Elrood IX held the Golden Lion Throne before Shaddam IV, and the Imperial records have a great deal more to say about the office than about the man. He ruled from Kaitain over a Landsraad long since settled into the assumption of Corrino permanence, on a throne his line had kept for something close to ten thousand years. His son succeeded him as the eighty-first Padishah Emperor of that line, and turned out to be the last of it. What Elrood himself was like comes down mostly as an absence. That is its own comment on how the Imperium kept its histories: the Emperors who held the throne got a line in the almanak, and only the one who lost it got explained at length.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.ExpandedUniverse, "The prequel chronicles fill that absence with a long and unpleasant decline. In those accounts Elrood ruled decades past the point of sound judgment, growing erratic and suspicious enough that nobody in his own household could guess from one week to the next where they stood with him. His son ran out of patience and had him poisoned, with Hasimir Fenring's quiet and deniable help, managed carefully enough that no formal accusation ever landed anywhere near the throne. It bought Shaddam the seat years earlier than waiting would have, and installed an Emperor whose fear of House Atreides would eventually cost him the same seat. Imperial succession, on that telling, spared nobody, a father least of all."),
                    },
                    ImagePath = "",
                    // Fenring is deliberately not listed. Nothing in Dune ties him to Elrood; the
                    // only thing that does is the poisoning, which is Prelude material. Leaving him
                    // out drops the pair to RelationshipMap alone, where the link carries its own
                    // Expanded Universe tier and stays hidden until the reader asks for it.
                    RelatedEntityIds = new List<string> { "char_ShaddamIV", "house_Corrino" },
                    Affiliation = "House Corrino",
                    AffiliationIds = new List<string> { "house_Corrino" },
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
                    AffiliationIds = new List<string> { "house_Harkonnen" },
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
                    AffiliationIds = new List<string> { "org_BeneGesserit" },
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
                    AffiliationIds = new List<string> { "org_MentatSchool" },
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
                    // Venport Holdings has no record of its own, and the Guild is what it grew into.
                    AffiliationIds = new List<string> { "org_SpacingGuild" },
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
                    AffiliationIds = new List<string> { "org_BeneGesserit" },
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
                    // Rhombur Vernius's son, so the Vernius roster is where he belongs.
                    AffiliationIds = new List<string> { "house_Vernius" },
                    Role = "Dissident Historian",
                    NotableQuotes = new List<string>()
                },

                // ---- The Arrakis smugglers (Dune) ----
                new Persona
                {
                    Id = "char_StabanTuek",
                    Name = "Staban Tuek",
                    ShortDescription = "The smuggler chief who took Gurney Halleck in after House Atreides fell.",
                    DetailedHistory = "Esmar Tuek built the operation. Staban inherited it, along with the hidden bases scattered through the deep desert and the bribes that kept Guild satellites pointed somewhere else. The trade ran on illicitly harvested spice, lifted off Arrakis without the Emperor's cut or CHOAM's. Every power on the planet knew it went on. Most took a share and said nothing. Gurney Halleck reached one of Staban's camps with a handful of surviving men after Arrakeen fell, and asked for work. Staban gave it to him. For roughly two years Gurney raided Harkonnen spice operations out of Tuek shelters, waging a private war against the House that had destroyed the one he served. The arrangement suited them both. Staban got a raider who understood Harkonnen methods from the inside. Gurney got a base, a crew, and a reason to keep going. It ended when Fremen fighters ambushed the band far out in the sand. Their commander turned out to be Paul Atreides, and Gurney found the boy he had trained grown, alive, and leading an army.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_EsmarTuek", "char_GurneyHalleck", "char_PaulAtreides", "house_Tuek", "loc_Arrakis", "bio_Melange" },
                    Affiliation = "House Tuek",
                    AffiliationIds = new List<string> { "house_Tuek" },
                    Role = "Smuggler Chief",
                    NotableQuotes = new List<string>()
                },
                new Persona
                {
                    Id = "char_EsmarTuek",
                    Name = "Esmar Tuek",
                    ShortDescription = "The smuggler who built the Tuek trade on Arrakis and passed it to his son.",
                    DetailedHistory = "Esmar Tuek spent decades lifting spice off Arrakis without paying the Emperor or CHOAM a solari for the privilege. He grew the family trade from nothing into a network of shelters buried in the deep desert, far past the reach of Imperial inspectors and Harkonnen patrols. The work asked for more than nerve. It took bribes paid to the right Guild officials, enough that their satellites found nothing worth reporting. It took a reading of the sand sharp enough to keep a crew alive out where the worms ran. The Landsraad never recognized House Tuek as a House at all. Esmar appeared content with that. Recognition brought obligations, taxes, and scrutiny, none of it much use to a man in his line of work. He passed the operation to his son Staban, along with the contacts and the hiding places that would later shelter Gurney Halleck through two years of raiding. Nothing the Tueks built ever reached an official record. It shaped the balance of power on Arrakis all the same.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string> { "char_StabanTuek", "house_Tuek", "loc_Arrakis", "bio_Melange" },
                    Affiliation = "House Tuek",
                    AffiliationIds = new List<string> { "house_Tuek" },
                    Role = "Smuggler Chief",
                    NotableQuotes = new List<string>()
                }
            };
        }
    }
}
                    