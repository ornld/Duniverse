using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    /// <summary>
    /// The Collected Sayings archive: the heading Herbert set over every chapter, one partial
    /// file per novel in reading order, from Luke's transcription. Quotations are verbatim, so
    /// fix wording against the printed books rather than restyling it.
    /// </summary>
    public static partial class EpigraphSeeder
    {
        public static List<Epigraph> GetEpigraphs()
        {
            var all = new List<Epigraph>();
            all.AddRange(Dune());
            all.AddRange(DuneMessiah());
            all.AddRange(ChildrenOfDune());
            all.AddRange(GodEmperorOfDune());
            all.AddRange(HereticsOfDune());
            all.AddRange(Chapterhouse());
            all.AddRange(SpokenLines());
            return all;
        }

        // The one survivor of the old spoken-lines page. It never headed a chapter, so it
        // stands apart from the book runs and keeps its place in the daily rotation.
        private static List<Epigraph> SpokenLines()
        {
            return new List<Epigraph>
            {
                new()
                {
                    Text = "I must not fear. Fear is the mind-killer. Fear is the little-death that brings total obliteration. I will face my fear. I will permit it to pass over me and through me. And when it has gone past I will turn the inner eye to see its path. Where the fear has gone there will be nothing. Only I will remain.",
                    Work = "The Litany Against Fear, a Bene Gesserit rite",
                    Spoken = true,
                },
            };
        }
    }
}
