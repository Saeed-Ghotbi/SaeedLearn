using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaeedLearn.Application.DTOs.Common;

namespace SaeedLearn.Application.DTOs.Course
{
    public class UpdateCourseDto : BaseCourseDto
    {
        public DateTime? DateModified { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public bool ActiveCourse { get; set; }
        public List<int> CategoryIds { get; set; }

    }
}
