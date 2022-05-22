using System;

namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());
            double lightsabersCount = studentsCount + Math.Ceiling(0.1 * studentsCount);
            double beltsCount = studentsCount - studentsCount / 6;
            double price = lightsaberPrice * lightsabersCount + beltsPrice * beltsCount + robesPrice * studentsCount;

            if (price <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {price:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {price-money:f2}lv more.");
            }
        }
    }
}
