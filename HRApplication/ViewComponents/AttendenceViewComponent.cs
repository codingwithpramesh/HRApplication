using Microsoft.AspNetCore.Mvc;
namespace HRApplication.ViewComponents
{
    public class AttendenceViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
