using System;

namespace _05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string websiteName = Console.ReadLine();
                if (websiteName == "Facebook")
                {
                    salary -= 150;
                }
                else if (websiteName == "Instagram")
                {
                    salary -= 100;
                }
                else if (websiteName == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }
            }
            Console.WriteLine(salary);
        }
    }
}
