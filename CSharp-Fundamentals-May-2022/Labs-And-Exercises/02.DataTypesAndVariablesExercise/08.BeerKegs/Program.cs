using System;

namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double volumeOfBiggestKeg = double.MinValue;
            string modelOfBiggestKeg = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string modelOfKeg = Console.ReadLine();
                double radiusOfKeg = double.Parse(Console.ReadLine());
                int heightOfKeg = int.Parse(Console.ReadLine());
                double volumeOfKeg = Math.PI * radiusOfKeg * radiusOfKeg * heightOfKeg;

                if (volumeOfKeg > volumeOfBiggestKeg)
                {
                    volumeOfBiggestKeg = volumeOfKeg;
                    modelOfBiggestKeg = modelOfKeg;
                }
            }

            Console.WriteLine(modelOfBiggestKeg);
        }
    }
}
