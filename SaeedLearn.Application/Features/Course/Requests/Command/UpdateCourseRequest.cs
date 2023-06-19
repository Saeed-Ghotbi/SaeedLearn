using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Responses;

namespace SaeedLearn.Application.Features.Course.Requests.Command
{
    public class UpdateCourseRequest : IRequest
    {
        public UpdateCourseDto? UpdateCourseDto { get; set; }
    }
}
