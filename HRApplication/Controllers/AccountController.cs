using Microsoft.AspNetCore.Mvc;

namespace HRApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
