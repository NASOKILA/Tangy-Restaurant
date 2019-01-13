using System.ComponentModel.DataAnnotations;
using TangyRestaurant.Models.Enums;

namespace TangyRestaurant.Models
{
    public class MenuItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Spicyness { get; set; } // We need an enum

        public enum Espicy {
            NA = 0,
            Spicy = 1,
            VerySpicy = 2
        }

        [Range(1, int.MaxValue,ErrorMessage = "Price must me grether than 1 !")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        
        public int SubCategoryId { get; set; }
        
        public SubCategory SubCategory { get; set; }

    }
}
