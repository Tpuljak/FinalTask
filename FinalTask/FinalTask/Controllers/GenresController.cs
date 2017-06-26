using FinalTask.Data.Models;
using FinalTask.Domain.Commands;
using FinalTask.Domain.Queries;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalTask.Controllers
{
    [RoutePrefix("genres")]
    public class GenresController : ApiController
    {
        private readonly CreateGenreCommand _createGenreCommand;
        private readonly GetAllGenresQuery _getAllGenresQuery;

        public GenresController()
        {
            _createGenreCommand = new CreateGenreCommand();
            _getAllGenresQuery = new GetAllGenresQuery();
        }
        
        [HttpGet]
        [Route("get-all")]
        public List<Genre> GetAllGenres()
        {
            return _getAllGenresQuery.Execute();
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
