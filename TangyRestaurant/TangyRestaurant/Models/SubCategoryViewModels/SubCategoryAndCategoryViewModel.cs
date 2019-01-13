using System.Collections.Generic;

namespace TangyRestaurant.Models.SubCategoryViewModels
{
    public class SubCategoryAndCategoryViewModel
    {
        public SubCategoryAndCategoryViewModel()
        {
            this.CategoriesList = new List<Category>();
            this.SubCategoriesNamesList = new List<string>();
        }

        public SubCategory subCategory { get; set; }

        public List<Category> CategoriesList { get; set; }

        public List<string> SubCategoriesNamesList { get; set; }

        public bool isNew { get; set; }

        public string StatusMessage { get; set; }
    }
}
