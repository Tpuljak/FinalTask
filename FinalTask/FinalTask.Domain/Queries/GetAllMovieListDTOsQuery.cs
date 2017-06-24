using FinalTask.Data;
using FinalTask.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.Queries
{
    public class GetAllMovieListDTOsQuery
    {
        private readonly MovieAppContext _context;

        public GetAllMovieListDTOsQuery()
        {
            _context = new MovieAppContext();
        }

        public List<MovieListForMovieDTO> Execute()
        {
            List<MovieListForMovieDTO> movieListDTOs = new List<MovieListForMovieDTO>();
            foreach (var movieList in _context.MovieLists.ToList())
            {
                movieListDTOs.Add(MovieListForMovieDTO.FromMovieList(movieList));
            }

            return movieListDTOs;
        }
    }
}
