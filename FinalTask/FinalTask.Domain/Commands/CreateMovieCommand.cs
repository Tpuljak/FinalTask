using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Commands
{
    public class CreateMovieCommand
    {
        private readonly MovieAppContext _context;

        public CreateMovieCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(Movie movie)
        {
            movie.Director = _context.Directors.Find(movie.DirectorId);
            movie.Genre = _context.Genres.Find(movie.GenreId);

            var movieLists = movie.MovieLists;
            foreach(var movieList in movieLists)
            {
                var modifymovieList = _context.MovieLists.Find(movieList.Id);
                modifymovieList.Movies.Add(movie);
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}
