using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Teacher;
using SaeedLearn.Application.Features.Teacher.Requests.Queries;

namespace SaeedLearn.Application.Features.Teacher.Handlers.Queries
{
    public class GetCategoryListHandle : IRequestHandler<GetTeacherListRequest, List<TeacherDto>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public GetCategoryListHandle(ITeacherRepository repository, IMapper mapper)
        {
            _teacherRepository = repository;
            _mapper = mapper;
        }
        public async Task<List<TeacherDto>> Handle(GetTeacherListRequest request, CancellationToken cancellationToken)
        {
            var teachers = await _teacherRepository.GetAll();
            return _mapper.Map<List<TeacherDto>>(teachers);
        }
    }
}
