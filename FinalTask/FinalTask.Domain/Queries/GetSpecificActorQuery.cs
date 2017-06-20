using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetSpecificActorQuery
    {
        private readonly MovieAppContext _context;

        public GetSpecificActorQuery()
        {
            _context = new MovieAppContext();
        }

        public Actor Execute(int id)
        {
            return _context.Actors.Find(id);
        }
    }
}
