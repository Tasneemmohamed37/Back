using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using task_2.Repository.CourseRepository;
using task_2.Repository.DepartmentRepository;

namespace task_2.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {

        public IActionResult CheckMinDegree(int MinDegree, int Degree)
        {
            if (MinDegree < Degree)
            {
                return Json(true);
            }
            return Json(false);
        }



        ICourseRepository _courseRepository;
        IDepartmentRepository _departmentRepository;

        //inject
        public CourseController(ICourseRepository _courseRep , IDepartmentRepository _departmentRep)
        {
            _courseRepository = _courseRep;
            _departmentRepository = _departmentRep;
        }


        public IActionResult Index()
        {
            return View("Index", _courseRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["deptList"] = _departmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course src)
        {
            if(ModelState.IsValid == true)
            {
                _courseRepository.Insert(src);
                _courseRepository.Save();
                return RedirectToAction("Index");
            }
            ViewData["deptList"] = _departmentRepository.GetAll();
            return View("Create", src);
        }
    }
}
