using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordsOfContests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> studentsPoints = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] contestInfo = Console.ReadLine().Split(':');

                if (contestInfo[0] == "end of contests")
                {
                    break;
                }

                AddContest(passwordsOfContests, contestInfo);
            }

            while (true)
            {
                string[] submissionInfo = Console.ReadLine().Split("=>");

                if (submissionInfo[0] == "end of submissions")
                {
                    break;
                }

                AddStudentAndPoints(passwordsOfContests, studentsPoints, submissionInfo);
            }

            PrintStudents(studentsPoints);
        }

        static void AddContest(Dictionary<string, string> passwordsOfContests, string[] contestInfo)
        {
            string contestName = contestInfo[0];
            string password = contestInfo[1];

            if (!passwordsOfContests.ContainsKey(contestName))
            {
                passwordsOfContests[contestName] = password;
            }
        }

        static void AddStudentAndPoints(Dictionary<string, string> passwordsOfContests, Dictionary<string, Dictionary<string, int>> studentsPoints, string[] submissionInfo)
        {
            string contestName = submissionInfo[0];
            string password = submissionInfo[1];
            string username = submissionInfo[2];
            int points = int.Parse(submissionInfo[3]);

            if (passwordsOfContests.ContainsKey(contestName) && passwordsOfContests[contestName] == password)
            {
                if (!studentsPoints.ContainsKey(username))
                {
                    studentsPoints[username] = new Dictionary<string, int>();
                }

                if (!studentsPoints[username].ContainsKey(contestName))
                {
                    studentsPoints[username][contestName] = 0;
                }

                studentsPoints[username][contestName] = Math.Max(studentsPoints[username][contestName], points); ;
            }
        }

        static void PrintStudents(Dictionary<string, Dictionary<string, int>> studentsPoints)
        {
            var bestCandidate = studentsPoints.First(s => s.Value.Values.Sum() == studentsPoints.Max(s => s.Value.Values.Sum()));

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");
            foreach (var (name, studentInfo) in studentsPoints.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{name}");

                foreach (var (contest, points) in studentInfo.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
