using System;

namespace GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int stringsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stringsCount; i++)
            {
                Box<string> box = new Box<string>() { Value = Console.ReadLine() };
                Console.WriteLine(box);
            }
        }
    }
}
