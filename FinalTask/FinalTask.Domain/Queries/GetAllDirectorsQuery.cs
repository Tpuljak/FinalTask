using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.Domain.Queries
{
    public class GetAllDirectorsQuery
    {
        private readonly MovieAppContext _context;

        public GetAllDirectorsQuery()
        {
            _context = new MovieAppContext();
        }

        public List<Director> Execute()
        {
            return _context.Directors.ToList();
        }
    }
}
