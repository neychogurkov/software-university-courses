using System;
using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            Animal animal = new Animal("Animal");
            animals.Add(animal);

            Reptile reptile = new Reptile("Reptile");
            animals.Add(reptile);
            Lizard lizard = new Lizard("Lizard");
            animals.Add(lizard);
            Snake snake = new Snake("Snake");
            animals.Add(snake);
            Mammal mammal = new Mammal("Mammal");
            animals.Add(mammal);
            Gorilla gorilla = new Gorilla("Gorilla");
            animals.Add(gorilla);
            Bear bear = new Bear("Bear");
            animals.Add(bear);

            foreach (Animal item in animals)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
