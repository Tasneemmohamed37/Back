using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string userName,string password)
        {
            if (userName == "Christen" && password == "123")
                return RedirectToAction("Index", "Employee");
            else
                return View("Login");
        }
    }
}
