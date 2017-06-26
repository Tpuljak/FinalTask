using FinalTask.Data;
using FinalTask.Data.Models;

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
