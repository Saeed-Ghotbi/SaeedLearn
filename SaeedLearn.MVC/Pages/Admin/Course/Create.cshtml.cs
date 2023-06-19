using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaeedLearn.Application.DTOs.Category;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.DTOs.Teacher;
using SaeedLearn.Application.Features.Category.Requests.Queries;
using SaeedLearn.Application.Features.Course.Requests.Command;
using SaeedLearn.Application.Features.Teacher.Requests.Queries;
using SaeedLearn.MVC.Models.Admin;
using SaeedLearn.MVC.Utilities;

namespace SaeedLearn.MVC.Pages.Admin.Course
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [BindProperty] public CourseViewModel Course { get; set; }
        public List<TeacherDto> Teachers { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public bool IsSuccessful { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {

            Teachers = await _mediator.Send(new GetTeacherListRequest());
            Categories = await _mediator.Send(new GetCategoryListRequest());

            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var guid = Guid.NewGuid().ToString();
                var courseDto = _mapper.Map<CreateCourseDto>(Course);
                courseDto.PicturePath = "/images/Uploads/300x150/" + guid + Path.GetExtension(Course.Picture.FileName);
                var result = await _mediator.Send(new CreateCourseRequest { CreateCourseDto = courseDto });
                if (result.Success)
                {
                    Course.Picture.UploadImage(guid);
                    IsSuccessful = true;
                    return RedirectToPage("/Admin/Course/index");
                }
                else
                {
                    IsSuccessful = false;
                    return Page();
                }
            }
            ModelState.AddModelError("error", "");
            return Page();
        }
    }
}
