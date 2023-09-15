using HRApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRApplication.Controllers
{
    [Area("Employee")]
    public class CalenderController : Controller
    {
      
        public CalenderController()
        {
            
        }
        public IActionResult Index()
        {
           return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Created()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult Edited()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted()
        {
            return View();
        }


        public IActionResult Details()
        {
            return View();
        }

     
    }
}
