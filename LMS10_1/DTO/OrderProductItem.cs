namespace LMS10_1.DTO
{
    public class OrderProductItem
    {
     
            public string Image { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public decimal Total { get; set; }
            public int ProductId { get; set; }
            public int OrderItemId { get; set; }


        }
    }

