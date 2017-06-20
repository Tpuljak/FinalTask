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
    [RoutePrefix("hashtags")]
    public class HashtagsController : ApiController
    {
        private readonly CreateHashtagCommand _createHashtagCommand;
        private readonly GetAllHashtagsQuery _getAllHashtagsQuery;
        private readonly GetSpecificHashtagQuery _getSpecificHashtagQuery;

        public HashtagsController()
        {
            _createHashtagCommand = new CreateHashtagCommand();
            _getAllHashtagsQuery = new GetAllHashtagsQuery();
            _getSpecificHashtagQuery = new GetSpecificHashtagQuery();
        }

        [HttpGet]
        [Route("get-all")]
        public List<Hashtag> GetAllHashtags()
        {
            return _getAllHashtagsQuery.Execute();
        }

        [HttpGet]
        [Route("get")]
        public Hashtag GetSpecificHashtag(int id)
        {
            return _getSpecificHashtagQuery.Execute(id);
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
