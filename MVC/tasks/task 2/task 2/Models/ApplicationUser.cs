using Microsoft.AspNetCore.Identity;

namespace task_2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
