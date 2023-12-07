using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    /*Database*/
    public class ITIContext:DbContext
    {
       
        public ITIContext()//:base()
        {

        }
        ////Day8
        public ITIContext(DbContextOptions<ITIContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DotNet2324;Integrated Security=True;Encrypt=False");
        }

        //Dbset ==>table
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
    }
}
