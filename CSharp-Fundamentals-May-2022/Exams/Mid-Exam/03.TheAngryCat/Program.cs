using System;
using System.Linq;

namespace _03.TheAngryCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            string itemsType = Console.ReadLine();
            int leftDamage = 0;
            int rightDamage = 0;

            if (itemsType == "cheap")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        leftDamage += priceRatings[i];
                    }
                }

                for (int i = entryPoint + 1; i < priceRatings.Length; i++)
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        rightDamage += priceRatings[i];
                    }
                }
            }
            else if (itemsType == "expensive")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        leftDamage += priceRatings[i];
                    }
                }

                for (int i = entryPoint + 1; i < priceRatings.Length; i++)
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        rightDamage += priceRatings[i];
                    }
                }
            }

            if (rightDamage > leftDamage)
            {
                Console.WriteLine($"Right - {rightDamage}");
            }
            else
            {
                Console.WriteLine($"Left - {leftDamage}");
            }

        }
    }
}
