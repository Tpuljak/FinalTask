using FinalTask.Data.Models;
using FinalTask.Domain.Commands;
using FinalTask.Domain.Queries;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalTask.Controllers
{
    [RoutePrefix("hashtags")]
    public class HashtagsController : ApiController
    {
        private readonly CreateHashtagCommand _createHashtagCommand;
        private readonly GetAllHashtagsQuery _getAllHashtagsQuery;

        public HashtagsController()
        {
            _createHashtagCommand = new CreateHashtagCommand();
            _getAllHashtagsQuery = new GetAllHashtagsQuery();
        }

        [HttpGet]
        [Route("get-all")]
        public List<Hashtag> GetAllHashtags()
        {
            return _getAllHashtagsQuery.Execute();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateHashtag(Hashtag hashtag)
        {
            _createHashtagCommand.Execute(hashtag);
            return Ok();
        }
    }
}
