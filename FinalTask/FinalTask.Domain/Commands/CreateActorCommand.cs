using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
