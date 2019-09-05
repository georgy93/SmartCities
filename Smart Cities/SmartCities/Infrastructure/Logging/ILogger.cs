namespace SmartCities.Infrastructure.Logging
{
    using System;

    public interface ILogger
    {
        void Information(string message);

        void Error(Exception exception);

        void Warning(string message);
    }
}
