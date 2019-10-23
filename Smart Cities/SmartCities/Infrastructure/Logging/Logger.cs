namespace SmartCities.Infrastructure.Logging
{
    using System;
    using System.Diagnostics;

    public class Logger : ILogger
    {
        public void Error(Exception exception)
        {
            Debug.WriteLine(exception.ToString());
        }

        public void Information(string message)
        {
            Debug.WriteLine(message);
        }

        public void Warning(string message)
        {
            Debug.WriteLine(message);
        }
    }
}