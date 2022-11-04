namespace BorderControl.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;
    using Models.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<IIdentifiable> identifiables;

        private Engine()
        {
            this.identifiables = new List<IIdentifiable>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string[] command = this.reader.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                if (command.Length == 2)
                {
                    string model = command[0];
                    string id = command[1];
                    this.identifiables.Add(new Robot(model, id));
                }
                else if (command.Length == 3)
                {
                    string name = command[0];
                    int age = int.Parse(command[1]);
                    string id = command[2];
                    this.identifiables.Add(new Citizen(name, age, id));
                }
            }

            string fakeId = this.reader.ReadLine();

            foreach (var identifiable in identifiables.Where(i => i.Id.EndsWith(fakeId)))
            {
                this.writer.WriteLine(identifiable.Id);
            }
        }
    }
}
