using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split();

                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index >= numbers.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers = ExchangeArray(numbers, index);
                    }
                }
                else if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        PrintIndexOfMaxEvenElement(numbers);
                    }
                    else if (command[1] == "odd")
                    {
                        PrintIndexOfMaxOddElement(numbers);
                    }
                }
                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        PrintIndexOfMinEvenElement(numbers);
                    }
                    else if (command[1] == "odd")
                    {
                        PrintIndexOfMinOddElement(numbers);
                    }
                }
                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        if (command[2] == "even")
                        {
                            GetFirstCountEvenElements(numbers, count);
                        }
                        else if (command[2] == "odd")
                        {
                            GetFirstCountOddElements(numbers, count);
                        }
                    }
                }
                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        if (command[2] == "even")
                        {
                            GetLastCountEvenElements(numbers, count);
                        }
                        else if (command[2] == "odd")
                        {
                            GetLastCountOddElements(numbers, count);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        static int[] ExchangeArray(int[] array, int splitIndex)
        {
            int[] exchangedArray = new int[array.Length];
            int index = 0;

            for (int i = splitIndex + 1; i < array.Length; i++)
            {
                exchangedArray[index] = array[i];
                index++;
            }

            for (int i = 0; i <= splitIndex; i++)
            {
                exchangedArray[index] = array[i];
                index++;
            }

            return exchangedArray;
        }

        static void PrintIndexOfMaxEvenElement(int[] array)
        {
            int maxEvenNumber = int.MinValue;
            int maxIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] >= maxEvenNumber)
                    {
                        maxEvenNumber = array[i];
                        maxIndex = i;
                    }
                }
            }

            Console.WriteLine(maxEvenNumber == int.MinValue ? "No matches" : maxIndex.ToString());
        }

        static void PrintIndexOfMaxOddElement(int[] array)
        {
            int maxOddNumber = int.MinValue;
            int maxIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] >= maxOddNumber)
                    {
                        maxOddNumber = array[i];
                        maxIndex = i;
                    }
                }
            }

            Console.WriteLine(maxOddNumber == int.MinValue ? "No matches" : maxIndex.ToString());
        }

        static void PrintIndexOfMinEvenElement(int[] array)
        {
            int minOddNumber = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] <= minOddNumber)
                    {
                        minOddNumber = array[i];
                        minIndex = i;
                    }
                }
            }

            Console.WriteLine(minOddNumber == int.MaxValue ? "No matches" : minIndex.ToString());
        }

        static void PrintIndexOfMinOddElement(int[] array)
        {
            int minOddNumber = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] <= minOddNumber)
                    {
                        minOddNumber = array[i];
                        minIndex = i;
                    }
                }
            }

            Console.WriteLine(minOddNumber == int.MaxValue ? "No matches" : minIndex.ToString());
        }

        static void GetFirstCountEvenElements(int[] array, int count)
        {
            List<int> evenNumbers = new List<int>();
            int evenCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenNumbers.Add(array[i]);
                    evenCount++;
                }

                if (count == evenCount)
                {
                    break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", evenNumbers)}]");
        }

        static void GetFirstCountOddElements(int[] array, int count)
        {
            List<int> oddNumbers = new List<int>();
            int oddCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    oddNumbers.Add(array[i]);
                    oddCount++;
                }

                if (count == oddCount)
                {
                    break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", oddNumbers)}]");
        }

        static void GetLastCountEvenElements(int[] array, int count)
        {
            List<int> evenNumbers = new List<int>();
            int evenCount = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    evenNumbers.Add(array[i]);
                    evenCount++;
                }

                if (count == evenCount)
                {
                    break;
                }
            }

            evenNumbers.Reverse();
            Console.WriteLine($"[{string.Join(", ", evenNumbers)}]");
        }

        static void GetLastCountOddElements(int[] array, int count)
        {
            List<int> oddNumbers = new List<int>();
            int oddCount = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    oddNumbers.Add(array[i]);
                    oddCount++;
                }

                if (count == oddCount)
                {
                    break;
                }
            }

            oddNumbers.Reverse();
            Console.WriteLine($"[{string.Join(", ", oddNumbers)}]");
        }
    }
}
