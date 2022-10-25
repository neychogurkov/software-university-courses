using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.Eat();

            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();

            Cat cat = new Cat();
            cat.Meow();
            cat.Eat();
        }
    }
}
