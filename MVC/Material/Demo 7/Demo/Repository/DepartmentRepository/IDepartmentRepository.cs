using Demo.Models;

namespace Demo.Repository
{
    public interface IDepartmentRepository
    {
        Guid ID { get; set; }
        void Delete(int id);
        List<Department> GetAll();
        Department GetByID(int id);
        void Insert(Department department);
        int Save();
        void Update(Department newDept);
    }
}