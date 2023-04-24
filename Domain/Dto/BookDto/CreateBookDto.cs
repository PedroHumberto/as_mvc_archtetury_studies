using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.BookDto
{
    public class CreateBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public virtual List<BookAuthor>? BookAuthor { get; set; }
        public Guid AuthorId { get; set; }
    }
}
