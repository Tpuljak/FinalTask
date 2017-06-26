using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;

namespace FinalTask.Domain.Commands
{
    public class CreateMovieListCommand
    {
        private readonly MovieAppContext _context;

        public CreateMovieListCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(MovieList movieList)
        {
            var movies = new List<Movie>();

            foreach (var movie in movieList.Movies)
            {
                movies.Add(_context.Movies.Find(movie.Id));
            }

            movieList.Movies.Clear();
            movieList.Movies = movies;
            _context.MovieLists.Add(movieList);
            _context.SaveChanges();
        }
    }
}
