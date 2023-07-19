using Microsoft.AspNetCore.Mvc;

namespace myreviewapplication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult Logout() {
            return View();
        }
        public IActionResult Signup() {
            return View(); 
        }
    }
}
