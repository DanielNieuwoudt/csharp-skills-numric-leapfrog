using NumericLeapFrogConsole.Constants;

namespace NumericLeapFrogConsole.Helpers
{
    public class PlayerInputHelper(IConsoleHelper consoleHelper) : IPlayerInputHelper
    {
        public int? GetPlayerValue()
        {
            consoleHelper.WriteLine($"Enter a number between {PlayerConstants.MinimumValue}-{PlayerConstants.MaximumValue} to start the leap frog game or type '{PlayerConstants.ExitCommand}' to quit:");

            var input = consoleHelper.ReadLine();

            if (string.Equals(input, PlayerConstants.ExitCommand, StringComparison.OrdinalIgnoreCase)) return -1;
            if (!int.TryParse(input, out var value)) return null;
            
            switch (value)
            {
                case < PlayerConstants.MinimumValue:
                    consoleHelper.WriteLine(PlayerConstants.InvalidMinimumNumberMessage);
                    break;
                case > PlayerConstants.MaximumValue:
                    consoleHelper.WriteLine(PlayerConstants.InvalidMaximumNumberMessage);
                    break;
                default:
                    return value;
            }
            return null;
        }
    }
}
