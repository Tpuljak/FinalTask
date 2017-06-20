using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Commands
{
    public class CreateHashtagCommand
    {
        private readonly MovieAppContext _context;

        public CreateHashtagCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(Hashtag hashtag)
        {
            _context.Hashtags.Add(hashtag);
            _context.SaveChanges();
        }
    }
}
