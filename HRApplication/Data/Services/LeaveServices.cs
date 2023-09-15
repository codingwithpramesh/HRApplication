using HRApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HRApplication.Data.Services
{
    public class LeaveServices : ILeaveServices
    {
        private readonly ApplicationDbContext _context;
        public LeaveServices(ApplicationDbContext context)
        {
            _context = context;
        }
        /*
                public void Accepted( int id ,Leave leave)
                {
                    var data = _context.leaves.FirstOrDefault(x => x.LeaveId == id);
                    leave.Status = Enum.Status.Approved;
                    _context.leaves.Update(data);
                    _context.SaveChanges();

                }*/

        public void Accepted(int id)
        {
            var data = _context.leaves.FirstOrDefault(x => x.LeaveId == id);
            data.Status = Enum.Status.Approved;
            _context.leaves.Update(data);
            _context.SaveChanges();
        }

        public async Task<Leave> Add(Leave leave)
        {
            var data = _context.leaves.Add(leave);
            _context.SaveChanges();
            return leave;
        }

        public void Delete(int id)
        {
            Leave leave = _context.leaves.FirstOrDefault(p => p.LeaveId == id);
            _context.leaves.Remove(leave);
            _context.SaveChanges();
        }

        public IEnumerable<Leave> GetAll()
        {
            var result = _context.leaves.Include(x => x.Comments).ToList();
            return result;
        }

        public Leave GetById(int id)
        {
            var data = _context.leaves.Include(x => x.Comments).FirstOrDefault(x => x.LeaveId == id);
            return data;
        }

        /*  public void Rejected(int id, Leave leave)
          {
              var data = _context.leaves.FirstOrDefault(x => x.LeaveId == id);
              leave.Status = Enum.Status.Rejected;
              _context.leaves.Update(data);
              _context.SaveChanges();
          }*/

        public void Rejected(int id)
        {
            var data = _context.leaves.FirstOrDefault(x => x.LeaveId == id);
            data.Status = Enum.Status.Rejected;
            _context.leaves.Update(data);
            _context.SaveChanges();
        }

        public async Task<Leave> Update(Leave leave)
        {

            _context.leaves.Update(leave);
            await _context.SaveChangesAsync();
            return (leave);
        }

        public async Task<List<Leave>> GetPostsAsync()
        {
            return _context.leaves.Include(x => x.Comments).ToList();
        }

        public Leave GetPosts(int id)
        {
            return _context.leaves.OrderBy(x => x.LeaveId).Include(x => x.Comments).FirstOrDefault(x => x.LeaveId == id);
        }

        public void UpdatePost(Leave Leave)
        {
            _context.leaves.Update(Leave);
        }

        public async Task<bool> SavechangesAsync()
        {
            if (await _context.SaveChangesAsync()>0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
