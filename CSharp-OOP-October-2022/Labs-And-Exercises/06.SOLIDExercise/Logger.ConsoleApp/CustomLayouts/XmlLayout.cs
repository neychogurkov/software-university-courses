namespace Logger.ConsoleApp.Layouts
{
    using System.Text;

    using Logger.Core.Layouts.Contracts;

    public class XmlLayout : ILayout
    {
        public string Format => this.CreateFormat();

        private string CreateFormat()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine("<log>")
                .AppendLine("   <date>{0}</date>")
                .AppendLine("   <level>{1}</level>")
                .AppendLine("   <message>{2}</message>")
                .AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
