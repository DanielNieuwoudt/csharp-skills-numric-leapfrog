using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Enumerations;
using NumericLeapFrogConsole.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace NumericLeapFrogConsole.Tests.Helpers
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class GuessHelperTests
    {
        [Theory]
        [InlineData(GameConstants.MinimumValue, GameConstants.MaximumValue, 1)]
        [InlineData(GameConstants.MinimumValue, GameConstants.MaximumValue, 5)]
        [InlineData(GameConstants.MinimumValue, GameConstants.MaximumValue, 10)]
        public void Given_GuessHelper_When_Guess_Then_ReturnsSumOfGuesses(int minimumValue, int maximumValue, int numberOfGuesses)
        {
            var guessHelper = new GuessHelper();
            var guess = 0;

            for (var i = 0; i < numberOfGuesses; i++)
            {
                guess = guessHelper.Guess(minimumValue, maximumValue);    
            }

            guess
                .Should()
                .Be(guessHelper.Guesses.Sum());
        }

        [Theory]
        [InlineData(50, 60, GuessOutcomes.TooHigh)]
        [InlineData(50, 47, GuessOutcomes.IsClose)]
        [InlineData(50, 25, GuessOutcomes.GuessAgain)]
        public void Given_GuessHelper_When_GetOutcome_Then_ReturnsCorrectOutcome(int playerValue, int guess, GuessOutcomes expectedOutcome)
        {
            var guessHelper = new GuessHelper();
            var outcome = guessHelper.GetOutcome(playerValue, guess);
            outcome
                .Should()
                .Be(expectedOutcome);
        }
    }
}
