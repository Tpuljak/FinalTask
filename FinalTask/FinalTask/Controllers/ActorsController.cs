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
    [RoutePrefix("actors")]
    public class ActorsController : ApiController
    {
        private readonly CreateActorCommand _createActorCommand;
        private readonly GetAllActorsQuery _getAllActorsQuery;
        private readonly GetSpecificActorQuery _getSpecificActorQuery;

        public ActorsController()
        {
            _createActorCommand = new CreateActorCommand();
            _getAllActorsQuery = new GetAllActorsQuery();
            _getSpecificActorQuery = new GetSpecificActorQuery();
        }

        [HttpGet]
        [Route("get-all")]
        public List<Actor> GetAllActors()
        {
            return _getAllActorsQuery.Execute();
        }

        [HttpGet]
        [Route("get")]
        public Actor GetSpecificActor(int id)
        {
            return _getSpecificActorQuery.Execute(id);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateActor(Actor actor)
        {
            _createActorCommand.Execute(actor);
            return Ok();
        }
    }
}
