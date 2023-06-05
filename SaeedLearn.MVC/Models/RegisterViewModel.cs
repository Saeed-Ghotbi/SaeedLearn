using System.ComponentModel.DataAnnotations;

namespace SaeedLearn.MVC.Models
{
	public class RegisterViewModel
	{
		[Required]
		[MaxLength(50)]
		[Display(Name = "نام کاربری")]
		public string UserName { get; set; }
		[Required]
		[EmailAddress]
		[MaxLength(100)]
		[Display(Name = "ایمیل")]
		public string EmailAddress { get; set; }
		[MaxLength(100)]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "شماره موبایل")]
		public string PhoneNumber { get; set; }
		[Required]
		[MaxLength(50)]
		[Display(Name = "پسورد")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare("Password")]
		[Display(Name = "تکرار پسورد")]
		public string ConfirmPassword { get; set; }

	}
}
