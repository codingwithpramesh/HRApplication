using System.ComponentModel.DataAnnotations;

namespace HRApplication.Models
{
    public class DepartmentMember
    {
        [Key]
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeId { get; set; }

        public string? Role { get; set; }
    }
}
