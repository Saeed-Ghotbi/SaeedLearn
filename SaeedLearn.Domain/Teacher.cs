using SaeedLearn.Domain.Common;

namespace SaeedLearn.Domain
{
    public class Teacher : BaseDomainEntity
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
