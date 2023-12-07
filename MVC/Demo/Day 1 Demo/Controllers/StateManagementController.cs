using Microsoft.AspNetCore.Mvc;

namespace Day_1_Demo.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult SetCookie()
        {
            Response.Cookies.Append("name", "tasneem ):");
            Response.Cookies.Append("age", "22");
            return Content("set cookie sucess");
        }
        public IActionResult GetCookie()
        {
            string name = Request.Cookies["name"];
            int age = int.Parse(Request.Cookies["age"]);
            return Content($"hello {name} with age = {age}");
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("name", "tasneem ):");
            HttpContext.Session.SetInt32("age", 22);
            return Content("set session sucess");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("name");
            int age = HttpContext.Session.GetInt32("age").Value;
            return Content($"hello {name} with age = {age}");
        }

        public IActionResult SetTempData()
        {
            //set to temp
            TempData["msg"] = "Massege set hello :)";
            return Content("data saved!!");
        }
        public IActionResult get1()
        {
            string msg = "empty msg";

            //read from temp but check first
            if (TempData.ContainsKey("msg"))
            {
                //msg = TempData["msg"].ToString(); // -->  normal read
                msg = TempData.Peek("msg").ToString(); // --> peek read :: save data for only more one request
               
            }

            return Content("get1" + msg);
        }
        public IActionResult get2()
        {
            string msg = TempData["msg"].ToString(); // normal read 
            TempData.Keep("msg"); // keep --> save data  until session end

            return Content("get2" + msg);
        }
    }
}
