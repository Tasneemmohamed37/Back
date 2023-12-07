using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using task_2.Models;
using task_2.ViewModel;

namespace task_2.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //Mapping from VM to model[applicationuser]
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                //save db
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);

                //check
                if (result.Succeeded)
                {
                    //await userManager.AddToRoleAsync(userModel, "Student");

                    //create cookies
                    // first overload whick create cookie include[id - name - role]
                    await signInManager.SignInAsync(userModel, false);

                    #region or second overload in which cookie will include claim
                    //List<Claim> claims = new List<Claim>();
                    //claims.Add(new Claim("color", "red"));
                    //await signInManager.SignInWithClaimsAsync(userModel, false , claims); 
                    #endregion

                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    //exeption
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                        return View(newUserVM);
                    }
                }
            }
            return View(newUserVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                //check db
                ApplicationUser userModel = await userManager.FindByNameAsync(userVM.UserName);
                if (userModel != null)
                {
                    bool checkPass = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (checkPass)
                    {
                        //create cookie
                        await signInManager.SignInAsync(userModel, userVM.RememberMe);
                        return RedirectToAction("Index", "Course");
                    }
                }
                ModelState.AddModelError("", "Please Enter Correct UserName And Password");


            }
            return View(userVM);
        }

    }
}
