namespace RestaurantAPI.DTOs.Reservation
{
    public class ReservationPatchDTO
    {
        public int? Customer_Fk { get; set; }
        public List<int>? Tables { get; set; }
        public List<int>? ServiceOrder { get; set; }
        public string? Status { get; set; }
        public DateOnly? BookingDate { get; set; }
        public DateTime? StartTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? AmountOfGuests { get; set; }
        public int? AmountOfTables { get; set; }
    }
}
