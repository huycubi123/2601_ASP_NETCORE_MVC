using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson06_EFCore_CodeFIrst.Models.DataModels
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DisplayName("Mã loại")]
        public int CategoryId { get; set; }

        [DisplayName("Tên loại")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        // Thuộc tính quan hệ (1 Category có nhiều Books)
        public ICollection<Book> Books { get; set; }
    }
}