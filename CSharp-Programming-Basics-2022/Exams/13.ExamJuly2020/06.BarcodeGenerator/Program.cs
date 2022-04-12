using System;

namespace _06.BarcodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            int firstDigitStart = int.Parse(start[0].ToString());
            int secondDigitStart = int.Parse(start[1].ToString());
            int thirdDigitStart = int.Parse(start[2].ToString());
            int fourthDigitStart = int.Parse(start[3].ToString());

            int firstDigitEnd = int.Parse(end[0].ToString());
            int secondDigitEnd = int.Parse(end[1].ToString());
            int thirdDigitEnd = int.Parse(end[2].ToString());
            int fourthDigitEnd = int.Parse(end[3].ToString());

            for (int d1 = firstDigitStart; d1 <= firstDigitEnd; d1++)
            {
                for (int d2 = secondDigitStart; d2 <= secondDigitEnd; d2++)
                {
                    for (int d3 = thirdDigitStart; d3 <= thirdDigitEnd; d3++)
                    {

                        for (int d4 = fourthDigitStart; d4 <= fourthDigitEnd; d4++)
                        {
                            if (d1 % 2 != 0 && d2 % 2 != 0 && d3 % 2 != 0 && d4 % 2 != 0)
                            {
                                Console.Write($"{d1}{d2}{d3}{d4} ");
                            }
                        }
                    }
                }
            }
        }

    }
}
