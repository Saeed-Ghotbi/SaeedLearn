using AutoMapper;
using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Category;
using SaeedLearn.Application.DTOs.Teacher;
using SaeedLearn.Application.Features.Category.Requests.Queries;
using SaeedLearn.Application.Features.Teacher.Requests.Queries;

namespace SaeedLearn.Application.Features.Category.Handlers.Queries
{
    public class GetCategoryListHandle : IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListHandle(ICategoryRepository repository, IMapper mapper)
        {
            _categoryRepository = repository;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
