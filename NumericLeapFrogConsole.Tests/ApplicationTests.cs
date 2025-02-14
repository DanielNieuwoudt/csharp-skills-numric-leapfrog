using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Helpers;

namespace NumericLeapFrogConsole.Tests
{
    public class ApplicationTests
    {
        private readonly Mock<IConsoleHelper> _consoleHelperMock = new ();
        private readonly Mock<IPlayerInputHelper> _playerInputHelperMock = new ();

        public ApplicationTests()
        {
            _playerInputHelperMock
                .Setup(m => m.GetPlayerValue())
                .Returns(-1);
        }

        [Fact]
        public async Task Given_Application_When_RunAsync_Then_ClearsConsoleOnce()
        {
            await new Application(_consoleHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync();

            _consoleHelperMock.Verify(m => m.Clear(), Times.Once);
        }

        [Fact]
        public async Task Given_Application_When_RunAsync_Then_GetPlayerValueAtLeastOnce()
        {
            await new Application(_consoleHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync();

            _playerInputHelperMock.Verify(m => m.GetPlayerValue(), Times.Once);
        }

        [Fact]
        public async Task Given_Application_When_RunAsync_Then_ExitsWhenPlayerValueIsMinusOne()
        {
            _playerInputHelperMock
                .Setup(m => m.GetPlayerValue())
                .Returns(-1);

            await new Application(_consoleHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync();

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

            await new Application(_consoleHelperMock.Object, _playerInputHelperMock.Object)
                .RunAsync();

            _playerInputHelperMock.Verify(m => m.GetPlayerValue(), Times.Once);

            _consoleHelperMock.Verify(m => m.WriteLine(string.Format(GameConstants.PlayerValueMessage, playerValue)), Times.Once);
            _consoleHelperMock.Verify(m => m.WriteLine(GameConstants.StartMessage));
        }
    }
}