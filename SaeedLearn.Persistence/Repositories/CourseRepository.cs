using Microsoft.EntityFrameworkCore;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Repositories
{
    public class CourseRepository : GenericRepository<Course> , ICourseRepository {
        private readonly SaeedLearnDbContext _dbContext;
        public CourseRepository(SaeedLearnDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Course>> GetListCard()
        {
           return await _dbContext.Courses.Include(c => c.Teacher).ToListAsync();
        }
    }
}
