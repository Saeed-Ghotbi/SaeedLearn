using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Requests.Queries;

namespace SaeedLearn.MVC.Pages.Admin.Course
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public List<CourseDto> CourseList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            CourseList = await _mediator.Send(new GetCourseListRequest());

            return Page();
        }

    }
}
