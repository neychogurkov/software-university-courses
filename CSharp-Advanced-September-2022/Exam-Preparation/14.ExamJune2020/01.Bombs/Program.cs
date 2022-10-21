using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            Dictionary<int, string> bombsByValue = new Dictionary<int, string>()
            {
                {40, "Datura Bombs"},
                {60, "Cherry Bombs"},
                {120, "Smoke Decoy Bombs"}
            };
            SortedDictionary<string, int> bombsByCount = new SortedDictionary<string, int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };

            bool isFilled = false;

            while (bombEffects.Any() && bombCasings.Any())
            {
                int currentBombEffect = bombEffects.Peek();
                int currentBombCasing = bombCasings.Pop();

                if (bombsByValue.ContainsKey(currentBombEffect + currentBombCasing))
                {
                    string bombName = bombsByValue[currentBombEffect + currentBombCasing];
                    bombsByCount[bombName]++;

                    bombEffects.Dequeue();
                }
                else
                {
                    bombCasings.Push(currentBombCasing - 5);
                }

                if (bombsByCount.Values.All(x => x >= 3))
                {
                    isFilled = true;
                    break;
                }
            }

            string bombEffectsLeft = bombEffects.Any()
                ? string.Join(", ", bombEffects)
                : "empty";
            string bombCasingsLeft = bombCasings.Any()
                ? string.Join(", ", bombCasings)
                : "empty";

            Console.WriteLine(isFilled
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");
            Console.WriteLine($"Bomb Effects: {bombEffectsLeft}");
            Console.WriteLine($"Bomb Casings: {bombCasingsLeft}");

            foreach (var bomb in bombsByCount)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
