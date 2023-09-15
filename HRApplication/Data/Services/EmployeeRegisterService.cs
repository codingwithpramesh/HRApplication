using HRApplication.Data.Repository;
using HRApplication.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HRApplication.Data.Services
{
    public class EmployeeRegisterService :/*EntityBaseRepository<Employee>,*/ IEmployeeRegister
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRegisterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Employee reg)
        {
         _context.Add(reg);
        _context.SaveChanges();
          
        }

        public void Delete(int id)
        {
            Employee data = _context.Employee.FirstOrDefault(x => x.Id == id);
            _context.Employee.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = _context.Employee.ToList();
            return (IEnumerable<Employee>)result;

        }

        public Employee GetById(int id)
        {
            var data = _context.Employee.FirstOrDefault(x => x.Id == id);
            return data;
            
        }

        public Employee update(Employee reg)
        {
            /*EntityEntry entityEntry = _context.Entry(reg);
            entityEntry.State = EntityState.Modified;
            _context.SaveChanges();*/
            _context.Employee.Update(reg);
            _context.SaveChanges();
            return reg;
        }
    }
}
