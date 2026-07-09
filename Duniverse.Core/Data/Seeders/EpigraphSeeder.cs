using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    /// <summary>
    /// The Collected Sayings archive: chapter epigraphs and famous lines from across the saga,
    /// credited to their in-universe sources. Quotations are stored verbatim, original
    /// punctuation included, so wording should be corrected against the printed books rather
    /// than restyled. The set leans toward Dune itself on purpose; that is where the most
    /// quoted material lives, and it keeps the page friendly to new readers.
    /// </summary>
    public static class EpigraphSeeder
    {
        public static List<Epigraph> GetEpigraphs()
        {
            return new List<Epigraph>
            {
                // ---- Manual of Muad'Dib, by the Princess Irulan ----
                new()
                {
                    Text = "A beginning is the time for taking the most delicate care that the balances are correct. This every sister of the Bene Gesserit knows.",
                    Work = "Manual of Muad'Dib, by the Princess Irulan",
                },
                new()
                {
                    Text = "What do you despise? By this are you truly known.",
                    Work = "Manual of Muad'Dib, by the Princess Irulan",
                },

                // ---- Collected Sayings of Muad'Dib, by the Princess Irulan ----
                new()
                {
                    Text = "Greatness is a transitory experience. It is never consistent.",
                    Work = "Collected Sayings of Muad'Dib, by the Princess Irulan",
                },
                new()
                {
                    Text = "The concept of progress acts as a protective mechanism to shield us from the terrors of the future.",
                    Work = "Collected Sayings of Muad'Dib, by the Princess Irulan",
                },
                new()
                {
                    Text = "Arrakis teaches the attitude of the knife—chopping off what's incomplete and saying: \"Now, it's complete because it's ended here.\"",
                    Work = "Collected Sayings of Muad'Dib, by the Princess Irulan",
                },
                new()
                {
                    Text = "There is no escape—we pay for the violence of our ancestors.",
                    Work = "Collected Sayings of Muad'Dib, by the Princess Irulan",
                },

                // ---- The Sayings of Muad'Dib, by the Princess Irulan ----
                new()
                {
                    Text = "Deep in the human unconscious is a pervasive need for a logical universe that makes sense. But the real universe is always one step beyond logic.",
                    Work = "The Sayings of Muad'Dib, by the Princess Irulan",
                },

                // ---- Sayings of the Bene Gesserit ----
                new()
                {
                    Text = "I must not fear. Fear is the mind-killer. Fear is the little-death that brings total obliteration. I will face my fear. I will permit it to pass over me and through me. And when it has gone past I will turn the inner eye to see its path. Where the fear has gone there will be nothing. Only I will remain.",
                    Work = "The Litany Against Fear, a Bene Gesserit rite",
                },
                new()
                {
                    Text = "Survival is the ability to swim in strange water.",
                    Work = "A Bene Gesserit axiom",
                },
                new()
                {
                    Text = "Once men turned their thinking over to machines in the hope that this would set them free. But that only permitted other men with machines to enslave them.",
                    Work = "Reverend Mother Gaius Helen Mohiam, to Paul Atreides",
                },
                new()
                {
                    Text = "Hope clouds observation.",
                    Work = "Reverend Mother Gaius Helen Mohiam, to Paul Atreides",
                },
                new()
                {
                    Text = "The willow submits to the wind and prospers until one day it is many willows—a wall against the wind. This is the willow's purpose.",
                    Work = "Reverend Mother Gaius Helen Mohiam, to Paul Atreides",
                },
                new()
                {
                    Text = "The mystery of life isn't a problem to solve, but a reality to experience.",
                    Work = "Reverend Mother Gaius Helen Mohiam, to Paul Atreides",
                },

                // ---- Muad'Dib: Family Commentaries, by the Princess Irulan ----
                new()
                {
                    Text = "Any road followed precisely to its end leads precisely nowhere. Climb the mountain just a little bit to test that it's a mountain. From the top of the mountain, you cannot see the mountain.",
                    Work = "Muad'Dib: Family Commentaries, by the Princess Irulan",
                },

                // ---- The Orange Catholic Bible ----
                new()
                {
                    Text = "Thou shalt not make a machine in the likeness of a human mind.",
                    Work = "The Orange Catholic Bible",
                },

                // ---- Voices of the first book ----
                new()
                {
                    Text = "He who can destroy a thing controls a thing.",
                    Work = "Paul Muad'Dib",
                },
                new()
                {
                    Text = "Parting with friends is a sadness. A place is only a place.",
                    Work = "Thufir Hawat, to Paul Atreides",
                },
                new()
                {
                    Text = "It is said in the desert that possession of water in great amount can inflict a man with fatal carelessness.",
                    Work = "Liet-Kynes",
                },
                new()
                {
                    Text = "The sleeper must awaken.",
                    Work = "Duke Leto Atreides",
                },
                new()
                {
                    Text = "God created Arrakis to train the faithful.",
                    Work = "A saying of the Fremen",
                },
                new()
                {
                    Text = "Polish comes from the cities; wisdom from the desert.",
                    Work = "A saying of the Arrakeen villagers",
                },

                // ---- Later books ----
                new()
                {
                    Text = "Here lies a toppled god—\nHis fall was not a small one.\nWe did but build his pedestal,\nA narrow and a tall one.",
                    Work = "Tleilaxu Epigram",
                    Tier = SpoilerTier.DuneMessiah,
                },
                new()
                {
                    Text = "Empires do not suffer emptiness of purpose at the time of their creation. It is when they have become established that aims are lost and replaced by vague ritual.",
                    Work = "Words of Muad'Dib, by the Princess Irulan",
                    Tier = SpoilerTier.DuneMessiah,
                },
                new()
                {
                    Text = "Truth suffers from too much analysis.",
                    Work = "An ancient Fremen saying",
                    Tier = SpoilerTier.DuneMessiah,
                },
                new()
                {
                    Text = "The assumption that a whole system can be made to work better through an assault on its conscious elements betrays a dangerous ignorance.",
                    Work = "The Butlerian Jihad, by Harq al-Ada",
                    Tier = SpoilerTier.ChildrenOfDune,
                },
                new()
                {
                    Text = "The problem of leadership is inevitably: Who will play God?",
                    Work = "Muad'Dib, from the Oral History",
                    Tier = SpoilerTier.GodEmperorOfDune,
                },
                new()
                {
                    Text = "Most civilization is based on cowardice. It's so easy to civilize by teaching cowardice.",
                    Work = "Leto II, the God Emperor",
                    Tier = SpoilerTier.GodEmperorOfDune,
                },
                new()
                {
                    Text = "Governments, if they endure, always tend increasingly toward aristocratic forms. No government in history has been known to evade this pattern.",
                    Work = "The Stolen Journals of Leto II",
                    Tier = SpoilerTier.GodEmperorOfDune,
                },
                new()
                {
                    Text = "The purpose of argument is to change the nature of truth.",
                    Work = "The Bene Gesserit Coda",
                    Tier = SpoilerTier.Chapterhouse,
                },
                new()
                {
                    Text = "Seek freedom and become captive of your desires. Seek discipline and find your liberty.",
                    Work = "The Bene Gesserit Coda",
                    Tier = SpoilerTier.Chapterhouse,
                },
            };
        }
    }
}
