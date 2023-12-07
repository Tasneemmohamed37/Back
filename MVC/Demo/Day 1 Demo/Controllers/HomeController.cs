using Day_1_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_1_Demo.Controllers
{
    /* catch request
     * get data from model
     * send data to view
    */
    public class HomeController : Controller
    {
        #region Intro Day1

        /* Method Called Action
            1- must be public
            2- cant be static
            3- cant be overload
         */

        // request it in url by -> home/showtext 
        // routing engine work now


        // !!!!!!!! parent class for all action return -> actionresult | Iactionresult !!!!!!!!!
        /* Action return     class for it
            1- content      contentResult
            2- view         view result
            3- json         jsonresult
            ...........
         */
        //public string ShowText()
        //{
        //    return "hello world !!";
        //}

        public ContentResult Showcontext()
        {
            //logic
            //1- declare contentresult
            ContentResult result = new ContentResult();

            //2- set data
            result.Content = "hello world";

            //3- return
            return result;
        }

        public ViewResult ShowView()
        {
            //logic
            //1- declare contentresult
            ViewResult result = new ViewResult();

            // set data
            result.ViewName = "View1";
            // views / home [folder same as controller name] /view1.cshtml
            // if not found in priveus path will see -> views/shared/view1.cshtml
            // else -> throw exeption

            // return
            return result;
        }


        // business logic ->  Action URL if age < 10 return content & age> 10 return view1
        // home/showmix?age=5
        public IActionResult ShowMix(int Age)
        {
            if (Age < 10)
            {
                return Content("hello world by built in content !!");
            }
            else
            {
                //dry [dont repeat your self]
                 return View("View1");
            }
        }

        

        #endregion

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