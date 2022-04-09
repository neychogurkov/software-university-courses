using System;

namespace _03.SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (command != "stop")
            {
                int number = int.Parse(command);
                bool isPrime = true;

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    command = Console.ReadLine();
                    continue;
                }

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        nonPrimeSum += number;
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primeSum += number;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
