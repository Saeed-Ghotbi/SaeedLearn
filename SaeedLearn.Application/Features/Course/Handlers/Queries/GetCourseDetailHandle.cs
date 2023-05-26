using AutoMapper;
using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Requests.Queries;

namespace SaeedLearn.Application.Features.Course.Handlers.Queries
{
    public class GetCourseDetailHandle : IRequestHandler<GetCourseDetailRequest, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseDetailHandle(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CourseDto> Handle(GetCourseDetailRequest request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetCourseById(request.Id);
            return _mapper.Map<CourseDto>(course);
        }
    }
}
