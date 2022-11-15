namespace Logger.Core.IO
{
    using System.Linq;
    using System.Text;

    using Contracts;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder content;

        public LogFile()
        {
            this.content = new StringBuilder();
        }

        public int Size => this.Content.Where(ch => char.IsLetter(ch)).Sum(ch => ch);

        public string Content => this.content.ToString();

        public void Write(string text)
        {
            this.content.AppendLine(text);
        }
    }
}
