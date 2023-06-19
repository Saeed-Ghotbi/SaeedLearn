using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Domain;

namespace SaeedLearn.Application.Contracts.Persistence
{
    public interface ICourseRepository : IGenericRepository<Course> {
        public Task<List<Course>> GetCardList();
        public Task<List<Course>> GetCourseList();
        public Task<Course> GetCourse(int id);
    }
}
