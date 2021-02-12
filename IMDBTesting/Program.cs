using System;

namespace IMDBTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new IMDBRepository();

            var movieList = repo.GetMovies("Gone With The Wind");

            foreach(var movie in movieList)
            {
                Console.WriteLine($"title: {movie.Title} id: {movie.ID}");
            }

            
        }
    }
}
