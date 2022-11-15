namespace Logger.Core.Appenders.Contracts
{
    using Enums;
    using Layouts.Contracts;
    using Models.Contracts;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        int AppendedMessages { get; }

        void AppendMessage(IMessage message);
    }
}
