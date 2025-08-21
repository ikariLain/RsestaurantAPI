using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.DTOs.Table
{
    public class TablePutDTO
    {
        [Key, Required(ErrorMessage = "Missing Id")]
        public int TableId { get; set; }
        [Required(ErrorMessage = "Missing seat amount"), Range(1, 100, ErrorMessage = "Max amount of seat is 1 to 100")]
        public int SeatAmount { get; set; }
        [Required(ErrorMessage = "Missing availability status")]
        public bool IsAvailable { get; set; } = true;
    }
}
