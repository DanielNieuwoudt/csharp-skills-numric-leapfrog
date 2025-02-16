using NumericLeapFrogConsole.Constants;

namespace NumericLeapFrogConsole.Helpers
{
    public class PlayerInputHelper(IConsoleHelper consoleHelper) : IPlayerInputHelper
    {
        public int? GetPlayerValue()
        {
            consoleHelper.WriteLine($"Enter a number between {GameConstants.MinimumValue}-{GameConstants.MaximumValue} to start the leap frog game or type '{GameConstants.ExitCommand}' to quit:");

            var input = consoleHelper.ReadLine();

            if (string.Equals(input, GameConstants.ExitCommand, StringComparison.OrdinalIgnoreCase)) return -1;
            if (!int.TryParse(input, out var value)) return null;

            switch (value)
            {
                case < GameConstants.MinimumValue:
                    consoleHelper.WriteLine(GameConstants.InvalidMinimumNumberMessage);
                    break;
                case > GameConstants.MaximumValue:
                    consoleHelper.WriteLine(GameConstants.InvalidMaximumNumberMessage);
                    break;
                default:
                    return value;
            }
            return null;
        }
    }
}
