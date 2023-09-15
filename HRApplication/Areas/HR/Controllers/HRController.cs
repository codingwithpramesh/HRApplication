using Microsoft.AspNetCore.Mvc;

namespace HRApplication.Areas.HR.Controllers
{
    [Area("HR")]
    public class HRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
