using Logger.ConsoleApp.Factories.Contracts;
using Logger.Core.Appenders;
using Logger.Core.Appenders.Contracts;
using Logger.Core.IO.Contracts;
using Logger.Core.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.ConsoleApp.Factories
{
    internal class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ILogFile logFile = null)
        {
            IAppender appender = null;
            if (type == "ConsoleAppender")
            {
                appender =  new ConsoleAppender(layout);
            }
            else if(type == "FileAppender")
            {
                appender = new FileAppender(layout, logFile);
            }

            return appender;
        }
    }
}
