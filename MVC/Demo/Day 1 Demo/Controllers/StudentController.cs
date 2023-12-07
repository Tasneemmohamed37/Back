using Day_1_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_1_Demo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult All()
        {
            //ask model [get data from model]
            StudentSampleData data = new StudentSampleData();
            List<Student> stdListModel = data.GetStudents();

            //send data to view
            return View("ShowAll", stdListModel);

            // view-> showAll  , model-> list<std> 
            //URL -> /Student/all
        }

        public IActionResult Details(int id)
        {
            //ask model
            StudentSampleData sampleData = new StudentSampleData();
            Student stdModel = sampleData.GetStudents().FirstOrDefault(s => s.Id == id);

            //send data to view
            return View("Details",stdModel);

            //view -> details , model -> student
            //URL == /Student/details?id=1
        }
    }
}
