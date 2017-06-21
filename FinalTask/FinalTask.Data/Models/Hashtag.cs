using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
