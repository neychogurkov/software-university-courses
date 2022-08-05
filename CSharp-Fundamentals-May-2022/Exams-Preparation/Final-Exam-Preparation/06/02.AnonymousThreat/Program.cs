using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "3:1")
                {
                    break;
                }

                if (command[0] == "merge")
                {
                    MergeData(command, data);
                }
                else if (command[0] == "divide")
                {
                    DivideData(command, data);
                }
            }

            Console.WriteLine(string.Join(" ", data));
        }

        static void MergeData(string[] command, List<string> data)
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);

            if (startIndex < 0 || startIndex >= data.Count)
            {
                startIndex = 0;
            }

            if (endIndex < 0 || endIndex >= data.Count)
            {
                endIndex = data.Count - 1;
            }

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                data[startIndex] += data[startIndex + 1];
                data.RemoveAt(startIndex + 1);
            }
        }

        static void DivideData(string[] command, List<string> data)
        {
            int index = int.Parse(command[1]);
            int partitions = int.Parse(command[2]);

            string text = data[index];
            int textLength = text.Length;
            int length = text.Length / partitions;

            data.RemoveAt(index);

            for (int i = 0; i < partitions; i++)
            {
                if (textLength % partitions != 0 && i == partitions - 1)
                {
                    data.Insert(index, text);
                    break;
                }

                data.Insert(index, text.Substring(0, length));
                text = text.Substring(length);
                index++;
            }
        }
    }
}
