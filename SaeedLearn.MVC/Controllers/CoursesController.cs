using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Requests.Queries;
using SaeedLearn.MVC.Contracts;

namespace SaeedLearn.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICourseService _courseService;

        public CoursesController(IMediator mediator, ICourseService courseService)
        {
            _mediator = mediator;
            _courseService = courseService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> CourseDetails(int id)
        {
            var t = await _courseService.GetAll();
            var course = await _mediator.Send(new GetCourseDetailRequest() { Id = id });
            return View(course);
        }
        
    }
}
