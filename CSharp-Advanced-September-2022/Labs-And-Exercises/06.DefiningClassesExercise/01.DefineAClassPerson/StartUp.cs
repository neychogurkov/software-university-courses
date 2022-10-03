using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person()
            {
                Name = "Peter",
                Age = 20
            };
            Person secondPerson = new Person();
            Person thirdPerson = new Person()
            {
                Name = "Jose",
                Age = 43
            };

            Console.WriteLine($"{firstPerson.Name} - {firstPerson.Age}");
            Console.WriteLine($"{secondPerson.Name} - {secondPerson.Age}");
            Console.WriteLine($"{thirdPerson.Name} - {thirdPerson.Age}");
        }
    }
}
