using Demo.Models;
using Demo.Repository;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class Program
    {
        /*web application setting - web application run*/
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. day8 DI (Interface,class) ==REgister (services)
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("mycs"));
            });


            //REgister Custom Services
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline. Day2 Middlewares
            #region My own Custom Pipleline

            //app.Use(async(httpContext, next) => {
            //    await httpContext.Response.WriteAsync("1-Middleware1 \n");
            //    await next.Invoke();//Waiting 
            //    await httpContext.Response.WriteAsync("1-1 Middleware1 \n");

            //});
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("2-Middleware2 \n");
            //    await next.Invoke();//Waiting
            //    await httpContext.Response.WriteAsync("2-2 Middleware2 \n");

            //});



            //app.Run(async(httpContext) => { 
            //    await httpContext.Response.WriteAsync("3-Terminate \n");
            //});

            #endregion


            #region Default Pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }//---
            app.UseStaticFiles();//boots.css ,jqury.js
            //-----------------
            app.UseRouting();//DEpartment/index
            //---------
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            
            #endregion
            //-----------------------------------------------------
            app.Run();
        }
    }
}