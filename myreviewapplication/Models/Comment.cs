using System.ComponentModel.DataAnnotations.Schema;

namespace myreviewapplication.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string CommentText { get; set; }
    
        public Guid UserId { get; set; }
    
         
   public Guid ProductId {get; set ;}

    }
}
