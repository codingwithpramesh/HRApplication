using HRApplication.Models;

namespace HRApplication.Data.Services
{
    public interface IEmployeeAttendenceService
    {

        IEnumerable<EmployeeAttendence> GetAll();
        EmployeeAttendence GetById(int id);
        Task<EmployeeAttendence> Add(EmployeeAttendence empattendence);
        Task<EmployeeAttendence> Update(EmployeeAttendence empattendence);

        void Delete(int id);
    }
}
