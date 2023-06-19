using MediatR;
using SaeedLearn.Application.DTOs.Category;
using SaeedLearn.Application.DTOs.Teacher;

namespace SaeedLearn.Application.Features.Category.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<List<CategoryDto>>
    {
    }
}
