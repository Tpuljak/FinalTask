using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;
using System.Linq;

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
