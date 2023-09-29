using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Configuration;

namespace Repositories.EntityFrameworkCore
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
