using HRApplication.Data.Services;
using HRApplication.Models;
using HRApplication.Models.Comment;
using HRApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HRApplication.Areas.HR.Controllers
{
    [Area("HR")]
    public class LeaveController : Controller
    {
        
        private readonly ILeaveServices _services;
        public LeaveController(ILeaveServices services)
        {
            _services = services;

        }
        public IActionResult Index()
        {
            IEnumerable<Leave> data = _services.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Leave leave)
        {
            try
            {
                _services.Add(leave);
                return RedirectToAction("Index", new { area = "HR"});

                

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
            Leave data = _services.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Leave leave)
        {
            _services.Update(leave);
            return RedirectToAction("Index", new { area = "HR" });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Leave data = _services.GetById(id);
            return View(data);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _services.Delete(id);
            return RedirectToAction("Index", new { area = "HR" });
        }


        public IActionResult Details(int id)
        {
            Leave data = _services.GetById(id);
            return View(data);
        }


        public IActionResult LeaveRequest(int id)
        {
            var data = _services.GetById(id);
            return View(data);
        }

        /*
                [HttpGet]
                public IActionResult Accepted( int id)
                {
                    var data = _services.GetById(id);
                    return View(data);

                }*/


        public IActionResult Accepted(int id)
        {
            _services.Accepted(id);
            return RedirectToAction("Index", "Leave", new { area = "HR" });

        }


        /*  [HttpGet]
          public IActionResult Rejected(int id)
          {
              var data = _services.GetById(id);
              return View(data);

          }*/


        public IActionResult Rejected(int id)
        {
            _services.Rejected(id);
            return RedirectToAction("Index", "Leave", new { area = "HR" });

        }

        [HttpGet]
        public IActionResult Comment(int id)
        {
            try
            {
                Leave data = _services.GetById(id);
                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("comment", "Leave", ex);
            }
        }

        [HttpPost ,  ActionName("Comment")]
        public async Task<IActionResult> Commented(CommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Leave", new { id = commentViewModel.Id });
            }

            var post = _services.GetPosts(commentViewModel.Id);
            if (commentViewModel.MainCommentId == 0)
            {

                post.Comments = post.Comments ?? new List<Comment>();

                post.Comments.Add(new Comment
                {
                    Message = commentViewModel.Message,
                    Created = DateTime.Now,
                });

                post.Comments = post.Comments.OrderByDescending(c => c.Created).ToList();

                _services.UpdatePost(post);
            }
            
            await _services.SavechangesAsync();
            return RedirectToAction("comment", new { Id = commentViewModel.Id });
        }







    }
}
