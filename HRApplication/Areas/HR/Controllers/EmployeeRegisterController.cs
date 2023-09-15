using HRApplication.Data.Services;
using HRApplication.Models;
using Microsoft.AspNetCore.Mvc;


namespace HRApplication.Areas.HR.Controllers
{
    [Area("HR")]
    public class EmployeeRegisterController : Controller
    {
        private readonly IEmployeeRegister _service;
        public EmployeeRegisterController(IEmployeeRegister service)
        {
            _service = service;

        }
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        public IActionResult Created(Employee employee)
        {
            try
            {
                _service.Add(employee);
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
            Employee data = _service.GetById(id);
            return View(data);
        }


        [HttpPost, ActionName("Edit")]
        public IActionResult Edited(Employee employee)
        {
            _service.update(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee data = _service.GetById(id);
            return View(data);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee data = _service.GetById(id);
            return View(data);
        }



    }
}
