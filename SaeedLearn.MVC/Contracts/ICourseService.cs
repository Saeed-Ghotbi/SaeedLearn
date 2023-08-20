using SaeedLearn.MVC.Models.Admin;
using SaeedLearn.MVC.Services.Base;

namespace SaeedLearn.MVC.Contracts
{
    public interface ICourseService
    {
        public Task<Response<CourseViewModel>> GetAll();
    }
}
