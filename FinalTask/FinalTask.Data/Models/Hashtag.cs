﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FinalTask.Data.Models
{
    public class Hashtag
    {
        public Hashtag()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
