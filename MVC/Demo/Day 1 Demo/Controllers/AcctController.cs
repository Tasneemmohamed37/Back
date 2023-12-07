using Microsoft.AspNetCore.Mvc;

namespace Day_1_Demo.Controllers
{
    public class AcctController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username , string password)
        {
            if(username == "tasneem" && password == "123")
            {
                return RedirectToAction("Index", "Employee");
            }
            return View("Login");
        }
    }
}
