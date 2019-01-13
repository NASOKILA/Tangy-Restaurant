using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TangyRestaurant.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int MenuItemId { get; set; }

        public MenuItem MenuItem { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greather or equal than 1.")]
        public int Count { get; set; }

        [NotMapped]
        public string StatusMessage { get; set; } //This will not be mapped because we will use it only for displaying a message.
    }
}
