using System;

namespace _04.TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", TribonacciSequence(number)));
        }

        static int[] TribonacciSequence(int number)
        {
            int[] tribonacciSequence = new int[number];

            for (int i = 0; i < tribonacciSequence.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    tribonacciSequence[i] = 1;
                }
                else if (i == 2)
                {
                    tribonacciSequence[i] = 2;
                }
                else
                {
                    tribonacciSequence[i] = tribonacciSequence[i - 3] + tribonacciSequence[i - 2] +
                                            tribonacciSequence[i - 1];
                }
            }

            return tribonacciSequence;
        }
    }
}
