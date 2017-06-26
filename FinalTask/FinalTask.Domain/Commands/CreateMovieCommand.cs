using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;

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
            var actors = new List<Actor>();
            foreach (var actor in movie.Actors)
                actors.Add(_context.Actors.Find(actor.Id));

            var hashtags = new List<Hashtag>();
            foreach (var hashtag in movie.Hashtags)
                hashtags.Add(_context.Hashtags.Find(hashtag.Id));

            var movieLists = new List<MovieList>();
            foreach (var movieList in movie.MovieLists)
                movieLists.Add(_context.MovieLists.Find(movieList.Id));

            movie.MovieLists.Clear();
            movie.MovieLists = movieLists;

            movie.Hashtags.Clear();
            movie.Hashtags = hashtags;

            movie.Actors.Clear();
            movie.Actors = actors;

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}
