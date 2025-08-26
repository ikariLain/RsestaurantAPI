using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.DTOs.ServiceOrder
{
    public class ServiceOrderCreateDTO
    {
        public int ServiceOrderId { get; set; }
        //Can be null if food is not ordered
        public int? FoodId_FK { get; set; }

        [Required(ErrorMessage = "Need a Reservation to make a ServiceOrder")]
        public int Reservation_FK { get; set; }

        [Required(ErrorMessage = "Missing total price amount"), Range(0.01, 100000, ErrorMessage = "Total price amount must be between 0.01 and 100000")]
        public decimal TotalPriceAmount { get; set; }

        [Required(ErrorMessage = "Missing quantity"), 
        Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int Quantity { get; set; }
        [StringLength(500, ErrorMessage = "Note is over 500 character")]
        public string? Note { get; set; }
    }
}
