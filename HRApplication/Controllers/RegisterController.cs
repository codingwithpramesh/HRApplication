using HRApplication.Data.Services;
using HRApplication.Models;
using HRApplication.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRApplication.Controllers
{
    
    public class RegisterController : Controller
    {

        private readonly IUserAuthenticationService _service;
        public RegisterController(IUserAuthenticationService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginvm);
            }
            var data = await _service.LoginAsync(loginvm);
             
            


            if (data.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Register");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Registration Register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                Register.Roles = "Admin";
                var re = await _service.RegisterAsync(Register);
                return RedirectToAction("Login", "Register");

            }
        }

        public IActionResult Logout()
        {
            _service.LogoutAsync();
            return RedirectToAction("Login", "Register");
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _service.ChangePasswordAsync(model, User.Identity.Name);
            return RedirectToAction(nameof(ChangePassword));
        }
    }
}
