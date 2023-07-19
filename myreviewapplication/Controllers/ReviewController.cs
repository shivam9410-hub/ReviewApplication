using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myreviewapplication.Models;
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
               
            return View(comments); 
        }

        [HttpPost]
        public IActionResult PostReview(Product prod)
        {   
           
          
            User newuser = new User(); 
            newuser.Id = Guid.NewGuid();
            newuser.Name = "Shivam Khantwal";
            newuser.Email = "shivamkhantwal9410@gmail.com";

            newuser.Password = 123214;
            _dbContext.Users.Add(newuser);
            _dbContext.SaveChanges();



        Comment comment = new Comment {
                CommentText = prod.review,
                ProductId = prod.Id,
                UserId =  newuser.Id
            }; 
            

        

       _dbContext.Comments.Add(comment);
         

            var product = _dbContext.Products.FirstOrDefault(p => p.Id == prod.Id);


            var  lowercasereview= prod.review.ToLower();    
            
            var wordlist= lowercasereview.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            var previousrating = prod.Rating;
            
            int maximumrating = 0;
            
            int  found = 0;
            
            foreach(var reviewword in wordlist) {
            
                bool isWordPresent =ReviewDataRating.rating.Keys.Any(word => word == reviewword);
                
                if ( isWordPresent &&  maximumrating< ReviewDataRating.rating[reviewword])
                {
                    found = 1;
                    maximumrating = ReviewDataRating.rating[reviewword];
                }
            }
 if (found == 1)
            {
                var totalcommentscount = _dbContext.Comments.Count(c => c.ProductId == prod.Id);
                totalcommentscount++;
                product.Score += maximumrating;
                product.Rating = (double)(product.Score) / totalcommentscount;
                _dbContext.SaveChanges();
            }

         



            return Redirect("/");
        }
    }
}
