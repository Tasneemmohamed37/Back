using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StudentController : Controller
    {
        //Action (public ,cant overload ,cant static
        //Student/Method1 :Get
        [HttpGet]
        public IActionResult Method1()
        {
            return Content("Get Method1");
        }
        //Student/Method1 :Post
        [HttpPost]
        public IActionResult Method1(int id)
        {
            return Content("Post MEthod");
        }




        public IActionResult All()
        {
            //ask model
            StudentSampleData sampleData= new StudentSampleData();
            List<Student> stdListModel=
                sampleData.GetAllStudents();
            //send view
            return View("ShowAll",stdListModel);
            //view name =ShowAll ,Model  ==>List<Student>
        }
        public IActionResult DEatils(int id)
        {
            StudentSampleData sampleData = new StudentSampleData();
            Student stdModel =
                sampleData.GetAllStudents()
                .FirstOrDefault(s=>s.Id==id);
            return View("Details",stdModel);
            //view name="DEtails" , Model =Student
        }
    }
}
