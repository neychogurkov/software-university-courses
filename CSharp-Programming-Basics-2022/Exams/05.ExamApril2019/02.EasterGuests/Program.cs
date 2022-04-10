using System;

namespace _02.EasterGuests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double easterBreads = Math.Ceiling((double)guests / 3);
            int eggs = 2 * guests;

            double totalPrice = easterBreads * 4 + eggs * 0.45;
            double diff = Math.Abs(totalPrice - budget);

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Lyubo bought {easterBreads} Easter bread and {eggs} eggs.");
                Console.WriteLine($"He has {diff:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {diff:f2} lv. more.");
            }
        }
    }
}
