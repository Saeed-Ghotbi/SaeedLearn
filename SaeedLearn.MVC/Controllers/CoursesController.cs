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

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> CourseDetails(int id)
        {
            var course = await _mediator.Send(new GetCourseDetailRequest() { Id = id });
            return View(course);
        }
        
    }
}
