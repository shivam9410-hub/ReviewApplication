using System.ComponentModel.DataAnnotations.Schema;

namespace myreviewapplication.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string CommentText { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Product")] 
         
   public Guid ProductId {get; set ;}

    }
}
