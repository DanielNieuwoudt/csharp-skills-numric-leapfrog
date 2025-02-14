namespace NumericLeapFrogConsole;

public interface IApplication
{
    Task RunAsync(bool runOnce = true);
}