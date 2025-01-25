using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LMS10_1.Models.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        // الاسم الأول
        public string FirstName { get; set; }

        // الاسم الأخير
        public string LastName { get; set; }

        // الجنس (ذكر أو أنثى)
        public string? Gender { get; set; }

        // حالة الطلب ليصبح معلمًا (افتراضيًا False)
        public bool IsTeacherRequestPending { get; set; } = false;

        // تحديد ما إذا كان المستخدم معلمًا (افتراضيًا False)
        public bool IsTeacher { get; set; } = false;

        // الطلبات التي يرسلها المستخدم
        public ICollection<TeacherRequests> TeacherRequests { get; set; }
    }
}
