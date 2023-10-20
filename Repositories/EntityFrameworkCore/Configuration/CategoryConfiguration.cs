using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFrameworkCore.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryName).IsRequired();

            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Computer Science"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Network"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Database Management Systems"
                }
                );

            builder.HasIndex(indexExpression: c=>c.CategoryName,name:"UK_Categories_Name").IsUnique();
            //builder.HasMany(c => c.Books);
        }
    }
}
