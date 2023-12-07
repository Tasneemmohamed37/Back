using Day_1_Demo.Models;
using Day_1_Demo.Repository;
using Day_1_Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Day_1_Demo.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository deptRepository;

        //inject
        public DepartmentController(IDepartmentRepository deptRep)
        {
            deptRepository = deptRep;
        }

        public IActionResult Index()
        {
            return View("Index", deptRepository.GetAll());
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult SaveNew(Department newDept)
        {
            if (newDept.Name != null)
            {
                deptRepository.Insert(newDept);
                deptRepository.Save();
                return RedirectToAction("Index");
            }
            return View("New", newDept);
        }

        // want to make action return department+list<branch> +color + datetime + temprature
        public IActionResult Details(int id)
        {
            Department deptModel = deptRepository.GetById(id);

            List<string> Branchs = new List<string>();
            Branchs.Add("Alex");
            Branchs.Add("smart");
            Branchs.Add("assuit");
            Branchs.Add("munofia");

            string color = "red";

            string d = DateTime.Now.ToShortTimeString();

            int temp = 37;

            // viewdata is dictionary with key , value
            ViewData["branchs"] =Branchs;
            ViewData["color"] =  color;
            ViewData["date"] = d;
            //ViewData["temp"] =  temp;
            ViewBag.temp=temp; // set by view bag 
            ViewBag.color = "blue";

            return View("Details", deptModel);
            // view name = Details , model = department , viewData = 
        }


        // want to make action return department+list<branch> +color + datetime + temprature
        public IActionResult DetailsVm(int id)
        {
            Department deptModel = deptRepository.GetById(id);

            List<string> Branchs = new List<string>();
            Branchs.Add("Alex");
            Branchs.Add("smart");
            Branchs.Add("assuit");
            Branchs.Add("munofia");


           //create obj from view model
           var ModelVm= new DepartmentWithBranchsColorTempDateViewModel();

           //fill vm -> mapping from model to vm (automapper)
           ModelVm.DeptId = deptModel.Id;
            ModelVm.DeptName = deptModel.Name;
            ModelVm.Color = Branchs.Count > 3 ? "blue" : "red";
            ModelVm.Temp = 37;
            ModelVm.Date= DateTime.Now.ToShortTimeString();
            ModelVm.Branchs = Branchs;

           //return view with model
            return View("DetailsVm", ModelVm);
            // view name = Details , model = viewModel
        }
    }
}
