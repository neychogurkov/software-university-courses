using System;

namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalPriceWithoutTaxes = 0;

            while (command != "special" && command != "regular")
            {
                double priceWithoutTaxes = double.Parse(command);

                if (priceWithoutTaxes > 0)
                {
                    totalPriceWithoutTaxes += priceWithoutTaxes;
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }

                command = Console.ReadLine();
            }

            if (totalPriceWithoutTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double taxes = 0.2 * totalPriceWithoutTaxes;
            double totalPrice = totalPriceWithoutTaxes + taxes;

            if (command == "special")
            {
                totalPrice -= 0.1 * totalPrice;
            }

            Console.WriteLine($"Congratulations you've just bought a new computer!\nPrice without taxes: {totalPriceWithoutTaxes:f2}$\nTaxes: {taxes:f2}$\n-----------\nTotal price: {totalPrice:f2}$");
        }
    }
}
