using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.DTO
{
    public class MovieListForMovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static MovieListForMovieDTO FromMovieList(MovieList movieList)
        {
            return new MovieListForMovieDTO()
            {
                Id = movieList.Id,
                Name = movieList.Name
            };
        }
    }
}
