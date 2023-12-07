using Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public ServiceController(IDepartmentRepository deptRepo)//,IDepartmentRepository dept2)
        {
            this.deptRepo = deptRepo;
        }
        //Service/Index
        public IActionResult Index()
        {
            ViewData["ID"] = deptRepo.ID;
            return View();
        }
    }
}
