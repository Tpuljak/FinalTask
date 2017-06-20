using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
