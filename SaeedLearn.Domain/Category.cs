using SaeedLearn.Domain.Common;

namespace SaeedLearn.Domain
{
    public class Category : BaseDomainEntity
    {
        public IList<CourseCategory>? CourseCategories { get; set; }
    }
}
