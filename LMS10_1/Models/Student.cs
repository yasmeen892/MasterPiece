namespace LMS10_1.Models
{
    public class Student
    {
        public string StudentId { get; set; } // المفتاح الأساسي (Primary Key)

        public string FullName { get; set; }
        public string Email { get; set; }

        // علاقة Many-to-Many مع الدورات عبر جدول الربط
        public ICollection<StudentCourse> Courses { get; set; }
    }

}