using HRApplication.Data.Services;
using HRApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRApplication.Areas.HR.Controllers
{
    [Area("HR")]
    public class EmployeeAttendenceController : Controller
    {
        private readonly IEmployeeAttendenceService _Service;
        public EmployeeAttendenceController(IEmployeeAttendenceService service)
        {
            _Service = service; 
        }
        public IActionResult Index()
        {
            IEnumerable<EmployeeAttendence> data = _Service.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Created( EmployeeAttendence empattendence)
        {
            try
            {
                _Service.Add(empattendence);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _Service.GetById(id);
            return View(data);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult Edited( EmployeeAttendence empattendence)
        {
            _Service.Update(empattendence);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _Service.GetById(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _Service.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var data = _Service.GetById(id);
            return View(data);
        }
    }
}
