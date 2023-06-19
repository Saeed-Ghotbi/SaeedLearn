using Microsoft.EntityFrameworkCore;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Repositories
{
    public class CourseCategoryRepository : GenericRepository<CourseCategory>, ICourseCategoryRepository
    {
        private readonly SaeedLearnDbContext _dbContext;
        public CourseCategoryRepository(SaeedLearnDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

      
    }
}
