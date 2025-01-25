using System.ComponentModel.DataAnnotations;

namespace LMS10_1.Models
{
   

        public class Lesson
        {
            [Key]
            public int LessonId { get; set; }

            [Required]
            [StringLength(100)]
            public string LessonTitle { get; set; }
            public string VideoUrl { get; set; }

            [StringLength(1000)]
            public string ?LessonContent { get; set; }

            [DataType(DataType.Date)]
            public DateTime? PublishDate { get; set; }

  
      
        public Courses Course { get; set; }
        [Required]
        public int CoursesId { get; internal set; }
    }
    }

