using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Commands
{
    public class CreateGenreCommand
    {
        private readonly MovieAppContext _context;

        public CreateGenreCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
}
