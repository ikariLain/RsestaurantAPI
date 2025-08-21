using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [Required, Range(1, 100)]
        public int SeatAmount { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
