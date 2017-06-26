using FinalTask.Domain.Commands;
using System.Collections.Generic;
using System.Web.Http;
using FinalTask.Domain.Queries;
using FinalTask.Data.Models;

namespace FinalTask.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : ApiController
    {
        private readonly CreateMovieCommand _createMovieCommand;
        private readonly DeleteMovieCommand _deleteMovieCommand;
        private readonly GetAllMoviesQuery _getAllMoviesQuery;
        private readonly SearchMoviesQuery _searchMoviesQuery;
        private readonly EditMovieCommand _editMovieCommand;

        public MoviesController()
        {
            _createMovieCommand = new CreateMovieCommand();
            _deleteMovieCommand = new DeleteMovieCommand();
            _getAllMoviesQuery = new GetAllMoviesQuery();
            _searchMoviesQuery = new SearchMoviesQuery();
            _editMovieCommand = new EditMovieCommand();
        }

        [HttpGet]
        [Route("get-all")]
        public List<Movie> GetAllMovies()
        {
            return _getAllMoviesQuery.Execute();
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult DeleteMovie(int id)
        {
            _deleteMovieCommand.Execute(id);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            _createMovieCommand.Execute(movie);
            return Ok();
        }

        [HttpGet]
        [Route("search")]
        public List<Movie> SearchMovies(string searchText, [FromUri] List<string> searchBy)
        {
            return _searchMoviesQuery.Execute(searchText, searchBy);
        }

        [HttpPost]
        [Route("edit")]
        public IHttpActionResult EditMovie(Movie changedMovie)
        {
            _editMovieCommand.Execute(changedMovie);
            return Ok();
        }
    }
}
