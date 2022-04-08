using System;

namespace _01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            string book = Console.ReadLine();
            int searchedBooksCount = 0;

            while(book!="No More Books")
            {
                if(book==favouriteBook)
                {
                    Console.WriteLine($"You checked {searchedBooksCount} books and found it.");
                    return;
                }
                searchedBooksCount++;

                book = Console.ReadLine();
            }

            Console.WriteLine($"The book you search is not here!");
            Console.WriteLine($"You checked {searchedBooksCount} books.");
        }
    }
}
