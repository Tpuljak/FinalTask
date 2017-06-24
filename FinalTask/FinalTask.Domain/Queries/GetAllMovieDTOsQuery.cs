using FinalTask.Data;
using FinalTask.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetAllMovieDTOs
    {
        private readonly MovieAppContext _context;

        public GetAllMovieDTOs()
        {
            _context = new MovieAppContext();
        }

        public List<MovieForMovieListDTO> Execute()
        {
            List<MovieForMovieListDTO> movieDTOs = new List<MovieForMovieListDTO>();
            foreach (var movie in _context.Movies.ToList())
            {
                movieDTOs.Add(MovieForMovieListDTO.FromMovie(movie));
            }

            return movieDTOs;
        }
    }
}
