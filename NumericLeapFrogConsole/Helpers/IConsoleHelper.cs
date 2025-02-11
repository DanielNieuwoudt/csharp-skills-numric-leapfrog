namespace NumericLeapFrogConsole.Helpers;

/// <summary>
/// A wrapper for the console to make unit testing easier.
/// </summary>
public interface IConsoleHelper
{
    void Clear();
        
    string? ReadLine();
        
    void WriteLine(string value);
}