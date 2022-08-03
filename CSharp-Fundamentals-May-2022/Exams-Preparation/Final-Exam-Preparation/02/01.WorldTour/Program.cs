using System;

namespace _01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split(':');

                if (command[0] == "Travel")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Add Stop":
                        int index = int.Parse(command[1]);
                        string stop = command[2];

                        if (CheckIfIndexIsValid(stops, index))
                        {
                            stops = stops.Insert(index, stop);
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        if (CheckIfIndexIsValid(stops, startIndex) && CheckIfIndexIsValid(stops, endIndex))
                        {
                            stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                        }
                        break;
                    case "Switch":
                        string oldStop = command[1];
                        string newStop = command[2];

                        stops = stops.Replace(oldStop, newStop);
                        break;
                }

                Console.WriteLine(stops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        static bool CheckIfIndexIsValid(string text, int index)
        {
            if (index >= 0 && index < text.Length)
            {
                return true;
            }

            return false;
        }
    }
}
