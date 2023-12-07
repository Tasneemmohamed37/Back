using Day_1_Demo.Models;
using Day_1_Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day_1_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult CheckAge(int Age, string Name)
        {
            if (Age % 5 == 0)//&& Name =="ITI")
            {
                return Json(true);
            }
            return Json(false);
        }

        IEmployeeRepository empRepository;
        IDepartmentRepository deptRepository;

        //DI -> dependency injection design pattern
        public EmployeeController(IEmployeeRepository empRep, IDepartmentRepository deptRep)
        {
            empRepository = empRep;
            deptRepository = deptRep;
        }

        [Authorize] //filter will check if cookie found ->exec action | if not found -> redirect to login
        public IActionResult Index()
        {
            return View("Index", empRepository.GetAll());
        }

        public IActionResult Edit(int id)
        {
            //old refen
            Employee emp = empRepository.GetById(id);
            List<Department> departmentList = deptRepository.GetAll();
            ViewData["deptList"] = departmentList;
            //view
            return View("Edit", emp);//Employee
        }


        //Requst (Get |Post)
        [HttpPost]
        public IActionResult SaveEdit(Employee EmpReq, int id)
        {
            if (EmpReq.Name != null && EmpReq.Salary < 30000)
            {
                empRepository.Update(EmpReq);
                empRepository.Save();
                return RedirectToAction("Index");
            }
            List<Department> departmentList = deptRepository.GetAll();
            ViewData["deptList"] = departmentList;
            return View("Edit", EmpReq);
        }

        
        public IActionResult New()
        {
            ViewData["deptList"] = deptRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Employee emp)
        {
            if(ModelState.IsValid==true)
            {
                try
                {
                    empRepository.Insert(emp);
                    empRepository.Save();
                    return RedirectToAction("index");
                }
                catch(Exception ex) 
                {
                    ModelState.AddModelError("DeptId", "must select Department");
                }
                
            }
            ViewData["deptList"] = deptRepository.GetAll();
            return View("New",emp);
        }
    }
}
