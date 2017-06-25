using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            Hashtags = new HashSet<Hashtag>();
            Actors = new HashSet<Actor>();
            MovieLists = new HashSet<MovieList>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Hashtag> Hashtags { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }

        public virtual ICollection<MovieList> MovieLists { get; set; }
    }
}
