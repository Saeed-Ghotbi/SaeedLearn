using SaeedLearn.MVC.Contracts;
using SaeedLearn.MVC.Models.Admin;
using SaeedLearn.MVC.Services.Base;

namespace SaeedLearn.MVC.Services
{
    public class CourseService : ICourseService
    {
        private readonly IClient _client;

        public CourseService(IClient client)
        {
            _client = client;
        }
        public async Task<Response<CourseViewModel>> GetAll()
        {
            var response = new Response<CourseViewModel>();

            var t = await _client.CourseGetAll();
            
            return response;
        }
    }
}
