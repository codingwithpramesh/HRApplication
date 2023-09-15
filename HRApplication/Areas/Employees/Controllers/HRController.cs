using HRApplication.Data;
using HRApplication.Data.Services;
using HRApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRApplication.Areas.Employees.Controllers
{
    [Area("Employee")]
    public class HRController : Controller
    {
        private readonly IHRServices _Services;
        public HRController(IHRServices Services)
        {
            _Services = Services;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var lstemployee = _Services.GetAll().Select(x => new SelectListItem
            {

                Text = x.Name,
                Value = x.Id.ToString()

            });

            ViewData["employee"] = lstemployee;
            ViewData["Registration"] = new Registration();
            return View();
        }

        [HttpPost, ActionName("Register")]
        public IActionResult Registered(Employee employee)
        {
            var data = _Services.Add(employee);
            return RedirectToAction("Index", "EmployeeRegister");
        }


    }
}
