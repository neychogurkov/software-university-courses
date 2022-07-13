using System;
using System.Reflection.Metadata;

namespace _01.ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string personInfo = Console.ReadLine();
                string name = personInfo.Substring(personInfo.IndexOf('@') + 1, personInfo.IndexOf('|') - personInfo.IndexOf('@') - 1);
                string age = personInfo.Substring(personInfo.IndexOf('#') + 1, personInfo.IndexOf('*') - personInfo.IndexOf('#') - 1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
