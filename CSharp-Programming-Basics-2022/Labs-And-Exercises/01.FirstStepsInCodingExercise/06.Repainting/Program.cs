using System;

namespace _06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylonQuantity = int.Parse(Console.ReadLine());
            int paintQuantity = int.Parse(Console.ReadLine());
            int thinnerQuantity = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double totalExpenses = (nylonQuantity + 2) * 1.5 + (paintQuantity + 0.1 * paintQuantity) * 14.5 + thinnerQuantity * 5 + 0.4;
            totalExpenses += 0.3 * totalExpenses * hours;
            Console.WriteLine(totalExpenses);
        }
    }
}
