using System;

namespace Akbars.Lessons
{
    public class ConsoleLogger : ILogger
    {
        public void Debug(string message)
        {
            Console.WriteLine($"DEBUG | {message}");
        }
    }
}
