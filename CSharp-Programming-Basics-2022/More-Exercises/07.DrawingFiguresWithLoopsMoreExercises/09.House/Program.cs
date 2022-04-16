using System;

namespace _09.House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int dashes = 0;
            int asterisks = 0;

            if (n % 2 == 0)
            {
                dashes = n / 2 - 1;
                asterisks = 2;

                Console.WriteLine(new string('-', dashes) + new string('*', asterisks) + new string('-', dashes));

            }
            else
            {
                dashes = n / 2;
                asterisks = 1;

                Console.WriteLine(new string('-', dashes) + new string('*', asterisks) + new string('-', dashes));
            }

            for (int i = 0; i < (n + 1) / 2 - 1; i++)
            {
                if (dashes - 1 > 0)
                {
                    dashes -= 1;
                }
                else
                {
                    dashes = 0;
                }
                asterisks += 2;

                Console.WriteLine(new string('-', dashes) + new string('*', asterisks) + new string('-', dashes));
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine('|' + new string('*', n - 2) + '|');
            }
        }
    }
}
