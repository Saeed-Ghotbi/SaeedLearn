using MediatR;
using SaeedLearn.Application.DTOs.Teacher;

namespace SaeedLearn.Application.Features.Teacher.Requests.Queries
{
    public class GetTeacherListRequest : IRequest<List<TeacherDto>>
    {
    }
}
