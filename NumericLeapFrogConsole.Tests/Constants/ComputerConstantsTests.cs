using System.Diagnostics.CodeAnalysis;
using NumericLeapFrogConsole.Constants;

namespace NumericLeapFrogConsole.Tests.Constants
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class ComputerConstantsTests
    {
        public class GameConstantsTests
        {
            [Theory]
            [InlineData(ComputerConstants.GuessAgain, "Guessing again...")]
            [InlineData(ComputerConstants.GuessMessage, "Is the player number {0}...")]
            [InlineData(ComputerConstants.GuessIsClose, "{0} was close to the player value...")]
            [InlineData(ComputerConstants.GuessTooHigh, "{0} was more that the player value...")]
            public void Given_ConstantValue_When_ValueUsed_Then_ReturnsExpectedValue(object constantValue, object expectedValue)
            {
                constantValue.Should().Be(expectedValue);
            }
        }
    }
}
