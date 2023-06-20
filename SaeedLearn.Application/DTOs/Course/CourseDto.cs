using SaeedLearn.Application.DTOs.Common;
using SaeedLearn.Domain;

namespace SaeedLearn.Application.DTOs.Course
{
    public class CourseDto : BaseCourseDto
    {
        public DateTime DateCreated { get; set; }
        public string? Description { get; set; }
        public DateTime DateModified { get; set; }
        public bool ActiveCourse { get; set; }

        public Domain.Teacher? Teacher { get; set; }
        public IList<CourseCategory>? CourseCategories { get; set; }

    }
}
