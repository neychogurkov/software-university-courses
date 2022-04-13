using System;

namespace _04.TransportPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double price = 0;

            if (kilometers < 20)
            {
                if (timeOfDay == "day")
                {
                    price = 0.7 + 0.79 * kilometers;
                }
                else if (timeOfDay == "night")
                {
                    price = 0.7 + 0.9 * kilometers;
                }
            }
            else if(kilometers<100)
            {
                price = 0.09 * kilometers;
            }
            else
            {
                price = 0.06 * kilometers;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
