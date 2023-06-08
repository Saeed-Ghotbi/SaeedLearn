namespace SaeedLearn.Application.Models.Identity
{
    public class AuthLogin
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
