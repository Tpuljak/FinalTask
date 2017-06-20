using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Commands
{
    public class CreateDirectorCommand
    {
        private readonly MovieAppContext _context;

        public CreateDirectorCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();
        }
    }
}
