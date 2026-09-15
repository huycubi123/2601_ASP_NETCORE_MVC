using Microsoft.AspNetCore.Mvc;
using PGH_Lesson04_Model.Models.DataModels;

namespace PGH_Lesson04_Model.Controllers
{
    public class PGH_MemberController : Controller
    {
        // Thêm từ khóa static để danh sách không bị Reset mỗi khi Controller tạo lại
        private static List<PGH_Member> listMember = new List<PGH_Member>()
        {
            new PGH_Member { MemberId = "M01", FullName = "Phạm Gia Huy", UserName = "giahuy", Email = "huy@gmail.com", Password = "123" },
            new PGH_Member { MemberId = "M02", FullName = "Nguyễn Văn A", UserName = "nva", Email = "anv@gmail.com", Password = "123" },
            new PGH_Member { MemberId = "M03", FullName = "Trần Thị B", UserName = "ttb", Email = "btt@gmail.com", Password = "123" }
        };

        public IActionResult Index()
        {
            return View(listMember);
        }

        public IActionResult GetMember()
        {
            var pgh_member = new PGH_Member
            {
                MemberId = Guid.NewGuid().ToString(),
                FullName = "John Doe",
                UserName = "johndoe",
                Email = "huy@gmail.com",
                Password = Guid.NewGuid().ToString()
            };
            return View(pgh_member);
        }

        // 1. Mở comment hàm GET này để hiển thị form Create
        [HttpGet]
        public IActionResult Create()
        {
            var pgh_member = new PGH_Member();
            return View(pgh_member);
        }

        // 2. Hàm POST xử lý khi người dùng nhấn Submit
        [HttpPost]
        public IActionResult Create(PGH_Member pgh_member)
        {
            if (ModelState.IsValid)
            {
                listMember.Add(pgh_member);
                return RedirectToAction("Index");
            }
            return View(pgh_member);
        }
    }
}