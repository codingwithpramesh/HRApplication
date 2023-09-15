using HRApplication.Data.Enum;
using HRApplication.Data.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApplication.Models
{
    public class Employee  
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        
        public string? Email { get; set; }

        public DateTime DOB { get; set; }

        public Gender Gender { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? Role { get; set; } = "Employee";

        public string? Password { get; set; }

        public string? profilepicture { get; set; }

        public string? ConfirmPassword { get; set; }

        /*public int EmployeeAttendId { get; set; }
        [ForeignKey("EmployeeAttendId")]

        public EmployeeAttendence EmployeeAttendence { get; set; }*/
    }
}
