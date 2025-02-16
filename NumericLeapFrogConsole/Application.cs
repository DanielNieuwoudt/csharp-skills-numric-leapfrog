using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Helpers;

namespace NumericLeapFrogConsole
{
    public class Application(IConsoleHelper consoleHelper, IGuessHelper guessHelper, IPlayerInputHelper playerInputHelper) : IApplication
    {
        public Task RunAsync(bool isRunOnce = true, bool isGameMode = false)
        {
            consoleHelper.Clear();

            int? playerValue = null;

            do
            {
                playerValue = playerInputHelper.GetPlayerValue();

                if (isRunOnce) break;

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

            while (isGameMode)
            {
                var guess = guessHelper.Guess(GameConstants.MinimumValue, playerValue!.Value);

                consoleHelper.WriteLine(string.Format(ComputerConstants.GuessMessage, guess));

                if (guess >= playerValue)
                {
                    consoleHelper.WriteLine(string.Format(ComputerConstants.GuessTooHigh, guess));
                    break;
                }

                if (playerValue - guess <= 3)
                {
                    consoleHelper.WriteLine(string.Format(ComputerConstants.GuessIsClose, guess));
                    break;
                }

                consoleHelper.WriteLine(ComputerConstants.GuessAgain);
            }
            
            consoleHelper.WriteLine(GameConstants.GameOverMessage);

            return Task.CompletedTask;
        }
    }
}
