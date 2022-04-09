using System;

namespace _05.FitnessCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int backTrainings = 0;
            int chestTrainings = 0;
            int legsTrainings = 0;
            int absTrainings = 0;
            int proteinShakesBought = 0;
            int proteinBarsBought = 0;

            for (int i = 0; i < people; i++)
            {
                string activity = Console.ReadLine();

                switch (activity)
                {
                    case "Back":
                        backTrainings++;
                        break;
                    case "Chest":
                        chestTrainings++;
                        break;
                    case "Legs":
                        legsTrainings++;
                        break;
                    case "Abs":
                        absTrainings++;
                        break;
                    case "Protein shake":
                        proteinShakesBought++;
                        break;
                    case "Protein bar":
                        proteinBarsBought++;
                        break;
                }
            }

            double workoutPercentage = (double)(backTrainings + chestTrainings + legsTrainings + absTrainings) / people * 100;
            double proteinPercentage = (double)(proteinShakesBought + proteinBarsBought) / people * 100;

            Console.WriteLine($"{backTrainings} - back");
            Console.WriteLine($"{chestTrainings} - chest");
            Console.WriteLine($"{legsTrainings} - legs");
            Console.WriteLine($"{absTrainings} - abs");
            Console.WriteLine($"{proteinShakesBought} - protein shake");
            Console.WriteLine($"{proteinBarsBought} - protein bar");
            Console.WriteLine($"{workoutPercentage:f2}% - work out");
            Console.WriteLine($"{proteinPercentage:f2}% - protein");

        }
    }
}
