using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.Domain.Queries
{
    public class GetAllActorsQuery
    {
        private readonly MovieAppContext _context;

        public GetAllActorsQuery()
        {
            _context = new MovieAppContext();
        }

        public List<Actor> Execute()
        {
            return _context.Actors.ToList();
        }
    }
}
