using task_2.Models;

namespace task_2.Repository.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
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

        public void Update(Department dept)
        {
            con.Update(dept);
        }

        public void Delete(int id)
        {
            Department dept = GetById(id);
            con.Departments.Remove(dept);
        }

        public void Insert(Department dept)
        {
            con.Departments.Add(dept);
        }

        public void Save()
        {
            con.SaveChanges();
        }
    }
}
