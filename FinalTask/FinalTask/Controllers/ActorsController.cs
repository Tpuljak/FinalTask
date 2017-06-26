using FinalTask.Data.Models;
using FinalTask.Domain.Commands;
using FinalTask.Domain.Queries;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalTask.Controllers
{
    [RoutePrefix("actors")]
    public class ActorsController : ApiController
    {
        private readonly CreateActorCommand _createActorCommand;
        private readonly GetAllActorsQuery _getAllActorsQuery;

        public ActorsController()
        {
            _createActorCommand = new CreateActorCommand();
            _getAllActorsQuery = new GetAllActorsQuery();
        }

        [HttpGet]
        [Route("get-all")]
        public List<Actor> GetAllActors()
        {
            return _getAllActorsQuery.Execute();
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
