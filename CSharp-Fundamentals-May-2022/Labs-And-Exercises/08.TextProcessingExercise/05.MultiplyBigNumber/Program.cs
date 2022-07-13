using System;
using System.Numerics;
using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder product = new StringBuilder();
            int remainder = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(number[i].ToString());
                int result = currentDigit * multiplier + remainder;
                remainder = result / 10;

                product.Insert(0, result % 10);
            }

            if (remainder > 0)
            {
                product.Insert(0, remainder);
            }
            
            Console.WriteLine(product);
        }
    }
}
