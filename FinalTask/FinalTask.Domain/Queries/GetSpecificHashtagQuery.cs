using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetSpecificHashtagQuery
    {
        private readonly MovieAppContext _context;

        public GetSpecificHashtagQuery()
        {
            _context = new MovieAppContext();
        }

        public Hashtag Execute(int id)
        {
            return _context.Hashtags.Find(id);
        }
    }
}
