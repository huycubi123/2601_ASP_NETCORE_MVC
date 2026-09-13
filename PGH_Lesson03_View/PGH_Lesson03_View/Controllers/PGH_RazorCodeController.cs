using Microsoft.AspNetCore.Mvc;

namespace PGH_Lesson03_View.Controllers
{
    public class PGH_RazorCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
