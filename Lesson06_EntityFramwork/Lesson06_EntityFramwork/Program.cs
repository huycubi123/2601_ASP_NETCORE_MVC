using Lesson06_EntityFramwork.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson06_EntityFramwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Đăng ký DbContext với chuỗi kết nối từ appsettings.json để sử dụng Entity Framework Core
            var connectionString = builder.Configuration.GetConnectionString("BookStoreConn");
            builder.Services.AddDbContext<BookStoreContext>(options =>
                options.UseSqlServer(connectionString));
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
