namespace Logger.ConsoleApp.Factories.Contracts
{
    using Logger.Core.Appenders.Contracts;
    using Logger.Core.IO.Contracts;
    using Logger.Core.Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ILogFile logFile = null);
    }
}
