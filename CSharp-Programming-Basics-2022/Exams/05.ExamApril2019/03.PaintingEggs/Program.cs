using System;

namespace _03.PaintingEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eggSize = Console.ReadLine();
            string eggColor = Console.ReadLine();
            int batches = int.Parse(Console.ReadLine());
            double price = 0;

            if (eggSize == "Large")
            {
                if (eggColor == "Red")
                {
                    price = 16;
                }
                else if (eggColor == "Green")
                {
                    price = 12;
                }
                else if (eggColor == "Yellow")
                {
                    price = 9;
                }
            }
            else if(eggSize == "Medium")
            {
                if (eggColor == "Red")
                {
                    price = 13;
                }
                else if (eggColor == "Green")
                {
                    price = 9;
                }
                else if (eggColor == "Yellow")
                {
                    price = 7;
                }
            }
            else if (eggSize == "Small")
            {
                if (eggColor == "Red")
                {
                    price = 9;
                }
                else if (eggColor == "Green")
                {
                    price = 8;
                }
                else if (eggColor == "Yellow")
                {
                    price = 5;
                }
            }

            price *= batches;
            price -= 0.35 * price;

            Console.WriteLine($"{price:f2} leva.");
        }
    }
}
