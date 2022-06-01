using System;

namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();

            for (int i = 0; i < array.Length / 2; i++)
            {
                string swap = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = swap;
            }

            Console.WriteLine(string.Join(" ", array));

            //for (int i = array.Length - 1; i >= 0; i--)
            //{
            //    Console.Write(array[i] + " ");
            //}
        }
    }
}
