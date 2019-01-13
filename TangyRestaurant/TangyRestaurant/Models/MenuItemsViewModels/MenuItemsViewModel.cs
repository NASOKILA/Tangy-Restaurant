using System.Collections.Generic;

namespace TangyRestaurant.Models.MenuItemsViewModels
{
    public class MenuItemsViewModel
    {
        //View model for creating and editing MenuItems
        //it has a menuitem, all categories and all subcategories

        public MenuItem MenuItem { get; set; } 

        public IEnumerable<Category> Categories { get; set; } 

        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
