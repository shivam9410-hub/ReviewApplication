using Microsoft.AspNetCore.Mvc;
using myreviewapplication.Models;
using System.Diagnostics;
using myreviewapplication.ProductData;
namespace myreviewapplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _dbcontext;
        public HomeController(ILogger<HomeController> logger, MyDbContext _dbcontext)
        {
            _logger = logger;
            this._dbcontext = _dbcontext;
        }

        public IActionResult Index()
        { 
               List<Product>Products = _dbcontext.Products.OrderByDescending((product)=>product.Rating).ToList();    


            return View(Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}