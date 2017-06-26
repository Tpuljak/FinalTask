using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;

namespace FinalTask.Domain.Commands
{
    public class EditMovieCommand
    {
        private readonly MovieAppContext _context;

        public EditMovieCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(Movie changedMovie)
        {
            var movie = _context.Movies.Find(changedMovie.Id);
            movie.Actors.Clear();
            movie.Hashtags.Clear();
            movie.MovieLists.Clear();

            var actors = new List<Actor>();
            foreach (var actor in changedMovie.Actors)
                actors.Add(_context.Actors.Find(actor.Id));

            var hashtags = new List<Hashtag>();
            foreach (var hashtag in changedMovie.Hashtags)
                hashtags.Add(_context.Hashtags.Find(hashtag.Id));

            var movieLists = new List<MovieList>();
            foreach (var movieList in changedMovie.MovieLists)
                movieLists.Add(_context.MovieLists.Find(movieList.Id));

            var director = _context.Directors.Find(changedMovie.DirectorId);
            var genre = _context.Genres.Find(changedMovie.GenreId);

            movie.Name = changedMovie.Name;
            movie.Actors = actors;
            movie.DirectorId = changedMovie.DirectorId;
            movie.GenreId = changedMovie.GenreId;
            movie.Hashtags = hashtags;
            movie.MovieLists = movieLists;

            _context.SaveChanges();
        }
    }
}
