using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaeedLearn.Application.DTOs.Common;

namespace SaeedLearn.Application.DTOs.Course
{
    public class CourseDto : BaseDto
    {
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public DateTime DateModified { get; set; }
        public string? ImgPath { get; set; }
        public bool ActiveCourse { get; set; }


    }
}
