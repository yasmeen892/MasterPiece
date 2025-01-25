using System.ComponentModel.DataAnnotations;

namespace LMS10_1.Models
{
    public class Checkout
    {

      
            public int CheckoutId { get; set; }
        public Order Order { get; set; }

        public int OrderId { get; set; }
  

            public List<OrderItem> OrderItems { get; set; }
     

        public decimal Subtotal { get; set; }

        public decimal Shipping { get; set; }

        public decimal Total { get; set; }


    }
}
