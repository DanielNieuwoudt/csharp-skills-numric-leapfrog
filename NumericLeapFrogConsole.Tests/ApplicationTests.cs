using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Enumerations;
using NumericLeapFrogConsole.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace NumericLeapFrogConsole.Tests
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
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
        [InlineData(50,  60, GuessOutcomes.TooHigh)]
        [InlineData(50,  47, GuessOutcomes.IsClose)]
        public async Task Given_Application_When_RunAsync_Then_EndsGameWhenGuessTooHighOrIsClose(int playerValue, int guessedValue, GuessOutcomes outcome)
        {
            _playerInputHelperMock
                .Setup(m => m.GetPlayerValue())
                .Returns(playerValue);
            
            _guessHelperMock
                .Setup(m => m.Guess(GameConstants.MinimumValue, playerValue))
                .Returns(guessedValue);
            
            _guessHelperMock.Setup(m => m.GetOutcome(playerValue, guessedValue))
                .Returns(outcome);

            await new Application(_consoleHelperMock.Object, _guessHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync(true, true);
            
            _guessHelperMock.Verify(m => m.Guess(GameConstants.MinimumValue, playerValue), Times.Once);
            
            _consoleHelperMock.Verify(m => m.WriteLine(string.Format(ComputerConstants.GuessMessage, guessedValue)), Times.Once);

            switch (outcome)
            {
                case GuessOutcomes.TooHigh:
                    _consoleHelperMock.Verify(m => m.WriteLine(string.Format(ComputerConstants.GuessTooHigh, guessedValue)), Times.Once);
                    break;
                case GuessOutcomes.IsClose:
                    _consoleHelperMock.Verify(m => m.WriteLine(string.Format(ComputerConstants.GuessIsClose, guessedValue)), Times.Once);
                    break;
            }
            
            _consoleHelperMock.Verify(m => m.WriteLine(GameConstants.GameOverMessage), Times.Once);
        }

        [Theory]
        [InlineData(50,  new int[] { 25, 50 }, new GuessOutcomes[] { GuessOutcomes.GuessAgain, GuessOutcomes.IsClose })]
        public async Task Given_Application_When_RunAsync_Then_GuessesAgainWhenNumberLowAndNotTooHigh(int playerValue, int[] guessedValues, GuessOutcomes[] outcome)
        {
            _playerInputHelperMock
                .Setup(m => m.GetPlayerValue())
                .Returns(playerValue);
            
            _guessHelperMock
                .SetupSequence(m => m.Guess(GameConstants.MinimumValue, playerValue))
                .Returns(guessedValues[0])
                .Returns(guessedValues[1]);
            
            _guessHelperMock
                .SetupSequence(m => m.GetOutcome(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(outcome[0])
                .Returns(outcome[1]);

            await new Application(_consoleHelperMock.Object, _guessHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync(true, true);
            
            _guessHelperMock.Verify(m => m.Guess(GameConstants.MinimumValue, playerValue), Times.Exactly(2));
            
            _consoleHelperMock.Verify(m => m.WriteLine(string.Format(ComputerConstants.GuessAgain, guessedValues[0])), Times.Once);
            _consoleHelperMock.Verify(m => m.WriteLine(string.Format(ComputerConstants.GuessIsClose, guessedValues[1])), Times.Once);
            _consoleHelperMock.Verify(m => m.WriteLine(GameConstants.GameOverMessage), Times.Once);
        }
    }
}