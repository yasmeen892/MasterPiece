using LMS10_1.Models.ViewModels;

namespace LMS10_1.Models
{
    public class StudentCourse
    {

        public string StudentId { get; set; } // المفتاح الأجنبي للطالب
        public Student Student { get; set; } // العلاقة مع الطالب

        public int CourseId { get; set; } // المفتاح الأجنبي للدورة
        public Courses Course { get; set; } // العلاقة مع الدورة

        public DateTime EnrollmentDate { get; set; } // 
    }

}
