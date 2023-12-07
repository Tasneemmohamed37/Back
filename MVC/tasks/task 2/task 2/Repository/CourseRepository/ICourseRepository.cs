using task_2.Models;

namespace task_2.Repository.CourseRepository
{
    public interface ICourseRepository
    {
        void Delete(int id);
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course crs);
        void Save();
        void Update(Course crs);
    }
}