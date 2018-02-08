namespace Akbars.Lessons
{
    public static class Logger
    {
        public static ILogger GetLogger()
        {
            return new ConsoleLogger();
        }
    }
}
