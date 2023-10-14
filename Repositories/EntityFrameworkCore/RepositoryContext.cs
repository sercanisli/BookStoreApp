﻿using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFrameworkCore.Configuration;

namespace Repositories.EntityFrameworkCore
{
    public class RepositoryContext:IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
