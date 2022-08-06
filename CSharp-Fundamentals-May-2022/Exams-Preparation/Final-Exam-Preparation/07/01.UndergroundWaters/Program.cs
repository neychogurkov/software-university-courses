using System;
using System.Linq;

namespace _01.UndergroundWaters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string airInput = Console.ReadLine();
            string raindropInput = Console.ReadLine();

            int countOfLocalMaximumValues = 0;
            int biggestAirValue = 0;
            int biggestRaindropValue = 0;

            if (!string.IsNullOrEmpty(airInput))
            {
                int[] airArray = airInput.Split().Select(int.Parse).ToArray();

                GetCountAndBiggestValue(airArray, ref countOfLocalMaximumValues, ref biggestAirValue);
            }

            if (!string.IsNullOrEmpty(raindropInput))
            {
                int[] raindropsArray = raindropInput.Split().Select(int.Parse).ToArray();

                raindropsArray = raindropsArray
                    .Select(n => n - countOfLocalMaximumValues)
                    .Where(n => n > 0)
                    .ToArray();

                GetCountAndBiggestValue(raindropsArray, ref countOfLocalMaximumValues, ref biggestRaindropValue);
            }

            if (biggestAirValue == biggestRaindropValue)
            {
                Console.WriteLine("Something interesting was found!");
                Console.WriteLine($"Sum: {biggestAirValue * 2}");
            }
            else
            {
                Console.WriteLine("There is nothing unordinary!");
                Console.WriteLine($"Difference: {Math.Abs(biggestAirValue - biggestRaindropValue)}");
            }
        }

        private static void GetCountAndBiggestValue(int[] array, ref int countOfLocalMaximumValues, ref int biggestValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    if (array.Length == 1)
                    {
                        IncreaseCount(ref countOfLocalMaximumValues, array, i, ref biggestValue);
                    }
                    else
                    {
                        if (array[i] > array[i + 1])
                        {
                            IncreaseCount(ref countOfLocalMaximumValues, array, i, ref biggestValue);
                        }
                    }
                }
                else if (i == array.Length - 1)
                {
                    if (array[i] > array[i - 1])
                    {
                        IncreaseCount(ref countOfLocalMaximumValues, array, i, ref biggestValue);
                    }
                }
                else
                {
                    if (array[i] > array[i - 1] && array[i] > array[i + 1])
                    {
                        IncreaseCount(ref countOfLocalMaximumValues, array, i, ref biggestValue);
                    }
                }
            }
        }

        private static void IncreaseCount(ref int countOfLocalMaximumValues, int[] array, int i, ref int biggestValue)
        {
            countOfLocalMaximumValues++;

            if (array[i] > biggestValue)
            {
                biggestValue = array[i];
            }
        }
    }
}
