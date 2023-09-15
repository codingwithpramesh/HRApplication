using System.ComponentModel.DataAnnotations;

namespace HRApplication.Models
{
    public class Leave
    {

       /* public Leave()
        {
            Comments =  new List<HRApplication.Models.Comment.Comment>();
        }
*/

        [Key]
        public int LeaveId { get; set; }

        public string? LeaveType { get; set; }

        public int NoOfDays { get; set; }

       /* [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime From { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime To { get; set; }
*/
        public HRApplication.Data.Enum.Status Status { get; set; }


       // public List<Models.Comment> MainComments { get; set; }
       public List<HRApplication.Models.Comment.Comment> Comments { get; set; }

    }
}
