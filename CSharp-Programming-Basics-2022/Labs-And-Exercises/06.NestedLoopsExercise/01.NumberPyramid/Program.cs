using System;

namespace _01.NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 1;

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols <= rows; cols++)
                {
                    Console.Write(number + " ");
                    number++;

                    if (number > n)
                    {
                        return;
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
