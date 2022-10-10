using System;

namespace GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int integersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < integersCount; i++)
            {
                Box<int> box = new Box<int>() { Value = int.Parse(Console.ReadLine()) };
                Console.WriteLine(box);
            }
        }
    }
}
