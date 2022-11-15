namespace Logger.Core.IO.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        string Content { get; }

        void Write(string text);
    }
}
