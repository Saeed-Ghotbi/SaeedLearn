using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaeedLearn.Application.Contracts.Identity;
using SaeedLearn.Application.Models.Identity;
using SaeedLearn.MVC.Models;

namespace SaeedLearn.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, IAuthService authService, IMapper mapper)
        {
            _logger = logger;
            _authService = authService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _authService.IsAdmin(User.Identity.Name);
            if (result)
            {
                return Redirect("/Admin");
            }
            return View();
        }
        #region Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                AuthRegister authRegister = _mapper.Map<AuthRegister>(register);

                var result = await _authService.Register(authRegister);
                if (result.Success)
                {
                    _logger.LogInformation($"Register Account {register.UserName}");

                    return RedirectToAction("SuccessRegister");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError("Register", error);
                    }
                    return View(register);
                }
            }
            ModelState.AddModelError("Register", "اطلاعات وارد شده صحیح نیست.");
            return View(register);
        }

        public IActionResult SuccessRegister()
        {
            return View();
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                AuthLogin authLogin = _mapper.Map<AuthLogin>(login);

                var result = await _authService.Login(authLogin);

                if (result.Success)
                {
                    _logger.LogInformation($"Login Account {login.UserName}");
                    if (result.Message == "User Admin")
                    {
                        return Redirect("/Admin");
                    }
                    return RedirectToAction("index");
                }
                else if (result.Message == "Invalid password")
                {
                    ModelState.AddModelError("Login", "Invalid password for user.");
                    return View(login);
                }
                else
                {
                    ModelState.AddModelError("Login", "User Not Found.");
                    return View(login);
                }
            }
            ModelState.AddModelError("Login", "اطلاعات وارد شده صحیح نیست.");
            return View(login);
        }
        public async void Logout()
        {
            await _authService.Logout();
            RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
