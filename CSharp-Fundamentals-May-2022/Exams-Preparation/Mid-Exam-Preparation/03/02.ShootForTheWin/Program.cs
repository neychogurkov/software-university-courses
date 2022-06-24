using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            int shotTargets = 0;

            while (command != "End")
            {
                int index = int.Parse(command);

                if (index < 0 || index >=targets.Length)
                {
                    command = Console.ReadLine();
                    continue;
                }
                int shotTarget = targets[index];

                if (targets[index] != -1)
                {
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] > shotTarget)
                        {
                            if (targets[i] != -1)
                            {
                                targets[i] -= shotTarget;
                            }
                        }
                        else 
                        {
                            if (targets[i] != -1)
                            {
                                targets[i] += shotTarget;
                            }
                        }
                    }
                    
                    shotTargets++;
                    targets[index] = -1;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", targets)}");
        }
    }
}
