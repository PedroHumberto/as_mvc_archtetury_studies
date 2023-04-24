using Data.Service.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Service.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreDbContext _context;

        public AuthorService(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthor(Author author)
        {
            try
            {
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAuthor(Guid id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null)
            {
                throw new Exception($"There's no book with Id:{id}");
            }
            _context.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var authorsList = await _context.Authors.ToListAsync();

            return authorsList;
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null)
            {
                throw new Exception($"There's no book with Id:{id}");
            }

            return author;
        }

        public async Task<BookAuthor> GetBooksFromAuthor(Guid id)
        {
            var booksFromAuthor = await _context.BookAuthors.FirstOrDefaultAsync(a => a.AuthorId == id);

            if (booksFromAuthor == null)
            {
                return new BookAuthor();
            }
            
            return booksFromAuthor;
        }

        public async Task<Author> UpdateAuthor(Author newAuthor, Guid id)
        {
            var oldAuthor = await _context.Authors.FirstOrDefaultAsync(book => book.Id == id);

            //usar mapper aqui
            oldAuthor.BirthDate = newAuthor.BirthDate;
            oldAuthor.FirstName = newAuthor.FirstName;
            oldAuthor.LastName = newAuthor.LastName;
            oldAuthor.Email = newAuthor.Email;
            oldAuthor.BookAuthor = newAuthor.BookAuthor;
            
            await _context.SaveChangesAsync();

            return newAuthor;
        }
    }
}
