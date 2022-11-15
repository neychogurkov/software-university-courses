namespace Logger.Core.Appenders
{
    using System;

    using Contracts;
    using Enums;
    using Layouts;
    using Layouts.Contracts;
    using Models.Contracts;

    public class ConsoleAppender : IAppender
    {
        private readonly IFormatter formatter;

        private ConsoleAppender()
        {
            this.formatter = new Formatter();
        }

        public ConsoleAppender(ILayout layout)
            : this()
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int AppendedMessages { get; private set; }

        public void AppendMessage(IMessage message)
        {
            if (message.ReportLevel >= this.ReportLevel)
            {
                Console.WriteLine(this.formatter.Format(message, this.Layout));
                this.AppendedMessages++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.AppendedMessages}";
        }
    }
}
