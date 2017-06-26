using FinalTask.Data;
using FinalTask.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.Domain.Queries
{
    public class GetAllGenresQuery
    {
        private readonly MovieAppContext _context;

        public GetAllGenresQuery()
        {
            _context = new MovieAppContext();
        }

        public List<Genre> Execute()
        {
            return _context.Genres.ToList();
        }
    }
}
