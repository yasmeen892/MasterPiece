using LMS10_1.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace LMS10_1.Models
{
    public class Teacher
    {

        public int Id { get; set; } // المفتاح الأساسي
        public string ?Name { get; set; } // اسم المعلم
        public string ?CvFilePath { get; set; } // مسار السيرة الذاتية
        public string ?ImageFilePath { get; set; } // مسار الصورة
        public string ?Expertise { get; set; } // التخصص
        public string ?UserId { get; set; } // معرف المستخدم (ربط مع جدول المستخدمين)
        public virtual ApplicationUser ?User { get; set; } // العلاقة مع جدول المستخدمين
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        [EmailAddress ]
        public string? Email { get; internal set; }

        public ICollection<Courses>? Courses { get; set; } = new List<Courses>();
    }
}
