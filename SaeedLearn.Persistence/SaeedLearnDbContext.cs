using Microsoft.EntityFrameworkCore;
using SaeedLearn.Domain;
using SaeedLearn.Persistence.Configurations.Entities;

namespace SaeedLearn.Persistence
{
    public class SaeedLearnDbContext : DbContext
    {
        public SaeedLearnDbContext(DbContextOptions<SaeedLearnDbContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CourseConfiguration configuration = new CourseConfiguration();

            configuration.Configure(modelBuilder.Entity<Course>());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Category> Categories { get; set; }

    }
}
