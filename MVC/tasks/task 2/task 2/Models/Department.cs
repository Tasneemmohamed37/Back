namespace task_2.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Maneger { get; set; }

        public  ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>(); //nav prop -> many
        public  ICollection<Course> Courses { get; set; } = new HashSet<Course>(); //nav prop -> many
        public  ICollection<Trinee> Trinees { get; set; } = new HashSet<Trinee>(); //nav prop -> many
    }
}
