using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaeedLearn.Domain;

namespace SaeedLearn.Application.Contracts.Persistence
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetCourseById(int id);

    }
}
