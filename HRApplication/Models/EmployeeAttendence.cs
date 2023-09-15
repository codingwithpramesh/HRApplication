using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApplication.Models
{
    public class EmployeeAttendence
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        public DateTime CheckinTime { get; set; }

      //  public string Checkinlog { get; set; }

        public DateTime CheckoutTime { get; set; }

       // public string CheckoutLog { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Status { get; set; }

    }
}
