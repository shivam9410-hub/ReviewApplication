using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myreviewapplication.Models;
using myreviewapplication.Models.ViewModel;
using myreviewapplication.ProductData;


namespace myreviewapplication.Controllers
{
    public class ReviewController : Controller
    { private readonly MyDbContext _dbContext;

        public ReviewController(MyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public IActionResult GetReviews(Guid Id)
        {
      
            List<Comment> comments=_dbContext.Comments.Where(c=>c.ProductId == Id).ToList();


            var query = (from c in _dbContext.Comments
                         join p in _dbContext.Products on c.ProductId equals p.Id
                         join u in _dbContext.Users on c.UserId equals u.Id
                         where p.Id == Id
                         select new review
                         {
                             CommentText = c.CommentText,
                              UserName = u.Name,
                              CommentId= c.CommentId,
                              rating= c.rating
                         }).ToList();
              
            return  PartialView("_ReviewPartial", query); 
        }

        [HttpPost]
        public IActionResult PostReview(Product prod)
        {
            Console.WriteLine(prod);
          
            User newuser = new User(); 
            newuser.Id = Guid.NewGuid();
            newuser.Name = "Shivam Khantwal";
            newuser.Email = "shivamkhantwal9410@gmail.com";

            newuser.Password = 123214;
            _dbContext.Users.Add(newuser);
            _dbContext.SaveChanges();
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == prod.Id);


            var  lowercasereview= prod.review.ToLower();    
            
            var wordlist= lowercasereview.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            var previousrating = prod.Rating;
            
            int maximumrating = 0;
            
            int  wordfound = 0;
            int NotFound = 0;
            
            foreach(var reviewword in wordlist) {
            
                bool isWordPresent =ReviewDataRating.rating.Keys.Any(word => word == reviewword);
                
                if ( isWordPresent &&  maximumrating< ReviewDataRating.rating[reviewword])
                {
                    wordfound = 1;
                    maximumrating = ReviewDataRating.rating[reviewword];
                }
                if (reviewword == "not")
                {
                    NotFound = 1; 
                }
            }
                 if (wordfound == 1)
            {
                var totalcommentscount = _dbContext.Comments.Count(c => c.ProductId == prod.Id);
                totalcommentscount++;
                product.Score += maximumrating;
                if (NotFound==1)
                {
                    product.Score -= 1;

                }
                product.Rating = (double)(product.Score / totalcommentscount);
                Comment comment = new Comment
                {
                    CommentText = prod.review,
                    ProductId = prod.Id,
                    UserId = newuser.Id,

                     rating =  maximumrating

                };




                _dbContext.Comments.Add(comment);
          
                _dbContext.SaveChanges();
            }





            return  Ok("Successfuly submitted");
        }
    }
}
