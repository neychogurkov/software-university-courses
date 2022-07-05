using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ');
                string personName = personInfo[0];
                int personAge = int.Parse(personInfo[1]);

                Person person = new Person(personName, personAge);

                family.AddMember(person);
            }

            Person oldestFamilyMember = family.GetOldestMember();
            Console.WriteLine($"{oldestFamilyMember.Name} {oldestFamilyMember.Age}");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            return People.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
