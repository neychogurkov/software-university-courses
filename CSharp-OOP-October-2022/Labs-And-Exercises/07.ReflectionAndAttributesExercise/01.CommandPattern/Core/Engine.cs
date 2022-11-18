namespace CommandPattern.Core
{
    using Contracts;
    using IO;
    using IO.Contracts;
    using Utilities.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICommandInterpreter commandInterpreter;

        private Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public Engine(ICommandInterpreter command)
            : this()
        {
            this.commandInterpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();
                string result = this.commandInterpreter.Read(input);
                this.writer.WriteLine(result);
            }
        }
    }
}
