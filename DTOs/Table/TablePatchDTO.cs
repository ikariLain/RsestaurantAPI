using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs.Table
{
    public class TablePatchDTO
    {
        
        [Range(1,100, ErrorMessage = "Max amount of seat is 1 to 100")]
        public int? SeatAmount { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
