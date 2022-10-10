using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ');
            CustomTuple<string, string> firstTuple = new CustomTuple<string, string>()
            {
                Item1 = $"{firstInput[0]} {firstInput[1]}",
                Item2 = firstInput[2]
            };

            string[] secondInput = Console.ReadLine().Split(' ');
            CustomTuple<string, int> secondTuple = new CustomTuple<string, int>()
            {
                Item1 = secondInput[0],
                Item2 = int.Parse(secondInput[1])
            };

            string[] thirdInput = Console.ReadLine().Split(' ');
            CustomTuple<int, double> thirdTuple = new CustomTuple<int, double>()
            {
                Item1 = int.Parse(thirdInput[0]),
                Item2 = double.Parse(thirdInput[1])
            };

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
