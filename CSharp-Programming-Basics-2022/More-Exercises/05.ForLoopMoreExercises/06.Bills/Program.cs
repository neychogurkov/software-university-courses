using System;

namespace _06.Bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double totalElectricityBill = 0;
            double totalOtherBills = 0;

            for(int i = 0; i < months; i++)
            {
                double electricityBill = double.Parse(Console.ReadLine());
                totalElectricityBill += electricityBill;

                double otherBills = (electricityBill + 35);
                otherBills += 0.2 * otherBills;
                totalOtherBills += otherBills;
            }

            double totalWaterBill = 20*months;
            double totalInternetBill = 15*months;
            double totalBills = totalElectricityBill+totalWaterBill+totalInternetBill+totalOtherBills;

            Console.WriteLine($"Electricity: {totalElectricityBill:f2} lv");
            Console.WriteLine($"Water: {totalWaterBill:f2} lv");
            Console.WriteLine($"Internet: {totalInternetBill:f2} lv");
            Console.WriteLine($"Other: {totalOtherBills:f2} lv");
            Console.WriteLine($"Average: {totalBills/months:f2} lv");
        }
    }
}
