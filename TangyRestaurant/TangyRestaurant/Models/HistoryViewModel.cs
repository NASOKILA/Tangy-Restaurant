using System.Collections.Generic;

namespace TangyRestaurant.Models
{
    public class HistoryViewModel
    {
        public IList<OrderDetailsViewModel.OrderDetailsViewModel> Orders { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
