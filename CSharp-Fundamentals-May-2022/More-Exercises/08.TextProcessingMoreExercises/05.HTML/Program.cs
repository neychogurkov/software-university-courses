using System;
using System.Collections.Generic;

namespace _05.HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            List<string> comments = new List<string>();

            string command = Console.ReadLine();

            while (command!="end of comments")
            {
                comments.Add(command);
                command = Console.ReadLine();
            }

            Console.WriteLine($"<h1>\n    {title}\n</h1>");
            Console.WriteLine($"<article>\n    {content}\n</article>");

            foreach (var comment in comments)
            {
                Console.WriteLine($"<div>\n    {comment}\n</div>");
            }
        }
    }
}
