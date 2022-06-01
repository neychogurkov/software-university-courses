using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (array.Length> 1)
            {
                int[] condensedArray = new int[array.Length-1];

                for (int i = 0; i < condensedArray.Length; i++)
                {
                    condensedArray[i] = array[i] + array[i + 1];
                }

                array = condensedArray;
            }

            Console.WriteLine(array[0]);

        }
    }
}
