using RestaurantAPI.Models;

namespace RestaurantAPI.DTOs.Reservation
{
    public class ReservationDTO
    {
        public int BookingOrderId { get; set; }
        public int User_FK { get; set; }

        public string status { get; set; } = "Pending"; 
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public int AmountOfGuests { get; set; }

        public int AmountOfTables { get; set; }
    }
}
