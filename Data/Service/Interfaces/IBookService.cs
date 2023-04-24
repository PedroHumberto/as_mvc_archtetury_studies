using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service.Interfaces
{
    public interface IBookService
    {
        Task AddBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<BookAuthor> GetBookAuthorById(Guid id);
        Task DeleteBook(Guid id);
        Task<Book> UpdateBook(Book newBook, Guid id);
        Task AddAuthorToBook(Guid bookId, Guid authorId);
        Task<List<BookAuthor>> GetAllBookAuthor();

    }
}
