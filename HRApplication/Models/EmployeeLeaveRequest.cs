using System.ComponentModel.DataAnnotations;

namespace HRApplication.Models
{
    public class EmployeeLeaveRequest
    {
        [Key]
        public int Id { get; set; }

        public int LeaveId { get; set; }

        public int NoOfDays { get; set; }

        public string Reason { get; set; }

        public string ApprovedRemark { get; set; }
    }
}
