using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasMany(book => book.Author)
                .WithMany(author => author.Books);                
        } 

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}