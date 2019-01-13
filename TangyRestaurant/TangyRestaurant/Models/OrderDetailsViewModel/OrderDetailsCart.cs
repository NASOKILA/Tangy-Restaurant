using System.Collections.Generic;

namespace TangyRestaurant.Models.OrderDetailsViewModel
{
    public class OrderDetailsCart
    {
        public List<ShoppingCart> ShoppingCart { get; set; }

        public OrderHeader OrderHeader { get; set; }
    }
}
