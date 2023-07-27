using BookStoreWebApi.Models;
using BookStoreWebApi.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Repositories.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        { 
            
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
