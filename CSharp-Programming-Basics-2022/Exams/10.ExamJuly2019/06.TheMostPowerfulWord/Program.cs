using System;

namespace _06.TheMostPowerfulWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string mostPowerfulWord = string.Empty;
            double maxPower = double.MinValue;

            while (word != "End of words")
            {
                double power = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    power += word[i];
                }

                switch (word[0])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                    case 'Y':
                        power *= word.Length;
                        break;
                    default:
                        power = Math.Floor(power / word.Length);
                        break;
                }

                if (power > maxPower)
                {
                    maxPower = power;
                    mostPowerfulWord = word;
                }

                word = Console.ReadLine();
            }

            Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {maxPower}");
        }
    }
}
