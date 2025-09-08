using RestaurantAPI.Models;

namespace RestaurantAPI.DTOs.Reservation
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        public int User_FK { get; set; }

        public DateOnly BookingDate { get; set; }

        public DateTime StartTime { get; set; }

        public string Status { get; set; } 
        

        public int AmountOfGuests { get; set; }

        public int AmountOfTables { get; set; }
    }
}
