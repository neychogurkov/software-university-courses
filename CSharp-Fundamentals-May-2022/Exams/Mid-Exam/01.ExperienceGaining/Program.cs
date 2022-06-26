using System;

namespace _01.ExperienceGaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double experienceNeeded = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());
            double totalExperienceEarned = 0;

            for (int i = 1; i <= battlesCount; i++)
            {
                double experienceEarned = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    experienceEarned += 0.15 * experienceEarned;
                }

                if (i % 5 == 0)
                {
                    experienceEarned -= 0.1 * experienceEarned;
                }

                if (i % 15 == 0)
                {
                    experienceEarned += 0.05 * experienceEarned;
                }

                totalExperienceEarned += experienceEarned;

                if (totalExperienceEarned >= experienceNeeded)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {i} battles.");
                    return;
                }
            }

            Console.WriteLine($"Player was not able to collect the needed experience, {Math.Abs(experienceNeeded-totalExperienceEarned):f2} more needed.");
        }
    }
}
