using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class ArtifactSeeder
    {
        public static List<Artifact> GetArtifacts()
        {
            return new List<Artifact>
            {
                new Artifact
                {
                    Id = "art_GomJabbar",
                    Name = "Gom Jabbar",
                    ShortDescription = "A needle tipped with instant-killing poison. The Bene Gesserit use it to test whether someone counts as human.",
                    DetailedHistory = "The name comes from an old Fremen phrase for 'high-handed enemy.' It fits a needle whose poison drops a victim in seconds. Reverend Mother Gaius Helen Mohiam pressed one to young Paul Atreides' throat during his childhood trial at Castle Caladan. Her hand stayed steady. She waited for the instant his composure broke or his fingers slipped from the pain box. The needle supplies the stakes that make the whole ordeal matter. Only someone who can master raw animal instinct earns the right to pull back a hand and keep breathing. That is a human by the Sisterhood's unforgiving definition. Paul survived with the needle still at his neck, and that told Mohiam something unsettling. He might be more than just another heir waiting his turn.",
                    ImagePath = "images/artifacts/gom_jabbar.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_PaulAtreides", "char_GaiusHelenMohiam" },
                    PrimaryMaterial = "Metal needle, poison",
                    Functionality = "Lethal execution/Test of humanity"
                },
                new Artifact
                {
                    Id = "art_Crysknife",
                    Name = "Crysknife",
                    ShortDescription = "The Fremen's sacred blade, carved from a dead sandworm's tooth. They treat it as far more than a weapon.",
                    DetailedHistory = "The crysknife is carved from the tooth of a slain sandworm. It needs careful treatment to keep from crumbling once it leaves the electrical field of its owner's body. That fragility only deepens the reverence Fremen hold for it. Fremen custom treats a human's water as tribal property in the end, and the same logic extends to the blade. Draw a crysknife and it must taste blood before it returns to its sheath. The rule turns every duel into something with genuine weight rather than theater. The blades run deeply personal, so handing one over counts as a serious act of trust. Stilgar's gift of a crysknife to Paul Atreides marked real progress in Paul's standing among the Fremen of Sietch Tabr. Carrying one properly, knowing its rules and living by them, said as much about belonging as any spoken oath.",
                    ImagePath = "images/artifacts/crysknife.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "loc_Arrakis", "char_Stilgar" },
                    PrimaryMaterial = "Sandworm tooth",
                    Functionality = "Ritual combat weapon"
                },
                new Artifact
                {
                    Id = "art_Stillsuit",
                    Name = "Stillsuit",
                    ShortDescription = "A full-body suit built to catch and recycle nearly every drop of moisture the wearer loses.",
                    DetailedHistory = "Imperial Planetologist Pardot Kynes laid the ecological groundwork. Generations of Fremen craftsmanship sharpened it into the stillsuit. The garment reclaims sweat, breath, even bodily waste, and filters the lot back into water fit to drink. A well-fitted Fremen suit performs so well that an experienced wearer loses barely a thimbleful of moisture across a full day under Arrakis's punishing heat. Out on the open dunes, that margin separates survival from death. Off-worlders like Paul and Lady Jessica needed their Fremen hosts to walk them through fitting the suits correctly. A poorly sealed joint could kill a person slowly and without warning. Few pieces of technology capture humanity's adaptation to Arrakis quite like the stillsuit. It turns bare survival into something closer to engineering craft.",
                    ImagePath = "images/artifacts/stillsuit.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "loc_Arrakis", "char_LietKynes" },
                    PrimaryMaterial = "Poly-weave fabric",
                    Functionality = "Water reclamation/Environmental protection"
                },
                new Artifact
                {
                    Id = "art_PainBox",
                    Name = "The Pain Box",
                    ShortDescription = "A small black cube that convinces the mind a hand is burning away, with no real damage done.",
                    DetailedHistory = "The pain box works alongside the gom jabbar in the Bene Gesserit test of humanity. It floods the nervous system with a conviction that fire is consuming the subject's hand. All of it is illusion. None of it is real injury. The test asks a single question. Can a mind override the animal urge to flee agony at any cost, using will and reason alone? The gom jabbar waits the whole time to kill the instant the hand pulls free. Paul Atreides faced Reverend Mother Mohiam's Voice layered on top of the pain itself. That combined pressure drove him near the limit of what he could endure, and still he held still. The device looks almost crude for what it does. Yet the Bene Gesserit trusted nothing else so completely for telling a true human apart from a creature ruled by pure instinct.",
                    ImagePath = "images/artifacts/pain_box.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_GaiusHelenMohiam" },
                    PrimaryMaterial = "Unknown neural-active materials",
                    Functionality = "Neural pain induction"
                },
                new Artifact
                {
                    Id = "art_SignetRing",
                    Name = "Atreides Signet Ring",
                    ShortDescription = "The ducal signet marking the true Duke of House Atreides, proof no rival House could dispute.",
                    DetailedHistory = "The ducal signet ring is stamped with the seal of House Atreides. It carried the weight of legitimate succession from Duke Leto down to his heir. Loyal retainers and rival Houses alike knew it on sight, a mark nobody could easily fake or challenge. Lady Jessica kept it safe through the wreck of the Harkonnen assault on Arrakeen. Leto's death did nothing to erase what the ring proved about Atreides succession. Old retainers like Gurney Halleck recognized it the moment Paul resurfaced from hiding among the Fremen. At that point scattered Atreides loyalists had no way of knowing who, if anyone, had lived through the fall. The ring outlasted the near-destruction of House Atreides itself. It stood as quiet proof that the family's authority, battered as it was, had not gone out entirely.",
                    ImagePath = "images/artifacts/signet_ring.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "char_DukeLetoAtreides", "char_PaulAtreides" },
                    PrimaryMaterial = "Gold, House Crest seal",
                    Functionality = "Seal of authority/Identity"
                },
                new Artifact
                {
                    Id = "art_Thumper",
                    Name = "Thumper",
                    ShortDescription = "A stake driven into the sand to drum up a rhythm that lures sandworms to the surface.",
                    DetailedHistory = "Drive this small mechanical stake into a dune and set it thumping. The rhythm mimics movement across the sand closely enough to pull a nearby sandworm up from below. Fremen riders plant thumpers on purpose when they mean to summon and mount a worm. They time the device and their own approach with a precision that only comes from a lifetime spent reading the desert, so Shai-Hulud never catches them flat-footed. The same trick doubles as a decoy. Set one at a distance and a worm's attention drifts away from a group, or from equipment that needs protecting. The device itself could not be simpler. Using it well cannot be faked, and a miscalculated approach to open sand kills fast.",
                    ImagePath = "images/artifacts/thumper.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "loc_Arrakis" },
                    PrimaryMaterial = "Metal, mechanical striker",
                    Functionality = "Sandworm summoning"
                },
                new Artifact
                {
                    Id = "art_WaterOfLife",
                    Name = "Water of Life",
                    ShortDescription = "The liquid a drowning sandworm excretes, deadly to nearly anyone who drinks it raw.",
                    DetailedHistory = "A sandworm drowning during the ritual that transforms it into fresh pre-spice mass excretes this liquid. In its raw state it kills almost anyone who swallows it. Only a trained Reverend Mother can turn the poison inward and transmute it into a safe, mind-opening catalyst. The Bene Gesserit refined these techniques since their earliest days. The change unlocks the accumulated memories of her female ancestors. Most Sisters who attempt the transformation without proper grounding die trying. Lady Jessica underwent the ritual carrying Alia. Her unborn daughter absorbed the same transformation and woke with ancestral memory before she had even drawn a first breath. Paul Atreides survived a version of this ordeal that no man had ever lived through before. That alone told the Bene Gesserit their breeding program had produced something past anything they had planned for.",
                    ImagePath = "images/artifacts/water_of_life.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "org_Fremen", "char_LadyJessica", "char_RaquellaBertoAnirul", "event_ReverendMotherBreakthrough" },
                    PrimaryMaterial = "Sandworm secretion",
                    Functionality = "Psychoactive catalyst/Rite of passage"
                },
                new Artifact
                {
                    Id = "art_Lasgun",
                    Name = "Lasgun",
                    ShortDescription = "A high-energy laser weapon that cuts through nearly any armor, and turns catastrophic near a shield.",
                    DetailedHistory = "The lasgun slices through almost any conventional armor or barrier a person could put in front of it. Its real menace has little to do with raw power. Fire one at a shielded target and the beam triggers an uncontrolled subatomic explosion on the scale of a tactical nuclear strike. It kills shooter and target together. That single, well-known hazard pushed large-scale energy weapons out of common battlefield use across the Imperium. No commander wanted a lasgun-shield blast going off inside his own ranks. Ten thousand years of Imperial warfare bent around this one fact. It dragged combat back toward slow, deliberate blade work even in an age full of far more advanced technology. A lasgun sees real use only where shields are nowhere in the picture, or when someone reaches for it as a last, desperate option.",
                    ImagePath = "images/artifacts/lasgun.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen" },
                    PrimaryMaterial = "Las-crystal, energy cell",
                    Functionality = "Ranged combat weapon"
                },
                new Artifact
                {
                    Id = "art_ShieldGenerator",
                    Name = "Personal Shield Generator",
                    ShortDescription = "A body-worn device generating a Holtzman field that stops fast strikes cold and lets slow ones through.",
                    DetailedHistory = "A personal shield generator throws up a Holtzman-effect field. It lets slow-moving objects pass and violently repels anything crossing a certain velocity. That single quirk rewired combat across the Imperium. High-speed projectiles and blows became close to useless against a shielded opponent overnight. Fighters adapted by returning to slow, deliberate knife work, precise enough to probe past a shield's threshold speed. Entire martial traditions grew out of that adaptation, the Swordmasters of Ginaz chief among them. Shields carry another weakness beyond their cost and fragility. The hum they give off drives sandworms into a killing frenzy on Arrakis. Wearing one openly in the open desert can get a person killed just as surely as any blade. Paul Atreides' Fremen forces turned that weakness against Sardaukar and Harkonnen troops during the Battle of Arrakeen. They threw shielded soldiers into a fight against an enemy that did not need speed to kill them.",
                    ImagePath = "images/artifacts/shield.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Harkonnen", "char_NormaCenva" },
                    PrimaryMaterial = "Suspensor film",
                    Functionality = "Personal defense"
                },
                new Artifact
                {
                    Id = "art_Distrans",
                    Name = "Distrans",
                    ShortDescription = "A device that hides a spoken message inside a bird or bat's natural call.",
                    DetailedHistory = "A distrans takes a spoken message and folds it into the natural call of a bird or small bat. The recording plays back only when triggered by a creature trained to carry that exact call. Conventional surveillance never sees it coming. Biological transmission beats electronic transmission here. A distrans-carrying creature slips right past security built to catch radio signals, telepathic contact, or written notes. That makes it a natural choice for messages nobody can afford to have intercepted. House Atreides leaned on distrans-carrying bats to pass word quietly between trusted agents. The method's low-tech simplicity resisted Imperial or rival-House interception better than anyone expected. This pattern keeps repeating in the Dune universe. A civilization suspicious of thinking machines often finds its sharpest tools in biology instead of computation.",
                    ImagePath = "images/artifacts/distrans.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides" },
                    PrimaryMaterial = "Biological recording medium",
                    Functionality = "Data storage/Communication"
                },
                new Artifact
                {
                    Id = "art_HunterSeeker",
                    Name = "Hunter-Seeker",
                    ShortDescription = "A needle-thin assassination drone flown by a hidden operator, built to kill before its victim notices.",
                    DetailedHistory = "A human controller stationed nearby guides the hunter-seeker as it hovers through a room hunting its target. A single poison-tipped strike can kill before the victim even registers a threat in the air. Someone has to guide it close enough to work, which points straight at an insider with real access to the target's household. That suspicion proved correct when a hunter-seeker went after young Paul Atreides inside his own chambers at Arrakeen, steered by a traitor buried within House Atreides itself. Paul's Bene Gesserit-trained reflexes and sharpened awareness let him spot the drone and destroy it before it struck. It was an early flash of the perception that would later define him as Muad'Dib. The attack stands as one of the first hard proofs that House Atreides' new fief hid betrayal closer to home than anyone had guessed.",
                    ImagePath = "images/artifacts/hunter_seeker.jpg",
                    RelatedEntityIds = new List<string> { "house_Harkonnen", "char_PaulAtreides" },
                    PrimaryMaterial = "Metal",
                    Functionality = "Assassination"
                },
                new Artifact
                {
                    Id = "art_MentatChart",
                    Name = "Mentat Data Chart",
                    ShortDescription = "Portable data pads that give Mentats a quick reference for figures too vast to hold fresh in memory.",
                    DetailedHistory = "A trained Mentat's mind holds and processes staggering amounts of information through pure internal recall. Even so, portable data charts remain a common practical aid. They let a Mentat like Thufir Hawat cross-reference figures, logistics, and political data too voluminous, or shifting too quickly, to keep entirely current in active memory. Call them an extension of a Mentat's working method rather than a crutch. They free his trained recall for the deeper pattern recognition and projection that real Mentat computation depends on. Rival Mentats serving opposing Houses put the same tools to equally practical use. Piter De Vries, twisted and unpredictable in Harkonnen service, approached strategy nothing like Hawat did, and still reached for the same charts. Simple as they look, the numbers on those charts often held the raw material behind decisions that shaped the fate of entire Houses.",
                    ImagePath = "images/artifacts/chart.jpg",
                    RelatedEntityIds = new List<string> { "char_ThufirHawat", "char_PiterDeVries" },
                    PrimaryMaterial = "Synthetic substrate",
                    Functionality = "Data computation support"
                },
                new Artifact
                {
                    Id = "art_GoldenLionThrone",
                    Name = "Golden Lion Throne",
                    ShortDescription = "The Padishah Emperor's throne, seat of Corrino rule for ten thousand years.",
                    DetailedHistory = "The Golden Lion Throne sat within Kaitain's most opulent hall. For ten thousand years it stood as the single most recognized symbol of authority across the Known Universe. Its name was shorthand throughout the Imperium for the Corrino dynasty's claim to rule. Every Padishah Emperor from the earliest post-Jihad days down to Shaddam IV held court from this seat. Its grandeur reinforced an idea Corrino rulers wanted believed: that their reign was as permanent and unshakeable as the gold beneath them. Paul Atreides defeated Shaddam IV and claimed the throne as the spoils of that victory. He took on a title carrying ten millennia of unbroken succession, and he claimed it on Arrakis, a long way from the hall on Kaitain. The throne outlasted the dynasty that built it. It remained a touchstone of Imperial legitimacy long after House Corrino lost its grip on power.",
                    ImagePath = "images/artifacts/throne.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino" },
                    PrimaryMaterial = "Gold, precious gems",
                    Functionality = "Imperial seat of power"
                },
                new Artifact
                {
                    Id = "art_StoneBurner",
                    Name = "Stone Burner",
                    ShortDescription = "A nuclear device disguised as an ordinary rock, built to blind rather than kill outright.",
                    DetailedHistory = "The stone burner is disguised as nothing more than a plain rock and armed with a directed nuclear charge. It exists to maim more than to kill. Its blast releases a localized burst of radiation that destroys the optic nerve of anyone caught in range. Survivors are left blind and often, deliberately, alive. That grim precision made it the tool of choice for factions that wanted an enemy hurt without the political mess of an obvious kill. A blinded rival can be quietly written off as the victim of an accident rather than an act of war. A stone burner used against Emperor Paul Atreides in a Guild-arranged conspiracy took his sight. The strike was aimed at breaking him as much in mind as in body. It did the opposite. Paul leaned harder into his prescient sight instead of buckling. The same pattern ran through so much of his reign. Strip away his power, and his own strange gifts filled the gap left behind.",
                    ImagePath = "images/artifacts/stone_burner.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino" },
                    PrimaryMaterial = "Nuclear fissile material",
                    Functionality = "Strategic destruction"
                },
                new Artifact
                {
                    Id = "art_SuspensorBelt",
                    Name = "Suspensor Belt",
                    ShortDescription = "A belt that generates a localized anti-gravity field, easing or erasing the wearer's body weight.",
                    DetailedHistory = "A suspensor belt is built on the same Holtzman-effect principles behind personal combat shields and starship suspensor drives. It throws up a localized anti-gravity field capable of offsetting some or nearly all of a wearer's body weight. That grants movement far beyond what their natural mass would allow. Decades of gluttony and a refusal to exert himself left Baron Vladimir Harkonnen too massive to walk unaided. He came to depend on a personal suspensor harness at all times, drifting through his chambers on Giedi Prime rather than face what his own excess had cost him. The device grew into a symbol of the Baron's corruption and vanity nearly as much as a physical necessity. It was technology bent toward indulging weakness instead of overcoming it. Lesser, more mundane versions of the same field lift furniture, light fixtures, and cargo throughout the Imperium. That ordinariness only sharpens the point. The Baron needed for his own body what everyone else used to move their belongings.",
                    ImagePath = "images/artifacts/suspensor.jpg",
                    RelatedEntityIds = new List<string> { "char_BaronHarkonnen" },
                    PrimaryMaterial = "Suspensor field generator",
                    Functionality = "Gravity negation"
                },
                new Artifact
                {
                    Id = "art_ResearchJournal",
                    Name = "Imperial Planetologist Journal",
                    ShortDescription = "Liet Kynes' record of Arrakis ecology, the quiet blueprint for turning desert into green world.",
                    DetailedHistory = "The Imperial Planetologist's journal was compiled over decades of secret fieldwork. It held the ecological observations and long-term calculations behind an audacious hidden project: turning Arrakis, across centuries, from arid wasteland into a world that could sustain open water and green life. Pardot Kynes started the work, and his son Liet carried it forward. The title of Imperial Planetologist served as cover to quietly draw the Fremen themselves into a patient, generations-long conspiracy few outsiders ever suspected existed. The projections demanded the labor and secrecy of generation after generation. They became the scientific backbone behind the Fremen's own dream of a green Arrakis. Most of them held that goal on faith and longing long before anyone explained the mathematics to them. The journal's knowledge eventually reached Paul Atreides. It handed him a grasp of the planet's true potential deeper than any other Great House had ever managed.",
                    ImagePath = "images/artifacts/journal.jpg",
                    RelatedEntityIds = new List<string> { "char_LietKynes", "loc_Arrakis" },
                    PrimaryMaterial = "Paper, data crystal",
                    Functionality = "Ecological planning"
                },
                new Artifact
                {
                    Id = "art_CoffinShield",
                    Name = "Death-Guard Shield",
                    ShortDescription = "Specialized protective field for high-value funerary goods.",
                    DetailedHistory = "The death-guard shield is a specialized variant of Holtzman shield technology. It is calibrated not to stop weapons but to preserve the remains of high-ranking nobles during transit. It maintains a stable, sealed environment that protects a body from decay, tampering, or damage before a proper funeral rite can be conducted. Its use reflects how deeply questions of honor and succession run through Imperial noble culture. Even the journey a fallen leader's remains take back to their ancestral seat carries symbolic weight for the House's legitimacy. Great Houses such as Atreides and Corrino made particular use of the technology when a Duke, Emperor, or other high figure died far from home. For them, funerary rites reinforce claims of continuity and rightful inheritance. The death-guard shield is modest compared to the Imperium's more dramatic technologies. Still, it quietly underscores how much ceremony and propriety mattered even in matters of death.",
                    ImagePath = "images/artifacts/coffin_shield.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "house_Corrino" },
                    PrimaryMaterial = "Energy field",
                    Functionality = "Post-mortem preservation"
                }
            };
        }
    }
}