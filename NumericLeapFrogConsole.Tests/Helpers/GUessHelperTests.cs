using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Helpers;

namespace NumericLeapFrogConsole.Tests.Helpers
{
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
    }
}
