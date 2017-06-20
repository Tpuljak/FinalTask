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
    [RoutePrefix("directors")]
    public class DirectorsController : ApiController
    {
        private readonly CreateDirectorCommand _createDirectorCommand;
        private readonly GetAllDirectorsQuery _getAllDirectorsQuery;
        private readonly GetSpecificDirectorQuery _getSpecificDirectorQuery;

        public DirectorsController()
        {
            _createDirectorCommand = new CreateDirectorCommand();
            _getAllDirectorsQuery = new GetAllDirectorsQuery();
            _getSpecificDirectorQuery = new GetSpecificDirectorQuery();
        }

        [HttpGet]
        [Route("get-all")]
        public List<Director> GetAllDirectors()
        {
            return _getAllDirectorsQuery.Execute();
        }

        [HttpGet]
        [Route("get")]
        public Director GetSpecificDirector(int id)
        {
            return _getSpecificDirectorQuery.Execute(id);
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
