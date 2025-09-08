namespace RestaurantAPI.DTOs.Reservation
{
    public class ReservationPatchDTO
    {
        public string? Status { get; set; }
        public DateTime? StartTime { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
