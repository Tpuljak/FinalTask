using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetSpecificGenreQuery
    {
        private readonly MovieAppContext _context;

        public GetSpecificGenreQuery()
        {
            _context = new MovieAppContext();
        }

        public Genre Execute(int id)
        {
            return _context.Genres.Find(id);
        }
    }
}
