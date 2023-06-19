using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SaeedLearn.Application.Contracts.Identity;
using SaeedLearn.Application.Models.Identity;
using SaeedLearn.Application.Responses;
using SaeedLearn.Identity.Models;
using System.Security.Claims;

namespace SaeedLearn.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthLogin> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User>? _userManager;

        public AuthService(ILogger<AuthLogin> logger, IHttpContextAccessor contextAccessor, SignInManager<User> signInManager, UserManager<User>? userManager)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<BaseCommandResponse> Login(AuthLogin login)
        {
            BaseCommandResponse response = new BaseCommandResponse();

            var user = await UserCheck(login.UserName);
            if (!user.Success)
            {
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.", login.UserName);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,login.UserName),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = login.RememberMe });

                response.Success = true;
                response.Message = (login.UserName == "admin" ? "User Admin" : "User logged in." + login.UserName);
                return response;
            }
            response.Success = false;
            response.Message = "Invalid password";
            return response;
        }

        public async Task<BaseCommandResponse> Logout()
        {
            await _signInManager.SignOutAsync();
            return new BaseCommandResponse()
            {
                Success = true,
                Message = "User Logout",
            };
        }

        public async Task<BaseCommandResponse> Register(AuthRegister register)
        {
            BaseCommandResponse response = new BaseCommandResponse();

            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = register.FirstName,
                Lastname = register.LastName,
                Email = register.EmailAddress,
                UserName = register.UserName,
                PhoneNumber = register.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                response.Success = true;
                response.Message = "Create User Ok";
                return response;
            }
            else
            {
                response.Success = false;
                response.Errors = result.Errors.Select(e => e.Description).ToList();
                return response;
            }
        }

        public async Task<BaseCommandResponse> UserCheck(string user)
        {
            BaseCommandResponse response = new BaseCommandResponse();
            var result = await _userManager.FindByNameAsync(user);

            if (user == null)
            {
                response.Success = false;
                response.Message = "User Not Found";
                return response;
            }

            response.Success = true;
            response.Message = "User Exist";
            return response;
        }

        public async Task<bool> IsAdmin(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && user.IsAdmin)
                return true;
            return false;
        }
    }
}

