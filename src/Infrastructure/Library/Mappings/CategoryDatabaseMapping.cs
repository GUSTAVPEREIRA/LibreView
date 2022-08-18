using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library.Mappings;

public class CategoryDatabaseMapping : IMappings
{
    public void Mapping(ref ModelBuilder builder)
    {
        builder.Entity<Category>().ToTable("categories");
        builder.Entity<Category>().HasKey(x => x.Id);
        builder.Entity<Category>().Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Entity<Category>().Property(x => x.Description).HasMaxLength(500).IsRequired(false);
    }
}