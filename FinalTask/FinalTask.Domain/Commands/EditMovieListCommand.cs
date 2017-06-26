using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;

namespace FinalTask.Domain.Commands
{
    public class EditMovieListCommand
    {
        private readonly MovieAppContext _context;

        public EditMovieListCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(MovieList changedMovieList)
        {
            var movies = new List<Movie>();

            foreach (var movie in changedMovieList.Movies)
                movies.Add(_context.Movies.Find(movie.Id));

            var movieList = _context.MovieLists.Find(changedMovieList.Id);
            movieList.Name = changedMovieList.Name;
            movieList.Movies.Clear();
            movieList.Movies = movies;

            _context.SaveChanges();
        }
    }
}
