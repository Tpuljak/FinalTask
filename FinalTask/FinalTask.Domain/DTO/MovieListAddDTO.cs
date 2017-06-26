using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.DTO
{
    public class MovieListAddDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }

        public MovieListAddDTO()
        {
            Movies = new List<Movie>();
        }

        public static MovieList ToMovieList(MovieListAddDTO movieListDTO)
        {
            return new MovieList()
            {
                Id = movieListDTO.Id,
                Name = movieListDTO.Name,
                Movies = movieListDTO.Movies
            };
        }
    }
}
