using System;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleInfo = Console.ReadLine().Split(", ");
            string title = articleInfo[0];
            string content = articleInfo[1];
            string author = articleInfo[2];
            Article article = new Article(title, content, author);
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                switch (command[0])
                {
                    case "Edit":
                        article.Edit(command[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(command[1]);
                        break;
                    case "Rename":
                        article.Rename(command[1]);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string newContent) => Content = newContent;

        public void ChangeAuthor(string newAuthor) => Author = newAuthor;

        public void Rename(string newTitle) => Title = newTitle;

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
