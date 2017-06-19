using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Commands
{
    public class CreateMovieCommand
    {
        private readonly MovieAppContext _context;

        public CreateMovieCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}
