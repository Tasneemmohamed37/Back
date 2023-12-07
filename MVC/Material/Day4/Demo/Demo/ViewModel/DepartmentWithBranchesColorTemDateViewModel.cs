using Demo.Models;

namespace Demo.ViewModel
{
    public class DepartmentWithBranchesColorTemDateViewModel
    {
        
        public int DeptID { get; set; }
        public string  DeptName { get; set; }
        public string Color { get; set; }
        public int Temp { get; set; }
        public string Date { get; set; }
        public List<string> Branches { get; set; }
            =new List<string>();
        
    }
}
