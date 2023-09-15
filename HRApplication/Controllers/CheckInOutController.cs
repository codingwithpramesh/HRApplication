using HRApplication.Data.Services;
using HRApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace HRApplication.Controllers
{
    public class CheckInOutController : Controller
    {
        private readonly IcheckInOutServices _services;
        public CheckInOutController(IcheckInOutServices services)
        {
            _services = services;
        }
       /* public IActionResult _NavbarItems( )
        {
            var model = new EmployeeAttendence { Status = GetStatus(id) };
            return PartialView(model);
        }*/


        public IActionResult CheckIn(int id)
        {
            id=1;
           
            var status = _services.Checkinoutstatus(id);
            if (status == false)
            {
                _services.Checkin(id);

            }
            ViewBag.status = status;

            HttpContext.Session.SetString("UserStatus", status.ToString());

            return PartialView("_NavbarItems");
        }



        public IActionResult checkout(int id)
        {
            EmployeeAttendence emp = new EmployeeAttendence();
            if(emp.Status == false)
            {
                _services.Checkout(id);
                return RedirectToAction("Index", "Home");

            }
            return View();
          
        }

        private void GetStatus(int id)
        {
            var data = _services.Checkinoutstatus(id);
        }

    }
}
