namespace RestaurantAPI.DTOs.ServiceOrder
{
    public class ServiceOrderListDTO
    {
        public int FoodOrderId { get; set; }
        public int FoodId_FK { get; set; }
        public int Reservation_FK { get; set; }
        public decimal TotalPriceAmount { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
    }
}
