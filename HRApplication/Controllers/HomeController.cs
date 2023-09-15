using HRApplication.Data;
using HRApplication.Data.Services;
using HRApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        

        public HomeController(ILogger<HomeController> logger , IEmailService emailService, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _emailService = emailService;
            _context = context;     
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           /* int id= 1;
            var data = _context.EmployeeAttendence.FirstOrDefault(x => x.Id == id);
            ViewBag.status = data.Status;*/
         
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Hi( int id)
        {
         var data = _context.EmployeeAttendence.FirstOrDefault(x => x.EmployeeId == id);
            /* EmployeeAttendence? model = new EmployeeAttendence
             {
                 Status = true
             };*/

            EmployeeAttendence empattend = new EmployeeAttendence();
            empattend.EmployeeId = id;
            return PartialView("_NavbarItems", empattend);
        }
    }
}