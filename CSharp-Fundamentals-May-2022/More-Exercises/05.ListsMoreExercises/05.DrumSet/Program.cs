using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> initialdrumsQuality = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drumsQuality = new List<int>(initialdrumsQuality);
            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < drumsQuality.Count; i++)
                {
                    if (drumsQuality[i] - hitPower > 0)
                    {
                        drumsQuality[i] -= hitPower;
                    }
                    else
                    {
                        if (savings - initialdrumsQuality[i] * 3 >= 0)
                        {
                            drumsQuality[i] = initialdrumsQuality[i];
                            savings -= initialdrumsQuality[i] * 3;
                        }
                        else
                        {
                            drumsQuality.RemoveAt(i);
                            initialdrumsQuality.RemoveAt(i);
                            i--;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drumsQuality));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
