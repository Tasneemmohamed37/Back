
using System.Security.Principal;

namespace Demo.Models
{
    public class Department
    {
        public int Id { get; set; }/*pk idenityt*/
        public string Name { get; set; }
        public string ManagerNAme { get; set; }

        public List<Employee>? Emps { get; set; }
    }
}