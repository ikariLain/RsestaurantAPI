using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.DTOs.Food
{
    public class FoodListDTO
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsPopular { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }
    }
}
