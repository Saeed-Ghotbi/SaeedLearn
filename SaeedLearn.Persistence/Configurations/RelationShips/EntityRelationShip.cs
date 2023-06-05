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
                    c.HasOne<Teacher>(t => t.Teacher)
                        .WithOne(t => t.Course)
                        .HasForeignKey<Teacher>(t => t.Id);
                }
            );
        }
    }
}
