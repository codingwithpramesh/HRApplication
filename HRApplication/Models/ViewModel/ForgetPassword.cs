using System.ComponentModel.DataAnnotations;

namespace HRApplication.Models.ViewModel
{
    public class ForgetPassword
    {
        [EmailAddress]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
