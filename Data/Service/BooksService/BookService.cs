using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Data.Service.BooksService
{
    public class BookService : IBookService
    {
        private readonly BookStoreDbContext _context;
        public async void AddBook(Book book)
        {
            try
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public async void DeleteBook(Guid id)
        {
            var Book = _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (Book == null)
            {
                throw new Exception($"There's no book with Id:{id}");
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();

            return books;

        }

        public async Task<Book> GetBookById(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (book == null)
            {
                throw new Exception($"There's no book with Id:{id}");
            }

            return book;
        }
    }
}
