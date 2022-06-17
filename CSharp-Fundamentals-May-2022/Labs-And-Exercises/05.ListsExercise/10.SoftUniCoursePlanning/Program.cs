using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] tokens = input.Split(':');
                string command = tokens[0];
                string lessonTitle = tokens[1];

                switch (command)
                {
                    case "Add":
                        if (!lessons.Contains(lessonTitle))
                        {
                            lessons.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(tokens[2]);

                        if (!lessons.Contains(lessonTitle))
                        {
                            lessons.Insert(index, lessonTitle);
                        }
                        break;
                    case "Remove":
                        if (lessons.Contains(lessonTitle))
                        {
                            lessons.Remove(lessonTitle);

                            if (lessons.Contains($"{lessonTitle}-Exercise"))
                            {
                                lessons.Remove($"{lessonTitle}-Exercise");
                            }
                        }
                        break;
                    case "Swap":
                        string firstLessonTitle = tokens[1];
                        string secondLessonTitle = tokens[2];

                        if (lessons.Contains(firstLessonTitle) && lessons.Contains(secondLessonTitle))
                        {
                            int firstLessonIndex = lessons.IndexOf(firstLessonTitle);
                            int secondLessonIndex = lessons.IndexOf(secondLessonTitle);
                            lessons[firstLessonIndex] = secondLessonTitle;
                            lessons[secondLessonIndex] = firstLessonTitle;

                            if (lessons.Contains($"{secondLessonTitle}-Exercise"))
                            {
                                lessons.Remove($"{secondLessonTitle}-Exercise");
                                lessons.Insert(firstLessonIndex + 1, $"{secondLessonTitle}-Exercise");
                            }

                            if (lessons.Contains($"{firstLessonTitle}-Exercise"))
                            {
                                lessons.Remove($"{firstLessonTitle}-Exercise");
                                lessons.Insert(secondLessonIndex + 1, $"{firstLessonTitle}-Exercise");
                            }
                        }
                        break;
                    case "Exercise":
                        if (lessons.Contains(lessonTitle))
                        {
                            if (!(lessons.Contains($"{lessonTitle}-Exercise")))
                            {
                                lessons.Insert(lessons.IndexOf(lessonTitle) + 1, $"{lessonTitle}-Exercise");
                            }
                        }
                        else
                        {
                            lessons.Add(lessonTitle);
                            lessons.Add($"{lessonTitle}-Exercise");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            int counter = 0;

            foreach (var lesson in lessons)
            {
                counter++;
                Console.WriteLine($"{counter}.{lesson}");
            }
        }
    }
}
