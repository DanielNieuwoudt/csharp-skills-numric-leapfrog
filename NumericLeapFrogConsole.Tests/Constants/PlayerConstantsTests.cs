using FluentAssertions;
using NumericLeapFrogConsole.Constants;

namespace NumericLeapFrogConsole.Tests.Constants
{
    public class PlayerConstantsTests
    {
        [Theory]
        [InlineData(PlayerConstants.ExitCommand, "exit")]
        [InlineData(PlayerConstants.InvalidMinimumNumberMessage, "The number must be greater than 0.")]
        [InlineData(PlayerConstants.InvalidMaximumNumberMessage, "The number must be less than 101.")]
        [InlineData(PlayerConstants.MinimumValue, 1)]
        [InlineData(PlayerConstants.MaximumValue, 100)]
        public void Given_ConstantValue_When_ValueUsed_Then_ReturnsExpectedValue(object constantValue, object expectedValue)
        {
            constantValue.Should().Be(expectedValue);
        }
    }
}
