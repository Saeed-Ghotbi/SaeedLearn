using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaeedLearn.Application.Features.Course.Requests.Queries;

namespace SaeedLearn.MVC.ViewComponent
{
    public class ListCardCourseViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IMediator _mediator;

        public ListCardCourseViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _mediator.Send(new GetCardCourseListRequest());

            return View(list);
        }
    }
}
