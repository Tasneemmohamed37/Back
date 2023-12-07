namespace Day_1_Demo.ViewModel
{
    public class DepartmentWithBranchsColorTempDateViewModel
    {
        //prefer to sepret obj 
        // wrong -->  public department dept { get; set; }
        //best -->public int DeptId { get; set; } && public string DeptName { get; set; }
        // but in case of list its ok

        public int DeptId { get; set; }

        public string DeptName { get; set; }
        public string Color { get; set; }

        public int Temp { get; set; }

        public string Date { get; set;}

        //dont forget!!!!! must initialized
        public List<string> Branchs { get; set; } = new List<string>();
    }
}
