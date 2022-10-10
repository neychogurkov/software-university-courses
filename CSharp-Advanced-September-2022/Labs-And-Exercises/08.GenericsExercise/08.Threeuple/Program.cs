using System;
using System.Linq;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ');
            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>()
            {
                Item1 = $"{firstInput[0]} {firstInput[1]}",
                Item2 = firstInput[2],
                Item3 = string.Join(' ', firstInput.Skip(3)),
            };

            string[] secondInput = Console.ReadLine().Split(' ');
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>()
            {
                Item1 = secondInput[0],
                Item2 = int.Parse(secondInput[1]),
                Item3 = secondInput[2] == "drunk"
            };

            string[] thirdInput = Console.ReadLine().Split(' ');
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>()
            {
                Item1 = thirdInput[0],
                Item2 = double.Parse(thirdInput[1]),
                Item3 = thirdInput[2]
            };

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
