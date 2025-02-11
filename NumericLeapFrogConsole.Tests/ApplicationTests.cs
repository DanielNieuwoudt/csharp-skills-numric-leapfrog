using FluentAssertions;

namespace NumericLeapFrogConsole.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public async Task Given_Application_When_RunAsync_Then_ThrowsNotImplementedException()
        {
            var action = async () => await new Application().RunAsync();

            await action
                .Should()
                .ThrowAsync<NotImplementedException>();
        }
    }
}