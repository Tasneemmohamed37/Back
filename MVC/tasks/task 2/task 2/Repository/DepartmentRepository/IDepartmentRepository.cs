using task_2.Models;

namespace task_2.Repository.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        void Delete(int id);
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department dept);
        void Save();
        void Update(Department dept);
    }
}