using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.ApplicationServices;
using ToDoList.Domain.Core.Contracts.ApplicationService;
using ToDoList.Domain.Core.Contracts.Repository;
using ToDoList.Domain.Core.Contracts.Service;
using ToDoList.Domain.Services;
using ToDoList.Infra.Data.Repos.Ef;
using ToDoList.Infra.Db.SqlServer.Ef;

namespace ToDoList.Presentation.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HW19;User ID=sa;Password=Az@r4180;Trust Server Certificate=True "));

            builder.Services.AddScoped<IUserService, UserServices>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserApplicationService, UserApplicationServices>();

            builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            builder.Services.AddScoped<IToDoListService, ToDoListServices>();
            builder.Services.AddScoped<IToDoListApplicationService, ToDoListApplicationServices>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryServices>();
            builder.Services.AddScoped<ICategoryApplicationService, CategoryApplicationServices>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
