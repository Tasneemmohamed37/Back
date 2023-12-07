namespace Day_1_Demo.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ManegerName { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>() ;   // nav prop -> many
    }
}
