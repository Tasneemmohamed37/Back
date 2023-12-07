using Demo.Models;

namespace Demo.Repository
{
    public class EmpSampleDataREpository : IEmployeeRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {

            List<Employee> Emplist = new List<Employee>();
            Emplist.Add(new Employee { Id = 1, Name = "Ahmed" });
            Emplist.Add(new Employee { Id = 2, Name = "alaa" });
            return Emplist;
        }

        public Employee GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee newEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
