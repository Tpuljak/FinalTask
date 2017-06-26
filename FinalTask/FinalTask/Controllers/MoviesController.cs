using FinalTask.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalTask.Domain.Queries;
using FinalTask.Data.Models;
using FinalTask.Domain.DTO;

namespace FinalTask.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : ApiController
    {
        private readonly CreateMovieCommand _createMovieCommand;
        private readonly DeleteMovieCommand _deleteMovieCommand;
        private readonly GetAllMoviesQuery _getAllMoviesQuery;
        private readonly GetSpecificMovieQuery _getSpecificMovieQuery;
        private readonly SearchMoviesQuery _searchMoviesQuery;
        private readonly GetAllMovieDTOsQuery _getAllMovieDTOsQuery;
        private readonly EditMovieCommand _editMovieCommand;

        public MoviesController()
        {
            _createMovieCommand = new CreateMovieCommand();
            _deleteMovieCommand = new DeleteMovieCommand();
            _getAllMoviesQuery = new GetAllMoviesQuery();
            _getSpecificMovieQuery = new GetSpecificMovieQuery();
            _searchMoviesQuery = new SearchMoviesQuery();
            _getAllMovieDTOsQuery = new GetAllMovieDTOsQuery();
            _editMovieCommand = new EditMovieCommand();
        }

        [HttpGet]
        [Route("get-all")]
        public List<Movie> GetAllMovies()
        {
            return _getAllMoviesQuery.Execute();
        }

        [HttpGet]
        [Route("get")]
        public Movie GetSpecificMovie(int id)
        {
            return _getSpecificMovieQuery.Execute(id);
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

        [HttpGet]
        [Route("get-dto")]
        public List<MovieForMovieListDTO> GetAllMovieDTOs()
        {
            return _getAllMovieDTOsQuery.Execute();
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
