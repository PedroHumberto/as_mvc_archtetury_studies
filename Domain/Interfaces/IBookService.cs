using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBookService
    {
        void AddBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        void DeleteBook(Guid id);

    }
}
