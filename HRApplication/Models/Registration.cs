using HRApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApplication.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }


        /*[Required]*/
        public string? Name { get; set; }

      /*  [Required]*/
        [EmailAddress]
        public string? Email { get; set; }

       // [Required]
        public string Username { get; set; }


        public string? ProfilePicture { get; set; }

        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //[Required]
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }

       /* [Required]*/
        public string? Roles { get; set; }

        public int EmployeeId { get; set; }

    }
}
