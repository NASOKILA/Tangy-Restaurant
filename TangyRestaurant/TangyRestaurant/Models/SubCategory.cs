using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TangyRestaurant.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Sub Category")]
        public string Name { get; set; }
        
        public Category category { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int categoryId { get; set; }
    }
}
