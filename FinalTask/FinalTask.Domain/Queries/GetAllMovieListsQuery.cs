using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetAllMovieListsQuery
    {
        private readonly MovieAppContext _context;

        public GetAllMovieListsQuery()
        {
            _context = new MovieAppContext();
        }

        public List<MovieList> Execute()
        {
            return _context.MovieLists.ToList();
        }
    }
}
