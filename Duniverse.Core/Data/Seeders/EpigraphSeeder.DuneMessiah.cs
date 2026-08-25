using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static partial class EpigraphSeeder
    {
        // Dune Messiah's chapter headings in reading order. The transcription printed the
        // name as Muad'dib; I keep the site's one spelling so the archive speaks together.
        private static List<Epigraph> DuneMessiah()
        {
            Epigraph E(string text, string work) => new() { Text = text, Work = work, Tier = SpoilerTier.DuneMessiah };

            return new List<Epigraph>
            {
                E("Such a rich store of myths enfolds Paul Muad'Dib, the Mentat Emperor, and his sister, Alia, it is difficult to see the real persons behind these veils. But there were, after all, a man born Paul Atreides and a woman born Alia. Their flesh was subject to space and time. And even though their oracular powers placed them beyond the usual limits of time and space, they came from human stock. They experienced real events which left real traces upon a real universe. To understand them, it must be seen that their catastrophe was the catastrophe of all mankind. This work is dedicated, then, not to Muad'Dib or his sister, but to their heirs—to all of us.",
                    "Dedication in the Muad'Dib Concordance as copied from the Tabla Memorium of the Mahdi Spirit Cult"),
                E("There exists no separation between gods and men; one blends softly casual into the other.",
                    "Proverbs of Muad'Dib"),
                E("Every civilization must contend with an unconscious force which can block, betray or countermand almost any conscious intention of the collectivity.",
                    "Tleilaxu Theorem (unproven)"),
                E("The advent of the Field Process shield and the lasgun with their explosive interaction, deadly to attacker and attacked, placed the current determinatives on weapons technology. We need not go into the special role of atomics. The fact that any Family in my Empire could so deploy its atomics as to destroy the planetary bases of fifty or more other Families causes some nervousness, true. But all of us possess precautionary plans for devastating retaliation. Guild and Landsraad contain the keys which hold this force in check. No, my concern goes to the development of humans as special weapons. Here is a virtually unlimited field which a few powers are developing.",
                    "Muad'Dib: Lecture to the War College, from The Stilgar Chronicle"),
                E("Empires do not suffer emptiness of purpose at the time of their creation. It is when they have become established that aims are lost and replaced by vague ritual.",
                    "Words of Muad'Dib, by the Princess Irulan"),
                E("Once more the drama begins.",
                    "The Emperor Paul Muad'Dib, on his ascension to the Lion Throne"),
                E("Truth suffers from too much analysis.",
                    "Ancient Fremen Saying"),
                E("The Fremen see her as the Earth Figure, a demi-goddess whose special charge is to protect the tribes through her powers of violence. She is Reverend Mother to their Reverend Mothers. To pilgrims who seek her out with demands that she restore virility or make the barren fruitful, she is a form of antimentat. She feeds on that proof that the \"analytic\" has limits. She represents ultimate tension. She is the virgin-harlot—witty, vulgar, cruel, as destructive in her whims as a coriolis storm.",
                    "St. Alia of the Knife, as taken from The Irulan Report"),
                E("The most dangerous game in the universe is to govern from an oracular base. We do not consider ourselves wise enough or brave enough to play that game. The measures detailed here for regulation in lesser matters are as near as we dare venture to the brink of government. For our purposes, we borrow a definition from the Bene Gesserit and we consider the various worlds as gene pools, sources of teachings and teachers, sources of the possible. Our goal is not to rule, but to tap these gene pools, to learn, and to free ourselves from all restraints imposed by dependency and government.",
                    "The Orgy as a Tool of Statecraft, Chapter Three of The Steersman's Guild"),
                E("Here lies a toppled god—\nHis fall was not a small one.\nWe did but build his pedestal,\nA narrow and a tall one.",
                    "Tleilaxu Epigram"),
                E("I think what a joy it is to be alive, and I wonder if I'll ever leap inward to the root of this flesh and know myself as once I was. The root is there. Whether any act of mine can find it, that remains tangled in the future. But all things a man can do are mine. Any act of mine may do it.",
                    "The Ghola Speaks, Alia's Commentary"),
                E("You do not beg the sun for mercy.",
                    "Muad'Dib's Travail, from The Stilgar Commentary"),
                E("I've had a bellyful of the god and priest business! You think I don't see my own mythos? Consult your data once more, Hayt. I've insinuated my rites into the most elementary human acts. The people in the name of Muad'Dib! They make love in my name, are born in my name—cross the street in my name. A roof beam cannot be raised in the lowliest hovel of far Gangishree without invoking the blessing of Muad'Dib!",
                    "Book of Diatribes, from the Hayt Chronicle"),
                E("Oh, worm of many teeth,\nCanst thou deny what has no cure?\nThe flesh and breath which lure thee\nTo the ground of all beginnings\nFeed on monsters twisting in a door of fire!\nThou hast no robe in all thy attire\nTo cover intoxications of divinity\nOr hide the burnings of desire!",
                    "Wormsong, from the Dunebook"),
                E("The audacious nature of Muad'Dib's actions may be seen in the fact that He knew from the beginning whither He was bound, yet not once did He step aside from that path. He put it clearly when He said: \"I tell you that I come now to my time of testing when it will be shown that I am the Ultimate Servant.\" Thus He weaves all into One, that both friend and foe may worship Him. It is for this reason and this reason only that His Apostles prayed: \"Lord, save us from the other paths which Muad'Dib covered with the Waters of His Life.\" Those \"other paths\" may be imagined only with the deepest revulsion.",
                    "The Yiam-el-Din (Book of Judgement)"),
                E("No matter how exotic human civilization becomes, no matter the developments of life and society nor the complexity of the machine/human interface, there always come interludes of lonely power when the course of humankind, the very future of humankind, depends on the relatively simple actions of single individuals.",
                    "The Tleilaxu Godbuk"),
                E("Production growth and income growth must not get out of step in my Empire. That is the substance of my command. There are to be no balance-of-payment difficulties between the different spheres of influence. And the reason for this is simply because I command it. I want to emphasize my authority in this area. I am the supreme energy-eater of this domain, and will remain so, alive or dead. My Government is the economy.",
                    "Orders in Council, The Emperor Paul Muad'Dib"),
                E("The convoluted wording of legalisms grew up around the necessity to hide from ourselves the violence we intend toward each other. Between depriving a man of one hour from his life and depriving him of his life there exists only a difference of degree. You have done violence to him, consumed his energy. Elaborate euphemisms may conceal your intent to kill, but behind any use of power over another the ultimate assumption remains: \"I feed on your energy.\"",
                    "Addenda to Orders in Council, The Emperor Paul Muad'Dib"),
                E("He has gone from Alia,\nThe womb of heaven!\nHoly, holy, holy!\nFire-sand leagues\nConfront our Lord.\nHe can see\nWithout eyes!\nA demon upon him!\nHoly, holy, holy\nEquation:\nHe solved for\nMartyrdom!",
                    "The Moon Falls Down, from Songs of Muad'Dib"),
                E("Tibana was an apologist for Socratic Christianity, probably a native of IV Anbus who lived between the eighth and ninth centuries before Corrino, likely in the second reign of Dalamak. Of his writings, only a portion survives from which this fragment is taken: \"The hearts of all men dwell in the same wilderness.\"",
                    "The Dunebuk of Irulan"),
                E("The sequential nature of actual events is not illuminated with lengthy precision by the powers of prescience except under the most extraordinary circumstances. The oracle grasps incidents cut out of the historic chain. Eternity moves. It inflicts itself upon the oracle and the supplicant alike. Let Muad'Dib's subjects doubt his majesty and his oracular visions. Let them deny his powers. Let them never doubt Eternity.",
                    "The Dune Gospels"),
                E("There exists a limit to the force even the most powerful may apply without destroying themselves. Judging this limit is the true artistry of government. Misuse of power is the fatal sin. The law cannot be a tool of vengeance, never a hostage, nor a fortification against the martyrs it has created. You cannot threaten any individual and escape the consequences.",
                    "Muad'Dib on Law, The Stilgar Commentary"),
                E("There was a man so wise,\nHe jumped into\nA sandy place\nAnd burnt out both his eyes!\nAnd when he knew his eyes were gone,\nHe offered no complaint.\nHe summoned up a vision\nAnd made himself a saint.",
                    "Children's Verse, from History of Muad'Dib"),
                E("We say of Muad'Dib that he has gone on a journey into that land where we walk without footprints.",
                    "Preamble to the Qizarate Creed"),
                E("No bitter stench of funeral-still for Muad'Dib.\nNo knell nor solemn rite to free the mind\nFrom avaricious shadows.\nHe is the fool saint,\nThe golden stranger living forever\nOn the edge of reason.\nLet your guard fall and he is there!\nHis crimson peace and sovereign pallor\nStrike into our universe on prophetic webs\nTo the verge of a quiet place—there!\nOut of bristling star-jungles:\nMysterious, lethal, an oracle without eyes,\nCatspaw of prophecy, whose voice never dies!\nShai-hulud, he awaits thee upon a strand\nWhere couples walk and fix, eye to eye,\nThe delicious ennui of love.\nHe strides through the long cavern of time,\nScattering the fool-self of his dream.",
                    "The Ghola's Hymn"),
            };
        }
    }
}
