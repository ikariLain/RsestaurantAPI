using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs.Food
{
    public class FoodDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsPopular { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }
    }
}
