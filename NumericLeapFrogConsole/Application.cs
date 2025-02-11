using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Helpers;

namespace NumericLeapFrogConsole
{
    public class Application(IConsoleHelper consoleHelper, IPlayerInputHelper playerInputHelper) : IApplication
    {
        public Task RunAsync()
        {
            consoleHelper.Clear();

            int? playerValue = null;

            do
            {
                playerValue = playerInputHelper.GetPlayerValue();
            } while (!playerValue.HasValue);

            switch (playerValue)
            {
                case -1:
                    consoleHelper.WriteLine(GameConstants.ExitMessage);
                    return Task.CompletedTask;
                default:
                    consoleHelper.WriteLine(string.Format(GameConstants.PlayerValueMessage, playerValue));
                    break;
            }

            consoleHelper.WriteLine(GameConstants.StartMessage);

            return Task.CompletedTask;
        }
    }
}
