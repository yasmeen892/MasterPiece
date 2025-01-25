using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS10_1.Models
{
    public class Article
    {

        public int ArticleId { get; set; }
        [Required(ErrorMessage = " Enter Article Title")]
        [DisplayName("Article Title")]
        public string ?ArticleTitle { get; set; }


        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string ?ArticleContent { get; set; }



    }
}
