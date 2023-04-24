using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatorio")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "O campo {0} é invalido")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual List<BookAuthor>? BookAuthor { get; set; }
    }
}
