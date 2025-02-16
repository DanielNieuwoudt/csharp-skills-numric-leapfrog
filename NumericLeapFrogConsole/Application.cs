using NumericLeapFrogConsole.Constants;
using NumericLeapFrogConsole.Enumerations;
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

            var keepGuessing = true;

            while (isGameMode && keepGuessing)
            {
                var guess = guessHelper.Guess(GameConstants.MinimumValue, playerValue!.Value);

                consoleHelper.WriteLine(string.Format(ComputerConstants.GuessMessage, guess));

                var guessOutcome = guessHelper.GetOutcome(playerValue.Value, guess);

                switch (guessOutcome)
                {
                    case GuessOutcomes.TooHigh:
                        consoleHelper.WriteLine(string.Format(ComputerConstants.GuessTooHigh, guess));
                        keepGuessing = false;
                        break;
                    case GuessOutcomes.IsClose:
                        consoleHelper.WriteLine(string.Format(ComputerConstants.GuessIsClose, guess));
                        keepGuessing = false;
                        break;
                    case GuessOutcomes.GuessAgain:
                        consoleHelper.WriteLine(ComputerConstants.GuessAgain);
                        break;
                }
            }
            
            consoleHelper.WriteLine(GameConstants.GameOverMessage);

            return Task.CompletedTask;
        }
    }
}
