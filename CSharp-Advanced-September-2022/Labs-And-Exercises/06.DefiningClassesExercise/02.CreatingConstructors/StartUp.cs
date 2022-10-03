using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();
            Person secondPerson = new Person(15);
            Person thirdPerson = new Person("George", 20);

            Console.WriteLine($"{firstPerson.Name} - {firstPerson.Age}");
            Console.WriteLine($"{secondPerson.Name} - {secondPerson.Age}");
            Console.WriteLine($"{thirdPerson.Name} - {thirdPerson.Age}");
        }
    }
}
