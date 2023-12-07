using task_2.Models;

namespace task_2.Repository.CourseRepository
{
    public class CourseRepository : ICourseRepository
    {
        ITIContext con;

        public CourseRepository(ITIContext _con)
        {
            con = _con;
        }

        public List<Course> GetAll()
        {
            return con.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return con.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Course crs)
        {
            con.Update(crs);
        }

        public void Delete(int id)
        {
            Course crs = GetById(id);
            con.Courses.Remove(crs);
        }

        public void Insert(Course crs)
        {
            con.Courses.Add(crs);
        }

        public void Save()
        {
            con.SaveChanges();
        }
    }
}
