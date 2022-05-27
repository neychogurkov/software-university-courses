using System;
using System.Collections.Generic;

namespace _06.BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> openedBrackets = new Stack<string>();
            bool isBalanced = true;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    openedBrackets.Push(input);
                }
                else if (input == ")")
                {
                    if (openedBrackets.Count > 0)
                    {
                        openedBrackets.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
            }

            if (openedBrackets.Count == 0 && isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
