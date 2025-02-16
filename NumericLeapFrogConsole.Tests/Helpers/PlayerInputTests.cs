using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Helpers;

namespace NumericLeapFrogConsole.Tests.Helpers
{
    public class PlayerInputTests
    {
        private readonly Mock<IConsoleHelper> _consoleHelperMock = new();

        [Theory]
        [InlineData(0, GameConstants.InvalidMinimumNumberMessage, null)]
        [InlineData(50, null, 50)]
        [InlineData(101, GameConstants.InvalidMaximumNumberMessage, null)]
        [InlineData("exit", null, -1)]
        public void Given_GetPlayerValue_When_ValueProvided_Then_DisplaysInvalidValueMessage(object playerValue, string? message, int? expectedValue)
        {
            _consoleHelperMock
                .Setup(m => m.ReadLine())
                .Returns(playerValue.ToString());
            
            var playerInputHelper = new PlayerInputHelper(_consoleHelperMock.Object);
            var playerInput = playerInputHelper.GetPlayerValue();

            playerInput
                .Should()
                .Be(expectedValue);

            _consoleHelperMock.Verify(m => m.ReadLine(), Times.Once);

            if (!string.IsNullOrWhiteSpace(message)) 
            {
                _consoleHelperMock.Verify(m => m.WriteLine(message), Times.Once);
            }
        }
    }
}
