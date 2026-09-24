using Lesson06_EFCore_CodeFIrst.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Lesson06_EFCore_CodeFIrst.Models.BusinessModels
{
    public class BusinessDBContext : DbContext
    {
        public BusinessDBContext(DbContextOptions<BusinessDBContext> options) : base(options)
        {
        }

        // Khai báo các bảng dữ liệu
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        // Thêm dữ liệu  mặc định vào cơ sở dữ liệu khi tạo cơ sở dữ liệu lần đầu tiên
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Seed dữ liệu cho Category
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Sách kinh tế" },
                new Category { CategoryId = 2, CategoryName = "Sách tin học" },
                new Category { CategoryId = 3, CategoryName = "Sách thiếu nhi" }
            );

            // 2. Seed dữ liệu cho Publisher
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherId = 1, PublisherName = "Nhà xuất bản trẻ", Phone = "098746533", Address = "Hà Nội" },
                new Publisher { PublisherId = 2, PublisherName = "Nhà xuất bản Kim Đồng", Phone = "096833435", Address = "Hà Nội" }
            );

            // 3. Seed dữ liệu cho Book
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = "P68050",
                    Title = "Đừng Bao Giờ Đi Ăn Một Mình",
                    Author = "Keith Ferrazzi",
                    Release = 2016,
                    Price = 95000,
                    Description = "Sách kỹ năng giao tiếp",
                    Picture = "images/books/P68050.jpg",
                    CategoryId = 1,
                    PublisherId = 1
                },
                new Book
                {
                    BookId = "P67842",
                    Title = "Shin - Cậu Bé Bút Chì",
                    Author = "Yoshito Usui",
                    Release = 2016,
                    Price = 18000,
                    Description = "Truyện tranh",
                    Picture = "images/books/P67842.jpg",
                    CategoryId = 3,
                    PublisherId = 2
                }
            );
        }
    }
}