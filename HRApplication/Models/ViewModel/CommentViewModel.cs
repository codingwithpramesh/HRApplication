using System.ComponentModel.DataAnnotations;

namespace HRApplication.Models.ViewModel
{
    public class CommentViewModel
    {

        [Key]
        public int Id { get; set; }

        public int MainCommentId { get; set; }

        public string? Message { get; set;}
    }
}
