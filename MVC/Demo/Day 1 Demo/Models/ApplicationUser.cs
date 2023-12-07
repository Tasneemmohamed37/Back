using Microsoft.AspNetCore.Identity;

namespace Day_1_Demo.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Address { get; set; }
    }
}
