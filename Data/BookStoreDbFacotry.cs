using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class BookStoreDbFacotry : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
       
        public BookStoreDbContext CreateDbContext(string[] args)
        {            
            var optionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("BookStoreConnection"));

            return new BookStoreDbContext(optionsBuilder.Options);
        }
    }
}
