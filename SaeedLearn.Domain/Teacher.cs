using SaeedLearn.Domain.Common;

namespace SaeedLearn.Domain
{
    public class Teacher : BaseDomainEntity
    {
        public ICollection<Course>? Courses { get; set; }
    }
}
