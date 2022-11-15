namespace Logger.Core.Loggers
{
    using System.Collections.Generic;

    using Appenders.Contracts;
    using Contracts;
    using Enums;
    using Models;
    using Models.Contracts;

    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.Warning, message);
        }

        public void Error(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.Error, message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Append(dateTime, ReportLevel.Fatal, message);
        }

        private void Append(string dateTime, ReportLevel reportLevel, string messageText)
        {
            IMessage message = new Message(dateTime, reportLevel, messageText);
            foreach (IAppender appender in this.appenders)
            {
                appender.AppendMessage(message);
            }
        }
    }
}
