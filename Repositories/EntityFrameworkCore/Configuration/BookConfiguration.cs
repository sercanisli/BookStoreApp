using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFrameworkCore.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 75 },
                new Book { Id = 2, Title = "Hamlet", Price = 5 },
                new Book { Id = 3, Title = "Mesnevi", Price = 100 },
                new Book { Id = 4, Title = "Araba Sevdası", Price = 15 },
                new Book { Id = 5, Title = "Kaşağı", Price = 55 },
                new Book { Id = 6, Title = "Uçurtma Avcısı", Price = 150 },
                new Book { Id = 7, Title = "Ateşten Gömlek", Price = 100 },
                new Book { Id = 8, Title = "Çalukuşu", Price = 90 },
                new Book { Id = 9, Title = "Tutunamayanlar", Price = 45 },
                new Book { Id = 10, Title = "Nutuk", Price = 10000 }
            );
        }
    }
}
