using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    
    public class EmployeeController : Controller
    {
        //        ITIContext context = new ITIContext();
        //DIP
        IEmployeeRepository EmployeeRepository=null;
        IDepartmentRepository DepartmentRepository;
        //not create but ask (inject) (Denpency inject) [IOC Container]
        //Construct as parameter
        //Method    as parameter
        public EmployeeController
            (IEmployeeRepository EmpRepo, IDepartmentRepository DEptRepo)
        {
            //IOC
            EmployeeRepository =  EmpRepo;//ask
            DepartmentRepository = DEptRepo;
        }
        //
        public IActionResult CheckAge
            (int Age,string Name)
        {
            if(Age%5 == 0 )//&& Name =="ITI")
            {
                return Json(true);
            }
            return Json(false);
        }
       
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public IActionResult Index()
        {
            return View("Index",EmployeeRepository.GetAll());
        }

        public IActionResult Edit(int id)
        {
            //old refen
            Employee emp=EmployeeRepository.GetByID(id);
            List<Department> departmentList =DepartmentRepository.GetAll();
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
                    EmployeeRepository.Update(EmpReq);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }

            List<Department> departmentList = DepartmentRepository.GetAll(); ;
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
            ViewData["depts"] = DepartmentRepository.GetAll();
            return View("New");//
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Employee newEmployee)
        {
            //if (newEmployee.Name != null && newEmployee.Salary<30000)
            if(ModelState.IsValid==true)
            {
                try
                {
                    EmployeeRepository.Insert(newEmployee);
                    EmployeeRepository.Save();
                    
                    return RedirectToAction("Index");
                }catch(Exception ex) {
                    //custrom error ex ==>Front
                    //ModelState.AddModelError("MyError", ex.InnerException.Message);
                    ModelState.AddModelError("DeptId", "Select DEpartment");
                }
            }
            ViewData["depts"] = DepartmentRepository.GetAll();

            return View("New",newEmployee);//

        }
    }
}
