using FinalTask.Data.Models;
using FinalTask.Domain.Commands;
using FinalTask.Domain.DTO;
using FinalTask.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalTask.Controllers
{
    [RoutePrefix("movieLists")]
    public class MovieListsController : ApiController
    {
        private readonly CreateMovieListCommand _createMovieListCommand;
        private readonly DeleteMovieListCommand _deleteMovieListCommand;
        private readonly GetAllMovieListsQuery _getAllMovieListsQuery;
        private readonly GetSpecificMovieListQuery _getSpecificMovieListQuery;
        private readonly GetAllMovieListDTOsQuery _getAllMovieListDTOsQuery;
        private readonly EditMovieListCommand _editMovieListCommand;

        public MovieListsController()
        {
            _createMovieListCommand = new CreateMovieListCommand();
            _deleteMovieListCommand = new DeleteMovieListCommand();
            _getAllMovieListsQuery = new GetAllMovieListsQuery();
            _getSpecificMovieListQuery = new GetSpecificMovieListQuery();
            _getAllMovieListDTOsQuery = new GetAllMovieListDTOsQuery();
            _editMovieListCommand = new EditMovieListCommand();
        }

        [HttpGet]
        [Route("get-all")]
        public List<MovieList> GetAllMovieLists()
        {
            return _getAllMovieListsQuery.Execute();
        }

        [HttpGet]
        [Route("get")]
        public MovieList GetSpecificMovieList(int id)
        {
            return _getSpecificMovieListQuery.Execute(id);
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult DeleteMovieList(int id)
        {
            _deleteMovieListCommand.Execute(id);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateMovieList(MovieListAddDTO movieListDTO)
        {
            MovieList movieList = MovieListAddDTO.ToMovieList(movieListDTO);
            _createMovieListCommand.Execute(movieList);
            return Ok();
        }

        [HttpGet]
        [Route("get-dto")]
        public List<MovieListForMovieDTO> GetAllMovieListDTOs()
        {
            return _getAllMovieListDTOsQuery.Execute();
        }

        [HttpPost]
        [Route("edit")]
        public IHttpActionResult EditMovieList(MovieListAddDTO changedMovieList)
        {
            MovieList movieList = MovieListAddDTO.ToMovieList(changedMovieList);
            _editMovieListCommand.Execute(movieList);

            return Ok();
        }
    }
}
