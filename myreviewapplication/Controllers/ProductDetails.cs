using Microsoft.AspNetCore.Mvc;
using myreviewapplication.ProductData;
namespace myreviewapplication.Controllers
{
    public class ProductDetails : Controller
    {


        public IActionResult ProductDetail(Guid Id)
        { 


            return View(ProductData.Productdata.myproddict[Id]);
        }
    }
}
