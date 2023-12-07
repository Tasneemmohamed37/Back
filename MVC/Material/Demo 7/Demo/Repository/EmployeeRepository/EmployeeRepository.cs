using Demo.Models;

namespace Demo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _Context)
        {
            context = _Context;// new ITIContext();
        }
        //CRUD Employee
        public List<Employee> GetAll()//string include)
        {
            return context.Employees.ToList();
        }
        public Employee GetByID(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee newEmployee)
        {

            //.net 7
            //context.Update(employee);
            //.net less than 7
            Employee EmpOrg = GetByID(newEmployee.Id);
            EmpOrg.Name = newEmployee.Name;
            EmpOrg.Salary = newEmployee.Salary;
            EmpOrg.Address = newEmployee.Address;
            EmpOrg.Age = newEmployee.Age;
            EmpOrg.ImageUrl = newEmployee.ImageUrl;
            EmpOrg.DeptId = newEmployee.DeptId;
        }

        public void Delete(int id)
        {
            Employee EmpOrg = GetByID(id);
            //context.Remove(EmpOrg);
            context.Employees.Remove(EmpOrg);
        }

        public void Insert(Employee employee)
        {
            context.Employees.Add(employee);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
