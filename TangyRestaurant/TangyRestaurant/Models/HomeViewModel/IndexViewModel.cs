using System.Collections.Generic;

namespace TangyRestaurant.Models.HomeViewModel
{
    public class IndexViewModel
    {

        public IndexViewModel()
        {
            this.MenuItems = new List<MenuItem>();
            this.Categories = new List<Category>();
            this.Coupons = new List<Coupon>();
        }

        public string StatusMessage { get; set; }

        public IEnumerable<MenuItem> MenuItems { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Coupon> Coupons { get; set; }
    }
}
