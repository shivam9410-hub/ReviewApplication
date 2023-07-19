using Microsoft.AspNetCore.Mvc;
using myreviewapplication.Models;
using myreviewapplication.ProductData;
namespace myreviewapplication.Controllers
{
    public class ProductDetailsController : Controller
    {

        private readonly MyDbContext _dbContext;

        public ProductDetailsController(MyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


         public IActionResult AddProduct() {


            return View(); 
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {     Console.WriteLine(product.Name);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();   
            return Redirect("/");

        }

        public IActionResult ProductDetail(Guid Id)
        {
             
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == Id); 

            return View(product);
        }
    }
}
