using HRApplication.Models;

namespace HRApplication.Data.Services
{
    public interface IEmployeeRegister
    {

        IEnumerable<Employee> GetAll();

        Employee GetById(int id);

        void Add(Employee reg);

        Employee update(Employee reg);

        void Delete(int id);
    }
}
