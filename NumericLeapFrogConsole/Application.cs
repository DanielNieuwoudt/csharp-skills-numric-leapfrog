namespace NumericLeapFrogConsole
{
    public interface IApplication
    {
        Task RunAsync();
    }

    public class Application : IApplication
    {
        public Task RunAsync()
        {
            throw new NotImplementedException();
        }
    }
}
