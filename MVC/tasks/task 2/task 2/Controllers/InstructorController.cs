using Microsoft.AspNetCore.Mvc;
using task_2.Models;

namespace task_2.Controllers
{
    public class InstructorController : Controller
    {
        ITIContext con = new ITIContext();

        //URL == Instructor/index
        public IActionResult Index()
        {
             // get data
            List<Instructor> InstListModel = con.Instructors.ToList();

            //send data to view
            return View("Index", InstListModel);
            // view name = index , model = list<inst>
        }

        public IActionResult Details(int id)
        {
            //get data
            var inst = con.Instructors.FirstOrDefault(d => d.Id == id);

            //send to view
            return View(inst);
        }

        public IActionResult New()
        {
            ViewBag.deptList = con.Departments.ToList();
            ViewBag.CrsList = con.Courses.ToList();
            return View();
        }

        public IActionResult SaveData(Instructor inst)
        {
           if(inst.Name != null)
            {
                con.Instructors.Add(inst);
                con.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New", inst);
        }

        public IActionResult Edit(int id)
        {
            Instructor inst = con.Instructors.FirstOrDefault(i => i.Id == id);
            ViewBag.DeptList = con.Departments.ToList();
            ViewBag.CrsList = con.Courses.ToList();
            return View(inst);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id , Instructor inst)
        {
            if (inst.Name != null && inst.Salary < 30000)
            {
                Instructor NewInst = con.Instructors.FirstOrDefault(i => i.Id == id);
                NewInst.Name = inst.Name;
                NewInst.Image = inst.Image;
                NewInst.Salary = inst.Salary;
                NewInst.Address = inst.Address;
                NewInst.Dept_Id = inst.Dept_Id;
                NewInst.Crs_Id = inst.Crs_Id;
                con.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptList = con.Departments.ToList();
            ViewBag.CrsList = con.Courses.ToList();
            return View("Edit", inst);

        }
    }
}
