using Day_1_Demo.Models;

namespace Day_1_Demo.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        //CRUD
        ITIContext con;

        public DepartmentRepository(ITIContext _con)
        {
            con = _con;
        }

        public List<Department> GetAll()
        {
            return con.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return con.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Department department)
        {
            con.Update(department);
        }

        public void Delete(int id)
        {
            Department deptOrg = GetById(id);
            con.Departments.Remove(deptOrg);
        }

        public void Insert(Department department)
        {
            con.Departments.Add(department);
        }

        public void Save()
        {
            con.SaveChanges();
        }
    }
}
