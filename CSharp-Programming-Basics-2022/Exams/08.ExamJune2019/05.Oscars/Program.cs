using System;

namespace _05.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double startingPoints = double.Parse(Console.ReadLine());
            int juryMembers = int.Parse(Console.ReadLine());
            for (int i = 0; i < juryMembers; i++)
            {
                string juryName = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                juryPoints *= juryName.Length;
                juryPoints /= 2;
                startingPoints += juryPoints;
                if (startingPoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {startingPoints:f1}!");
                    return;
                }
            }
            Console.WriteLine($"Sorry, {actorName} you need {1250.5-startingPoints:f1} more!");
        }
    }
}
