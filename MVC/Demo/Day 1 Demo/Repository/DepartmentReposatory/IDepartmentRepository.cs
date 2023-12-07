using Day_1_Demo.Models;

namespace Day_1_Demo.Repository
{
    public interface IDepartmentRepository
    {
        void Delete(int id);
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department department);
        void Save();
        void Update(Department department);
    }
}