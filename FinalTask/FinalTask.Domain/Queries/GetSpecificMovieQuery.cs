using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetSpecificMovieQuery
    {
        private readonly MovieAppContext _context;

        public GetSpecificMovieQuery()
        {
            _context = new MovieAppContext();
        }

        public Movie Execute(int id)
        {
            return _context.Movies.Find(id);
        }
    }
}
