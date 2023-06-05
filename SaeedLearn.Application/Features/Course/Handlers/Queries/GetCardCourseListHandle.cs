using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Requests.Queries;

namespace SaeedLearn.Application.Features.Course.Handlers.Queries
{
    public class GetCardCourseListHandle : IRequestHandler<GetCardCourseListRequest,List<CardCourseDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCardCourseListHandle(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<List<CardCourseDto>> Handle(GetCardCourseListRequest request, CancellationToken cancellationToken)
        {
            var cardList = await _courseRepository.GetListCard();  
            return _mapper.Map<List<CardCourseDto>>(cardList); 
        }
    }
}
