namespace Logger.Core.Layouts
{
    using Contracts;
    using Models.Contracts;

    public class Formatter : IFormatter
    {
        public string Format(IMessage message, ILayout layout)
        {
            return string.Format(layout.Format, message.DateTime, message.ReportLevel, message.Text);
        }
    }
}
