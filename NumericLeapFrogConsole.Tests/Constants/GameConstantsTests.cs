using NumericLeapFrogConsole.Constants;
using System.Diagnostics.CodeAnalysis;

namespace NumericLeapFrogConsole.Tests.Constants
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class GameConstantsTests
    {
        [Theory]
        [InlineData(GameConstants.ExitMessage, "Exiting game...")]
        [InlineData(GameConstants.ExitCommand, "exit")]
        [InlineData(GameConstants.GameOverMessage, "Game over...")]
        [InlineData(GameConstants.InvalidMinimumNumberMessage, "The number must be greater than 0.")]
        [InlineData(GameConstants.InvalidMaximumNumberMessage, "The number must be less than 101.")]
        [InlineData(GameConstants.MinimumValue, 1)]
        [InlineData(GameConstants.MaximumValue, 100)]
        [InlineData(GameConstants.PlayerValueMessage, "You entered: {0}")]
        [InlineData(GameConstants.StartMessage, "Starting game...")]
        public void Given_ConstantValue_When_ValueUsed_Then_ReturnsExpectedValue(object constantValue, object expectedValue)
        {
            constantValue.Should().Be(expectedValue);
        }
    }
}
