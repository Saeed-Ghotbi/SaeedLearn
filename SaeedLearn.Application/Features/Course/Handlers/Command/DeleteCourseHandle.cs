using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.Exceptions;
using SaeedLearn.Application.Features.Course.Requests.Command;
using SaeedLearn.Application.Responses;

namespace SaeedLearn.Application.Features.Course.Handlers.Command
{
    public class DeleteCourseHandle : IRequestHandler<DeleteCourseRequest>
    {
        private readonly ICourseRepository _courseRepository;

        public DeleteCourseHandle(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Unit> Handle(DeleteCourseRequest request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.Get(request.Id);
            if (course == null)
            {
                throw new NotFoundException(nameof(course), request.Id);
            }

            await _courseRepository.Delete(course);

            return Unit.Value;

        }
    }
}
