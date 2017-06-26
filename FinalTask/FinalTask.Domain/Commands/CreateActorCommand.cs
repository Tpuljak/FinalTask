using FinalTask.Data;
using FinalTask.Data.Models;

namespace FinalTask.Domain.Commands
{
    public class CreateActorCommand
    {
        private readonly MovieAppContext _context;

        public CreateActorCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
    }
}
