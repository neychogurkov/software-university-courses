using System;

namespace _03.AluminumJoinery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int joineryCount = int.Parse(Console.ReadLine());
            if (joineryCount < 10)
            {
                Console.WriteLine("Invalid order");
                return;
            }

            string joineryType = Console.ReadLine();
            string shipmentMethod = Console.ReadLine();
            double price = 0;

            switch (joineryType)
            {
                case "90X130":
                    {
                        price = 110;
                        price *= joineryCount;

                        if (joineryCount > 60)
                        {
                            price -= 0.08 * price;
                        }
                        else if (joineryCount > 30)
                        {
                            price -= 0.05 * price;
                        }
                        break;
                    }
                case "100X150":
                    {
                        price = 140;
                        price *= joineryCount;

                        if (joineryCount > 80)
                        {
                            price -= 0.1 * price;
                        }
                        else if (joineryCount > 40)
                        {
                            price -= 0.06 * price;
                        }
                        break;
                    }
                case "130X180":
                    {
                        price = 190;
                        price *= joineryCount;

                        if (joineryCount > 50)
                        {
                            price -= 0.12 * price;
                        }
                        else if (joineryCount > 20)
                        {
                            price -= 0.07 * price;
                        }
                        break;
                    }
                case "200X300":
                    {
                        price = 250;
                        price *= joineryCount;

                        if (joineryCount > 50)
                        {
                            price -= 0.14 * price;
                        }
                        else if (joineryCount > 25)
                        {
                            price -= 0.09 * price;
                        }
                        break;
                    }
            }

            if(shipmentMethod=="With delivery")
            {
                price += 60;
            }

            if (joineryCount > 99)
            {
                price -= 0.04 * price;
            }

            Console.WriteLine($"{price:f2} BGN");
        }
    }
}
