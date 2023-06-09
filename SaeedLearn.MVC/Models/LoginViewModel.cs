﻿using System.ComponentModel.DataAnnotations;

namespace SaeedLearn.MVC.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        [Display(Name = "رمز ورود")]
        public string? Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
