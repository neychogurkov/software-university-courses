using System;

namespace _01.EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] values = new int[n];

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                int sum = 0;

                for (int j = 0; j < word.Length; j++)
                {
                    int letterCode = word[j];

                    switch (word[j])
                    {
                        case 'A':
                        case 'E':
                        case 'I':
                        case 'O':
                        case 'U':
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            sum += letterCode * word.Length;
                            break;
                        default:
                            sum += letterCode / word.Length;
                            break;
                    }
                }
                values[i] = sum;
            }

            Console.WriteLine(string.Join("\n", SelectionSort(values)));
        }

        static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;

                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[minIndex] > array[j])
                    {
                        int swap = array[minIndex];
                        array[minIndex] = array[j];
                        array[j] = swap;
                    }
                }
            }

            return array;
        }
    }
}
