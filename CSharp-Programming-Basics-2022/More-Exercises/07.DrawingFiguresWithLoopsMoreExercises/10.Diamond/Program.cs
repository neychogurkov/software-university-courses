using System;

namespace _10.Diamond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftRight = (n - 1) / 2;
            int mid = 0;

            for (int i = 0; i < n / 2; i++)
            {
                mid = n - 2 * leftRight - 2;
                Console.Write(new string('-', leftRight) + '*');
                if (mid >= 0)
                {
                    Console.Write(new string('-', mid) + '*');
                }
                Console.WriteLine(new string('-', leftRight));
                leftRight--;
            }

            if (n % 2 == 0)
            {
                leftRight = 0;
                for (int i = n / 2+1; i < n; i++)
                {
                    leftRight++;
                    mid = n - 2 * leftRight - 2;
                    Console.Write(new string('-', leftRight) + '*');
                    if (mid >= 0)
                    {
                        Console.Write(new string('-', mid) + '*');
                    }
                    Console.WriteLine(new string('-', leftRight));
                }
            }
            else
            {
                for (int i = n / 2 ; i < n; i++)
                {
                    mid = n - 2 * leftRight - 2;
                    Console.Write(new string('-', leftRight) + '*');
                    if (mid >= 0)
                    {
                        Console.Write(new string('-', mid) + '*');
                    }
                    Console.WriteLine(new string('-', leftRight));
                    leftRight++;
                }
            }

        }
    }
}
