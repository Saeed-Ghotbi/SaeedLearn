using Microsoft.EntityFrameworkCore;
using SaeedLearn.Domain;

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
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Category> Categories { get; set; }

    }
}
