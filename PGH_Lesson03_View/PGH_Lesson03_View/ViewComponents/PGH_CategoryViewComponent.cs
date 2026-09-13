using Microsoft.AspNetCore.Mvc;
using PGH_Lesson03_View.Models;
namespace PGH_Lesson03_View.ViewComponents
{
    public class PGH_CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int ?n)
        {
            List<Category> categories = new List<Category>()
            {
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Books" },
                new Category { CategoryId = 3, CategoryName = "Clothing" },
                new Category { CategoryId = 4, CategoryName = "Home & Kitchen" }
            };
            n = n ?? 0; // nếu n là null thì gán giá trị mặc định là 0
            var search = categories.Where(c => c.CategoryId > n).ToList();
            return View(categories);
        }
    }
}
