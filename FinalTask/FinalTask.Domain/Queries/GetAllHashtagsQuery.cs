using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.Domain.Queries
{
    public class GetAllHashtagsQuery
    {
        private readonly MovieAppContext _context;

        public GetAllHashtagsQuery()
        {
            _context = new MovieAppContext();
        }

        public List<Hashtag> Execute()
        {
            return _context.Hashtags.ToList();
        }
    }
}
