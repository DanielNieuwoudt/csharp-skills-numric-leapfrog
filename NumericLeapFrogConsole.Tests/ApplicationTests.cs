using FluentAssertions;
using Moq;
using NumericLeapFrogConsole.Helpers;

namespace NumericLeapFrogConsole.Tests
{
    public class ApplicationTests
    {
        private readonly Mock<IConsoleHelper> _consoleHelperMock = new ();
        private readonly Mock<IPlayerInputHelper> _playerInputHelper = new ();

        [Fact]
        public async Task Given_Application_When_RunAsync_Then_ThrowsNotImplementedException()
        {
            var action = async () => await new Application(_consoleHelperMock.Object, _playerInputHelper.Object).RunAsync();

            await action
                .Should()
                .ThrowAsync<NotImplementedException>();
        }
    }
}