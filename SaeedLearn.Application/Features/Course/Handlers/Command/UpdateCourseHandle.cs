using AutoMapper;
using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.Features.Course.Requests.Command;

namespace SaeedLearn.Application.Features.Course.Handlers.Command
{
    public class UpdateCourseHandle : IRequestHandler<UpdateCourseRequest>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public UpdateCourseHandle(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetCourse(request.UpdateCourseDto.Id);
            _mapper.Map(request.UpdateCourseDto, course);


            await _courseRepository.Update(course);
            return Unit.Value;

        }
    }
}
