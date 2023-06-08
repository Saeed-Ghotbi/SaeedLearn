using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SaeedLearn.Application.Models.Identity
{
    public class AuthRegister
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
