using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaeedLearn.Application.Features.Course.Requests.Command;

namespace SaeedLearn.MVC.Pages.Admin.Course
{
    public class DeleteModel : PageModel
    {
        private readonly IMediator _mediator;

        public DeleteModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var id = RouteData.Values["id"];
            await _mediator.Send(new DeleteCourseRequest(){Id = Convert.ToInt32(id)});
            return RedirectToPage("/Admin/Course/index");
        }
    }
}
