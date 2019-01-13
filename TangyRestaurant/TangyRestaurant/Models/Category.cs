using System.ComponentModel.DataAnnotations;

namespace TangyRestaurant.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Category Name")] //We display it like this
        public string Name { get; set; }

        [Required]
        [Display(Name= "Display Order")] //We display it like this
        public int DisplayOrder { get; set; }
        
    }
}
