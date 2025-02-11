using System.Diagnostics.CodeAnalysis;

namespace NumericLeapFrogConsole.Helpers
{
    /// <inheritdoc />
    [ExcludeFromCodeCoverage(Justification = "Simple delegating wrapper.")]
    public class ConsoleHelper : IConsoleHelper
    {
        public void Clear()
        {
            Console.Clear();
        }
        
        public string? ReadLine()
        {
            return Console.ReadLine();
        }
        
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
