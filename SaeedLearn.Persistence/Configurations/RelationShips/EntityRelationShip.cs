using Microsoft.EntityFrameworkCore;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Configurations.RelationShips
{
    public class EntityRelationShip
    {
        private readonly ModelBuilder _modelBuilder;
        public EntityRelationShip(ModelBuilder model)
        {
            _modelBuilder = model;
        }
        public void Configure()
        {
            _modelBuilder.Entity<Course>(c =>
            {
                c.HasOne<Teacher>(course => course.Teacher)
                    .WithMany(t => t.Courses)
                    .HasForeignKey(course => course.TeacherId);
            });

            _modelBuilder.Entity<CourseCategory>(cc =>
            {
                cc.HasOne<Course>(courseCategory => courseCategory.Course)
                    .WithMany(c => c.CourseCategories)
                    .HasForeignKey(courseCategory => courseCategory.CourseId);
            });

            _modelBuilder.Entity<CourseCategory>(cc =>
            {
                cc.HasOne<Category>(courseCategory => courseCategory.Category)
                    .WithMany(c => c.CourseCategories)
                    .HasForeignKey(courseCategory => courseCategory.CategoryId);
            });

        }
    }
}
