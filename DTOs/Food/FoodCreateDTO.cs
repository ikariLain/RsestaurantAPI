using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.DTOs.Food
{
    public class FoodCreateDTO
    {
        [Required(ErrorMessage = "Missing name"), StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Missing price"), StringLength(50)]
        public double Price { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Missing bool value to IsPopular")]
        public bool IsPopular { get; set; }
        [Required]
        public bool IsVegetarian { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [StringLength(8000, ErrorMessage = "ImageUrl is over 8000 character")]
        public string ImageUrl { get; set; }
    }
}
