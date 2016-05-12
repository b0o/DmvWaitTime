using System;

namespace DmvWaitTime.Logging
{
    class MyLogger : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
