using Day_1_Demo.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day_1_Demo.Controllers
{
    public class ServisesController : Controller
    {

        [Authorize]
        public IActionResult testClaims()
        {
            string name = User.Identity.Name;
            Claim idClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return Content("Claim to user" + name + "with id " + idClaim.Value);
        }


        [MyFilter]
        public IActionResult test()
        {
            return Content("hi");
        }
    }
}
