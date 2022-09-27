using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string outputFormat = Console.ReadLine();

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
            Action<Person> printer = CreatePrinter(outputFormat);
            PrintFilteredPeople(people, filter, printer);
        }

        static List<Person> ReadPeople()
        {
            List<Person> people = new List<Person>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ");

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            return people;
        }

        static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if (condition == "younger")
            {
                return person => person.Age < ageThreshold;
            }
            else if (condition == "older")
            {
                return person => person.Age >= ageThreshold;
            }

            throw new ArgumentException(condition);
        }

        static Action<Person> CreatePrinter(string outputFormat)
        {
            if (outputFormat == "name")
            {
                return person => Console.WriteLine(person.Name);
            }
            else if (outputFormat == "age")
            {
                return person => Console.WriteLine(person.Age);
            }
            else if (outputFormat == "name age")
            {
                return person => Console.WriteLine(person.Name + " - " + person.Age);
            }

            throw new ArgumentException(outputFormat);
        }

        static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            foreach (Person person in people.Where(filter))
            {
                printer(person);
            }
        }
    }

    internal class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
