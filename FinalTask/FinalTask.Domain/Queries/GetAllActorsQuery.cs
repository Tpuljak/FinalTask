using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
