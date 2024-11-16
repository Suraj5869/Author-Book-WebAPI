using AuthorWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Data
{
    public class AuthorContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetail> AuthorDetails { get; set; }
        public DbSet<Book> Books { get; set; }

        public AuthorContext(DbContextOptions<AuthorContext> options):base(options) 
        {
            
        }
    }
}
