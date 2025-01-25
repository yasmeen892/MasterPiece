using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS10_1.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        // ربط العنصر بالكورس
        [ForeignKey("Courses")]
        public int CoursesId { get; set; }
        public Courses Courses { get; set; }

        // ربط العنصر بالمستخدم
        [Required]
        public string UserId { get; set; }

        // الكمية والسعر
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
    }
}
