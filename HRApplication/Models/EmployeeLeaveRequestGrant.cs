using System.ComponentModel.DataAnnotations;

namespace HRApplication.Models
{
    public class EmployeeLeaveRequestGrant
    {
        [Key]
        public int Id { get; set; }

        public int LeaveRequestId { get; set; }

        public int NumberOfDays { get; set; }

        public int ApprovedBy { get; set; }

        public string ApprovedRemark { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
