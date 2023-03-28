namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //string ageRestriction = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(db, ageRestriction);

            //string result = GetGoldenBooks(db);

            //string result = GetBooksByPrice(db);

            //int year = int.Parse(Console.ReadLine());
            //string result = GetBooksNotReleasedIn(db, year);

            //string categories = Console.ReadLine();
            //string result = GetBooksByCategory(db, categories);

            //string date = Console.ReadLine();
            //string result = GetBooksReleasedBefore(db, date);

            //string endOfName = Console.ReadLine();
            //string result = GetAuthorNamesEndingIn(db, endOfName);

            //string text = Console.ReadLine();
            //string result = GetBookTitlesContaining(db, text);

            //string startOfAuthorLastName = Console.ReadLine();
            //string result = GetBooksByAuthor(db, startOfAuthorLastName);

            //int minTitleLength = int.Parse(Console.ReadLine());
            //int result = CountBooks(db, minTitleLength);

            //string result = CountCopiesByAuthor(db);

            //string result = GetTotalProfitByCategory(db);

            //string result = GetMostRecentBooks(db);

            //IncreasePrices(db);

            int result = RemoveBooks(db);

            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            string[] books = context.Books
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - {book.Price:c}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] books = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            int[] dateParts = date
                .Split('-')
                .Select(int.Parse)
                .ToArray();

            DateTime dateTime = new DateTime(dateParts[2], dateParts[1], dateParts[0]);

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    EditionType = b.EditionType.ToString(),
                    Price = b.Price.ToString("F2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    Author = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.Author})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
            => context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesByAuthor = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .ToArray()
                .OrderByDescending(a => a.Copies);

            StringBuilder sb = new StringBuilder();

            foreach (var author in copiesByAuthor)
            {
                sb.AppendLine($"{author.Name} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .ToArray()
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var category in profitByCategory)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var booksByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Select(cb => new
                        {
                            cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate!.Value.Year
                        })
                        .Take(3)
                        .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in booksByCategory)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            Book[] booksToUpdate = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            Book[] books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            int removedBooks = books.Length;
            context.RemoveRange(books);
            context.SaveChanges();

            return removedBooks;
        }
    }
}


