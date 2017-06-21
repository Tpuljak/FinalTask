﻿using FinalTask.Data;
using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetSpecificMovieListQuery
    {
        private readonly MovieAppContext _context;

        public GetSpecificMovieListQuery()
        {
            _context = new MovieAppContext();
        }

        public MovieList Execute(int id)
        {
            return _context.MovieLists.Find(id);
        }
    }
}