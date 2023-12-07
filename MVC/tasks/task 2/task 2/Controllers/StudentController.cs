using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using task_2.ViewModel;

namespace task_2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowResult(int id , int crsId)
        {
            //get data from db
            ITIContext context = new ITIContext();
            var std = context.Trinees.FirstOrDefault(s => s.Id == id);
            var crs = context.Courses.FirstOrDefault(c => c.Id == crsId);
            var crsRst = context.SrcResults.FirstOrDefault(c => c.Trinee_Id == id && c.Crs_Id == crsId);

            //2.1 create obj from vm
            var ModelVm = new StudentWithCourseNameDegreeColorViewModel();

            //2.2 fill vm
            ModelVm.StdId = std.Id;
            ModelVm.StdName = std.Name;
            ModelVm.CrsName = crs.Name;
            ModelVm.CrsDegree = crsRst.Degree;
            ModelVm.Color = crs.MinDegree > crsRst.Degree ? "red" : "green";

            //send data to view
            return View(ModelVm);
        }
    }
}
