namespace BirthdayCelebrations.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<IBirthable> birthables;

        private Engine()
        {
            this.birthables = new List<IBirthable>();
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

                string type = command[0];

                if (type == "Robot")
                {
                    string model = command[0];
                    string id = command[1];
                }
                else if (type == "Citizen")
                {
                    string name = command[1];
                    int age = int.Parse(command[2]);
                    string id = command[3];
                    string birthdate = command[4];
                    this.birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if (type == "Pet")
                {
                    string name = command[1];
                    string birthdate = command[2];
                    this.birthables.Add(new Pet(name, birthdate));
                }
            }

            string year = this.reader.ReadLine();

            foreach (var birthable in this.birthables.Where(b => b.Birthdate.EndsWith(year)))
            {
                this.writer.WriteLine(birthable.Birthdate);
            }
        }
    }
}
