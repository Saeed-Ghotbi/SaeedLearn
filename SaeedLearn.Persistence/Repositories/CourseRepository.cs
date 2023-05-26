using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Course> GetCourseById(int id)
        { 
           return await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
