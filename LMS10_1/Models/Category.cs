using System.ComponentModel.DataAnnotations.Schema;

namespace LMS10_1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string ?CategoryName { get; set; }

        // حقل لتخزين المسار الفعلي للصورة في قاعدة البيانات
        public string ?ImagePath { get; set; }

        // حقل لرفع الصورة
        [NotMapped]  // هذا يخبر Entity Framework بعدم تتبع الحقل في قاعدة البيانات
        public IFormFile ?Image { get; set; }

        public ICollection<Courses> ?Courses { get; set; } = new List<Courses>();
        public ICollection<TeacherRequests>?TeacherRequests { get; set; }
        public virtual ICollection<Teacher>? Teachers { get; set; }
    }
}
