namespace NumericLeapFrogConsole
{
    internal interface IApplication
    {
        Task RunAsync();
    }

    internal class Application : IApplication
    {
        public Task RunAsync()
        {
            throw new NotImplementedException();
        }
    }
}
