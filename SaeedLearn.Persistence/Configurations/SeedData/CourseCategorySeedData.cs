using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Configurations.SeedData
{
    public class CourseCategorySeedData : IEntityTypeConfiguration<CourseCategory>
    {
        public void Configure(EntityTypeBuilder<CourseCategory> builder)
        {
            builder.HasData(new CourseCategory
            {
                CourseId = 1,
                CategoryId = 1
            }, new CourseCategory
            {
                CourseId = 2,
                CategoryId = 2
            });
        }
    }
}
