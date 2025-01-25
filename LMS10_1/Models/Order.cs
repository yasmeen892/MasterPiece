namespace LMS10_1.Models
{
      public class Order
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public decimal Discount { get; set; }
        public decimal SubPrice { get; set; }
        public decimal TotalPrice { get; set; }
    
      
        
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }

}
