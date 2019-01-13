using System.Collections.Generic;

namespace TangyRestaurant.Models.OrderDetailsViewModel
{
    public class OrderDetailsViewModel
    {
        public OrderHeader OrderHeader { get; set; }

        public List<OrderDetails> OrderDetailsList { get; set; }
    }
}
