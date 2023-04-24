using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookAuthor
    {
        public Guid AuthorId { get; set; }
        [JsonIgnore]
        public virtual Author? Author { get; set; }
        public Guid BookId { get; set; }
        [JsonIgnore]
        public virtual Book? Book { get; set; }
    }
}
