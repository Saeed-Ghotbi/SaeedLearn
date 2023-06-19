using AutoMapper;
using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Requests.Queries;

namespace SaeedLearn.Application.Features.Course.Handlers.Queries
{
    public class GetCourseListHandle : IRequestHandler<GetCourseListRequest, List<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseListHandle(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<List<CourseDto>> Handle(GetCourseListRequest request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetCourseList();

            return _mapper.Map<List<CourseDto>>(courses); ;
        }
    }
}
