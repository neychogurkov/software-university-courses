using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> studentsSubmissions = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] contestInfo = Console.ReadLine().Split(':');

                if (contestInfo[0] == "end of contests")
                {
                    break;
                }

                string contestName = contestInfo[0];
                string passwordOfContest = contestInfo[1];

                contests[contestName] = passwordOfContest;
            }

            while (true)
            {
                string[] submissionInfo = Console.ReadLine().Split("=>");

                if (submissionInfo[0] == "end of submissions")
                {
                    break;
                }

                string contestName = submissionInfo[0];
                string passwordOfContest = submissionInfo[1];
                string username = submissionInfo[2];
                int points = int.Parse(submissionInfo[3]);

                if (contests.ContainsKey(contestName))
                {
                    if (contests[contestName] == passwordOfContest)
                    {
                        if (studentsSubmissions.ContainsKey(username))
                        {
                            if (studentsSubmissions[username].ContainsKey(contestName))
                            {
                                if (studentsSubmissions[username][contestName] < points)
                                {
                                    studentsSubmissions[username][contestName] = points;
                                }
                            }
                            else
                            {
                                studentsSubmissions[username].Add(contestName, points);
                            }
                        }
                        else
                        {
                            studentsSubmissions[username] = new Dictionary<string, int> { { contestName, points } };
                        }
                    }
                }
            }

            string bestStudent = string.Empty;
            int bestStudentPoints = 0;

            foreach (var student in studentsSubmissions)
            {
                if (studentsSubmissions[student.Key].Values.Sum()>bestStudentPoints)
                {
                    bestStudent = student.Key;
                    bestStudentPoints = studentsSubmissions[student.Key].Values.Sum();
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {bestStudentPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var student in studentsSubmissions.OrderBy(s=>s.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(c=>c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
