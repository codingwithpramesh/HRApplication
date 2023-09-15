using System.ComponentModel.DataAnnotations;

namespace HRApplication.Models.ViewModel
{
    public class LoginVM
    {

      /*  [Required]*/
        public string UserName { get; set; }

        /*[Required]*/
        public string Password { get; set; }
    }
}
