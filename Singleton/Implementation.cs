namespace Singleton
{
    public class Logger
    {
        // thread safe implementation
        private static readonly Lazy<Logger> LazyLogger = new(() => new Logger());

        public static Logger Instance => LazyLogger.Value;

        // protected if you want to allow inheritance
        // private if you want to prevent inheritance
        // nevertheless the ctor needs to be either protected or private so that there is no way to create an instance of the class
        protected Logger(){}

        public void LogInfo(string message)
        {
            Console.WriteLine($"Info: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"Warning: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
