using SaeedLearn.Application.DTOs.Common;

namespace SaeedLearn.Application.DTOs.Course
{
    public class CardCourseDto : BaseCourseDto
    {
        public TimeOnly TimeCourse { get; set; }

        public Domain.Teacher? Teacher { get; set; }

    }
}
