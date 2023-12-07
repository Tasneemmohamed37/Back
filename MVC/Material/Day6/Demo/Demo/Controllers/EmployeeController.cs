using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    
    public class EmployeeController : Controller
    {
        //
        public IActionResult CheckAge(int Age,string Name)
        {
            if(Age%5 == 0 )//&& Name =="ITI")
            {
                return Json(true);
            }
            return Json(false);
        }
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            return View("Index",context.Employees.ToList());
        }

        public IActionResult Edit(int id)
        {
            //old refen
            Employee emp= context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> departmentList =
                context.Department.ToList() ;
            ViewData["deptList"] = departmentList;
            //view
            return View("Edit",emp);//Employee
        }
        //Requst (Get |Post)
        [HttpPost]//filtter
        public IActionResult SaveEdit(Employee EmpReq,int id)
        {
            //if (Request.Method == "POST")
            //{
                if (EmpReq.Name != null && EmpReq.Salary < 30000)
                {
                    //savecore 7
                    context.Update(EmpReq);
                    //context.SaveChanges();
                    Employee orgEmp = context.Employees.FirstOrDefault(e => e.Id == id);
                    orgEmp.Name = EmpReq.Name;
                    orgEmp.Salary = EmpReq.Salary;
                    orgEmp.Age = EmpReq.Age;
                    orgEmp.Address = EmpReq.Address;
                    orgEmp.ImageUrl = EmpReq.ImageUrl;
                    orgEmp.DeptId = EmpReq.DeptId;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                List<Department> departmentList =
                       context.Department.ToList();
                ViewData["deptList"] = departmentList;

                return View("Edit", EmpReq);

            //}
            //else
            //{
            //    return NotFound("");
            //}
        }

        public IActionResult New()
        {
            ViewData["depts"] = context.Department.ToList();
            return View("New");//
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Employee newEmployee)
        {
            //if (newEmployee.Name != null && newEmployee.Salary<30000)
            if(ModelState.IsValid==true)
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();//run throw exxcpeiton
                return RedirectToAction("Index");
                
            }
            ViewData["depts"] = context.Department.ToList();
            return View("New",newEmployee);//

        }
    }
}
