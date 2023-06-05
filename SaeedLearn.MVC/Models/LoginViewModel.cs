using System.ComponentModel.DataAnnotations;

namespace SaeedLearn.MVC.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        [Display(Name = "نام کاربری")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        [Display(Name = "رمز ورود")]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe{ get; set; }
    }
}
