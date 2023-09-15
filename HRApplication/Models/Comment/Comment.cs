using MessagePack;

namespace HRApplication.Models.Comment
{
    public class Comment
    {
      
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }
    }
}
