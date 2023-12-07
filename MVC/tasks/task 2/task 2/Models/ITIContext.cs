using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace task_2.Models
{
    public class ITIContext :IdentityDbContext<ApplicationUser>
    {
        public ITIContext() : base()
        {
        }

        //day 8
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=khristenTasks;Integrated Security=True;Encrypt = False");
        //}

        public DbSet<Department> Departments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Trinee> Trinees  { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SrcResult> SrcResults { get; set; }
        
    }
}
