using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string? ProfilePicture { get; set; }

        public string Role { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

       
       

    }
}
