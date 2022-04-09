using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                bool isSpecial = true;
                int currentNumber = i;

                while (currentNumber > 0)
                {
                    int currentDigit = currentNumber % 10;

                    if (currentDigit == 0)
                    {
                        isSpecial = false;
                        break;
                    }

                    if (n % currentDigit != 0)
                    {
                        isSpecial = false;
                        break;
                    }

                    currentNumber /= 10;
                }

                if (isSpecial)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
