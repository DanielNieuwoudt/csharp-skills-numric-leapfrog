using System.Collections.Frozen;

namespace NumericLeapFrogConsole.Helpers
{
    public class GuessHelper : IGuessHelper
    {
        private readonly Random _guess = new ();

        private readonly IList<int> _guesses = new List<int>();

        public IReadOnlyList<int> Guesses => _guesses.ToList();

        public int Guess(int minimumValue, int maximumValue)
        {
            var guess = _guess.Next(minimumValue, maximumValue + 1);
           
            _guesses.Add(guess);

            return _guesses.Sum();
        }
    }
}
