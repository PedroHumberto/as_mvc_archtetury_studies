using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service.Interfaces
{
    public interface IAuthorService
    {
        Task AddAuthor(Author author);
        Task<List<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(Guid id);
        Task<BookAuthor> GetBooksFromAuthor(Guid id);
        Task DeleteAuthor(Guid id);
        Task<Author> UpdateAuthor(Author newAuthor, Guid id);
    }
}
