namespace LMS10_1.Models
{
    public class OrderItem
    {

        public int OrderItemId { get; set; }

        public int CoursesId { get; set; }
        public virtual Courses? Courses { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }

    }
}