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
            List<int> initialdrumsQualities = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drumsQualities = new List<int>(initialdrumsQualities);
            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < drumsQualities.Count; i++)
                {
                    if (drumsQualities[i] - hitPower > 0)
                    {
                        drumsQualities[i] -= hitPower;
                    }
                    else
                    {
                        if (savings - initialdrumsQualities[i] * 3 >= 0)
                        {
                            drumsQualities[i] = initialdrumsQualities[i];
                            savings -= initialdrumsQualities[i] * 3;
                        }
                        else
                        {
                            drumsQualities.RemoveAt(i);
                            initialdrumsQualities.RemoveAt(i);
                            i--;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drumsQualities));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
