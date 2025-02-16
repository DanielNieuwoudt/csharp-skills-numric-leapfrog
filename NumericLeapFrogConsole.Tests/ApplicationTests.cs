using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Helpers;

namespace NumericLeapFrogConsole.Tests
{
    public class ApplicationTests
    {
        private readonly Mock<IConsoleHelper> _consoleHelperMock = new ();
        private readonly Mock<IPlayerInputHelper> _playerInputHelperMock = new ();
        private readonly Mock<IGuessHelper> _guessHelperMock = new();

        [Fact]
        public async Task Given_Application_When_RunAsync_Then_ClearsConsoleOnce()
        {
            await new Application(_consoleHelperMock.Object, _guessHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync(true, false);

            _consoleHelperMock.Verify(m => m.Clear(), Times.Once);
        }

        [Fact]
        public async Task Given_Application_When_RunAsync_Then_GetPlayerValueAtLeastOnce()
        {
            await new Application(_consoleHelperMock.Object, _guessHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync(true, false);

            _playerInputHelperMock.Verify(m => m.GetPlayerValue(), Times.Once);
        }

        [Fact]
        public async Task Given_Application_When_RunAsync_Then_ExitsWhenPlayerValueIsMinusOne()
        {
            _playerInputHelperMock
                .Setup(m => m.GetPlayerValue())
                .Returns(-1);

            await new Application(_consoleHelperMock.Object, _guessHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync(true, false);

            _playerInputHelperMock.Verify(m => m.GetPlayerValue(), Times.Once);

            _consoleHelperMock.Verify(m => m.WriteLine(GameConstants.ExitMessage), Times.Once);
        }

        [Fact]
        public async Task Given_Application_When_RunAsync_Then_ContinuesWithValidPlayerValue()
        {
            const int playerValue = 50;

            _playerInputHelperMock
                .Setup(m => m.GetPlayerValue())
                .Returns(50);

            await new Application(_consoleHelperMock.Object, _guessHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync(true, false);

            _playerInputHelperMock.Verify(m => m.GetPlayerValue(), Times.Once);

            _consoleHelperMock.Verify(m => m.WriteLine(string.Format(GameConstants.PlayerValueMessage, playerValue)), Times.Once);
            _consoleHelperMock.Verify(m => m.WriteLine(GameConstants.StartMessage));
        }

        [Theory]
        [InlineData(50, 60, "high")]
        [InlineData(50, 47, "close")]
        public async Task Given_Application_When_RunAsync_Then_EndsGameWhenGuessToHigh(int playerValue, int guessedValue, string outcome)
        {
            
            _playerInputHelperMock
                .Setup(m => m.GetPlayerValue())
                .Returns(50);

            _guessHelperMock
                .SetupSequence(m => m.Guess(GameConstants.MinimumValue, playerValue))
                .Returns(guessedValue);
            
            await new Application(_consoleHelperMock.Object, _guessHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync(true, true);
            
            
            _guessHelperMock.Verify(m => m.Guess(GameConstants.MinimumValue, playerValue), Times.Once);
            
            _consoleHelperMock.Verify(m => m.WriteLine(string.Format(ComputerConstants.GuessMessage, guessedValue)), Times.Once);

            switch (outcome)
            {
                case "high":
                    _consoleHelperMock.Verify(m => m.WriteLine(string.Format(ComputerConstants.GuessTooHigh, guessedValue)), Times.Once);
                    break;
                case "close":
                    _consoleHelperMock.Verify(m => m.WriteLine(string.Format(ComputerConstants.GuessIsClose, guessedValue)), Times.Once);
                    break;
            }
            
            _consoleHelperMock.Verify(m => m.WriteLine(GameConstants.GameOverMessage), Times.Once);
        }
    }
}