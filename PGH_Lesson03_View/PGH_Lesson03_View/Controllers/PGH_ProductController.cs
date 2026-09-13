using Microsoft.AspNetCore.Mvc;
using PGH_Lesson03_View.Models;

namespace PGH_Lesson03_View.Controllers
{
    public class PGH_ProductController : Controller
    {
        // Giả lập danh sách sản phẩm (hoặc lấy từ Database qua DbContext)
        private List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop Dell XPS", Price = 1500, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "Tủ lạnh Panasonic", Price = 800, CategoryId = 2 },
                new Product { ProductId = 3, ProductName = "Nồi cơm điện Cuckoo", Price = 120, CategoryId = 3 },
                new Product { ProductId = 4, ProductName = "Ổ cắm điện thông minh", Price = 25, CategoryId = 4 }
            };
        }

        // Trang danh sách sản phẩm: GET /Product
        public IActionResult Index()
        {
            var products = GetSampleProducts();
            return View(products);
        }

        // Trang chi tiết sản phẩm: GET /Product/Detail/1
        public IActionResult Detail(int id)
        {
            var product = GetSampleProducts().FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}