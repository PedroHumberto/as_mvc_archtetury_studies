using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public int Year { get; set; }
        public virtual List<BookAuthor>? BookAuthor { get; set; }
    }
}
