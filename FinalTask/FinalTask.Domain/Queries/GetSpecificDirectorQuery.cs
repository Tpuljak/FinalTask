using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetSpecificDirectorQuery
    {
        private readonly MovieAppContext _context;

        public GetSpecificDirectorQuery()
        {
            _context = new MovieAppContext();
        }

        public Director Execute(int id)
        {
            return _context.Directors.Find(id);
        }
    }
}
