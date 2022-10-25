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

            Puppy puppy = new Puppy();
            puppy.Bark();
            puppy.Eat();
            puppy.Weep();
        }
    }
}
