using System;

namespace _09.CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());
            char thirdCharacter = char.Parse(Console.ReadLine());
            string result = firstCharacter.ToString() + secondCharacter.ToString() + thirdCharacter.ToString();
            Console.WriteLine(result);
        }
    }
}
