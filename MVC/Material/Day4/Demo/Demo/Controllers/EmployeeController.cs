using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
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
        [HttpPost]
        public IActionResult SaveEdit(Employee EmpReq,int id)
        {
            //if (Request.Method == "POST")
            //{
                //SAve database validation
                if (EmpReq.Name != null && EmpReq.Salary < 30000)
                {
                    //savecore 7
                    //context.Update(EmpReq);
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
    }
}
