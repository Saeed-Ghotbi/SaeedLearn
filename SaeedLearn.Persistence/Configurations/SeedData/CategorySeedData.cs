using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Configurations.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = 1,
                Name = "طراحی وب",
                DateCreated = DateTime.Now,

            }, new Category
            {
                Id = 2,
                Name = "فرانت اند",
                DateCreated = DateTime.Now,
            }, new Category

            {
                Id = 3,
                Name = "بک اند",
                DateCreated = DateTime.Now,
            }, new Category
            {
                Id = 4,
                Name = "هوش مصنوعی",
                DateCreated = DateTime.Now,
            });
        }
    }
}
