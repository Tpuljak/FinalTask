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
            foreach (var actor in movie.Actors)
                _context.Actors.Attach(actor);

            foreach (var hashtag in movie.Hashtags)
                _context.Hashtags.Attach(hashtag);

            foreach (var movieList in movie.MovieLists)
                _context.MovieLists.Attach(movieList);

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}
