using Demo.Models;

namespace Demo.Repository
{
    public interface IEmployeeRepository
    {
        void Delete(int id);
        List<Employee> GetAll();
        Employee GetByID(int id);
        void Insert(Employee employee);
        int Save();
        void Update(Employee newEmployee);
    }
}