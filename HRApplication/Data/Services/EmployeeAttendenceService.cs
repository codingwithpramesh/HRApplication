using HRApplication.Models;

namespace HRApplication.Data.Services
{
    public class EmployeeAttendenceService : IEmployeeAttendenceService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeAttendenceService(ApplicationDbContext context)
        {

            _context=context;

        }

        public async Task<EmployeeAttendence> Add(EmployeeAttendence empattendence)
        {
            var data = _context.EmployeeAttendence.Add(empattendence);
            _context.SaveChanges();
            return empattendence;
        }

        public void Delete(int id)
        {
            var data = _context.EmployeeAttendence.FirstOrDefault(x => x.Id == id);
            _context.EmployeeAttendence.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<EmployeeAttendence> GetAll()
        {
            var result = _context.EmployeeAttendence.ToList();
            return result;
        }

        public EmployeeAttendence GetById(int id)
        {
            var data = _context.EmployeeAttendence.FirstOrDefault(c => c.Id == id);
            return data;
        }

        public async Task<EmployeeAttendence> Update(EmployeeAttendence empattendence)
        {
            _context.EmployeeAttendence.Update(empattendence);
            _context.SaveChanges();
            return empattendence;
        }
    }
}
