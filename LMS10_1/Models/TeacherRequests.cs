using LMS10_1.Models.ViewModels;

namespace LMS10_1.Models
{

    public class TeacherRequests
    {
        public int Id { get; set; }

        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public string ?CvFilePath { get; set; } 
        public string ?ImageFilePath { get; set; } 
        public string Status { get; set; } = "Pending"; 
        public DateTime RequestDate { get; set; } = DateTime.Now;


        // العلاقة مع المستخدم
        public string ?UserId { get; set; } // مرتبط بحساب المستخدم الذي قدم الطلب
        public virtual ApplicationUser ?User { get; set; }

        public int ?CategoryId { get; set; }
        public virtual Category ?Category { get; set; }
 
    }

}