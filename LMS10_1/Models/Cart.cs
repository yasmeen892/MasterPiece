namespace LMS10_1.Models
{
    public class Cart
    {

       
        
            public int Id { get; set; }
            public int CoursesId { get; set; }
            public Courses Courses { get; set; }
            public int Qty { get; set; }

        
    }
}
