using HRApplication.Models;
using System.Numerics;

namespace HRApplication.Data.Services
{
    public class HRServices : IHRServices
    {
        private readonly ApplicationDbContext _context;
        public HRServices(ApplicationDbContext context)
        {

            _context=context;

        }
        public async Task<ApplicationUser> Add(Employee employee)
        {
           ApplicationUser user = new ();
            user.Name = employee.Name;
            user.EmployeeId = employee.Id;
            user.Role = employee.Role;
             return  user;
        }

        public void Delete(int id)
        {
            Employee data = _context.Employee.FirstOrDefault(p => p.Id == id);
            _context.Employee.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = _context.Employee.ToList();
            return result;
        }

        public Employee GetById(int id)
        {
           var data = _context.Employee.FirstOrDefault( x =>x.Id == id);
            return data;
        }

        public async Task<Employee> Update(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
            return employee;  
        }
    }
}
