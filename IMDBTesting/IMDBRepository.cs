using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace IMDBTesting
{
    public class IMDBRepository
    {
        public IMDBRepository()
        {
        }

        public IEnumerable<Movie> GetMovies(string movieTitle)
        {
            var client = new RestClient($"https://imdb-internet-movie-database-unofficial.p.rapidapi.com/search/{movieTitle}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "75659707a4mshbe175a73468d4e2p1b9494jsn356396c32494");
            request.AddHeader("x-rapidapi-host", "imdb-internet-movie-database-unofficial.p.rapidapi.com");


            IRestResponse response = client.Execute(request);

            var responseOBJ = JObject.Parse(response.Content);

            var movieList = new List<Movie>();

            foreach(var movie in responseOBJ["titles"])
            {
                var myMovie = new Movie();
                myMovie.ID = (string) movie["id"];
                myMovie.Image = (string)movie["image"];
                myMovie.Title = (string)movie["title"];

                movieList.Add(myMovie);
            }

            return movieList;
        }
        
    }
}
