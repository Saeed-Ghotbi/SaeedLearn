using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SaeedLearn.Application.DTOs.Course;

namespace SaeedLearn.Application.Features.Course.Requests.Queries
{
    public class GetCourseListRequest:IRequest<List<CourseDto>>
    {
    }
}
