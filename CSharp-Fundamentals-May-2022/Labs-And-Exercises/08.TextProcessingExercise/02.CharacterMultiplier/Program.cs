using System;

namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();

            Console.WriteLine(GetSumOfStrings(strings[0], strings[1]));
        }

        static int GetSumOfStrings(string firstString, string secondString)
        {
            int characterSum = 0;

            int shorterLength = Math.Min(firstString.Length, secondString.Length);

            for (int i = 0; i < shorterLength; i++)
            {
                characterSum += firstString[i] * secondString[i];
            }

            for (int i = shorterLength; i < firstString.Length; i++)
            {
                characterSum += firstString[i];
            }

            for (int i = shorterLength; i < secondString.Length; i++)
            {
                characterSum += secondString[i];
            }
            
            return characterSum;
        }
    }
}
