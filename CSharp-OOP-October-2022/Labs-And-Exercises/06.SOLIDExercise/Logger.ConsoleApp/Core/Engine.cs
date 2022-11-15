namespace Logger.ConsoleApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Factories;
    using Factories.Contracts;
    using Logger.Core.Appenders.Contracts;
    using Logger.Core.Enums;
    using Logger.Core.IO;
    using Logger.Core.Layouts.Contracts;
    using Logger.Core.Loggers;
    using Logger.Core.Loggers.Contracts;

    public class Engine : IEngine
    {
        private readonly ICollection<IAppender> appenders;
        private ILogger logger;

        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;

        public Engine()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void Run()
        {
            this.CreateAppenders();

            this.logger = new Logger(this.appenders.ToArray());
            this.LogCommands();

            this.PrintAppenders();
        }

        private void CreateAppenders()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderInfo = Console.ReadLine().Split();
                string appenderType = appenderInfo[0];
                string layoutType = appenderInfo[1];

                ILayout layout = this.layoutFactory.CreateLayout(layoutType);

                IAppender appender = null;
                appender = this.appenderFactory.CreateAppender(appenderType, layout, new LogFile());
                if (appenderInfo.Length == 3)
                {
                    string reportLevelText = appenderInfo[2];
                    appender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelText, true);
                }

                this.appenders.Add(appender);
            }
        }

        private void LogCommands()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] messageInfo = command.Split('|');
                string reportLevel = messageInfo[0];
                string dateTime = messageInfo[1];
                string message = messageInfo[2];

                if (reportLevel == "INFO")
                {
                    this.logger.Info(dateTime, message);
                }
                else if (reportLevel == "WARNING")
                {
                    this.logger.Warning(dateTime, message);
                }
                else if (reportLevel == "ERROR")
                {
                    this.logger.Error(dateTime, message);
                }
                else if (reportLevel == "CRITICAL")
                {
                    this.logger.Critical(dateTime, message);
                }
                else if (reportLevel == "FATAL")
                {
                    this.logger.Fatal(dateTime, message);
                }
            }
        }

        private void PrintAppenders()
        {
            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
