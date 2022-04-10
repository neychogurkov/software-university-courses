using System;

namespace _05.MovieRatings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int moviesCount = int.Parse(Console.ReadLine());
            double ratingSum = 0;
            double highestRating = int.MinValue;
            string highestRatedMovie = string.Empty;
            double lowestRating = int.MaxValue;
            string lowestRatedMovie = string.Empty;

            for (int i = 0; i < moviesCount; i++)
            {
                string movieName = Console.ReadLine();
                double movieRating = double.Parse(Console.ReadLine());
                ratingSum += movieRating;
                
                if (highestRating < movieRating)
                {
                    highestRating = movieRating;
                    highestRatedMovie = movieName;
                }

                if (lowestRating > movieRating)
                {
                    lowestRating = movieRating;
                    lowestRatedMovie = movieName;
                }
            }

            Console.WriteLine($"{highestRatedMovie} is with highest rating: {highestRating:f1}");
            Console.WriteLine($"{lowestRatedMovie} is with lowest rating: {lowestRating:f1}");
            Console.WriteLine($"Average rating: {ratingSum/moviesCount:f1}");
        }
    }
}
