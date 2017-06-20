using FinalTask.Data.Models;
using FinalTask.Domain.Commands;
using FinalTask.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalTask.Controllers
{
    [RoutePrefix("genres")]
    public class GenresController : ApiController
    {
        private readonly CreateGenreCommand _createGenreCommand;
        private readonly GetAllGenresQuery _getAllGenresQuery;
        private readonly GetSpecificGenreQuery _getSpecificGenreQuery;

        public GenresController()
        {
            _createGenreCommand = new CreateGenreCommand();
            _getAllGenresQuery = new GetAllGenresQuery();
            _getSpecificGenreQuery = new GetSpecificGenreQuery();
        }
        
        [HttpGet]
        [Route("get-all")]
        public List<Genre> GetAllGenres()
        {
            return _getAllGenresQuery.Execute();
        }

        [HttpGet]
        [Route("get")]
        public Genre GetSpecificGenre(int id)
        {
            return _getSpecificGenreQuery.Execute(id);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateGenre(Genre genre)
        {
            _createGenreCommand.Execute(genre);
            return Ok();
        }
    }
}
