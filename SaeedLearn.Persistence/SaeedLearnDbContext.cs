using Microsoft.EntityFrameworkCore;
using SaeedLearn.Domain;
using SaeedLearn.Persistence.Configurations.RelationShips;
using SaeedLearn.Persistence.Configurations.SeedData;

namespace SaeedLearn.Persistence
{
    public class SaeedLearnDbContext : DbContext
    {
        public SaeedLearnDbContext(DbContextOptions<SaeedLearnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CourseSeedData courseConfiguration = new CourseSeedData();
            CategorySeedData categoryConfiguration = new CategorySeedData();
            TeacherSeedData teacherConfiguration = new TeacherSeedData();
            EntityRelationShip entityRelation = new EntityRelationShip(modelBuilder);

            courseConfiguration.Configure(modelBuilder.Entity<Course>());
            categoryConfiguration.Configure(modelBuilder.Entity<Category>());
            teacherConfiguration.Configure(modelBuilder.Entity<Teacher>());
            entityRelation.Configure();
          
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
