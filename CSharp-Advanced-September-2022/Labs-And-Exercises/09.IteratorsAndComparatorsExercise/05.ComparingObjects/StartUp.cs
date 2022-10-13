using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] personInfo = Console.ReadLine().Split();

                if (personInfo[0] == "END")
                {
                    break;
                }

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine());
            Person personToCompare = people[index - 1];
            int matchingPeople = people.Count(p => p.CompareTo(personToCompare) == 0);

            Console.WriteLine(matchingPeople > 1
                ? $"{matchingPeople} {people.Count - matchingPeople} {people.Count}"
                : "No matches");
        }
    }
}
