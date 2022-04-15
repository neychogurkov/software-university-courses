using System;

namespace _07.SafePasswordsGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());
            char firstSymbol = (char)35;
            char secondSymbol = (char)64;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    Console.Write($"{firstSymbol}{secondSymbol}{x}{y}{secondSymbol}{firstSymbol}|");
                    firstSymbol++;
                    secondSymbol++;
                    maxPasswords--;

                    if (firstSymbol == (char)56)
                    {
                        firstSymbol = (char)35;
                    }
                    if (secondSymbol == (char)97)
                    {
                        secondSymbol = (char)64;
                    }

                    if (maxPasswords == 0)
                    {
                        return;
                    }
                }
            }


        }
    }
}
