using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, Range(0,5000)]
        public double Price { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public bool IsPopular { get; set; }
        [Required]
        public bool IsVegetarian { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [StringLength(8000)]
        public string ImageUrl { get; set; }
    }
}
