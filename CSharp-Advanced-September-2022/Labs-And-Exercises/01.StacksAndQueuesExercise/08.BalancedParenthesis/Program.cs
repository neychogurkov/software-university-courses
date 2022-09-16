using System;
using System.Collections;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            bool isBalanced = true;

            foreach (var ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else
                {
                    if (stack.Count == 0 ||
                        (ch == ')' && stack.Pop() != '(') ||
                        (ch == '}' && stack.Pop() != '{') ||
                        (ch == ']' && stack.Pop() != '['))
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
