using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Requests.Queries;

namespace SaeedLearn.Application.Features.Course.Handlers.Queries
{
    public class GetCardCourseListHandle : IRequestHandler<GetCardCourseListRequest,CardCourseDto>
    {
        public Task<CardCourseDto> Handle(GetCardCourseListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
