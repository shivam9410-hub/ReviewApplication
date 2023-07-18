using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myreviewapplication.Models;
using myreviewapplication.ProductData;

namespace myreviewapplication.Controllers
{
    public class Review : Controller
    {  private readonly MyDbContext _dbContext;        

          public  Review(MyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpPost]
        public IActionResult PostReview(Product prod)
        {   
            Guid guid = Guid.NewGuid(); 
           Console.WriteLine(Productdata.myproddict[prod.Id]);
            Comment comment = new Comment {
                CommentText = prod.review,
                ProductId = prod.Id,
                UserId = guid 
            }; 
            

         

       _dbContext.Comments.Add(comment);
            Console.WriteLine(comment);
            _dbContext.SaveChanges();
      
  

     
            return Redirect("/");
        }
    }
}
