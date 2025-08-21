using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturangAPI.DTOs.ServiceOrder
{
    public class ServiceOrderDTO
    {
        public int FoodOrderId { get; set; }
        public int FoodId_FK { get; set; }
        public int Reservation_FK { get; set; }
        public decimal TotalPriceAmount { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
    }
}
