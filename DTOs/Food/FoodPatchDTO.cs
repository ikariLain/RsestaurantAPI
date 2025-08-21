using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.DTOs.Food
{
    public class FoodPatchDTO
    {
        [StringLength(50, ErrorMessage = "Name is over 50 character")]
        public string? Name { get; set; }
        [Range(0,5000, ErrorMessage = "Price must be between 0 and 5000")]
        public double? Price { get; set; }
        [StringLength(500, ErrorMessage = "Description is over 500 character")]
        public string? Description { get; set; }
        public bool? IsPopular { get; set; }
        public bool? IsVegetarian { get; set; }
        public bool? IsAvailable { get; set; }
        [StringLength(8000, ErrorMessage = "ImageUrl is over 8000 character")]
        public string? ImageUrl { get; set; }
    }
}
