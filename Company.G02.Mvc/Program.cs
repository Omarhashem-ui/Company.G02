using AutoMapper;
using Company.G02.BLL.Interfaces;
using Company.G02.BLL.Repository;
using Company.G02.DAL.Dataa.Contexts;
using Company.G02.Mvc.Mapping;
using Company.G02.Mvc.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Company.G02.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>(); // allow Dependancy Injection (DI) for DepartmentRepository 
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddDbContext<CompanyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            }); // allow Dependancy Injection (DI) for CompanyDbContext

            builder.Services.AddAutoMapper(M=>M.AddProfile(new EmployeeProfile())); // allow Dependancy Injection (DI) for AutoMapper
            builder.Services.AddScoped<IScopedServices, ScopedServices>();
            builder.Services.AddSingleton<ISingeltonServices, SingeltonServices>();
            builder.Services.AddTransient<ITransientServices, TransientServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

         

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
