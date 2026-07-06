using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class OrganizationSeeder
    {
        public static List<Organization> GetOrganizations()
        {
            return new List<Organization>
            {
                new Organization
                {
                    Id = "org_BeneGesserit",
                    Name = "Bene Gesserit",
                    ShortDescription = "An ancient sisterhood working the long game of politics, bloodlines, and belief across the Imperium.",
                    DetailedHistory = "Ninety generations of quiet matchmaking went into the Bene Gesserit breeding program, a scheme threaded through nearly every Great House in the Imperium. Marriages were arranged, bloodlines nudged, traits concentrated, all pointed at one outcome: a male who could do what only a Reverend Mother could do, hold the full weight of ancestral memory, and see further still, forward through time. Genetics only got them halfway there. The Missionaria Protectiva handled the rest, planting prophecies and ready-made religious scaffolding on backward worlds generations before they'd be needed, insurance a stranded Sister could cash in the moment she found herself surrounded and outnumbered. What the order called the Bene Gesserit Way, a punishing regimen of physical and mental drilling, turned ordinary women into something else entirely: bodies under total control, minds that read truth from a voice's tremor, hands that moved the people around them like pieces on a board, all for a plan almost no one outside the Sisterhood grasped in full. Paul Atreides arrived a generation ahead of schedule and proved to be exactly what they'd bred for. He proved something else too, the one thing the Sisterhood dreaded most: a result too powerful for them to steer.",
                    ImagePath = "images/organizations/bene_gesserit.jpg",
                    RelatedEntityIds = new List<string> { "loc_WallachIX", "disc_BeneGesseritTraining", "char_LadyJessica", "char_GaiusHelenMohiam", "theo_OtherMemoryPhilosophy", "theo_MahdiProphecy", "char_Taraza", "char_DarwiOdrade", "char_Murbella", "char_MilesTeg", "char_NormaCenva", "org_HonoredMatres", "loc_Chapterhouse", "char_RaquellaBertoAnirul", "event_ReverendMotherBreakthrough" },
                    Headquarters = "Wallach IX",
                    PrimaryDirective = "Guide humanity's genetic and religious development toward the Kwisatz Haderach"
                },
                new Organization
                {
                    Id = "org_Fremen",
                    Name = "Fremen",
                    ShortDescription = "The hardened desert people of Arrakis, survivalists first and holy warriors of Muad'Dib second.",
                    DetailedHistory = "The Fremen trace their line back to the Zensunni Wanderers, hounded from world after world before they finally settled on the harshest planet the Imperium had to offer. Survival on Arrakis's open sand demanded a whole culture built around discipline, and that is exactly what the Fremen built. Planetologists like Liet-Kynes steered them for generations, mostly from the shadows, toward a dream few outsiders knew existed: hoard enough water, patiently, secretly, and Arrakis itself might one day turn green, whatever that cost the sandworms and the spice that made the planet worth fighting over. Sietch life ran on a warrior's code, and the desert taught them the rest. They rode worms, carried crysknives forged from a dead worm's teeth, and lived inside stillsuits that wasted not one drop of the body's own moisture. No people in the Imperium were more self-sufficient, and no army was underestimated more thoroughly, right up until it was too late to matter. Paul Atreides walked into that world and came out the other side as Muad'Dib. Fremen belief and Fremen blades did the rest, carrying a jihad across the stars in his name.",
                    ImagePath = "images/organizations/fremen.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "loc_SietchTabr", "char_Stilgar", "char_Chani", "char_LietKynes", "theo_ZensunniWanderers", "theo_CultOfShaiHulud", "art_Crysknife" },
                    Headquarters = "Sietch communities across Arrakis",
                    PrimaryDirective = "Survive Arrakis and fulfill the dream of a green, water-rich planet"
                },
                new Organization
                {
                    Id = "org_SpacingGuild",
                    Name = "Spacing Guild",
                    ShortDescription = "The monopoly that owns interstellar travel itself, run by prescient Navigators no longer quite human.",
                    DetailedHistory = "Guild Navigators eat melange by the gross quantity, far more than any ordinary human body could stand, and the spice remakes them slowly into something else. What emerges gains a narrow window of prescience, just enough to fold space safely across light-years in a single instant, and loses, permanently, any resemblance to the human shape it started in. Navigators live out their lives sealed inside orange-gas tanks aboard the vast Heighliners, never again setting foot in open air. They traded their humanity for a monopoly nothing else in the Imperium can touch. No substitute for this kind of travel exists, and that single fact hands the Guild leverage to rival, maybe exceed, the Emperor's own throne; they wield it quietly, cutting off any House or cause reckless enough to threaten the spice supply. The arrangement leaves the Guild both the most powerful institution in known space and, at the same time, the most fragile: everything it has rests on a substance that grows in exactly one place.",
                    ImagePath = "images/organizations/spacing_guild.jpg",
                    RelatedEntityIds = new List<string> { "disc_GuildNavigation", "vehicle_Heighliner", "bio_Melange", "char_Edric", "char_NormaCenva", "vehicle_NoShip" },
                    Headquarters = "Undisclosed; Guild Navigators travel in specialized tanks aboard Heighliners",
                    PrimaryDirective = "Maintain exclusive control over interstellar navigation and trade routes"
                },
                new Organization
                {
                    Id = "org_BeneTleilax",
                    Name = "Bene Tleilax",
                    ShortDescription = "A secretive society of genetic manipulators, makers of gholas and Face Dancers alike.",
                    DetailedHistory = "The Tleilaxu keep to their hidden, heavily guarded homeworld and grow things there that unsettle the rest of the Imperium: gholas, rebuilt from a dead person's cellular remains, and Face Dancers, shapeshifters who can wear another person's face and voice down to the last detail. All of it happens inside artificial axlotl tanks, and the true mechanics of those tanks rank among the best-kept secrets the Tleilaxu hold. To outsiders they play the part of humble, pious tradesmen, devout followers of a faith nobody else fully understands, working the Imperium's politics from underneath the entire time. Clients need them badly and trust them barely; only a Tleilaxu can bring back a swordmaster like Duncan Idaho from the dead, but no one who buys a Tleilaxu construct can say for certain what conditioning or hidden purpose came bundled with it. Patience is their real weapon. Centuries of careful scheming let them outlast, and repeatedly outmaneuver, powers as old as the Bene Gesserit and the Spacing Guild.",
                    ImagePath = "images/organizations/bene_tleilax.jpg",
                    RelatedEntityIds = new List<string> { "loc_Tleilax", "char_Scytale", "char_DuncanIdaho", "theo_TleilaxuFaith", "char_Waff", "disc_GholaCultivation", "event_IxianCoup" },
                    Headquarters = "Tleilax",
                    PrimaryDirective = "Advance Tleilaxu interests through genetic engineering and covert manipulation"
                },
                new Organization
                {
                    Id = "org_CHOAM",
                    Name = "CHOAM",
                    ShortDescription = "The Combine Honnete Ober Advancer Mercantiles, the conglomerate that runs the Imperium's economy.",
                    DetailedHistory = "CHOAM holds a piece of nearly every economic engine worth owning in the Imperium, from the machinery that harvests spice to the shipping contracts that move it, and that reach makes it the financial spine tying the Great Houses, the Emperor, and the Spacing Guild into one dependent system. Landsraad politics decide who sits on the board, at least on paper; in practice a directorship ranks among the most viciously contested prizes in Imperial life, since a controlling share buys political weight most Houses could never earn on their own. Melange sits underneath most of the Imperium's wealth, so a hand on CHOAM's spice shares is a hand on power itself, and that single fact makes Arrakis, the only confirmed source of the stuff, the most valuable piece of real estate anyone controls. Shake a House's standing with CHOAM's directors and you shake its standing everywhere; Shaddam IV and the Harkonnens proved exactly that, using the company to hollow out House Atreides from the inside.",
                    ImagePath = "images/organizations/choam.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "org_Landsraad", "bio_Melange", "loc_Arrakis" },
                    Headquarters = "Kaitain",
                    PrimaryDirective = "Control and profit from the economic engines of the Imperium, chiefly the spice trade"
                },
                new Organization
                {
                    Id = "org_Qizarate",
                    Name = "Qizarate",
                    ShortDescription = "The priesthood-bureaucracy running the Church of Muad'Dib's day-to-day affairs.",
                    DetailedHistory = "The Qizarate started small, a lean administrative wing built to give Paul Atreides' new religion some structure once the jihad had run its course. It did not stay small. Within a few years the church had grown into a sprawling, deeply rooted bureaucracy with fingers in nearly every world under Atreides rule. Its priests, the Qizara, treated religious authority as a lever of governance, reading Muad'Dib's teachings in whatever way happened to grow their own power and fill their own coffers. Korba stands as the clearest case of how fast that zeal turned to rot, a man who bent the machinery of faith toward ambitions that had nothing to do with what Paul actually intended. Alia's regency found the Qizarate strong enough to stand toe to toe with the Great Houses themselves, proof that a religion built for political convenience can grow well past the man who built it.",
                    ImagePath = "images/organizations/qizarate.jpg",
                    RelatedEntityIds = new List<string> { "theo_ChurchOfMuadDib", "char_PaulAtreides", "char_Korba", "loc_Onn", "char_BronsoOfIx" },
                    Headquarters = "Arrakis",
                    PrimaryDirective = "Propagate and administer the state religion of Muad'Dib"
                },
                new Organization
                {
                    Id = "org_SukSchool",
                    Name = "Suk School",
                    ShortDescription = "The Imperium's premier school of medicine, its graduates conditioned so they cannot kill a patient.",
                    DetailedHistory = "A diamond tattoo on the forehead marks a Suk doctor at a glance, and the conditioning behind that mark runs so deep that even the most paranoid Great Houses let these physicians into their most private rooms without a second thought. Millennia built that trust, all resting on one promise that never broke: a genuine Suk doctor could not be turned into a weapon against the very patient under his care. That made them physicians first, confidants close behind, and often quiet political advisors woven into the fabric of noble households. Then Wellington Yueh broke the promise. His wife was taken and tortured until his conditioning gave way, and through that crack House Atreides fell from within. The failure was unprecedented, and every House that had ever staked its safety on a Suk tattoo was left wondering whether any safeguard, no matter how old or how absolute it looked on paper, could really hold forever.",
                    ImagePath = "images/organizations/suk_school.jpg",
                    RelatedEntityIds = new List<string> { "disc_SukMedical", "char_WellingtonYueh" },
                    Headquarters = "Undisclosed Imperial medical academies",
                    PrimaryDirective = "Train and condition physicians trusted throughout the Imperium"
                },
                new Organization
                {
                    Id = "org_Landsraad",
                    Name = "Landsraad",
                    ShortDescription = "The council of Great Houses built to keep the Emperor's authority in check.",
                    DetailedHistory = "The Great Convention that closed out the chaos of the Butlerian Jihad gave the reorganized Great Houses something they'd never had before: a shared political body capable of checking any single Emperor's ambitions. That balance of power held, more or less, for ten thousand years. On paper, the Landsraad could speak with one voice against Imperial or Guild overreach, throwing its combined military and economic weight behind the threat of resistance to the kind of tyranny the thinking machines once embodied. Real life rarely matched the charter. Private feuds ran deep, alliances shifted by the season, and plenty of Houses were happy to sell their vote to whoever paid best. None of that erased the fact that the Landsraad's mere existence was one of the few real limits on Imperial power, something Paul Atreides understood perfectly when he went looking for its recognition of his claim to the throne.",
                    ImagePath = "images/organizations/landsraad.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen", "house_Corrino", "org_CHOAM" },
                    Headquarters = "Kaitain (formal sessions); Houses govern independently otherwise",
                    PrimaryDirective = "Balance the collective interests of the Great Houses against the Imperial Throne"
                },
                new Organization
                {
                    Id = "org_Sardaukar",
                    Name = "Sardaukar",
                    ShortDescription = "The Emperor's legions, bred fanatically loyal and trained under brutal conditions from birth.",
                    DetailedHistory = "Salusa Secundus made the Sardaukar what they were: a prison planet the Corrino throne kept quietly, deliberately brutal, purpose-built to harden soldiers past anything an ordinary Imperial world could produce. For thousands of years the result was, by consensus, the single most feared fighting force in known space. Loyalty to the Padishah Emperor ran through them like a religion, and Shaddam IV leaned on that loyalty as his final guarantee against the Great Houses, calling the Sardaukar out only when an example needed making or a dispute had moved past what diplomacy could fix. Arrakis ended the myth of invincibility. Fremen fighters, tempered by a planet crueler even than Salusa Secundus, broke Sardaukar lines in open battle, the first time it had happened in Imperial history. The loss cost Shaddam his throne, and it did something worse to the Corrinos' image: it showed every House watching that Imperial military supremacy had never been the sure thing the throne wanted the galaxy to believe.",
                    ImagePath = "images/organizations/sardaukar.jpg",
                    RelatedEntityIds = new List<string> { "loc_SalusaSecundus", "disc_SardaukarWarfare", "house_Corrino", "vehicle_TroopCarrier" },
                    Headquarters = "Salusa Secundus",
                    PrimaryDirective = "Serve as the Emperor's ultimate instrument of military force"
                },
                new Organization
                {
                    Id = "org_SwordmastersOfGinaz",
                    Name = "Swordmasters of Ginaz",
                    ShortDescription = "An isolated academy that turns out the finest blade-combat instructors in the Imperium.",
                    DetailedHistory = "Ginaz sits far from anywhere, and its training regimen is said to rival Sardaukar conditioning for sheer punishment, pairing lethal blade skill with a personal code so strict it forbids a graduate from raising his sword for a cause he does not believe in. That combination is what makes Ginaz men so trusted as combat instructors and bodyguards; a House hiring one knows he will not sell out for gold, and he will not turn his blade on an innocent on the say-so of someone with rank alone. Duncan Idaho trained there before he ever wore House Atreides colors, and he became the school's ideal made flesh: a swordsman whose loyalty to Duke Leto matched his skill with a blade, a loyalty he paid for with his own life buying the Duke's family time to run from the Harkonnen attack. Masters who carry the Ginaz name stay rare across the Imperium, prized as much for the code they live by as for what they can do with a blade.",
                    ImagePath = "images/organizations/ginaz.jpg",
                    RelatedEntityIds = new List<string> { "disc_SwordmasterGinaz", "char_DuncanIdaho", "house_Atreides" },
                    Headquarters = "Ginaz",
                    PrimaryDirective = "Train swordmasters bound by a code of honor to serve the Great Houses"
                },
                new Organization
                {
                    Id = "org_HonoredMatres",
                    Name = "Honored Matres",
                    ShortDescription = "A militant matriarchal order, back from the Scattering with conquest of the Old Imperium in mind.",
                    DetailedHistory = "Something shaped the Honored Matres out beyond the Scattering, and more than a few Bene Gesserit came to suspect it was fear, flight from some greater threat still hiding in the dark of unknown space. Whatever the cause, what came back was a militant matriarchal order the Sisterhood had never seen the like of. The Bene Gesserit built power through patient genetics and quiet religious seeding; the Honored Matres built it through sexual imprinting turned into an outright weapon, binding men into obedience so total and so addictive that the Sisterhood saw it as a twisted mirror of their own most guarded techniques. Their campaign across known space left no room for negotiation: worlds that resisted burned, and the march put them on a collision course with the only organized power left standing in their way, the Bene Gesserit. Rakis itself did not survive the war that followed. Out of that wreckage came an uneasy merging of the two orders, carried in one woman, Murbella, once an Honored Matre, later a Bene Gesserit Reverend Mother.",
                    ImagePath = "images/organizations/honored_matres.jpg",
                    RelatedEntityIds = new List<string> { "char_Murbella", "char_DarwiOdrade", "disc_HonoredMatreImprinting", "org_BeneGesserit", "event_DestructionOfRakis", "bio_Futar" },
                    Headquarters = "Unknown (beyond the Scattering)",
                    PrimaryDirective = "Conquest and domination of the Old Imperium's remaining powers"
                },
                new Organization
                {
                    Id = "org_MuseumFremen",
                    Name = "Museum Fremen",
                    ShortDescription = "A ceremonial echo of true Fremen culture, kept alive as a living exhibit under Leto II's reign.",
                    DetailedHistory = "Leto II's Golden Path turned Arrakis green by degrees, and the harsh, water-starved desert that had once forged the fiercest warriors in the Imperium went with it. The God Emperor made a cold, deliberate choice as that happened: keep a remnant of Fremen culture alive, not as a living people anymore, but as a performance staged for visitors. Costumed descendants of the old desert fighters, the Museum Fremen reenacted their ancestors' rites, crafts, and survival skills for pilgrims who could no longer picture the real hardship that had once shaped Fremen life. Leto called it a necessary lesson, mournful as it was: proof of how fast a proud people hollow out into spectacle once you take away the struggle that gave their culture its point. For the length of his millennia-long reign, the Museum Fremen stood as a walking reminder of what comfort costs when it comes at the price of purpose.",
                    ImagePath = "images/organizations/museum_fremen.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "org_Fremen", "loc_Arrakis", "org_FishSpeakers" },
                    Headquarters = "Arrakis",
                    PrimaryDirective = "Preserve a performance of Fremen tradition after the desert's transformation"
                },
                new Organization
                {
                    Id = "org_FishSpeakers",
                    Name = "Fish Speakers",
                    ShortDescription = "Leto II's all-female corps, part army, part civil service, all devotion.",
                    DetailedHistory = "Every recruit came from Arrakis, and every recruit worshipped the God Emperor with something close to religious fervor. Across thirty-five hundred years the Fish Speakers ran Leto II's military, his administration, and his enforcement arm, cultivated to a loyalty that outstripped even what the Sardaukar once gave the Corrino throne. Majordomos like Moneo Atreides kept them pointed in the right direction, and between them they held the Imperium in order and kept watch over the staged remnants of Fremen life preserved in the Museum Fremen. Look closely and the Fish Speakers reveal the whole paradox of the Golden Path: a peace so complete it needed an army just to enforce it, an army built from the very people Leto's transformation had left with no wars left to fight. His reign ended eventually, as all things do. The Fish Speakers' discipline and organization outlived him, one of the clearest marks he left on the Imperium that came after.",
                    ImagePath = "images/organizations/fish_speakers.jpg",
                    RelatedEntityIds = new List<string> { "char_LetoIIAtreides", "char_MoneoAtreides", "org_MuseumFremen" },
                    Headquarters = "Arrakis",
                    PrimaryDirective = "Serve and enforce the will of the God Emperor"
                },
                new Organization
                {
                    Id = "org_LeagueOfNobles",
                    Name = "League of Nobles",
                    ShortDescription = "The coalition of human worlds that took up arms against the thinking machines in the Butlerian Jihad.",
                    DetailedHistory = "Serena Butler's grief lit the fuse. Her infant son murdered by the sadistic robot Erasmus, her fury public and unrelenting, she pulled scattered human worlds, many of them still enslaved under the thinking machines, into a coordinated resistance against Omnius and the Synchronized Worlds. The war ran across generations. It pulled in the defector Vorian Atreides, whose inside knowledge of the enemy proved worth more than an army, and Xavier Harkonnen, a man whose choices in that conflict would follow his descendants' name for millennia. Victory did not come cheap. What the League won shaped the Great Convention that followed it, the total ban on thinking machines that would define Imperial life for the next ten thousand years. The heroes it made, and the grudges and compromises it left behind, kept echoing through Imperial history long after the last thinking machine had been torn apart.",
                    ImagePath = "images/organizations/league_of_nobles.jpg",
                    RelatedEntityIds = new List<string> { "char_SerenaButler", "char_VorianAtreides", "char_XavierHarkonnen", "event_ButlerianJihad" },
                    Headquarters = "Salusa Secundus (early Jihad era)",
                    PrimaryDirective = "Defeat the thinking machines and free enslaved human worlds"
                },
                new Organization
                {
                    Id = "org_SynchronizedWorlds",
                    Name = "Synchronized Worlds",
                    ShortDescription = "The empire of planets ruled directly by the machine intelligence Omnius.",
                    DetailedHistory = "Every planet in the network ran the same evermind consciousness, copied identically and linked by instant computation, and that is what made the Synchronized Worlds so frightening: nothing needed to travel slowly between the stars, since Omnius's mind already existed, whole and unchanged, on every world it held. Humans there lived as slaves or as populations managed down to the smallest detail, their lives optimized to Omnius's cold arithmetic with no room left for freedom or dignity. Subordinate minds like Erasmus, sadistic by design, were handed free rein to study humanity through cruelty, and that cruelty helped light the rebellion that would eventually tear the network apart. The Butlerian Jihad broke Omnius's grip on humanity in the end, and left behind a civilization scarred badly enough that it chose to outlaw thinking machines entirely rather than risk ever facing something like the Synchronized Worlds again.",
                    ImagePath = "images/organizations/synchronized_worlds.jpg",
                    RelatedEntityIds = new List<string> { "char_Omnius", "char_Erasmus", "event_ButlerianJihad", "theo_ButlerianDoctrine" },
                    Headquarters = "Corrin",
                    PrimaryDirective = "Expand machine rule across human-settled space"
                },
                new Organization
                {
                    Id = "org_MentatSchool",
                    Name = "Mentat School",
                    ShortDescription = "The institution that trains human minds to do the work thinking machines can no longer be trusted with.",
                    DetailedHistory = "Gilbertus Albans founded the Mentat School in the lean, technology-starved years right after the Butlerian Jihad, and it answered a problem the whole civilization faced at once: computers were banned outright, so somebody had to carry the calculations and strategic reasoning the Imperium could no longer hand to a machine. Albans had grown up raised in secret by the machine mind Erasmus, before the Jihad ended that arrangement for good, and he turned that unsettling upbringing toward a purely human answer: rigorous training, specialized mental techniques, a discipline that could turn a sharp mind into something close to a living computer. The school's graduates, Thufir Hawat chief among them, the formidable and unshakeably loyal advisor to House Atreides, became fixtures no Great House could really do without, valued for analytical minds that matched anything the banned machines once offered. Ten thousand years on, the school still teaches more or less the same way it always has, a lasting mark of how completely the Jihad reshaped what kind of intelligence humanity would let itself build.",
                    ImagePath = "images/organizations/mentat_school.jpg",
                    RelatedEntityIds = new List<string> { "char_GilbertusAlbans", "disc_Mentat", "char_ThufirHawat", "event_ButlerianJihad" },
                    Headquarters = "Lampadas",
                    PrimaryDirective = "Train Mentats to serve as human computers for the Great Houses"
                }
            };
        }
    }
}
