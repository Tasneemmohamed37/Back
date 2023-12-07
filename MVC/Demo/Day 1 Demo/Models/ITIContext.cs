using Day_1_Demo.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace Day_1_Demo.Models
{
    public class ITIContext :IdentityDbContext<ApplicationUser>
    {

        public ITIContext():base()
        { 
        }

        //day 8
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
           
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DotNet2324;Integrated Security=True;Encrypt = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
