using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] personInfo = command.Split();
                string name = personInfo[0];
                string id = personInfo[1];
                int age = int.Parse(personInfo[2]);


                if (persons.Any(p => p.ID == id))
                {
                    persons.FirstOrDefault(p => p.ID == id).Name=name;
                    persons.FirstOrDefault(p => p.ID == id).Age=age;
                    continue;
                }

                Person person = new Person(name, id, age);
                persons.Add(person);

                command = Console.ReadLine();
            }

            foreach (var person in persons.OrderBy(p=>p.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
    }
}
