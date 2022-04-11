using System;

namespace _03.TravelAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cityName = Console.ReadLine();
            string packetType = Console.ReadLine();
            string discount = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double price = 0;

            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                    return;
            }

            if ((cityName!="Bansko"&&cityName!="Borovets"&&cityName!="Varna"&&cityName!="Burgas")||(packetType!="noEquipment"&& packetType != "withEquipment"&& packetType != "noBreakfast" && packetType != "withBreakfast"))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            switch (cityName)
            {
                case "Bansko":
                case "Borovets":
                    {
                        if (packetType == "withEquipment")
                        {
                            price = 100;
                            if (discount == "yes")
                            {
                                price -= 0.1 * price;
                            }
                        }
                        else if (packetType == "noEquipment")
                        {
                            price = 80;
                            if (discount == "yes")
                            {
                                price -= 0.05 * price;
                            }
                        }
                        break;
                    }
                case "Varna":
                case "Burgas":
                    {
                        if (packetType == "withBreakfast")
                        {
                            price = 130;
                            if (discount == "yes")
                            {
                                price -= 0.12 * price;
                            }
                        }
                        else if (packetType == "noBreakfast")
                        {
                            price = 100;
                            if (discount == "yes")
                            {
                                price -= 0.07 * price;
                            }
                        }
                        break;
                    }
            }

            if (days > 7)
            {
                days--;
            }

            price *= days;

            Console.WriteLine($"The price is {price:f2}lv! Have a nice time!");

        }
    }
}
