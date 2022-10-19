using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wavesCount = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> orcsLeft = new Stack<int>();

            bool isDestroyed = false;

            for (int i = 0; i < wavesCount; i++)
            {
                Stack<int> orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

                if ((i + 1) % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (orcs.Any() && plates.Any())
                {
                    int currentOrc = orcs.Pop();
                    int currentPlate = plates.Dequeue();

                    if (currentOrc > currentPlate)
                    {
                        orcs.Push(currentOrc - currentPlate);
                    }
                    else if (currentPlate > currentOrc)
                    {
                        Queue<int> newPlates = new Queue<int>();

                        newPlates.Enqueue(currentPlate - currentOrc);

                        foreach (var plate in plates)
                        {
                            newPlates.Enqueue(plate);
                        }

                        plates = newPlates;
                    }

                    if (!plates.Any())
                    {
                        isDestroyed = true;
                        orcsLeft = orcs;
                        break;
                    }
                }
            }

            if (isDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsLeft)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
