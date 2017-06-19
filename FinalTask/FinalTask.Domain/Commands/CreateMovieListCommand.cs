using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Commands
{
    public class CreateMovieListCommand
    {
        private readonly MovieAppContext _context;

        public CreateMovieListCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(MovieList movieList)
        {
            _context.MovieLists.Add(movieList);
            _context.SaveChanges();
        }
    }
}
