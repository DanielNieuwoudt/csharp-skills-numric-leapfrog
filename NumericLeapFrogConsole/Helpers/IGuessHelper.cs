using NumericLeapFrogConsole.Enumerations;

namespace NumericLeapFrogConsole.Helpers;

public interface IGuessHelper
{
    int Guess(int minimumValue, int maximumValue);

    public GuessOutcomes GetOutcome(int playerValue, int guess);
}