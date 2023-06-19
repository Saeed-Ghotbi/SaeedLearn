using Microsoft.EntityFrameworkCore;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly SaeedLearnDbContext _dbContext;
        public CourseRepository(SaeedLearnDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Course>> GetCardList()
        {
            return await _dbContext.Courses
                .Include(c => c.Teacher)
                .Include(c => c.CourseCategories)
                .ToListAsync();
        }

        public async Task<List<Course>> GetCourseList()
        {
            return await _dbContext.Courses
                .Include(c => c.CourseCategories)
                .ThenInclude(cc => cc.Category)
                .Include(c => c.Teacher)
                .ToListAsync();
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _dbContext.Courses
                .Include(c => c.CourseCategories)
                .ThenInclude(cc => cc.Category)
                .Include(c => c.Teacher)
                .Where(c=>c.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}
