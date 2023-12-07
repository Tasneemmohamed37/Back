namespace Day_1_Demo.Models
{
    public class StudentSampleData
    {
        List<Student> students;

        public StudentSampleData()
        {
            students = new List<Student>();
            students.Add(new Student() { Id = 1 , Name="tasneem" , Address="minia" , ImageURL="m.png"});
            students.Add(new Student() { Id = 2 , Name="hamada" , Address="cairo" , ImageURL="2.png"});
            students.Add(new Student() { Id = 3 , Name="ayman" , Address="alex" , ImageURL="2.png"});
            students.Add(new Student() { Id = 4 , Name="aya" , Address="minia" , ImageURL="m.png"});
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
