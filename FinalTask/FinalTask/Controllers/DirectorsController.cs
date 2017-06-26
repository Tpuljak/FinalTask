using FinalTask.Data.Models;
using FinalTask.Domain.Commands;
using FinalTask.Domain.Queries;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalTask.Controllers
{
    [RoutePrefix("directors")]
    public class DirectorsController : ApiController
    {
        private readonly CreateDirectorCommand _createDirectorCommand;
        private readonly GetAllDirectorsQuery _getAllDirectorsQuery;

        public DirectorsController()
        {
            _createDirectorCommand = new CreateDirectorCommand();
            _getAllDirectorsQuery = new GetAllDirectorsQuery();
        }

        [HttpGet]
        [Route("get-all")]
        public List<Director> GetAllDirectors()
        {
            return _getAllDirectorsQuery.Execute();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateDirector(Director director)
        {
            _createDirectorCommand.Execute(director);
            return Ok();
        }
    }
}
