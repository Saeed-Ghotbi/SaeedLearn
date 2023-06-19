using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using SaeedLearn.Application.DTOs.Category;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.DTOs.Teacher;
using SaeedLearn.Application.Features.Category.Requests.Queries;
using SaeedLearn.Application.Features.Course.Requests.Command;
using SaeedLearn.Application.Features.Course.Requests.Queries;
using SaeedLearn.Application.Features.Teacher.Requests.Queries;
using SaeedLearn.Domain;
using SaeedLearn.MVC.Models.Admin;
using SaeedLearn.MVC.Utilities;

namespace SaeedLearn.MVC.Pages.Admin.Course
{
    public class UpdateModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [BindProperty] public CourseViewModel Course { get; set; }
        public List<TeacherDto> Teachers { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var id = Convert.ToInt32(RouteData.Values["id"]);

            var course = await _mediator.Send(new GetCourseDetailRequest() { Id = id });
            if (course != null)
            {
                Course = _mapper.Map<CourseViewModel>(course);
            }

            Teachers = await _mediator.Send(new GetTeacherListRequest());
            Categories = await _mediator.Send(new GetCategoryListRequest());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var updateCourseDto = _mapper.Map<UpdateCourseDto>(Course);
                if (Course.Picture != null)
                {
                    if (!updateCourseDto.PicturePath.IsNullOrEmpty())
                    {
                        System.IO.File.Delete(updateCourseDto.PicturePath);
                    }
                    var guid = Guid.NewGuid().ToString();
                    updateCourseDto.PicturePath = "/images/Uploads/300x150/" + guid + Path.GetExtension(Course.Picture.FileName);
                    Course.Picture.UploadImage(guid);
                }

                await _mediator.Send(new UpdateCourseRequest() { UpdateCourseDto = updateCourseDto });
            }

            return RedirectToPage();
        }
    }
}
