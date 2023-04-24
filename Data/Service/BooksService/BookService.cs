using Data.Service.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace Data.Service.BooksService
{
    public class BookService : IBookService
    {
        private readonly BookStoreDbContext _context;

        public BookService(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddBook(Book book)
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

        public async Task AddAuthorToBook(Guid bookId, Guid authorId)
        {
            var bookAuhor = new BookAuthor() { BookId = bookId, AuthorId = authorId};
            await _context.BookAuthors.AddAsync(bookAuhor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (book == null)
            {
                throw new Exception($"There's no book with Id:{id}");
            }
            _context.Remove(book);
            await _context.SaveChangesAsync();
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

        public async Task<Book> UpdateBook(Book newBook, Guid id)
        {
            var oldBook = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);

            //usar mapper aqui
            oldBook.BookAuthor = newBook.BookAuthor;
            oldBook.ISBN = newBook.ISBN;
            oldBook.Year = newBook.Year;
            oldBook.Title = newBook.Title;

            await _context.SaveChangesAsync();

            return newBook;
        }

        public async Task<List<BookAuthor>> GetAllBookAuthor()
        {
            var bookAuthor = await _context.BookAuthors.ToListAsync();

            return bookAuthor;
        }

        public async Task<BookAuthor> GetBookAuthorById(Guid id)
        {
            var bookAuthor = await _context.BookAuthors.FirstOrDefaultAsync(b => b.BookId == id);

            if(bookAuthor == null)
            {
                return new BookAuthor();
            }

            return bookAuthor;
        }
    }
}
