using Day_1_Demo.Models;

namespace Day_1_Demo.Repository
{
    public interface IEmployeeRepository
    {
        void Delete(int id);
        List<Employee> GetAll();
        Employee GetById(int id);
        void Insert(Employee employee);
        void Save();
        void Update(Employee employee);
    }
}