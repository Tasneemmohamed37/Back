using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo.Controllers
{
    /*
     catch request
     get model data
     send data to view
     */
    public class HomeController : Controller
    {

        //Method called Action
        //1) must be public 
        //2) cant be static 
        //3) cant be overload

        //Home/ShowText 
        //public string ShowText()
        //{
        //    return "Hello World!!";
        //}
        public ContentResult ShowText()
        {
            //logic
            //DElare Object ContentREsult
            ContentResult result=new ContentResult();
            //Set Data
            result.Content = "Helllo World";
            //return 
            return result;
        }

        //Home/ShowView
        public ViewResult ShowView()
        {
            //logic
            //declare viewResult
            ViewResult result=new ViewResult();
            //set data
            result.ViewName= "View1";
            //Views/Home/View1.cshtml
            //Views/Shared/View1.cshtml
            //throw exception

            //return
            return result;
        }

        //action URL : age <10 Content   & age >10  View1
        //Home/ShowMix?age=10 (Query string)
        public ActionResult ShowMix(int age)
        {
            if (age < 10)
            {
                return Content("Hellow world");
            }
            else
            {//dry
                return View("View1");
            }
        }
        //ViewResult setview(string nameview)
        //{
        //    ViewResult result = new ViewResult();
        //    result.ViewName = nameview;
        //    return result;
        //}






        //Action return
        /*
            1- content(string)  =>ContentResult :ActionRestusl :IActionREsult
            2- View             =>ViewResult
            3- Json             =>JsonREault
            4- Unauthorize      =>UnauthorizeResult
            5- NotFound         =>NotFoundResult
            6- File
            7- Javascript
        //.....
         
         
         */








        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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