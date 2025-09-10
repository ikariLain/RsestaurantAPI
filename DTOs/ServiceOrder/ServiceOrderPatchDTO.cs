using RestaurantAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs.ServiceOrder
{
    public class ServiceOrderPatchDTO
    {
        public List<ServiceOrderFood> Foods { get; set; }
        public int? Reservation_FK { get; set; }

        [Range(0, 50000, ErrorMessage = "Total price must be between 0 and 50000")]
        public decimal? TotalPriceAmount { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int? Quantity { get; set; }

        [MaxLength(500, ErrorMessage = "Note can only contain 500 characters")]
        public string? Note { get; set; }
    }
}
