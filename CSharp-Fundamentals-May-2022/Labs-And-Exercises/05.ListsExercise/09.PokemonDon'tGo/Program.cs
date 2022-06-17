using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sumOfRemovedElements = 0;

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int elementToRemove = 0;

                if (index < 0)
                {
                    elementToRemove = numbers[0];
                    numbers[0] = numbers[numbers.Count - 1]; 
                }
                else if (index >= numbers.Count)
                {
                    elementToRemove = numbers[numbers.Count-1];
                    numbers[numbers.Count - 1] = numbers[0]; 
                }
                else
                {
                    elementToRemove = numbers[index];
                    numbers.RemoveAt(index);
                }

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= elementToRemove)
                    {
                        numbers[i] += elementToRemove;
                    }
                    else
                    {
                        numbers[i] -= elementToRemove;
                    }
                }

                sumOfRemovedElements += elementToRemove;
            }

            Console.WriteLine(sumOfRemovedElements);
        }
        
    }
}
