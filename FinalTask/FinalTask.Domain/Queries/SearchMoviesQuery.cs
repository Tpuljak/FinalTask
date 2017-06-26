using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.Domain.Queries
{
    public class SearchMoviesQuery
    {
        private readonly MovieAppContext _context;

        public SearchMoviesQuery()
        {
            _context = new MovieAppContext();
        }

        public List<Movie> Execute (string searchText, List<string> searchBy)
        {
            var movies = new List<Movie>();

            foreach (var condition in searchBy)
            {
                if(condition == "director" || condition == "all")
                {
                    movies.AddRange(_context.Movies.Where(movie => movie.Director.Name.Contains(searchText)).ToList());
                }

                if(condition == "movieList" || condition == "all")
                {
                    var movieLists = (_context.MovieLists.Where(movieList => movieList.Name.Contains(searchText)).ToList());
                    foreach(var movieList in movieLists)
                    {
                        movies.AddRange(movieList.Movies);
                    }
                }

                if(condition == "name" || condition == "all")
                {
                    movies.AddRange(_context.Movies.Where(movie => movie.Name.Contains(searchText)).ToList());
                }
            }

            return movies;
        }
    }
}
