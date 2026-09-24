using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lesson06_EFCore_CodeFIrst.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Sách kinh tế" },
                    { 2, "Sách tin học" },
                    { 3, "Sách thiếu nhi" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Address", "Phone", "PublisherName" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "098746533", "Nhà xuất bản trẻ" },
                    { 2, "Hà Nội", "096833435", "Nhà xuất bản Kim Đồng" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CategoryId", "Description", "Picture", "Price", "PublisherId", "Release", "Title" },
                values: new object[,]
                {
                    { "P67842", "Yoshito Usui", 3, "Truyện tranh", "images/books/P67842.jpg", 18000.0, 2, 2016, "Shin - Cậu Bé Bút Chì" },
                    { "P68050", "Keith Ferrazzi", 1, "Sách kỹ năng giao tiếp", "images/books/P68050.jpg", 95000.0, 1, 2016, "Đừng Bao Giờ Đi Ăn Một Mình" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "P67842");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "P68050");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: 2);
        }
    }
}
