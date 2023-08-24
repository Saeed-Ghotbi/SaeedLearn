using AutoMapper;
using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Course.Validators;
using SaeedLearn.Application.Features.Course.Requests.Command;
using SaeedLearn.Application.Responses;
using SaeedLearn.Domain;

namespace SaeedLearn.Application.Features.Course.Handlers.Command
{
    public class CreateCourseHandle : IRequestHandler<CreateCourseRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;

        public CreateCourseHandle(IMapper mapper, ICourseCategoryRepository courseCategoryRepository, ICourseRepository courseRepository, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();
            var validator = new CreateCourseDtoValidator(_courseRepository, _teacherRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCourseDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Create Course Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {
                var createCourseDto = request.CreateCourseDto;
                var course = _mapper.Map<Domain.Course>(createCourseDto);

                var newCourse = await _courseRepository.Add(course);

                var courseCategory = await _courseCategoryRepository.Add(new CourseCategory()
                {
                    CourseId = newCourse.Id,
                    CategoryId = createCourseDto.CategoryIds.First()
                });

                response.Id = newCourse.Id;
                response.Success = true;
                response.Message = "Add Course Successful";

            }

            return response;
        }
    }
}
