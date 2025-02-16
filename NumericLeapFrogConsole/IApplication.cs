namespace NumericLeapFrogConsole;

public interface IApplication
{
    Task RunAsync(bool isRunOnce = true, bool isGameMode = true);
}