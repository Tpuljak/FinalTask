using FinalTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Domain.DTO
{
    public class MovieForMovieListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static MovieForMovieListDTO FromMovie(Movie movie)
        {
            return new MovieForMovieListDTO()
            {
                Id = movie.Id,
                Name = movie.Name
            };
        }
    }
}
