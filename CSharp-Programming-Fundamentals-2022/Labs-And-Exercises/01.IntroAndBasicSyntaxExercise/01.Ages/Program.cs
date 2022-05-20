using System;

namespace _01.Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string result = age <= 2 ? "baby" :
                age <= 13 ? "child" :
                age <= 19 ? "teenager" :
                age <= 65 ? "adult" : "elder";
            Console.WriteLine(result);
        }
    }
}
