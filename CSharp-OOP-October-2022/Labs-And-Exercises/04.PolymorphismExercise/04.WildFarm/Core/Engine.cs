namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        private Engine()
        {
            this.animals = new HashSet<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                this.ProcessCommand(command);
            }

            this.PrintAllAnimals();
        }

        private void ProcessCommand(string command)
        {
            IAnimal animal = this.CreateAnimalUsingFactory(command);
            IFood food = this.CreateFoodUsingFactory();

            try
            {
                this.writer.WriteLine(animal.ProduceSound());
                animal.Eat(food);
            }
            catch (ArgumentException ae)
            {
                this.writer.WriteLine(ae.Message);
            }
            finally
            {
                this.animals.Add(animal);
            }
        }

        private IAnimal CreateAnimalUsingFactory(string command)
        {
            string[] animalsInfo = command.Split();
            IAnimal animal = this.animalFactory.CreateAnimal(animalsInfo);

            return animal;
        }

        private IFood CreateFoodUsingFactory()
        {
            string[] foodInfo = this.reader.ReadLine().Split();
            string foodType = foodInfo[0];
            int foodQuantity = int.Parse(foodInfo[1]);
            IFood food = this.foodFactory.CreateFood(foodType, foodQuantity);

            return food;
        }

        private void PrintAllAnimals()
        {
            foreach (var animal in this.animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
