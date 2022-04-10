using System;

namespace _06.FavoriteMovie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int movieCounter = 0;
            int maxPoints = int.MinValue;
            string favouriteMovie = string.Empty;

            while (movie != "STOP")
            {
                movieCounter++;
                int points = 0;

                for (int i = 0; i < movie.Length; i++)
                {
                    if ((movie[i] >= 'a' && movie[i] <= 'z') || movie[i] >= 'A' && movie[i] <= 'Z')
                    {
                        if (movie[i].ToString() == movie[i].ToString().ToLower())
                        {
                            points += movie[i] - 2 * movie.Length;
                        }
                        else
                        {
                            points += movie[i] - movie.Length;
                        }
                    }
                    else
                    {
                        points += movie[i];
                    }
                }

                if (points > maxPoints)
                {
                    maxPoints = points;
                    favouriteMovie = movie;
                }

                if (movieCounter == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }

                movie = Console.ReadLine();
            }

            Console.WriteLine($"The best movie for you is {favouriteMovie} with {maxPoints} ASCII sum.");
        }
    }
}
