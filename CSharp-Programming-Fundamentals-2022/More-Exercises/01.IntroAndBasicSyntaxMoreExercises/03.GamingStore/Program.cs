using System;

namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string gameName = Console.ReadLine();
            double totalPrice = 0;

            while(gameName!="Game Time")
            {
                double price = 0;
                switch (gameName)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if (balance - price<0)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    balance -= price;
                    totalPrice += price;
                    Console.WriteLine($"Bought {gameName}");
                }
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                gameName = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${totalPrice:f2}. Remaining: ${balance:f2}");
        }
    }
}
