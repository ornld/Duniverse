using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class HistoricalEventSeeder
    {
        public static List<HistoricalEvent> GetHistoricalEvents()
        {
            return new List<HistoricalEvent>
            {
                new HistoricalEvent
                {
                    Id = "event_ButlerianJihad",
                    Name = "The Butlerian Jihad",
                    ShortDescription = "A crusade spanning generations, fought to wipe out every thinking machine in the galaxy.",
                    DetailedHistory = "The Butlerian Jihad was the crusade against computers, thinking machines and conscious robots, and it ran for the better part of a century. Humanity had handed its thinking over to machines by degrees and then found it could not take it back, which is the part of the story the later histories tend to skip in favour of the battles. The fighting lasted ninety-three years and cost more lives than anyone afterward could count. What came out of it was not a technology policy but a commandment, written into the Orange Catholic Bible and carried by every faith that followed it: Thou shalt not make a machine in the likeness of a human mind. Keeping that commandment left the species with no computation and no long-range calculation of any kind, so it filled the hole with people instead. The Mentats, the Guild Navigators and the Bene Gesserit all grew out of that vacuum, and ten thousand years later the Imperium still ran on disciplines it had improvised in a panic.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.ExpandedUniverse, "The prequel chronicles give the war a cast the older records never named. They set it against Omnius, an evermind copied across the Synchronized Worlds, and against his cymeks, human minds cut out of their bodies and fitted into war machines under the Titan Agamemnon. The spark, in those accounts, was Serena Butler, whose infant son was killed by the independent robot Erasmus and whose grief the League of Nobles turned into a war cry. Xavier Harkonnen commanded League forces through the worst of the fighting and was remembered as a hero for it, until rivals took his name apart after his death. That, by those same chronicles, is where House Harkonnen's long reputation for treachery actually begins, and none of it is deserved."),
                    },
                    ImagePath = "images/events/butlerian_jihad.jpg",
                    RelatedEntityIds = new List<string> { "disc_Mentat", "org_SpacingGuild", "org_BeneGesserit", "theo_ButlerianDoctrine", "char_VorianAtreides", "char_SerenaButler", "char_Omnius", "char_Erasmus", "char_XavierHarkonnen", "char_AgamemnonTitan", "org_LeagueOfNobles", "org_SynchronizedWorlds" },
                    Timeframe = "Roughly 10,000 years before the birth of Paul Atreides",
                    SortOrder = 10,
                    DateAG = "201 to 108 BG",
                    Era = "The Butlerian Age",
                    LastingImpact = "Permanent ban on thinking machines; rise of Mentats, Guild Navigators, and the Bene Gesserit"
                },
                new HistoricalEvent
                {
                    Id = "event_KwisatzHaderachBirth",
                    Name = "Birth of the Kwisatz Haderach",
                    ShortDescription = "Paul Atreides arrives, and with him the payoff of a Bene Gesserit breeding scheme ninety generations in the making.",
                    DetailedHistory = "Ninety generations of quiet manipulation across the Great Houses had gone into this. The Bene Gesserit paired bloodlines with surgical precision, chasing a male Reverend Mother. They called him the Kwisatz Haderach, a mind that could hold both male and female ancestral memory and see farther than any prescient before him. Lady Jessica belonged to the Sisterhood in body and training, but her heart belonged to Duke Leto. Her orders were plain: bear him daughters only, so the final cross could land a generation later with House Harkonnen. She loved her Duke, and he wanted a son. She gave him one. That broke her order's plan a generation early and dragged the entire program outside the Sisterhood's control. Paul grew up steeped in the Bene Gesserit Way, drilled in Mentat discipline, and schooled in combat by Gurney Halleck and Duncan Idaho. None of it was wasted. The powers waking in him found a mind already prepared. He was the variable nobody planned for, and the Sisterhood would spend the rest of the saga reckoning with him.",
                    ImagePath = "images/events/kwisatz_haderach_birth.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_LadyJessica", "char_PaulAtreides", "disc_KwisatzHaderachProcess" },
                    Timeframe = "Approximately 15 years before the fall of House Atreides",
                    SortOrder = 60,
                    DateAG = "10175 AG",
                    Era = "The Corrino Imperium",
                    LastingImpact = "Produced a male capable of prescience and access to both male and female ancestral memory, disrupting Bene Gesserit control"
                },
                new HistoricalEvent
                {
                    Id = "event_FallOfHouseAtreides",
                    Name = "The Fall of House Atreides",
                    ShortDescription = "A Harkonnen-Sardaukar ambush tears down Duke Leto's rule on Arrakis before it can take root.",
                    DetailedHistory = "The Arrakis fief was a gift with teeth. Baron Vladimir Harkonnen and Emperor Shaddam IV built the trap together. Both men were unsettled by the Duke's popularity and by the discipline of his Atreides fighting corps. Dr. Wellington Yueh carried Imperial Suk Conditioning meant to make harming a patient unthinkable. The kidnapping of his wife gave the Harkonnens their lever. He disabled the palace shields at the moment it would hurt most. Harkonnen shock troops stormed in, with Sardaukar hidden among them in Harkonnen livery. That was a strike against a Great House, and it broke the Great Convention outright. Arrakeen fell within hours. Duke Leto died trying to take the Baron with him. His last weapon was a poisoned false tooth, and it failed. Jessica and Paul fled into the deep desert. Only the quiet aid of the Imperial planetologist Liet-Kynes kept them alive long enough to reach the Fremen.",
                    ImagePath = "images/events/fall_of_atreides.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen", "house_Corrino", "char_WellingtonYueh" },
                    Timeframe = "Year of the Atreides' arrival on Arrakis",
                    SortOrder = 70,
                    DateAG = "10191 AG",
                    Era = "The Rise of Muad'Dib",
                    LastingImpact = "Ended House Atreides' open rule of Arrakis and drove Paul into the Fremen, setting his rise into motion"
                },
                new HistoricalEvent
                {
                    Id = "event_BattleOfArrakeen",
                    Name = "The Battle of Arrakeen",
                    ShortDescription = "Paul's Fremen legions storm Arrakeen and break the Emperor's grip on the planet.",
                    DetailedHistory = "Two years among the Fremen turned Paul into Muad'Dib, their war leader. It gave him an army that could do what no other force in the Imperium had managed: ride the sandworms themselves into battle. His family atomics blasted a permanent hole through the Shield Wall. The strike hit stone and sand rather than flesh, so the Great Convention had nothing to say about it. Fremen legions poured through the breach under cover of a coriolis storm, and Arrakeen's defenses gave way beneath them. The Sardaukar had never lost, not once, not anywhere. They broke here, against fighters the deadliest desert in the universe had already hardened past breaking. Arrakeen fell. Paul's forces stormed the throne room. Shaddam IV knelt before the Great Houses and the Spacing Guild in a surrender that humiliated him to the bone.",
                    ImagePath = "images/events/battle_of_arrakeen.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "house_Corrino", "house_Harkonnen", "char_PaulAtreides" },
                    Timeframe = "Culmination of Paul's desert campaign",
                    SortOrder = 80,
                    DateAG = "10193 AG",
                    Era = "The Rise of Muad'Dib",
                    LastingImpact = "Overthrew Shaddam IV and installed Paul Atreides as Emperor of the Known Universe"
                },
                new HistoricalEvent
                {
                    Id = "event_ThroneDuel",
                    Name = "Duel for the Throne",
                    ShortDescription = "A ritual knife fight between Paul Atreides and Feyd-Rautha Harkonnen settles the succession.",
                    DetailedHistory = "Paul stood before Shaddam IV's court and the gathered Great Houses and named his price: Princess Irulan's hand, and the throne itself, forfeit. Baron Harkonnen answered the claim in fury. He put forward his nephew Feyd-Rautha, vicious and eager, as champion. The duel followed Harkonnen custom to the letter. That meant Feyd-Rautha carried a poisoned needle hidden in his belt for an unseen strike. Paul's prescience caught the trick before it landed and sent it back on him instead. Feyd-Rautha died there, in front of the entire Landsraad, and House Harkonnen's line of open succession died with him. The Guild needed its spice. The Sisterhood feared what an unchecked Kwisatz Haderach might do unopposed. Between the two, the Great Houses found themselves with only one road left: Paul, and the Golden Lion Throne.",
                    ImagePath = "images/events/throne_duel.jpg",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_FeydRautha", "house_Harkonnen", "house_Atreides" },
                    Timeframe = "Immediately following the Battle of Arrakeen",
                    SortOrder = 90,
                    DateAG = "10193 AG",
                    Era = "The Rise of Muad'Dib",
                    LastingImpact = "Ended the Harkonnen line of succession and secured Paul's ascension to Emperor"
                },
                new HistoricalEvent
                {
                    Id = "event_MuadDibJihad",
                    Name = "The Jihad of Muad'Dib",
                    ShortDescription = "A holy war fought across the stars in Paul Atreides' name, and beyond his control.",
                    DetailedHistory = "Paul had seen this coming long before his boots ever touched Arrakis sand. His prescient visions showed it to him, and he dreaded every version of it. None of that dread slowed it down once he sat the throne. Fremen fanaticism fused with his messianic image, and the mixture proved impossible to cap. His legions believed, absolutely, that their Muad'Dib was the Lisan al-Gaib. That prophecy was one generations of Bene Gesserit religious engineering had planted for exactly this moment. They carried his rule and his faith across the Imperium at the point of a blade. A little over a decade of war cost an estimated sixty-one billion lives across ten thousand worlds. The toll haunted Paul most. His prescience showed him every death without ever once showing him how to stop it. Fremen military supremacy came out of the war unquestioned. The Church of Muad'Dib spread into every reach of known space. Paul himself ended up a prisoner of the very future he saw more clearly than anyone alive.",
                    ImagePath = "images/events/muaddib_jihad.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "theo_ChurchOfMuadDib", "char_PaulAtreides" },
                    Timeframe = "The first decade of Paul Atreides' reign",
                    SortOrder = 100,
                    DateAG = "10193 to 10205 AG",
                    Era = "The Atreides Empire",
                    LastingImpact = "Spread the Church of Muad'Dib across the Imperium at immense human cost; cemented Fremen military dominance"
                },
                new HistoricalEvent
                {
                    Id = "event_MessiahConspiracy",
                    Name = "The Conspiracy Against Muad'Dib",
                    ShortDescription = "The Bene Gesserit, the Guild, and the Tleilaxu bury their rivalries long enough to plot Paul Atreides' downfall.",
                    DetailedHistory = "Paul's prescience made him unpredictable, and his Fremen legions made him untouchable by ordinary force. That left the Bene Gesserit, the Spacing Guild, and the Bene Tleilax no good options. They set their old rivalries aside and came at him together. Reverend Mother Gaius Helen Mohiam and the bloated Guild Steersman Edric handled the political cover. The Tleilaxu Face Dancer Scytale brought the real weapon. It was a ghola of Paul's dead swordmaster Duncan Idaho, grown from cellular stock and renamed Hayt. The ghola was built to break Paul from the inside by dragging old loyalties and old grief back to the surface. The final blow landed through a stolen Guild weapon. It killed Paul's beloved Chani and burned out his eyes. He stood blind in a universe where prescience alone let him still see anything at all. It did not break him the way the conspirators wanted. Instead he walked out into the desert to die by Fremen custom. He vanished from the Imperium entirely and left his sister Alia to rule in his place as Regent.",
                    ImagePath = "images/events/messiah_conspiracy.jpg",
                    RelatedEntityIds = new List<string> { "char_GaiusHelenMohiam", "char_Edric", "char_Scytale", "char_DuncanIdaho", "org_BeneTleilax", "org_BeneGesserit", "org_SpacingGuild" },
                    Timeframe = "Roughly twelve years into Paul's reign",
                    SortOrder = 110,
                    DateAG = "c. 10205 AG",
                    Era = "The Atreides Empire",
                    LastingImpact = "Blinded Paul Atreides and precipitated his eventual disappearance into the desert, leaving his sister to rule in his place"
                },
                new HistoricalEvent
                {
                    Id = "event_AliaRegency",
                    Name = "Alia's Regency",
                    ShortDescription = "Alia Atreides rules as Regent, and the Baron's ego-memory quietly takes her over from within.",
                    DetailedHistory = "Paul was gone into the desert, and Leto II and Ghanima were still children, too young to rule. Alia stepped into the Regency instead. The same pre-birth awareness that gave the Atreides twins their power turned out to be the thing that destroyed her. Countless lifetimes of memory, absorbed before she was even born, proved too much psychic weight for one mind to hold. The cruel, dominant personality of her grandfather's old enemy, Baron Vladimir Harkonnen, took her over. The Bene Gesserit have a name for it: Abomination. She ruled in secret thrall to the Baron's ego. In public she was worshipped the whole time as a living saint of the Church of Muad'Dib. Her reign curdled into something tyrannical and unstable, dangerous even to her own niece and nephew. Her collapse exposed just how much of a threat Abomination poses to any pre-born Atreides child. It set up the choice Leto II would soon have to make about his own fate.",
                    ImagePath = "images/events/alia_regency.jpg",
                    RelatedEntityIds = new List<string> { "char_AliaAtreides", "char_BaronHarkonnen", "char_LetoIIAtreides", "char_GhanimaAtreides", "house_Atreides" },
                    Timeframe = "The years following Paul Atreides' disappearance",
                    SortOrder = 120,
                    DateAG = "10205 to 10218 AG",
                    Era = "The Atreides Empire",
                    LastingImpact = "Exposed the danger of Abomination among pre-born Atreides children and set the stage for Leto II's transformation"
                },
                new HistoricalEvent
                {
                    Id = "event_GoldenPathBegins",
                    Name = "The Golden Path Begins",
                    ShortDescription = "Leto II fuses with sandtrout and takes the throne, making the choice his father refused.",
                    DetailedHistory = "Leto II carried the same pre-born awareness as his twin sister Ghanima, and both had already looked at the future their father Paul saw and turned away from. Paul refused to pay what it asked. Leto, still a boy, went into the deep desert and paid it. The sandtrout, the larval stage of the sandworm, sealed themselves over his skin as a living membrane and gave him strength, speed and a resilience no human body can manage. They also began an irreversible slide into something part man and part worm. He came back to Arrakeen, ended his aunt Alia's regency, took the throne, and settled Ghanima on Farad'n Corrino so the human half of the bloodline would continue without him. The route he had committed to was the Golden Path, the one line through the coming centuries that did not end with the species dead. Holding it open would take a ruler prepared to last for thousands of years and be hated for every one of them.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.GodEmperorOfDune, "He held the throne for thirty-five hundred years, and the Imperium settled on God Emperor because nothing else in its vocabulary fit. The peace he imposed was total and deliberately dull: no war worth the name, no movement, no surprises, a whole species held still for a hundred generations until the pressure of it turned unbearable. That was the point, and the journals he left behind never pretended otherwise. A people ruled that long by a prescient tyrant will not hand itself to another one. He spent the same centuries breeding a line his own foresight could not see, so that when humanity finally broke and ran, it would run somewhere no oracle could follow."),
                        new(SpoilerTier.HereticsOfDune, "It ran the moment he was gone, and the Scattering carried humanity past every map the Imperium had ever kept. Thousands of years later, when part of what had left came back, nobody at home owned an instrument that could count it, much less steer it. The Golden Path bought precisely what it had been built to buy. Whether Leto also saw what would eventually follow humanity home, he left out of the journals."),
                    },
                    ImagePath = "images/events/golden_path_begins.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "bio_Sandtrout", "theo_GoldenPath", "house_Atreides" },
                    Timeframe = "Following Alia's regency",
                    SortOrder = 140,
                    DateAG = "10218 AG",
                    Era = "The Long Peace",
                    LastingImpact = "Began a reign meant to last millennia, and set the shape of everything that followed it"
                },
                new HistoricalEvent
                {
                    Id = "event_GuildFounding",
                    Name = "Founding of the Spacing Guild",
                    ShortDescription = "Spice-fueled prescience gives the Guild an unbreakable monopoly on interstellar travel.",
                    DetailedHistory = "Thinking machines had just been outlawed, and humanity scrambled for a replacement. A handful of people found one in melange itself. Enough of it, taken over enough time, produced a narrow, drug-soaked prescience. It was just enough to thread a course through folded space without clipping a star or a planet along the way. These were the first Guild Navigators. A lifetime of spice saturation reshaped their bodies into something no longer quite human. That one ability let them found the Spacing Guild and lock down interstellar travel entirely. No other method of faster-than-light navigation ever emerged to challenge them. Every Great House, every merchant, every pilgrim in the Imperium ended up permanently bound to the Guild. Through the Guild, they were bound to Arrakis, the only known source of the spice that made any of it possible.",
                    ImagePath = "images/events/guild_founding.jpg",
                    RelatedEntityIds = new List<string> { "org_SpacingGuild", "bio_Melange", "event_ButlerianJihad" },
                    Timeframe = "In the aftermath of the Butlerian Jihad",
                    SortOrder = 30,
                    DateAG = "c. 1 AG",
                    Era = "The Butlerian Age",
                    LastingImpact = "Created the Spacing Guild's enduring monopoly on space travel and cemented melange as the most valuable substance in the universe"
                },

                // ---- Children of Dune / God Emperor of Dune / Heretics & Chapterhouse ----
                new HistoricalEvent
                {
                    Id = "event_TigerAssassinationAttempt",
                    Name = "The Tiger Assassination Attempt",
                    ShortDescription = "Someone sets genetically bred Laza tigers loose on the Atreides twins, and they are meant to die.",
                    DetailedHistory = "Wensicia Corrino wanted the last of the Atreides line gone. That would clear the road back to the throne for House Corrino. Her steward Javid helped her arrange it. They turned Laza tigers, bred by the Bene Tleilax for nothing but savage efficiency, loose on two children. It nearly worked. The twins survived on reflexes and awareness alone, inherited straight from ancestral memory absorbed before birth. It was far beyond anything an ordinary child could manage. The failed attempt tore the lid off the wider conspiracy behind it. House Corrino's remaining loyalists were left exposed and humiliated across the Landsraad. Leto II, above all, came out of it certain of one thing. The fate waiting for House Atreides and the Imperium would not change on its own.",
                    ImagePath = "images/events/tiger_assassination.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_GhanimaAtreides", "bio_LazaTiger", "char_WensiciaCorrino", "char_Javid" },
                    Timeframe = "During the Atreides twins' childhood",
                    SortOrder = 130,
                    DateAG = "10218 AG",
                    Era = "The Atreides Empire",
                    LastingImpact = "Exposed the Corrino restoration conspiracy and hardened Leto II's resolve toward the Golden Path"
                },
                new HistoricalEvent
                {
                    Id = "event_DeathOfTheGodEmperor",
                    Name = "Death of the God Emperor",
                    ShortDescription = "Leto II dies at the Hidden Ford, and thirty-five hundred years of enforced peace end with him.",
                    DetailedHistory = "Thirty-five centuries of enforced peace came down to one crossing on the Royal Road. Siona Atreides had spent her life in rebellion against Leto II without ever grasping that her own invisibility to prescient sight was the thing millennia of Atreides breeding had been aimed at producing. The order to cut the bridge over the Idaho River during his wedding procession was hers. His cart went off the broken span into the water, and water killed what nothing else could: the sandtrout skin that had carried him for thirty-five hundred years cannot survive contact with it. As his flesh came apart, the sandtrout went free into the sand for the first time since he put them on, and they resumed the work of taking the planet's water back. He had spent centuries telling his court that his own death was written into the design, and the court had listened without ever quite believing him.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.HereticsOfDune, "The desert took the rest of the planet over the centuries that followed, and the world ended up with a shorter name to match the change: Rakis. His death also released the pressure he had spent the whole reign building. People who had lived their entire lives inside a policed, motionless Imperium poured out past known space in the flight remembered as the Scattering, which was the outcome he had bored and cornered the human race into choosing. They remembered him as the Tyrant, which was fair enough and also missed the point."),
                    },
                    ImagePath = "images/events/death_of_god_emperor.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_SionaAtreides", "char_DuncanIdaho", "bio_Sandtrout", "loc_Rakis" },
                    Timeframe = "The end of the God Emperor's reign",
                    SortOrder = 150,
                    DateAG = "13728 AG",
                    Era = "The Long Peace",
                    LastingImpact = "Ended the Golden Path's enforced peace, triggered the desert's return, and set the stage for the Scattering"
                },
                new HistoricalEvent
                {
                    Id = "event_TheScattering",
                    Name = "The Scattering",
                    ShortDescription = "Humanity floods out beyond the reach of any single power once the God Emperor's control is gone.",
                    DetailedHistory = "The God Emperor's control had held the Imperium still for thirty-five centuries. The moment it lifted, uncounted numbers of people left known space outright. They went past Imperial law, past Bene Gesserit oversight, past even the Guild's own navigation routes, and nobody left behind could say where any of them had gone. That was the design rather than the failure of it. Leto II had spent his reign pressing humanity down under a single throne so that the release would throw it as far as possible, and he had bred a line no prescient eye could track so the ones who ran could not be found afterward. Whatever the species met after that, it would never again be standing in one place to meet it.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.HereticsOfDune, "Not everything that grew out there stayed out there. Fifteen centuries on, populations began drifting back into the Imperium they had left, and among them came the Honored Matres, a matriarchal order that had turned sexual conditioning into a tool of ownership and could meet the Bene Gesserit blade for blade. The Sisterhood had spent more than a thousand years holding the old balance of power steady. It took very little of the Honored Matres to show how little that balance now weighed."),
                        new(SpoilerTier.Chapterhouse, "The Honored Matres had not come home out of ambition alone. Something in the far Scattering had frightened them into running, an enemy they would not name, and the Sisterhood came to believe it was following them back. That was pieced together late, deep into a war that cost both orders more than either could afford. The answer left in the end was to absorb the Honored Matres rather than beat them."),
                    },
                    ImagePath = "images/events/the_scattering.jpg",
                    RelatedEntityIds = new List<string> { "event_DeathOfTheGodEmperor", "org_HonoredMatres", "org_SpacingGuild" },
                    Timeframe = "Following the death of the God Emperor",
                    SortOrder = 160,
                    DateAG = "after 13728 AG",
                    Era = "The Scattering and the Return",
                    LastingImpact = "Seeded uncounted civilizations past the reach of any Imperial map or oracle"
                },
                new HistoricalEvent
                {
                    Id = "event_DestructionOfRakis",
                    Name = "Destruction of Rakis",
                    ShortDescription = "The Honored Matres wipe out the former Arrakis, and the galaxy loses its only known source of spice.",
                    DetailedHistory = "War with the Bene Gesserit over what remained of the old Imperium's power structures had been escalating for years. The Honored Matres decided to settle one question for good. They would deny the Sisterhood any advantage the spice might offer by destroying Rakis outright. The attack erased the planet's entire sandworm population and its melange production in a single stroke. It was the only confirmed natural source of the most valuable substance in existence, going back to the days of Shai-Hulud and Muad'Dib. With Rakis gone, the Bene Gesserit had one option left, and it was a gamble. They would transplant a fragile, artificially cultivated worm ecology onto their hidden fortress world of Chapterhouse. The sandrider and worm-speaker Sheeana guided the effort. Rakis's long reign at the center of galactic power and commerce ended there, for good.",
                    ImagePath = "images/events/destruction_of_rakis.jpg",
                    RelatedEntityIds = new List<string> { "loc_Rakis", "org_HonoredMatres", "loc_Chapterhouse", "char_Sheeana", "bio_ShaiHulud" },
                    Timeframe = "During the Bene Gesserit-Honored Matre war",
                    SortOrder = 170,
                    DateAG = "c. 15230 AG",
                    Era = "The Scattering and the Return",
                    LastingImpact = "Ended Rakis as the source of melange and forced the transplantation of sandworms to Chapterhouse"
                },

                // ---- Prelude to Dune (House trilogy) ----
                new HistoricalEvent
                {
                    Id = "event_IxianCoup",
                    Name = "The Ixian Coup",
                    ShortDescription = "The Bene Tleilax topple House Vernius and seize control of Ix.",
                    DetailedHistory = "The Imperial throne saw House Vernius's growing technological independence as a threat. It quietly blessed what came next. A Bene Tleilax coup seized Ix's advanced manufacturing base and forced Earl Dominic Vernius into hiding as a renegade smuggler. His family scattered in the chaos. His son Rhombur made it to Caladan, grew up alongside young Leto Atreides, and became one of his most trusted friends and advisors. Ix did not go dark. It kept producing forbidden technology under new, secretive Tleilaxu-linked management. That technology went quietly to any Great House willing to overlook where it came from. Decades later, the coup's ripples were still spreading. Rhombur's exile and his bond with House Atreides sat chief among them.",
                    ImagePath = "images/events/ixian_coup.jpg",
                    RelatedEntityIds = new List<string> { "house_Vernius", "loc_Ix", "char_DominicVernius", "char_RhomburVernius", "org_BeneTleilax" },
                    Timeframe = "Prior to the events of Dune",
                    SortOrder = 40,
                    DateAG = "c. 10156 AG",
                    Era = "The Corrino Imperium",
                    LastingImpact = "Exiled House Vernius, placed Ix under Tleilaxu-linked control, and forged Rhombur's lifelong bond with House Atreides"
                },
                new HistoricalEvent
                {
                    Id = "event_DeathOfDukePaulus",
                    Name = "Death of Duke Paulus Atreides",
                    ShortDescription = "A bullring accident, quietly arranged by House Harkonnen, kills Leto's father.",
                    DetailedHistory = "It looked like a tragic accident, nothing more. Harkonnen agents had drugged a bull in the Atreides bullring to run erratic, then to settle just long enough to gore Duke Paulus Atreides fatally in front of a stunned crowd. No one proved the sabotage in Paulus's lifetime, and that fit the pattern. House Harkonnen preferred exactly this kind of indirect, deniable strike against its Atreides rivals, since open warfare ran straight into the Great Convention. Young Leto took command of House Atreides years before anyone expected. He was thrust into rulership with his education under his father's mentors still unfinished. The killing drove the blood feud between the two Houses deeper still. It was a quiet, generations-old grudge that would erupt decades later in the destruction of Leto's own household on Arrakis.",
                    ImagePath = "images/events/death_of_duke_paulus.jpg",
                    RelatedEntityIds = new List<string> { "char_DukePaulusAtreides", "char_DukeLetoAtreides", "house_Harkonnen", "house_Atreides" },
                    Timeframe = "Years before Duke Leto's arrival on Arrakis",
                    SortOrder = 50,
                    DateAG = "c. 10156 AG",
                    Era = "The Corrino Imperium",
                    LastingImpact = "Placed Leto Atreides in command of House Atreides and deepened the Atreides-Harkonnen blood feud"
                },
                new HistoricalEvent
                {
                    Id = "event_ReverendMotherBreakthrough",
                    Name = "The First Reverend Mother Transformation",
                    ShortDescription = "Raquella Berto-Anirul's acolytes stumble onto the first true Reverend Mother transformation.",
                    DetailedHistory = "A wasting plague was killing her, and nothing in the fledgling Sisterhood's medicine could touch it. Raquella Berto-Anirul, the order's founder, let her acolytes try a last-resort dose of toxic distillation rather than wait for certain death. She did not die. Something inside her shifted instead. It neutralized the poison and threw open access to the full accumulated ancestral memory of her female bloodline. She became the first true Reverend Mother in history, by accident, on her deathbed. Later generations refined the breakthrough into a formal rite, the ritual ingestion of the Water of Life. It gave the young Bene Gesserit order the one defining ability its entire future structure, training, and political power would be built around. Strip it away and the Sisterhood's later roles simply do not happen: truthsayers, advisors, and architects of the breeding program that eventually produced Paul Atreides.",
                    ImagePath = "images/events/reverend_mother_breakthrough.jpg",
                    RelatedEntityIds = new List<string> { "char_RaquellaBertoAnirul", "org_BeneGesserit", "art_WaterOfLife", "disc_BeneGesseritTraining" },
                    Timeframe = "In the founding decades of the Bene Gesserit, following the Butlerian Jihad",
                    SortOrder = 20,
                    DateAG = "c. 88 BG",
                    Era = "The Butlerian Age",
                    LastingImpact = "Established the Reverend Mother transformation as the core rite of the Bene Gesserit Sisterhood"
                }
            };
        }
    }
}
