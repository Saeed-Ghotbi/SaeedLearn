using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Configurations.SeedData
{
    public class TeacherSeedData : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData(new Teacher
            {
                Id = 1,
                CourseId = 1,
                Name = "سعید قطبی",
                DateCreated = DateTime.Now,

            }, new Teacher
            {
                Id = 2,
                CourseId =  2,
                Name = "محسن نیری",
                DateCreated = DateTime.Now,
            });
        }
    }
}
