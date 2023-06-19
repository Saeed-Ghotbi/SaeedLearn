using AutoMapper;
using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
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

        public CreateCourseHandle(IMapper mapper, ICourseCategoryRepository courseCategoryRepository, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseRepository = courseRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();
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

            return response;
        }
    }
}
