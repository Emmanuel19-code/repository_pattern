using Microsoft.EntityFrameworkCore;
using repositorypattern.Domain.Entity;

namespace repositorypattern.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }
        public DbSet<Author> Authors {get;set;}
        public DbSet<Book> Books {get;set;}

    }
}