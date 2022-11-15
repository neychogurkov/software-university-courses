namespace Logger.Core.Appenders
{
    using System.IO;

    using Contracts;
    using Enums;
    using IO.Contracts;
    using Layouts;
    using Layouts.Contracts;
    using Models.Contracts;

    public class FileAppender : IAppender
    {
        private readonly IFormatter formatter;

        private FileAppender()
        {
            this.formatter = new Formatter();
        }

        public FileAppender(ILayout layout, ILogFile logFile)
            : this()
        {
            this.Layout = layout;
            this.LogFile = logFile;
        }

        public ILayout Layout { get; private set; }

        public ILogFile LogFile { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int AppendedMessages { get; private set; }

        public void AppendMessage(IMessage message)
        {
            if (message.ReportLevel >= this.ReportLevel)
            {
                this.LogFile.Write(this.formatter.Format(message, this.Layout));
                File.WriteAllText("../../../log.txt", this.LogFile.Content);
                this.AppendedMessages++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.AppendedMessages}, File size: {this.LogFile.Size}";
        }
    }
}
