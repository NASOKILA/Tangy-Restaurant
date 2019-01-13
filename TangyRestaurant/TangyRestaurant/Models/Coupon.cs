using System.ComponentModel.DataAnnotations;

namespace TangyRestaurant.Models
{
    public class Coupon
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CouponType { get; set; } 
        
        //There are only two types
        public enum ECouponType {
            Percent = 0,
            Dollar = 1
        }

        [Required]
        public double Discount { get; set; }

        [Required]
        public double MinAmount { get; set; }
        
        public byte[] Picture { get; set; } //We will store the picture in the database and not on the server

        public bool IsActive { get; set; }
    }
}
