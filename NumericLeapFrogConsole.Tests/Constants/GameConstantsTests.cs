using NumericLeapFrogConsole.Constants;

namespace NumericLeapFrogConsole.Tests.Constants
{
    public class GameConstantsTests
    {
        [Theory]
        [InlineData(GameConstants.ExitMessage, "Exiting leap frog game...")]
        [InlineData(GameConstants.PlayerValueMessage, "You entered: {0}")]
        [InlineData(GameConstants.StartMessage, "Starting leap frog game...")]
        public void Given_ConstantValue_When_ValueUsed_Then_ReturnsExpectedValue(object constantValue, object expectedValue)
        {
            constantValue.Should().Be(expectedValue);
        }

    }
}
