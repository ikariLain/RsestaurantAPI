namespace RestaurantAPI.DTOs.Table
{
    public class TableDTO
    {
        public int TableId { get; set; }
        public int SeatAmount { get; set; }
        public bool IsAvailable { get; set; }
    }
}
