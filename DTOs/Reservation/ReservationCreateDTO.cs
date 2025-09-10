using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs.Reservation
{
    public class ReservationCreateDTO
    {
        [Required]
        public int Customer_Fk { get; set; }
        [Required]
        public List<int> Tables { get; set; }
        [Required]
        public List <int> ServiceOrder { get; set; }
        [Required]
        public string? status { get; set; }
        [Required]
        public DateOnly BookingDate { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public TimeSpan? Duration { get; set; }
        [Required]
        public int AmountOfGuests { get; set; }
        public int AmountOfTables { get; set; }
    }
}
