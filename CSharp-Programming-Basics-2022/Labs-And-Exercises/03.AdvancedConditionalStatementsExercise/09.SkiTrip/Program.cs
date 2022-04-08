using System;

namespace _09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();
            int overnights = days - 1;
            double totalPrice = 0;

            if(roomType=="room for one person")
            {
                totalPrice = overnights * 18;
            }
            else if (roomType == "apartment")
            {
                totalPrice = overnights * 25;
                if (days < 10)
                {
                    totalPrice -= totalPrice * 0.3;
                }
                else if (days >= 10 && days <= 15)
                {
                    totalPrice -= totalPrice * 0.35;
                }
                else
                {
                    totalPrice -= totalPrice * 0.5;
                }
            }
            else if(roomType=="president apartment")
            {
                totalPrice = overnights * 35;
                if (days < 10)
                {
                    totalPrice -= totalPrice * 0.1;
                }
                else if (days <= 10 && days <= 15)
                {
                    totalPrice -= totalPrice * 0.15;
                }
                else
                {
                    totalPrice -= totalPrice * 0.2;
                }
            }

            if (rating == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else if (rating == "negative")
            {
                totalPrice -= totalPrice * 0.1;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
