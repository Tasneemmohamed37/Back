using Demo.Models;
using Demo.Repository;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Demo.Controllers
{
    //(High level class)
    public class DepartmentController : Controller
    {
        // ITIContext context = new ITIContext();
        //(low level class) //DIP X IOC
        IDepartmentRepository DeptRepository;

        
        public DepartmentController(IDepartmentRepository DeptRepository)//inject
        {
           this.DeptRepository= DeptRepository;
        }

        public IActionResult New()
        {
            return View("New");
        }

        public IActionResult SaveNew(Department newDept)//input name ==>property
        {
            if (newDept.Name != null)
            {
                
                DeptRepository.Insert(newDept);
                
                DeptRepository.Save();
                //return View("Index",context.Department.ToList());//back to list
                return RedirectToAction("Index");
            }
            return View("New",newDept);
        }
        //DRY
        //Department/Index
        public IActionResult Index()
        {
            List<Department> DepsModel=DeptRepository.GetAll();
            return View("Index",DepsModel);
            //view name=Index ,Model type= List<Department>
        }

        //Department/Details?deptId=1
        public IActionResult Details(int deptId)//id
        {
            //view (detail depsrte + list<braches> +color +datetime +temp 
            Department deptModel = DeptRepository.GetByID(deptId);

            List<string> brches= new List<string>();
            brches.Add("Alex");
            brches.Add("Smart");
            brches.Add("Assiut");
            brches.Add("Monofia");

            string color = "red";
            string datetime = DateTime.Now.ToShortDateString();
            //int temp = 39;

            ViewData["clr"] = "red";
            ViewData["brc"] = brches;
            ViewData["date"] = datetime;
            //ViewData["temp"] = temp;
            ViewBag.temp = 39;
            
            ViewBag.clr = "blue";
            //ViewData["clr"] = "blue";
            return View("Details", deptModel);//Model 
        }

        public IActionResult DetailsVm(int deptId)
        {
            Department deptModel = DeptRepository.GetByID(deptId);
                         
            List<string> brches = new List<string>();
            brches.Add("Alex");
            brches.Add("Smart");
            brches.Add("Assiut");
            brches.Add("Monofia");


            //create object from ViewModel
            var DeptVm =
                new DepartmentWithBranchesColorTemDateViewModel();
            //Mapping frm Model to ViewModel "Fill ViewModel" (automapper)
            DeptVm.DeptID = deptModel.Id;
            DeptVm.DeptName = deptModel.Name;
            DeptVm.Color= brches.Count() > 3 ? "red" : "blue";
            DeptVm.Date= DateTime.Now.ToShortDateString();
            DeptVm.Temp = 39;
            DeptVm.Branches = brches;

            //return view with model
            return View("DetailsVm", DeptVm);
            //View name =DEtailsVm , Model ==>ViewMode
        }
    }
}
