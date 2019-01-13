using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TangyRestaurant.Models
{
    public class OrderDetails
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrderHeaderId { get; set; }

        public OrderHeader OrderHeader { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
