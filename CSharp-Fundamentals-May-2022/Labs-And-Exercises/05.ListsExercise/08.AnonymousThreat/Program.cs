using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex < 0 || startIndex >= elements.Count)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= elements.Count || endIndex < 0)
                    {
                        endIndex = elements.Count - 1;
                    }

                    int index = startIndex + 1;

                    for (int i = startIndex + 1; i <= endIndex; i++)
                    {
                        elements[startIndex] += elements[index];
                        elements.RemoveAt(index);
                    }
                }
                else if (tokens[0] == "divide")
                {
                    List<string> dividedList = new List<string>();
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);
                    string currentWord = elements[index];
                    int length = currentWord.Length / partitions;
                    elements.RemoveAt(index);

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            dividedList.Add(currentWord.Substring(i * length));
                        }
                        else
                        {
                            dividedList.Add(currentWord.Substring(i * length, length));
                        }
                    }
                    elements.InsertRange(index, dividedList);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
