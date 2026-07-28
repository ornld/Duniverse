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
                    ShortDescription = "A composite scripture stitched together from the Known Universe's surviving faiths.",
                    DetailedHistory = "The Commission of Ecumenical Translators assembled the Orange Catholic Bible out of the wreckage religion left behind after the Butlerian Jihad. Christianity, Islam, Buddhism, Hinduism, Judaism, and dozens of smaller creeds all went into the mix. They fused into one scripture, built to keep faith from tearing humanity apart the way the war against thinking machines nearly had. The Jihad taught a brutal lesson. Unchecked technology and unchecked ideology had almost finished off the species. A shared spiritual framework offered some hope of heading off the next catastrophe. Great House courts cite it. Bene Gesserit teachings lean on it. Fremen sietch life quotes it in its own dialect. Each group reads something different into the same lines. Its lasting distrust of machine-worship gave the Butlerian Doctrine's ban a spiritual backbone. What began as hard political and military necessity turned into something closer to scripture.",
                    ImagePath = "images/theology/ocb.jpg",
                    RelatedEntityIds = new List<string> { "event_ButlerianJihad", "theo_ButlerianDoctrine" },
                    CoreTenets = "Reverence for a singular divine truth expressed through many inherited traditions; suspicion of machine-worship",
                    FoundationalTexts = new List<string> { "The Orange Catholic Bible", "The Azhar Book" }
                },
                new TheologicalSystem
                {
                    Id = "theo_ZensunniWanderers",
                    Name = "Zensunni Wanderers",
                    ShortDescription = "The ancestral Fremen faith, forged from Zen contemplation and Sunni Islamic tradition.",
                    DetailedHistory = "Generations of slavery, exile, and forced migration shaped the Zensunni faith long before its followers ever set foot on Arrakis. Zen Buddhist contemplative discipline merged with Sunni Islamic tradition. The result served one purpose: helping a persecuted people survive without losing themselves. Its stress on communal discipline and purification through hardship gave the Fremen's ancestors a way to outlast persecution across many worlds. The desert had not yet offered its own trials. The Zensunni Wanderers arrived on Arrakis carrying inherited habits of endurance and fierce communal loyalty. The planet demanded exactly that just to keep a person alive, and the fit proved uncanny. Those deep roots gave Fremen culture a gravity and toughness of its own. Later it made the people unusually ready to accept Paul Atreides as both political and religious leader.",
                    ImagePath = "images/theology/zensunni.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "theo_CultOfShaiHulud" },
                    CoreTenets = "Endurance through hardship, communal discipline, and spiritual purification through struggle",
                    FoundationalTexts = new List<string> { "Commentaries of the Zensunni Wanderers" }
                },
                new TheologicalSystem
                {
                    Id = "theo_CultOfShaiHulud",
                    Name = "Cult of Shai-Hulud",
                    ShortDescription = "Fremen worship of the sandworm as a living god of the desert.",
                    DetailedHistory = "Fremen religious life orbits Shai-Hulud. The sandworm is no mere predator to them. It is divine power made flesh on Arrakis. That status is confirmed by its role in producing the Water of Life and the melange that keeps the entire Imperium running. Poisoning a captured worm and transmuting its excretion into the Water of Life links the cult directly to the Bene Gesserit's own Reverend Mother rite. The Fremen had worked this connection out in their own religious terms long before outsiders showed up to make use of it. Reverence for the worm touches nearly everything. Crysknives are cut from its teeth. The worm-riding trial marks a young Fremen's passage into adulthood. Paul Atreides rose among the Fremen and was named the prophesied Lisan al-Gaib. From that point the cult's devotion to the sandworm fused with his own religious authority, and the two were never cleanly separable again.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.HereticsOfDune, "The worship outlived the worshippers. Thousands of years on, in a desert that had died and come back, it re-formed around a girl named Sheeana who could stand in open sand and give the worms orders, and the priesthood that grew up around her had no more idea what it was dealing with than the first Fremen had."),
                    },
                    ImagePath = "images/theology/shai_hulud.jpg",
                    RelatedEntityIds = new List<string> { "bio_ShaiHulud", "org_Fremen", "art_WaterOfLife", "theo_MahdiProphecy", "char_Sheeana", "loc_Rakis" },
                    CoreTenets = "The sandworm as the physical embodiment of the divine on Arrakis",
                    FoundationalTexts = new List<string> { "Oral Fremen liturgy passed through the sietches" }
                },
                new TheologicalSystem
                {
                    Id = "theo_MahdiProphecy",
                    Name = "Lisan al-Gaib Prophecy",
                    ShortDescription = "The messianic Mahdi prophecy the Missionaria Protectiva planted among the Fremen.",
                    DetailedHistory = "The Bene Gesserit's Missionaria Protectiva planted the prophecy of an off-world messiah, the Lisan al-Gaib, generations before anyone needed it. It was a survival contingency, nothing more. Any stranded Sister on a primitive world could claim instant religious authority and a shield against harm. The Fremen were one population among many across the Imperium seeded with this exact script. They had no idea the messiah they awaited had been written into their beliefs centuries earlier, by people with no real stake in its fulfillment. Paul Atreides arrived among them with his own prescient gifts and Bene Gesserit training. He read the prophecy's architecture clearly enough to use it, securing protection, loyalty, and eventually command over an entire people. A cynical fallback plan became the ideological engine of a jihad that swept the galaxy. Few episodes in Imperial history show so plainly how far a manufactured belief can travel once someone capable enough decides to claim it.",
                    ImagePath = "images/theology/mahdi.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "org_Fremen", "char_PaulAtreides" },
                    CoreTenets = "The coming of a Lisan al-Gaib who will lead the Fremen to paradise",
                    FoundationalTexts = new List<string> { "Panoplia Propheticus of the Missionaria Protectiva" }
                },
                new TheologicalSystem
                {
                    Id = "theo_ChurchOfMuadDib",
                    Name = "Church of Muad'Dib",
                    ShortDescription = "The state religion the Imperium built around Paul Atreides after his jihad.",
                    DetailedHistory = "After Paul took the Imperial throne, the Qizarate's bureaucratic machinery carried his image, teachings, and claimed divine authority to every corner of the galaxy. It moved at a speed no political conquest alone could match. Church doctrine held that Paul's rule was not just legitimate but divinely ordained. The jihad itself kept reinforcing that claim, spreading the faith by conquest even as it preached his message of religious truth. Paul carried no illusions about the religion built in his name. His own prescience showed him the suffering it would cause. His power, vast as it was, could not slow or redirect the thing once it had been set loose. By the time he vanished into the desert, the Church had already grown strong enough to survive him. It went on evolving under regents and successors, guarding its own authority about as fiercely as it guarded Paul's original intentions.",
                    ImagePath = "images/theology/muaddib_church.jpg",
                    RelatedEntityIds = new List<string> { "char_PaulAtreides", "org_Qizarate", "loc_Onn", "event_MuadDibJihad", "char_BronsoOfIx" },
                    CoreTenets = "Paul Atreides as messiah and emperor whose rule is divinely ordained",
                    FoundationalTexts = new List<string> { "The sermons and proclamations of Muad'Dib" }
                },
                new TheologicalSystem
                {
                    Id = "theo_OtherMemoryPhilosophy",
                    Name = "Litany Against Fear",
                    ShortDescription = "The Bene Gesserit mental discipline for mastering fear and unlocking ancestral memory.",
                    DetailedHistory = "The Sisterhood's mental discipline and the ordeal of the Spice Agony both rest on the same idea. Fear is the single greatest obstacle to clear thought and effective action. It is 'the mind-killer,' something to be named, faced, and let to pass rather than pushed down or denied. That premise gives Bene Gesserit acolytes a tool they can return to again and again. It is something to grip during extreme danger, pain, or the crushing weight of absorbing centuries of ancestral memory during the Reverend Mother transformation. Lady Jessica recites the Litany in moments of mortal danger, well past its most famous use in the Spice Agony. That shows how far the philosophy has worked its way into ordinary Bene Gesserit life. Self-mastery, not suppression, opens the path past fear. That single insistence captures the whole Bene Gesserit worldview: human potential unlocked through disciplined confrontation with one's limits rather than flight from them.",
                    ImagePath = "images/theology/litany.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "disc_BeneGesseritTraining", "char_LadyJessica" },
                    CoreTenets = "Fear is the mind-killer; mastery of self grants access to Other Memory",
                    FoundationalTexts = new List<string> { "The Litany Against Fear" }
                },
                new TheologicalSystem
                {
                    Id = "theo_ButlerianDoctrine",
                    Name = "Butlerian Doctrine",
                    ShortDescription = "The universal ban on thinking machines that emerged from the Butlerian Jihad.",
                    DetailedHistory = "The generations-long Butlerian Jihad ended with this doctrine enshrined at the center of civilization. No machine may be built in the likeness of a human mind. Breaking that rule ranks among the gravest crimes a person or institution can commit. The prohibition remade nearly every institution that came after it. Mentats emerged to replace computational machines with trained human minds. Guild Navigators turned to prescient, spice-fueled navigation instead of machine-guided flight. The Bene Gesserit built their disciplines around human potential rather than artificial augmentation. Ix kept producing advanced technology after the Jihad. It took great pains to maintain, in public at least, the fiction that none of it crossed the doctrine's line. The Imperium's response to a genuine violation was not something anyone wanted to test. Ten thousand years on, the doctrine stood largely unchallenged. It was a standing reminder of how close the species had once come to wiping itself out through its own inventions.",
                    ImagePath = "images/theology/butlerian.jpg",
                    RelatedEntityIds = new List<string> { "event_ButlerianJihad", "disc_Mentat", "loc_Ix", "char_Omnius", "char_Erasmus", "char_SerenaButler", "org_LeagueOfNobles", "org_SynchronizedWorlds" },
                    CoreTenets = "Thou shalt not make a machine in the likeness of a human mind",
                    FoundationalTexts = new List<string> { "The Great Convention's prohibitions on computers" }
                },
                new TheologicalSystem
                {
                    Id = "theo_TleilaxuFaith",
                    Name = "Tleilaxu Faith",
                    ShortDescription = "The closed, secretive religious philosophy that guides the Bene Tleilax.",
                    DetailedHistory = "A heterodox offshoot of older Zensunni belief underlies everything the Tleilaxu do, and the order guards it jealously. Outsiders rarely get more than fragments of the actual doctrine. The Tleilaxu treat secrecy itself as a spiritual principle, and a useful one, since it denies rivals any real window into what they actually want. Piety and calculation braid together so tightly that the order's biological work gets presented as devout craft rather than goods for sale. That framing has bought the Tleilaxu far more influence than their small homeworld and modest numbers would otherwise earn them. Rivals who wrote the whole thing off as cover for plain opportunism have more than once discovered, too late, how patient the planning underneath it runs.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.HereticsOfDune, "The doctrine came out eventually, and it was not what anyone had assumed. The Tleilaxu had spent millennia playing the humble tradesman for a galaxy they privately regarded as populated by animals, waiting on a promised age of their own. Every ghola sold and every Face Dancer placed had been a move in that, and the people buying had never once thought to ask what the sellers believed they were building toward."),
                    },
                    ImagePath = "images/theology/tleilaxu_faith.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneTleilax", "loc_Tleilax", "char_Scytale" },
                    CoreTenets = "Secretive devotion combining genetic mastery with a belief in eventual Tleilaxu supremacy",
                    FoundationalTexts = new List<string> { "Undisclosed Tleilaxu religious texts" }
                },
                new TheologicalSystem
                {
                    Id = "theo_GoldenPath",
                    Name = "The Golden Path",
                    ShortDescription = "Leto II's thirty-five-century campaign of enforced peace, meant to save humanity from itself.",
                    DetailedHistory = "Leto II inherited his father's prescience and drew the conclusion Paul had refused to act on. Humanity ruled from one predictable centre and watched by one set of eyes was drifting toward a quiet end, and only a single thread of future ran past it. Paul had seen that thread and turned away from what it asked. His son did not. Walking it cost him his body, since he let the sandtrout bind themselves to his skin and accepted what that would slowly make of him. The doctrine built on that sacrifice is simple to state and unbearable to live under: hold the species still under one throne for as long as it takes, and press hard enough that it learns to hate being ruled by anything that can predict it. Whatever comes through that lesson goes out past the reach of any one power's foresight, and never lets itself be herded again. Leto took the throne knowing exactly how he would be remembered, and counted the hatred as a working part of the design.",
                    HistoryLayers = new List<HistorySegment>
                    {
                        new(SpoilerTier.GodEmperorOfDune, "The reign ran thirty-five hundred years. He held it as God Emperor, worshipped through a religion he administered himself, policed by the all-female Fish Speakers, and funded out of a spice hoard nobody else could reach. He kept travel scarce and the Great Houses bored, and he steered his own bloodline toward people no prescience could track, so that nobody following him could work the trick he was working. His stolen journals came out of a sealed chamber long after his death and set the whole design down in his own voice, addressed to readers he had chosen without ever meeting them."),
                        new(SpoilerTier.HereticsOfDune, "Roughly fifteen hundred years after he died, the people who had gone out started coming back. They arrived in numbers nobody could total and in ships no prescience could locate, and the worst of them, the Honored Matres, fought with a savagery the Imperium had no answer for. Humanity had grown too large and too well hidden for any one power, or any one seer, to gather up again. Sisters who called Leto the Tyrant in every other sentence granted him that much, and granted him nothing else."),
                    },
                    ImagePath = "images/theology/golden_path.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "event_GoldenPathBegins", "bio_Sandtrout" },
                    CoreTenets = "Enforced peace and stagnation now to guarantee humanity's long-term survival and dispersal",
                    FoundationalTexts = new List<string> { "The Stolen Journals of Leto II" }
                },
                new TheologicalSystem
                {
                    Id = "theo_FedaykinCreed",
                    Name = "Fedaykin Creed",
                    ShortDescription = "The death-commando creed of Paul's most devoted Fremen shock troops.",
                    DetailedHistory = "The Fedaykin were Paul Atreides' elite death-commandos, drawn from the fiercest and most devoted of his Fremen followers. They did not treat near-certain death in Muad'Dib's service as a grim price of war. They treated it as a sacred act that bought paradise outright. That conviction made them at once the most feared and the most fatalistic soldiers fighting the jihad. This creed turned ordinary battlefield risk into religious opportunity. It produced fighters who took on missions so dangerous that other forces across the Imperium would have called them suicidal rather than merely difficult. Commanders like Stilgar leaned on Fedaykin units for exactly this reason. Their fatalism let them carry out plans no unit bound by ordinary self-preservation would ever attempt. Military discipline and religious certainty fused into one thing here. That fusion captures the larger shift the Fremen underwent under Paul. A people once fighting simply to survive Arrakis became a force convinced it was waging holy war for stakes that outlasted death itself.",
                    ImagePath = "images/theology/fedaykin.jpg",
                    RelatedEntityIds = new List<string> { "char_Stilgar", "char_Chani", "char_Otheym", "event_MuadDibJihad" },
                    CoreTenets = "Death in service to Muad'Dib is sacred and guarantees paradise",
                    FoundationalTexts = new List<string> { "Oral Fedaykin death-vows" }
                }
            };
        }
    }
}
