using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.Models
{
    public class ServiceOrder
    {
        [Key]
        public int FoodOrderId { get; set; }

        [ForeignKey("Food")]
        public int? FoodId_FK { get; set; }
        public virtual Food Food { get; set; }

        [ForeignKey("Reservation")]
        public int Reservation_FK { get; set; }
        public virtual Reservation Reservation { get; set; }
        [Required]
        public decimal TotalPriceAmount { get; set; }
        [Required, Range(1, 1000)]
        public int Quantity { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }
    }
}
