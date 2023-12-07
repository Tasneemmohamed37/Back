using Day_1_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_1_Demo.Controllers
{
    public class BindingController : Controller
    {
        //Can Bind Primitive Prameter (int ,string ,float,...)
        //Binding/TestPrmitive?name=ahmed&age=34&id=100
        //Binding/TestPrmitive/100?name=ahmed&age=34
        public IActionResult TestPrmitive(int id, int age, string[] name)
        {
            return Content($"name={name[0]}\t age={age}");
        }

        //Binding to Collection (List ,Dictioary<key,value>)
        //Binding/TestDic?name=ahmed&phones[alaa]=123&phones[Amr]=456
        public IActionResult TestDic(string name, Dictionary<string, string> phones)
        {
            return Content("Success");
        }

        //Binding Complex Type "Class"
        //Binding/TestObj?ManagerNAme=ahmed&name=sd&id=100&Emps[0].Name
        //Binding/TestObj/90?ManagerNAme=ahmed&name=sd&Emps[0].Name
        public IActionResult TestObj(string name, Department dept)
        {
            return Content("success");
        }
    }
}
