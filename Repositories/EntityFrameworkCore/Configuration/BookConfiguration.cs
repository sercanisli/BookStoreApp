using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFrameworkCore.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books").HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.HasData(
                new Book { Id = 1, CategoryId = 1, Title = "Karagöz ve Hacivat", Price = 75 },
                new Book { Id = 2, CategoryId = 3, Title = "Hamlet", Price = 5 },
                new Book { Id = 3, CategoryId = 4, Title = "Mesnevi", Price = 100 },
                new Book { Id = 4, CategoryId = 2, Title = "Araba Sevdası", Price = 15 },
                new Book { Id = 5, CategoryId = 2, Title = "Kaşağı", Price = 55 },
                new Book { Id = 6, CategoryId = 7, Title = "Uçurtma Avcısı", Price = 150 },
                new Book { Id = 7, CategoryId = 6, Title = "Ateşten Gömlek", Price = 100 },
                new Book { Id = 8, CategoryId = 7, Title = "Çalukuşu", Price = 90 },
                new Book { Id = 9, CategoryId = 3, Title = "Tutunamayanlar", Price = 45 },
                new Book { Id = 10, CategoryId = 3, Title = "Nutuk", Price = 10000 }
            );

            builder.HasOne(b => b.Category);
        }
    }
}
