using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Data;
using FinalTask.Data.Models;

namespace FinalTask.Domain.Queries
{
    public class GetAllMoviesQuery
    {
        private readonly MovieAppContext _context;

        public GetAllMoviesQuery()
        {
            _context = new MovieAppContext();
        }

        public List<Movie> Execute()
        {
            return _context.Movies.ToList();
        }
    }
}
