using LMS10_1.Models.ViewModels;

namespace LMS10_1.Models
{
    public class Certificate
    {

    
            public int CertificateId { get; set; }
            public string CertificateFile { get; set; } // Certificate link

            public int CourseId { get; set; } // Relation with course
           
            public string StudentId { get; set; } // Relation with student
            public ApplicationUser Student { get; set; }
      

    }
}
