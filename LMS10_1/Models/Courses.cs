using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS10_1.Models
{
    public class Courses
    {
      
        public int CoursesId { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }
    

        public string Duration { get; set; }
        public string Languge { get; set; }
        public bool IsCertificate { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal PriceBeforeDiscount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        public string CourseDescription { get; set; }
        public string CourseRequrments { get; set; }


        [Required(ErrorMessage = "Select a Category")]
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }


        public int ?TeacherId { get; set; }
        public Teacher ?Teacher { get; set; }

        [DataType(DataType.Date)]
        public DateTime CourseDate { get; set; }

        public string? ImagePath { get; set; }
     
        [NotMapped] // لن يتم تخزين هذه الخاصية في قاعدة البيانات
        public IFormFile ?ImageFile
        {
            get; set;
        }
        public ICollection<Lesson> ?Lessons { get; set; } = new List<Lesson>();
        public ICollection<StudentCourse> ?Students { get; set; } = new List<StudentCourse>();

        public ICollection<CartItem> ?CartItems { get; set; } = new List<CartItem>();
    }
}
