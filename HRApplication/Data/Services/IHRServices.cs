using HRApplication.Models;
using System.Numerics;

namespace HRApplication.Data.Services
{
    public interface IHRServices
    {

        IEnumerable<Employee> GetAll();

        Employee GetById(int id);
        Task<ApplicationUser> Add(Employee employee);
        Task<Employee> Update(Employee employee);

        void Delete(int id);
    }
}
