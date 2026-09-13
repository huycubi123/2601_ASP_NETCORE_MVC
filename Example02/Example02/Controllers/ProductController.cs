using Example02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example02.Controllers
{
    //[Route("/productMain")]  // khi này đường dẫn sẽ thành /productMain/product/index, nếu muốn đường dẫn là /product thì phải đặt ở trên action method Index
    public class ProductController : Controller
    {
        [Route("/product")]  // đường dẫn truy cập vào action method này là /product (không cần Product/product hay Product/Inedx như cũ nữa), nếu vị trí đặt ở trên Controller thì mới cần 
        public IActionResult Index()
        {
            ViewBag.Message = "Dữ liệu truyền qua ViewBag";
            ViewData["Message"] = "Dữ liệu truyền qua ViewData";
            TempData["Message"] = "Dữ liệu truyền qua TempData";
            return View();
        }

        // Tạo 1 action method để trả về view product.cshtml
        public IActionResult GetProduct()
        {
            Product p = new Product() {
                Id = 1,
                Name = "Iphone 14 Pro Max",
                YearRelease = 2022,
                Price = 30000000
            };
            ViewBag.Product = p;
            ViewData["Product"] = p;
            TempData["Product"] = p;  //khi gọi thì phải truyền

            return View();
        }

        public IActionResult GetAllProduct()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Iphone 14 Pro Max", YearRelease = 2022, Price = 30000000 },
                new Product() { Id = 2, Name = "Iphone 13 Pro Max", YearRelease = 2021, Price = 25000000 },
                new Product() { Id = 3, Name = "Iphone 12 Pro Max", YearRelease = 2020, Price = 20000000 },
                new Product() { Id = 4, Name = "Iphone 11 Pro Max", YearRelease = 2019, Price = 15000000 },
                new Product() { Id = 5, Name = "Iphone Xs Max", YearRelease = 2018, Price = 10000000 }
            };
            ViewBag.Products = products;
            return View(products);  // truyền là chỉ dùng khi truyền qua model
        }

        [Route("search/{name}")]
        public IActionResult Search(string name)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Iphone 14 Pro Max", YearRelease = 2022, Price = 30000000 },
                new Product() { Id = 2, Name = "Iphone 13 Pro Max", YearRelease = 2021, Price = 25000000 },
                new Product() { Id = 3, Name = "Iphone 12 Pro Max", YearRelease = 2020, Price = 20000000 },
                new Product() { Id = 4, Name = "Iphone 11 Pro Max", YearRelease = 2019, Price = 15000000 },
                new Product() { Id = 5, Name = "Iphone Xs Max", YearRelease = 2018, Price = 10000000 }
            };
            var productSearch = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            ViewBag.Products = productSearch;
            return View(productSearch);  // truyền là chỉ dùng khi truyền qua model
        }
        //public IActionResult Search(string name)
        //{
        //    List<Product> products = new List<Product>()
        //    {
        //        new Product() { Id = 1, Name = "Iphone 14 Pro Max", YearRelease = 2022, Price = 30000000 },
        //        new Product() { Id = 2, Name = "Iphone 13 Pro Max", YearRelease = 2021, Price = 25000000 },
        //        new Product() { Id = 3, Name = "Iphone 12 Pro Max", YearRelease = 2020, Price = 20000000 },
        //        new Product() { Id = 4, Name = "Iphone 11 Pro Max", YearRelease = 2019, Price = 15000000 },
        //        new Product() { Id = 5, Name = "Iphone Xs Max", YearRelease = 2018, Price = 10000000 }
        //    };
        //    var productSearch = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
        //    ViewBag.Products = products;
        //    return View(products); // như này khi ở đường dẫn sẽ phải có thêm ? name = ...
        //}
    }
}
