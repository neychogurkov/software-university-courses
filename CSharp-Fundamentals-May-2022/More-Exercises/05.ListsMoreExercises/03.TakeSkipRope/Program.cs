using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            List<char> nonNumbers = new List<char>();
            List<int> numbers = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            List<char> decryptedMessage = new List<char>();

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (char.IsDigit(encryptedMessage[i]))
                {
                    numbers.Add(int.Parse(encryptedMessage[i].ToString()));
                }
                else
                {
                    nonNumbers.Add(encryptedMessage[i]);
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            int charsToSkip = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                int charsToTake = takeList[i]; 
                decryptedMessage.AddRange(nonNumbers.Skip(charsToSkip).Take(charsToTake));
                charsToSkip += skipList[i];
                charsToSkip += charsToTake;
            }

            Console.WriteLine(string.Join("", decryptedMessage));
        }
    }
}
