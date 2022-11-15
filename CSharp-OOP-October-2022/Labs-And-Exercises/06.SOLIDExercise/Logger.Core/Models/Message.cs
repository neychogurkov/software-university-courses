namespace Logger.Core.Models
{
    using Contracts;
    using Enums;

    public class Message : IMessage
    {
        public Message(string dateTime, ReportLevel reportLevel, string text)
        {
            this.DateTime = dateTime;
            this.ReportLevel = reportLevel;
            this.Text = text;
        }

        public string DateTime { get; }

        public ReportLevel ReportLevel { get; }

        public string Text { get; }
    }
}
