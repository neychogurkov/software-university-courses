namespace FoodShortage.Core
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
        private readonly List<IBuyer> buyers;

        private Engine()
        {
            this.buyers = new List<IBuyer>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int peopleCount = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = this.reader.ReadLine().Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (personInfo.Length == 4)
                {
                    string id = personInfo[2];
                    string birthdate = personInfo[3];
                    this.buyers.Add(new Citizen(name, age, id, birthdate));
                }
                else if (personInfo.Length == 3)
                {
                    string group = personInfo[2];
                    this.buyers.Add(new Rebel(name, age, group));
                }
            }

            while (true)
            {
                string name = this.reader.ReadLine();

                if (name == "End")
                {
                    break;
                }

                IBuyer buyer = buyers.Find(b => b.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            this.writer.WriteLine(buyers.Sum(b => b.Food).ToString());
        }
    }
}
