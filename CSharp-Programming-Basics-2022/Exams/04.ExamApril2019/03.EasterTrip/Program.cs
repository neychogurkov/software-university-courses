using System;

namespace _03.EasterTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int overnights = int.Parse(Console.ReadLine());
            double oneOvernightPrice = 0;

            if (destination == "France")
            {
                if (dates == "21-23")
                {
                    oneOvernightPrice = 30;
                }
                else if (dates == "24-27")
                {
                    oneOvernightPrice = 35;
                }
                else if (dates == "28-31")
                {
                    oneOvernightPrice = 40;
                }
            }
            else if (destination == "Italy")
            {
                if (dates == "21-23")
                {
                    oneOvernightPrice = 28;
                }
                else if (dates == "24-27")
                {
                    oneOvernightPrice = 32;
                }
                else if (dates == "28-31")
                {
                    oneOvernightPrice = 39;
                }
            }
            else if (destination == "Germany")
            {
                if (dates == "21-23")
                {
                    oneOvernightPrice = 32;
                }
                else if (dates == "24-27")
                {
                    oneOvernightPrice = 37;
                }
                else if (dates == "28-31")
                {
                    oneOvernightPrice = 43;
                }
            }

            double totalPrice = oneOvernightPrice * overnights;
            Console.WriteLine($"Easter trip to {destination} : {totalPrice:f2} leva.");
        }
    }
}
