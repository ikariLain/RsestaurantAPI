using RestaurantAPI.Models;

namespace RestaurantAPI.DTOs.Reservation
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        public int Customer_FK { get; set; }
        public List<int> TableIds { get; set; } = new();

        public DateOnly BookingDate { get; set; }

        public DateTime StartTime { get; set; }
        public TimeSpan? Duration { get; set; }

        public string Status { get; set; } 
        

        public int AmountOfGuests { get; set; }

        public int AmountOfTables { get; set; }
    }
}
