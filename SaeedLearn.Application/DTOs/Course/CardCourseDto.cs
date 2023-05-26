using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaeedLearn.Application.DTOs.Common;

namespace SaeedLearn.Application.DTOs.Course
{
    public class CardCourseDto :BaseDto
    {
        public TimeOnly TimeCourse { get; set; } 
    }
}
