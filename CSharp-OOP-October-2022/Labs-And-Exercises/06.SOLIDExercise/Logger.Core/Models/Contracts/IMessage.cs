namespace Logger.Core.Models.Contracts
{
    using Enums;

    public interface IMessage
    {
        string DateTime { get; }

        ReportLevel ReportLevel { get; }

        string Text { get; }
    }
}
