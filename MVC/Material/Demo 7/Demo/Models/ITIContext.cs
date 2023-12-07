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
        public ITIContext(DbContextOptions<ITIContext> options)//inject ask ==>service
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=dotnet2324;integrated security=true;encrypt=false");
        }

        //Dbset ==>table
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
    }
}
