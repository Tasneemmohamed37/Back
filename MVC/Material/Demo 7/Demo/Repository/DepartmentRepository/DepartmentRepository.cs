using Demo.Models;

namespace Demo.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext context;

        public Guid ID { get; set; }

        public DepartmentRepository(ITIContext _Context)
        {
            context = _Context;
            ID= Guid.NewGuid();//unique id
        }
        //CRUD Employee
        public List<Department> GetAll()//string include)
        {
            return context.Department.ToList();
        }
        public Department GetByID(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Department newDept)
        {

            //.net 7
            //context.Update(employee);
            //.net less than 7
            Department DeptOrg = GetByID(newDept.Id);
            DeptOrg.Name = newDept.Name;
            DeptOrg.ManagerNAme = newDept.ManagerNAme;
        }

        public void Delete(int id)
        {
            Department DeptOrg = GetByID(id);
            //context.Remove(EmpOrg);
            context.Department.Remove(DeptOrg);
        }

        public void Insert(Department department)
        {
            context.Department.Add(department);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
