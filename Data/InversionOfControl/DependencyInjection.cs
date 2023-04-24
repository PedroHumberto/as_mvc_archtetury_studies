
using Data.Service.AuthorService;
using Data.Service.BooksService;
using Data.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Data.InversionofControl
{
    public class DependencyInjection
    {
        public static void Inject(IServiceCollection services, ConfigurationManager configuration)
        {
            //DbContext
            services.AddDbContext<BookStoreDbContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("BookStoreConnection"))); ;

            //Interfaces Injections
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
