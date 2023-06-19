namespace SaeedLearn.Application.DTOs.Common
{
    public abstract class BaseCourseDto : BaseDto
    {
        public double Price { get; set; }
        public float? Offer { get; set; }
        public string? TeacherName { get; set; }
        public string? PicturePath { get; set; }

    }
}
