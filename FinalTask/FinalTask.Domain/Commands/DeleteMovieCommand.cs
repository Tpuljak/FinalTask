using FinalTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Commands
{
    public class DeleteMovieCommand
    {
        private readonly MovieAppContext _context;

        public DeleteMovieCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(int id)
        {
            var movieToDelete = _context.Movies.Find(id);
            if (movieToDelete != null)
                _context.Movies.Remove(movieToDelete);

            _context.SaveChanges();
        }
    }
}
