using System;
using System.Collections.Generic;

namespace _03.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int numberOfArticles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] articleInfo = Console.ReadLine().Split(", ");
                string title = articleInfo[0];
                string content = articleInfo[1];
                string author = articleInfo[2];

                Article article = new Article(title, content, author);

                articles.Add(article);
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
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
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
