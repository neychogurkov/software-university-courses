using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int year = 1;
            int fails = 0;
            double gradeSum = 0;

            while (year < 13)
            {
                double grade = double.Parse(Console.ReadLine());
                gradeSum += grade;
                if (grade >= 4)
                {
                    year++;
                }
                else
                {
                    fails++;
                }
                if (fails > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {year} grade");
                    return;
                }
            }

            Console.WriteLine($"{name} graduated. Average grade: {gradeSum/12:f2}");
        }
    }
}
