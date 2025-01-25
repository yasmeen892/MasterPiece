using System.ComponentModel.DataAnnotations;

namespace LMS10_1.Models
{
    public class feedback
    {

        public Guid Id { get; set; }
        [Required]
        public string StudentName { get; set; }
       
        [DataType(DataType.MultilineText)]
        public string StudentComment { get; set; }

    }
}
