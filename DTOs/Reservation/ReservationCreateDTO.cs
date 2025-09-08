namespace RestaurantAPI.DTOs.Reservation
{
    public class ReservationCreateDTO
    {
        public int BookingOrderId { get; set; }
        public int User_FK { get; set; }
        public List <int> Tables { get; set; }
        public List <int> ServiceOrder { get; set; }
        public string status { get; set; } 
        public DateOnly BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public int AmountOfGuests { get; set; }
        public int AmountOfTables { get; set; }
    }
}
