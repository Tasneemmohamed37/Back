using Day_1_Demo.Models;
using Day_1_Demo.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Day_1_Demo
{
    public class Program
    {
        /* Web App Setting - Web App Run*/
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();//.AddSessionStateTempDataProvider(); -> to change defualt behaivure for temp and will store it in session

            //register connection string
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<ApplicationUser , IdentityRole>().AddEntityFrameworkStores<ITIContext>();

            builder.Services.AddSession(); //conf for middleware must before builder.build

            // register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline. => Day2 Middlewares
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization(); // hint for you to add authentcation middle ware also

            app.UseSession();  //to use session should in programe use[app.UseSession() -> before map && app.AddSession() -> before bulder]

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}