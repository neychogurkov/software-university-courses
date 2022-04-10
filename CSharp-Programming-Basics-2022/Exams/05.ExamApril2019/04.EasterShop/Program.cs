using System;

namespace _04.EasterShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggsQuantity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int eggsSold = 0;

            while (command != "Close")
            {
                int eggs = int.Parse(Console.ReadLine());

                if (command == "Buy")
                {
                    if (eggs > eggsQuantity)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggsQuantity}.");
                        return;
                    }
                    eggsSold += eggs;
                    eggsQuantity -= eggs;
                }
                else if (command == "Fill")
                {
                    eggsQuantity += eggs;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Store is closed!");
            Console.WriteLine($"{eggsSold} eggs sold.");
        }
    }
}
