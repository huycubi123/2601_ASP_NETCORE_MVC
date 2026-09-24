using Lesson06_EFCore_CodeFIrst.Models.BusinessModels;
using Microsoft.EntityFrameworkCore;

namespace Lesson06_EFCore_CodeFIrst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // Đăng ký BusinessDBContext với chuỗi kết nối từ appsettings.json
            builder.Services.AddDbContext<BusinessDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConn")));

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
