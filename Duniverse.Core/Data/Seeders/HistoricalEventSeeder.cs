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
                    DetailedHistory = "Computers and robots had come to rule most of humanity by the time the Butlerian Jihad broke out, a revolt provoked by the tyrannical evermind Omnius and his cymek allies: human minds torn from their bodies and grafted into mechanical shells, commanded by figures like Agamemnon and the turncoat Xavier Harkonnen. Serena Butler lost her infant son to the sadistic robot Erasmus, and her public grief lit the fuse; humanity rose in open revolt soon after. The fighting stretched across generations and swallowed billions of lives throughout the Synchronized Worlds. Victory did more than smash the machines. It carved the Orange Catholic Bible's commandment, 'Thou shalt not make a machine in the likeness of a human mind,' into unbreakable law. Humanity, left without computation or foresight, had to grow its own substitutes from scratch: the Mentats, the Guild Navigators, the Bene Gesserit.",
                    ImagePath = "images/events/butlerian_jihad.jpg",
                    RelatedEntityIds = new List<string> { "disc_Mentat", "org_SpacingGuild", "org_BeneGesserit", "theo_ButlerianDoctrine", "char_VorianAtreides", "char_SerenaButler", "char_Omnius", "char_Erasmus", "char_XavierHarkonnen", "char_AgamemnonTitan", "org_LeagueOfNobles", "org_SynchronizedWorlds" },
                    Timeframe = "Roughly 10,000 years before the birth of Paul Atreides",
                    SortOrder = 10,
                    LastingImpact = "Permanent ban on thinking machines; rise of Mentats, Guild Navigators, and the Bene Gesserit"
                },
                new HistoricalEvent
                {
                    Id = "event_KwisatzHaderachBirth",
                    Name = "Birth of the Kwisatz Haderach",
                    ShortDescription = "Paul Atreides arrives, and with him the payoff of a Bene Gesserit breeding scheme ninety generations in the making.",
                    DetailedHistory = "Ninety generations of quiet manipulation across the Great Houses had gone into this: the Bene Gesserit paired bloodlines with surgical precision, chasing a male Reverend Mother, a Kwisatz Haderach who could hold both male and female ancestral memory and see farther than any prescient mind before him. Lady Jessica belonged to the Sisterhood, body and training, but her heart belonged to Duke Leto, and she had been ordered to bear him daughters only, so the final cross could land a generation later with House Harkonnen. She loved her Duke, and he wanted a son; she gave him one, breaking her order's plan a generation early and dragging the entire program outside the Sisterhood's control. Paul grew up steeped in the Bene Gesserit Way, drilled in Mentat discipline, schooled in combat by Gurney Halleck and Duncan Idaho, and none of it was wasted: the powers waking in him found a mind already prepared. He was the variable nobody planned for, and the Sisterhood would spend the rest of the saga reckoning with him.",
                    ImagePath = "images/events/kwisatz_haderach_birth.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_LadyJessica", "char_PaulAtreides", "disc_KwisatzHaderachProcess" },
                    Timeframe = "Approximately 15 years before the fall of House Atreides",
                    SortOrder = 60,
                    LastingImpact = "Produced a male capable of prescience and access to both male and female ancestral memory, disrupting Bene Gesserit control"
                },
                new HistoricalEvent
                {
                    Id = "event_FallOfHouseAtreides",
                    Name = "The Fall of House Atreides",
                    ShortDescription = "A Harkonnen-Sardaukar ambush tears down Duke Leto's rule on Arrakis before it can take root.",
                    DetailedHistory = "The Arrakis fief was a gift with teeth. Baron Vladimir Harkonnen and Emperor Shaddam IV built the trap together, unsettled by the Duke's popularity and by the discipline of his Atreides fighting corps. Dr. Wellington Yueh carried Imperial Suk Conditioning meant to make harming a patient unthinkable, yet the kidnapping of his wife gave the Harkonnens their lever, and he disabled the palace shields at the moment it would hurt most. Harkonnen shock troops stormed in, Sardaukar hidden among them in Harkonnen livery (a strike against a Great House that broke the Great Convention outright), and Arrakeen fell within hours. Duke Leto died trying to take the Baron with him, a poisoned false tooth his last weapon, and it failed. Jessica and Paul fled into the deep desert; only the quiet aid of the Imperial planetologist Liet-Kynes kept them alive long enough to reach the Fremen.",
                    ImagePath = "images/events/fall_of_atreides.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen", "house_Corrino", "char_WellingtonYueh" },
                    Timeframe = "Year of the Atreides' arrival on Arrakis",
                    SortOrder = 70,
                    LastingImpact = "Ended House Atreides' open rule of Arrakis and drove Paul into the Fremen, setting his rise into motion"
                },
                new HistoricalEvent
                {
                    Id = "event_BattleOfArrakeen",
                    Name = "The Battle of Arrakeen",
                    ShortDescription = "Paul's Fremen legions storm Arrakeen and break the Emperor's grip on the planet.",
                    DetailedHistory = "Two years among the Fremen turned Paul into Muad'Dib, their war leader, and gave him an army that could do what no other force in the Imperium had managed: ride the sandworms themselves into battle. His family atomic blasted a permanent hole through the Shield Wall, a strike against stone and sand rather than flesh, so the Great Convention had nothing to say about it. Fremen legions poured through the breach under cover of a coriolis storm, and Arrakeen's defenses gave way beneath them. The Sardaukar had never lost, not once, not anywhere; they broke here, against fighters the deadliest desert in the universe had already hardened past breaking. Arrakeen fell, Paul's forces stormed the throne room, and Shaddam IV knelt before the Great Houses and the Spacing Guild in a surrender that humiliated him to the bone.",
                    ImagePath = "images/events/battle_of_arrakeen.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "house_Corrino", "house_Harkonnen", "char_PaulAtreides" },
                    Timeframe = "Culmination of Paul's desert campaign",
                    SortOrder = 80,
                    LastingImpact = "Overthrew Shaddam IV, installed Paul Atreides as Emperor, and began the Jihad of Muad'Dib"
                },
                new HistoricalEvent
                {
                    Id = "event_ThroneDuel",
                    Name = "Duel for the Throne",
                    ShortDescription = "A ritual knife fight between Paul Atreides and Feyd-Rautha Harkonnen settles the succession.",
                    DetailedHistory = "Paul stood before Shaddam IV's court and the gathered Great Houses and named his price: Princess Irulan's hand, and the throne itself, forfeit. Baron Harkonnen, furious, answered the claim by putting forward his nephew Feyd-Rautha, vicious and eager, as champion. The duel followed Harkonnen custom to the letter, meaning Feyd-Rautha carried a poisoned needle hidden in his belt for an unseen strike; Paul's prescience caught the trick before it landed and sent it back on him instead. Feyd-Rautha died there, in front of the entire Landsraad, and House Harkonnen's line of open succession died with him. The Guild needed its spice, the Sisterhood feared what an unchecked Kwisatz Haderach might do unopposed, and between the two the Great Houses found themselves with only one road left: Paul, and the Golden Lion Throne.",
                    ImagePath = "images/events/throne_duel.jpg",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "char_FeydRautha", "house_Harkonnen", "house_Atreides" },
                    Timeframe = "Immediately following the Battle of Arrakeen",
                    SortOrder = 90,
                    LastingImpact = "Ended the Harkonnen line of succession and secured Paul's ascension to Emperor"
                },
                new HistoricalEvent
                {
                    Id = "event_MuadDibJihad",
                    Name = "The Jihad of Muad'Dib",
                    ShortDescription = "A holy war fought across the stars in Paul Atreides' name, and beyond his control.",
                    DetailedHistory = "Paul had seen this coming long before his boots ever touched Arrakis sand, seen it in prescient visions and dreaded every version of it; none of that dread slowed it down once he sat the throne. Fremen fanaticism fused with his messianic image and the mixture proved impossible to cap. His legions believed, absolutely, that their Muad'Dib was the Lisan al-Gaib, a prophecy generations of Bene Gesserit religious engineering had planted for exactly this moment, and they carried his rule and his faith across the Imperium at the point of a blade. A little over a decade of war cost an estimated sixty-one billion lives across ten thousand worlds. The toll haunted Paul most: his prescience showed him every death without ever once showing him how to stop it. Fremen military supremacy came out of the war unquestioned, the Church of Muad'Dib spread into every reach of known space, and Paul himself ended up a prisoner of the very future he saw more clearly than anyone alive.",
                    ImagePath = "images/events/muaddib_jihad.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "theo_ChurchOfMuadDib", "char_PaulAtreides" },
                    Timeframe = "The first decade of Paul Atreides' reign",
                    SortOrder = 100,
                    LastingImpact = "Spread the Church of Muad'Dib across the Imperium at immense human cost; cemented Fremen military dominance"
                },
                new HistoricalEvent
                {
                    Id = "event_MessiahConspiracy",
                    Name = "The Conspiracy Against Muad'Dib",
                    ShortDescription = "The Bene Gesserit, the Guild, and the Tleilaxu bury their rivalries long enough to plot Paul Atreides' downfall.",
                    DetailedHistory = "An Emperor whose prescience made him unpredictable and whose Fremen legions made him untouchable by ordinary force left the Bene Gesserit, the Spacing Guild, and the Bene Tleilax no good options; they set their old rivalries aside and came at him together. Reverend Mother Gaius Helen Mohiam and the bloated Guild Steersman Edric handled the political cover. The Tleilaxu Face Dancer Scytale brought the real weapon: a ghola of Paul's dead swordmaster Duncan Idaho, grown from cellular stock and renamed Hayt, built to break Paul from the inside by dragging old loyalties and old grief back to the surface. The final blow landed through a stolen Guild weapon that killed Paul's beloved Chani and burned out his eyes, so he stood blind in a universe where prescience alone let him still see anything at all. It did not break him the way the conspirators wanted. Instead he walked out into the desert to die by Fremen custom, vanished from the Imperium entirely, and left his sister Alia to rule in his place as Regent.",
                    ImagePath = "images/events/messiah_conspiracy.jpg",
                    RelatedEntityIds = new List<string> { "char_GaiusHelenMohiam", "char_Edric", "char_Scytale", "char_DuncanIdaho", "org_BeneTleilax", "org_BeneGesserit", "org_SpacingGuild" },
                    Timeframe = "Roughly twelve years into Paul's reign",
                    SortOrder = 110,
                    LastingImpact = "Blinded Paul Atreides and precipitated his eventual disappearance into the desert, paving the way for Alia's regency"
                },
                new HistoricalEvent
                {
                    Id = "event_AliaRegency",
                    Name = "Alia's Regency",
                    ShortDescription = "Alia Atreides rules as Regent, and the Baron's ego-memory quietly takes her over from within.",
                    DetailedHistory = "Paul was gone into the desert, and Leto II and Ghanima were still children, too young to rule; Alia stepped into the Regency instead. The same pre-birth awareness that gave the Atreides twins their power turned out to be the thing that destroyed her. Countless lifetimes of memory, absorbed before she was even born, proved too much psychic weight for one mind to hold, and the dominant, cruel personality of her grandfather's old enemy, Baron Vladimir Harkonnen, took her over. The Bene Gesserit have a name for it: Abomination. She ruled in secret thrall to the Baron's ego, worshipped in public the whole time as a living saint of the Church of Muad'Dib, and her reign curdled into something tyrannical and unstable, dangerous even to her own niece and nephew. Her collapse exposed just how much of a threat Abomination poses to any pre-born Atreides child, and it set up the choice Leto II would soon have to make about his own fate.",
                    ImagePath = "images/events/alia_regency.jpg",
                    RelatedEntityIds = new List<string> { "char_AliaAtreides", "char_BaronHarkonnen", "char_LetoIIAtreides", "char_GhanimaAtreides", "house_Atreides" },
                    Timeframe = "The years following Paul Atreides' disappearance",
                    SortOrder = 120,
                    LastingImpact = "Exposed the danger of Abomination among pre-born Atreides children and set the stage for Leto II's transformation"
                },
                new HistoricalEvent
                {
                    Id = "event_GoldenPathBegins",
                    Name = "The Golden Path Begins",
                    ShortDescription = "Leto II fuses with sandtrout and becomes God Emperor, a transformation his father refused to make.",
                    DetailedHistory = "Leto II carried the same pre-born awareness as his sister Ghanima, the same glimpse of a terrible future their father Paul had seen and turned away from. Young as he was, Leto chose what Paul could not: total physical surrender to transformation. Thousands of sandtrout, the larval sandworm, bound themselves to his skin and gave him near-invulnerability and strength no human should have, at the price of his humanity itself; an irreversible slide into something part man, part worm, had begun. Out of that transformation came his 3,500-year reign as God Emperor, an era of peace so absolute and so deliberately crushing that it was meant to teach humanity a lesson it would never forget: never again submit to a prescient tyrant, never again let a breeding program predict and control you. Leto named the whole design the Golden Path. Its purpose, in the end, was to scatter humanity far enough that no single power's foresight could ever reach all of it again.",
                    ImagePath = "images/events/golden_path_begins.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "bio_Sandtrout", "theo_GoldenPath", "house_Atreides" },
                    Timeframe = "Following Alia's regency",
                    SortOrder = 140,
                    LastingImpact = "Began the millennia-long reign of the God Emperor and the eventual Scattering of humanity"
                },
                new HistoricalEvent
                {
                    Id = "event_GuildFounding",
                    Name = "Founding of the Spacing Guild",
                    ShortDescription = "Spice-fueled prescience gives the Guild an unbreakable monopoly on interstellar travel.",
                    DetailedHistory = "Thinking machines had just been outlawed, and humanity scrambled for a replacement; a handful of people found one in melange itself. Enough of it, taken over enough time, produced a narrow, drug-soaked prescience, just enough to thread a course through folded space without clipping a star or a planet along the way. These were the first Guild Navigators, their bodies reshaped by a lifetime of spice saturation into something no longer quite human, and this one ability let them found the Spacing Guild and lock down interstellar travel entirely. No other method of faster-than-light navigation ever emerged to challenge them. Every Great House, every merchant, every pilgrim in the Imperium ended up permanently bound to the Guild, and through the Guild, bound to Arrakis, the only known source of the spice that made any of it possible.",
                    ImagePath = "images/events/guild_founding.jpg",
                    RelatedEntityIds = new List<string> { "org_SpacingGuild", "bio_Melange", "event_ButlerianJihad" },
                    Timeframe = "In the aftermath of the Butlerian Jihad",
                    SortOrder = 30,
                    LastingImpact = "Created the Spacing Guild's enduring monopoly on space travel and cemented melange as the most valuable substance in the universe"
                },

                // ---- Children of Dune / God Emperor of Dune / Heretics & Chapterhouse ----
                new HistoricalEvent
                {
                    Id = "event_TigerAssassinationAttempt",
                    Name = "The Tiger Assassination Attempt",
                    ShortDescription = "Someone sets genetically bred Laza tigers loose on the Atreides twins, and they are meant to die.",
                    DetailedHistory = "Wensicia Corrino wanted the last of the Atreides line gone, a clear road back to the throne for House Corrino, and her steward Javid helped her arrange it: Laza tigers, bred by the Bene Tleilax for nothing but savage efficiency, turned loose on two children. It nearly worked. The twins survived on reflexes and awareness alone, inherited straight from ancestral memory absorbed before birth, far beyond anything an ordinary child could manage. The failed attempt tore the lid off the wider conspiracy behind it and left House Corrino's remaining loyalists exposed and humiliated across the Landsraad. Leto II, above all, came out of it certain of something: the fate waiting for House Atreides and the Imperium would not change on its own.",
                    ImagePath = "images/events/tiger_assassination.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_GhanimaAtreides", "bio_LazaTiger", "char_WensiciaCorrino", "char_Javid" },
                    Timeframe = "During the Atreides twins' childhood",
                    SortOrder = 130,
                    LastingImpact = "Exposed the Corrino restoration conspiracy and hardened Leto II's resolve toward the Golden Path"
                },
                new HistoricalEvent
                {
                    Id = "event_DeathOfTheGodEmperor",
                    Name = "Death of the God Emperor",
                    ShortDescription = "Leto II dies at the Hidden Ford, and thirty-five hundred years of enforced peace end with him.",
                    DetailedHistory = "Thirty-five centuries of enforced peace came down to one confrontation at the Hidden Ford. His rebellious descendant Siona helped engineer it, her genetic invisibility to prescient sight the product of millennia of breeding Leto himself had directed, and a newly awakened Duncan Idaho ghola stood alongside her. He went over the edge of his cart into the river below, and water killed what nothing else could: a body fused with worm flesh cannot survive contact with it. As his flesh dissolved, thousands of sandtrout carried inside him spilled back into the wild, free for the first time in thirty-five hundred years. They went straight back to consuming Arrakis's water, and the planet began its slow slide from the lush world Leto had built back toward true desert, the world later called Rakis. His death closed the Golden Path's era of imposed peace and loosed the forces that would eventually drive humanity's Scattering.",
                    ImagePath = "images/events/death_of_god_emperor.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_SionaAtreides", "char_DuncanIdaho", "bio_Sandtrout", "loc_Rakis" },
                    Timeframe = "The end of the God Emperor's reign",
                    SortOrder = 150,
                    LastingImpact = "Ended the Golden Path's enforced peace, triggered the desert's return, and set the stage for the Scattering"
                },
                new HistoricalEvent
                {
                    Id = "event_TheScattering",
                    Name = "The Scattering",
                    ShortDescription = "Humanity floods out beyond the reach of any single power once the God Emperor's control is gone.",
                    DetailedHistory = "The God Emperor's all-seeing control had smothered the Imperium for millennia; the moment it lifted, uncounted numbers of people fled known space outright, scattering past Imperial law, past Bene Gesserit oversight, past even the Guild's own navigation routes. Free at last to build hidden civilizations on their own terms, these lost populations grew apart for generations, developing cultures and disciplines the Old Imperium they had abandoned would barely recognize. The Honored Matres rose chief among them, a matriarchal order that turned pleasure into a weapon of psychological domination sharp enough to match the Bene Gesserit blade for blade. Eventually the Scattered peoples began drifting back, the Honored Matres leading the way, running from something that frightened even them, and their return would upend a balance of power the Sisterhood had spent a thousand years holding steady.",
                    ImagePath = "images/events/the_scattering.jpg",
                    RelatedEntityIds = new List<string> { "event_DeathOfTheGodEmperor", "org_HonoredMatres", "org_SpacingGuild" },
                    Timeframe = "Following the death of the God Emperor",
                    SortOrder = 160,
                    LastingImpact = "Seeded the unknown civilizations - including the Honored Matres - that would return to threaten the Old Imperium"
                },
                new HistoricalEvent
                {
                    Id = "event_DestructionOfRakis",
                    Name = "Destruction of Rakis",
                    ShortDescription = "The Honored Matres wipe out the former Arrakis, and the galaxy loses its only known source of spice.",
                    DetailedHistory = "War with the Bene Gesserit over what remained of the old Imperium's power structures had been escalating for years, and the Honored Matres decided to settle one question for good: deny the Sisterhood any advantage the spice might offer by destroying Rakis outright. The attack erased the planet's entire sandworm population and its melange production in a single stroke, ending, since the days of Shai-Hulud and Muad'Dib, the only confirmed natural source of the most valuable substance in existence. Rakis gone, the Bene Gesserit had one option left, and it was a gamble: transplant a fragile, artificially cultivated worm ecology onto their hidden fortress world of Chapterhouse, with the sandrider and worm-speaker Sheeana guiding the effort. Rakis's long reign at the center of galactic power and commerce ended there, for good.",
                    ImagePath = "images/events/destruction_of_rakis.jpg",
                    RelatedEntityIds = new List<string> { "loc_Rakis", "org_HonoredMatres", "loc_Chapterhouse", "char_Sheeana", "bio_ShaiHulud" },
                    Timeframe = "During the Bene Gesserit-Honored Matre war",
                    SortOrder = 170,
                    LastingImpact = "Ended Rakis as the source of melange and forced the transplantation of sandworms to Chapterhouse"
                },

                // ---- Prelude to Dune (House trilogy) ----
                new HistoricalEvent
                {
                    Id = "event_IxianCoup",
                    Name = "The Ixian Coup",
                    ShortDescription = "The Bene Tleilax topple House Vernius and seize control of Ix.",
                    DetailedHistory = "The Imperial throne saw House Vernius's growing technological independence as a threat and quietly blessed what came next: a Bene Tleilax coup that seized Ix's advanced manufacturing base and forced Earl Dominic Vernius into hiding as a renegade smuggler. His family scattered in the chaos. His son Rhombur made it to Caladan, grew up alongside young Leto Atreides, and became one of his most trusted friends and advisors. Ix did not go dark. It kept producing forbidden technology under new, secretive Tleilaxu-linked management, and kept quietly supplying it to any Great House willing to overlook where it came from. Decades later, the coup's ripples were still spreading; Rhombur's exile and his bond with House Atreides sat chief among them.",
                    ImagePath = "images/events/ixian_coup.jpg",
                    RelatedEntityIds = new List<string> { "house_Vernius", "loc_Ix", "char_DominicVernius", "char_RhomburVernius", "org_BeneTleilax" },
                    Timeframe = "Prior to the events of Dune",
                    SortOrder = 40,
                    LastingImpact = "Exiled House Vernius, placed Ix under Tleilaxu-linked control, and forged Rhombur's lifelong bond with House Atreides"
                },
                new HistoricalEvent
                {
                    Id = "event_DeathOfDukePaulus",
                    Name = "Death of Duke Paulus Atreides",
                    ShortDescription = "A bullring accident, quietly arranged by House Harkonnen, kills Leto's father.",
                    DetailedHistory = "It looked like a tragic accident, nothing more: a bull in the Atreides bullring, drugged by Harkonnen agents to run erratic, then to settle just long enough to gore Duke Paulus Atreides fatally in front of a stunned crowd. No one proved the sabotage in Paulus's lifetime, and that fit the pattern; House Harkonnen preferred exactly this kind of indirect, deniable strike against its Atreides rivals, since open warfare ran straight into the Great Convention. Young Leto took command of House Atreides years before anyone expected, thrust into rulership with his education under his father's mentors still unfinished. The killing drove the blood feud between the two Houses deeper still, a quiet, generations-old grudge that would erupt decades later in the destruction of Leto's own household on Arrakis.",
                    ImagePath = "images/events/death_of_duke_paulus.jpg",
                    RelatedEntityIds = new List<string> { "char_DukePaulusAtreides", "char_DukeLetoAtreides", "house_Harkonnen", "house_Atreides" },
                    Timeframe = "Years before Duke Leto's arrival on Arrakis",
                    SortOrder = 50,
                    LastingImpact = "Placed Leto Atreides in command of House Atreides and deepened the Atreides-Harkonnen blood feud"
                },
                new HistoricalEvent
                {
                    Id = "event_ReverendMotherBreakthrough",
                    Name = "The First Reverend Mother Transformation",
                    ShortDescription = "Raquella Berto-Anirul's acolytes stumble onto the first true Reverend Mother transformation.",
                    DetailedHistory = "A wasting plague was killing her, and nothing in the fledgling Sisterhood's medicine could touch it, so Raquella Berto-Anirul, the order's founder, let her acolytes try a last-resort dose of toxic distillation rather than wait for certain death. She did not die. Something inside her shifted instead, neutralizing the poison and throwing open access to the full accumulated ancestral memory of her female bloodline; she became the first true Reverend Mother in history, by accident, on her deathbed. Later generations refined the breakthrough into a formal rite, the ritual ingestion of the Water of Life, and it gave the young Bene Gesserit order the one defining ability its entire future structure, training, and political power would be built around. Strip it away and the Sisterhood's later roles as truthsayers, advisors, and architects of the breeding program that eventually produced Paul Atreides simply do not happen.",
                    ImagePath = "images/events/reverend_mother_breakthrough.jpg",
                    RelatedEntityIds = new List<string> { "char_RaquellaBertoAnirul", "org_BeneGesserit", "art_WaterOfLife", "disc_BeneGesseritTraining" },
                    Timeframe = "In the founding decades of the Bene Gesserit, following the Butlerian Jihad",
                    SortOrder = 20,
                    LastingImpact = "Established the Reverend Mother transformation as the core rite of the Bene Gesserit Sisterhood"
                }
            };
        }
    }
}
