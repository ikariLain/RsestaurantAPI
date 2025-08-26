namespace RestaurantAPI.DTOs.Table
{
    public class TableListDTO
    {
        public int TableId { get; set; }
        public int SeatAmount { get; set; }
        public bool IsAvailable { get; set; }
    }
}
