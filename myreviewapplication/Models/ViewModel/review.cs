namespace myreviewapplication.Models.ViewModel
{
    public class review
    {

        public string  CommentText { get; set; }
        public string UserName { get; set; } 
        public Guid CommentId { get; set; } 
        public double rating { get; set; }
    }
}
