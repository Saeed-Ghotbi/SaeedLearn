using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaeedLearn.Application.DTOs.Common
{
    public abstract class BaseCourseDto : BaseDto
    {
        public double Price { get; set; }

        public float? Offer { get; set; }
        public string TeacherName { get; set; }
        public string? ImgPath { get; set; }

    }
}
