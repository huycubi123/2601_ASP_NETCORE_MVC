namespace Example02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            // Tạo route cho action method GetAllProduct trong ProductController nếu không tạo route trên file ProductController.cs
            //app.MapControllerRoute(
            //    name: "product",
            //    pattern: "sanpham/danh-sach-sanpham",
            //    defaults: new { controller = "Product" ,action = "GetAllProduct"} );

            app.Run();
        }
    }
}
