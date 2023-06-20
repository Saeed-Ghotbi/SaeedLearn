using SaeedLearn.Domain.Common;

namespace SaeedLearn.Domain
{
    public class Course : BaseDomainEntity
    {
        public string? Description { get; set; }
        public DateTime? DateModified { get; set; }
        public string? PicturePath { get; set; }
        public bool ActiveCourse { get; set; }
        public double Price { get; set; }
        public float? Offer { get; set; }
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }
        public IList<CourseCategory>? CourseCategories { get; set; }

        public static implicit operator List<object>(Course v)
        {
            throw new NotImplementedException();
        }
    }
}
