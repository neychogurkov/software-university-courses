using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split('!').ToList();
            string input = Console.ReadLine();

            while (input!="Go Shopping!")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                string item = tokens[1];

                switch (command)
                {
                    case "Urgent":
                        if (!products.Contains(item))
                        {
                            products.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (products.Contains(item))
                        {
                            products.Remove(item);
                        }
                        break;
                    case "Correct":
                        string oldItem = item;
                        string newItem = tokens[2];

                        if (products.Contains(oldItem))
                        {
                            int indexOfOldItem = products.IndexOf(oldItem);
                            products[indexOfOldItem] = newItem;
                        }
                        break;
                    case "Rearrange":
                        if (products.Contains(item))
                        {
                            int indexOfProduct = products.IndexOf(item);
                            products.Add(products[indexOfProduct]);
                            products.RemoveAt(indexOfProduct);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", products));
        }
    }
}
