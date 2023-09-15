using System.ComponentModel.DataAnnotations;

namespace HRApplication.Models.ViewModel
{
    public class ResetPassword
    {

        /*  [Required]
          public string UserId { get; set; }

          [Required]
          public string Token { get; set; }*/

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }

        public bool IsSuccess { get; set; }
    }
}
