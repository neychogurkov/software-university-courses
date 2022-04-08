using System;

namespace _04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int GOAL = 10000;
            int totalSteps = 0;

            while(totalSteps<GOAL)
            {
                string input = Console.ReadLine();
                if(input=="Going home")
                {
                    totalSteps += int.Parse(Console.ReadLine());
                    if (totalSteps < GOAL)
                    {
                        Console.WriteLine($"{GOAL-totalSteps} more steps to reach goal.");
                        return;
                    }
                    break;
                }

                int steps = int.Parse(input);
                totalSteps += steps;
            }

            Console.WriteLine("Goal reached! Good job!");
            Console.WriteLine($"{totalSteps-GOAL} steps over the goal!");
        }
    }
}
