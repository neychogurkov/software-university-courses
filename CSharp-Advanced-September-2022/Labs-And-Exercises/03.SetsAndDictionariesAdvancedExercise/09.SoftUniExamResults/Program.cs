using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> studentsExamResults = new Dictionary<string, int>();
            Dictionary<string, int> submissionsByLanguage = new Dictionary<string, int>();

            while (true)
            {
                string[] studentInfo = Console.ReadLine().Split('-');

                if (studentInfo[0] == "exam finished")
                {
                    break;
                }

                if (studentInfo.Length == 3)
                {
                    AddStudentPoints(studentsExamResults, submissionsByLanguage, studentInfo);
                }
                else
                {
                    string username = studentInfo[0];
                    studentsExamResults.Remove(username);
                }
            }

            PrintResultsAndSubmissions(studentsExamResults, submissionsByLanguage);
        }

        static void AddStudentPoints(Dictionary<string, int> studentsExamResults, Dictionary<string, int> submissionsByLanguage, string[] studentInfo)
        {
            string username = studentInfo[0];
            string language = studentInfo[1];
            int points = int.Parse(studentInfo[2]);

            if (!studentsExamResults.ContainsKey(username))
            {
                studentsExamResults[username] = 0;

                if (!submissionsByLanguage.ContainsKey(language))
                {
                    submissionsByLanguage[language] = 0;
                }
            }

            studentsExamResults[username] = Math.Max(studentsExamResults[username], points);
            submissionsByLanguage[language]++;
        }

        static void PrintResultsAndSubmissions(Dictionary<string, int> studentsExamResults, Dictionary<string, int> submissionsByLanguage)
        {
            Console.WriteLine("Results:");
            foreach (var (username, points) in studentsExamResults.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{username} | {points}");
            }

            Console.WriteLine("Submissions:");
            foreach (var (language, submissionsCount) in submissionsByLanguage.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{language} - {submissionsCount}");
            }
        }
    }
}
