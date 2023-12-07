namespace Demo.Models
{
    public class StudentSampleData
    {
        List<Student> students;
        public StudentSampleData()
        {
            students= new List<Student>();
            students.Add(new Student() { Id = 1 ,Name="Ahmed",Address="Cairo",ImageUrl="m.png"}); ;
            students.Add(new Student() { Id = 2, Name = "Amira", Address = "Alex", ImageUrl = "2.jpg" }); ;
            students.Add(new Student() { Id = 3, Name = "Adel", Address = "Mansoura", ImageUrl = "m.png" }); ;
            students.Add(new Student() { Id = 4, Name = "Abdelrahman", Address = "Cairo", ImageUrl = "m.png" }); ;
            students.Add(new Student() { Id = 5, Name = "Abdelrahman", Address = "Cairo", ImageUrl = "m.png" }); ;


        }
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
