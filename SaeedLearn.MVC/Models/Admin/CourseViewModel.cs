using System.ComponentModel.DataAnnotations;

namespace SaeedLearn.MVC.Models.Admin
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "نام دوره")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(500)]
        [DataType(DataType.Text)]
        [Display(Name = "توضیحات دوره")]
        public string? Description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "قیمت دوره")]
        [Required]
        public double Price { get; set; }
        [Display(Name = "تخفیف دوره")]
        public float? Offer { get; set; }
        public string? PicturePath { get; set; }
        [Display(Name = "عکس دوره")]
        public IFormFile? Picture { get; set; }
        [Required]
        public bool ActiveCourse { get; set; }
        public int TeacherId { get; set; }
        public List<int>? CategoryIds { get; set; }
    }
}
