using System.Text.RegularExpressions;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Tests
{
    /// <summary>
    /// The daily trial's two promises: the same day deals the same puzzle, and no clue
    /// prints a name the record answers to. The alias leak shipped once; never again.
    /// </summary>
    [Collection("archive")]
    public sealed class MentatTrialTests
    {
        private readonly EntityRegistry _registry;
        private readonly MentatTrialService _trial;

        public MentatTrialTests(ArchiveFixture fixture)
        {
            _registry = fixture.Registry;
            _trial = new MentatTrialService(fixture.Registry, new PathFinderService());
        }

        [Fact]
        public void TheSameDayDealsTheSameAnswer()
        {
            var pool = _trial.BuildPool(ArchiveFixture.ReaderAt(SpoilerTier.Chapterhouse, expanded: true));
            var date = new DateOnly(2026, 8, 26);

            Assert.Equal(_trial.SelectDaily(date, pool)!.Id, _trial.SelectDaily(date, pool)!.Id);
        }

        [Fact]
        public void TheFirstClueSealsEveryNameTheAnswerCarries()
        {
            // Paul's summary names him only through an alias, which is exactly how the
            // leak slipped out the first time. Arrakis does the same through "Dune".
            var reader = ArchiveFixture.ReaderAt(SpoilerTier.Chapterhouse, expanded: true);

            foreach (var id in new[] { "char_PaulAtreides", "loc_Arrakis" })
            {
                var answer = _registry.GetEntity(id)!;
                var clue = _trial.BuildClues(answer, reader)[0];

                foreach (var name in new[] { answer.Name }.Concat(answer.Aliases))
                {
                    foreach (var word in name.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Where(word => word.Length > 3))
                    {
                        Assert.DoesNotContain(word, clue, StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
        }

        [Fact]
        public void AdjacentBarsFuseIntoOne()
        {
            // "Kwisatz Haderach" is two sealed words side by side. One bar tells less than
            // two, and the count of a name's words is itself a clue.
            var reader = ArchiveFixture.ReaderAt(SpoilerTier.Chapterhouse, expanded: true);
            var clue = _trial.BuildClues(_registry.GetEntity("char_PaulAtreides")!, reader)[0];

            Assert.Single(Regex.Matches(clue, Regex.Escape(MentatTrialService.RedactionBar)));
        }

        [Fact]
        public void AGuessOneLinkAwayMeasuresAsOne()
        {
            var reader = ArchiveFixture.ReaderAt(SpoilerTier.Chapterhouse, expanded: true);
            var answer = _registry.GetEntity("char_PaulAtreides")!;
            var guess = _registry.GetEntity("char_LadyJessica")!;

            var result = _trial.EvaluateGuess(guess, answer, reader);

            Assert.False(result.IsCorrect);
            Assert.True(result.SameCategory);
            Assert.Equal(1, result.LinkDistance);
        }
    }
}
