using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            //ask model
            ProductBL productBL = new ProductBL();
            List<Product> productListModel = productBL.GetAll();

            // send view
            return View("getAllPrds",productListModel);

            //view ->  , model -> list<product>
        }

        public IActionResult Details(int id)
        {
            //ask model
            ProductBL productBL = new ProductBL();
            Product prd = productBL.GetById(id);

            // send view
            return View("Details", prd);
            //view -> details , model->product
        }
    }
}
