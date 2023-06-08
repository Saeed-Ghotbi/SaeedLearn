using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SaeedLearn.Identity.Models
{
    public class User : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public bool IsAdmin { get; set; }
    }
}
