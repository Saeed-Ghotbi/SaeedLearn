using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SaeedLearn.MVC.Models;

namespace SaeedLearn.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region Register
        public IActionResult Register()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            return RedirectToAction("SuccessRegister");
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
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            return RedirectToAction("index");
        }
        #endregion
    }
}
