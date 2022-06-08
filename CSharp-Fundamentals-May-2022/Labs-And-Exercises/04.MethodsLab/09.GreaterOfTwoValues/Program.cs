using System;

namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    Console.WriteLine(GetMax(int.Parse(first), int.Parse(second)));
                    break;
                case "char":
                    Console.WriteLine(GetMax(char.Parse(first), char.Parse(second)));
                    break;
                case "string":
                    Console.WriteLine(GetMax(first, second));
                    break;
            }
        }

        static int GetMax(int firstNum, int secondNum)
        {
            if(firstNum>secondNum)
            {
                return firstNum;
            }

            return secondNum;
        }

        static char GetMax(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }

            return secondChar;
        }

        static string GetMax(string firstString, string secondString)
        {
            if (firstString.CompareTo(secondString) == 1)
            {
                return firstString;
            }

            return secondString;
        }
    }
}
