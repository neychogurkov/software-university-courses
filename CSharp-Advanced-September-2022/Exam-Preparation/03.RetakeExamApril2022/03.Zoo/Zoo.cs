using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; set; }

        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (this.Capacity == this.Animals.Count)
            {
                return "The zoo is full.";
            }
            else
            {
                this.Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }
        public int RemoveAnimals(string species) => this.Animals.RemoveAll(a => a.Species == species);
        public List<Animal> GetAnimalsByDiet(string diet) => this.Animals.FindAll(a => a.Diet == diet);
        public Animal GetAnimalByWeight(double weight) => this.Animals.FirstOrDefault(a => a.Weight == weight);
        public string GetAnimalCountByLength(double minimumLength, double maximumLength) => $"There are {this.Animals.Count(a => a.Length >= minimumLength && a.Length <= maximumLength)} animals with a length between {minimumLength} and {maximumLength} meters.";
    }
}
