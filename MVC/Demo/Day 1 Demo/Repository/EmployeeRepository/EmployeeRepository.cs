using Day_1_Demo.Models;

namespace Day_1_Demo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //CRUD
        ITIContext con;

        public EmployeeRepository(ITIContext _con)
        {
            con = _con;
        }

        public List<Employee> GetAll()
        {
            return con.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return con.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee employee)
        {
            con.Update(employee);
        }

        public void Delete(int id)
        {
            Employee emp = GetById(id);
            con.Employees.Remove(emp);
        }

        public void Insert(Employee employee)
        {
            con.Employees.Add(employee);
        }

        public void Save()
        {
            con.SaveChanges();
        }
    }
}
