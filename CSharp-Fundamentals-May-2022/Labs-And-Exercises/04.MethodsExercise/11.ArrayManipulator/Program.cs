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
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] elements = command.Split();

                if (elements[0] == "exchange")
                {
                    int index = int.Parse(elements[1]);

                    if (index < 0 || index >= numbers.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        ExchangeArray(numbers, index);
                    }
                }
                else if (elements[0] == "max")
                {
                    if (elements[1] == "even")
                    {
                        PrintIndexOfMaxEvenElement(numbers);
                    }
                    else if (elements[1] == "odd")
                    {
                        PrintIndexOfMaxOddElement(numbers);
                    }
                }
                else if (elements[0] == "min")
                {
                    if (elements[1] == "even")
                    {
                        PrintIndexOfMinEvenElement(numbers);
                    }
                    else if (elements[1] == "odd")
                    {
                        PrintIndexOfMinOddElement(numbers);
                    }
                }
                else if (elements[0] == "first")
                {
                    int count = int.Parse(elements[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        if (elements[2] == "even")
                        {
                            GetFirstCountEvenElements(numbers, count);
                        }
                        else if (elements[2] == "odd")
                        {
                            GetFirstCountOddElements(numbers, count);
                        }
                    }
                }
                else if (elements[0] == "last")
                {
                    int count = int.Parse(elements[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        if (elements[2] == "even")
                        {
                            GetLastCountEvenElements(numbers, count);
                        }
                        else if (elements[2] == "odd")
                        {
                            GetLastCountOddElements(numbers, count);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        static void ExchangeArray(int[] array, int index)
        {
            int[] subArray1 = new int[array.Length - index - 1];
            int[] subArray2 = new int[index + 1];

            for (int i = 0; i < subArray1.Length; i++)
            {
                subArray1[i] = array[i + index + 1];
            }

            for (int i = 0; i < subArray2.Length; i++)
            {
                subArray2[i] = array[i];
            }

            for (int i = 0; i < subArray1.Length; i++)
            {
                array[i] = subArray1[i];
            }

            for (int i = 0; i < subArray2.Length; i++)
            {
                array[subArray1.Length + i] = subArray2[i];
            }
        }

        static void PrintIndexOfMaxEvenElement(int[] array)
        {
            int max = int.MinValue;
            int maxIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] >= max)
                    {
                        max = array[i];
                        maxIndex = i;
                    }
                }
            }

            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxIndex);
            }
        }

        static void PrintIndexOfMaxOddElement(int[] array)
        {
            int max = int.MinValue;
            int maxIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] >= max)
                    {
                        max = array[i];
                        maxIndex = i;
                    }
                }
            }

            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxIndex);
            }
        }

        static void PrintIndexOfMinEvenElement(int[] array)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] <= min)
                    {
                        min = array[i];
                        minIndex = i;
                    }
                }
            }

            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minIndex);
            }
        }

        static void PrintIndexOfMinOddElement(int[] array)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] <= min)
                    {
                        min = array[i];
                        minIndex = i;
                    }
                }
            }

            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minIndex);
            }
        }

        static void GetFirstCountEvenElements(int[] array, int count)
        {
            List<int> evenElements = new List<int>();
            int evenCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenElements.Add(array[i]);
                    evenCount++;
                }

                if (count == evenCount)
                {
                    break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", evenElements)}]");
        }

        static void GetFirstCountOddElements(int[] array, int count)
        {
            List<int> oddElements = new List<int>();
            int oddCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    oddElements.Add(array[i]);
                    oddCount++;
                }

                if (count == oddCount)
                {
                    break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", oddElements)}]");
        }

        static void GetLastCountEvenElements(int[] array, int count)
        {
            List<int> evenElements = new List<int>();
            int evenCount = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    evenElements.Add(array[i]);
                    evenCount++;
                }

                if (count == evenCount)
                {
                    break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", evenElements)}]");
        }

        static void GetLastCountOddElements(int[] array, int count)
        {
            List<int> oddElements = new List<int>();
            int oddCount = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    oddElements.Add(array[i]);
                    oddCount++;
                }

                if (count == oddCount)
                {
                    break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", oddElements)}]");
        }
    }
}
