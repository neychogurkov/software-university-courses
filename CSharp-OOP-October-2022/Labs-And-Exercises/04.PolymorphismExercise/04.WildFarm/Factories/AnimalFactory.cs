namespace WildFarm.Factories
{
    using Contracts;
    using Models;
    using Models.Contracts;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            IAnimal animal = null;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(animalInfo[3]));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(animalInfo[3]));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, animalInfo[3]);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, animalInfo[3]);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, animalInfo[3], animalInfo[4]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, animalInfo[3], animalInfo[4]);
            }

            return animal;
        }
    }
}
