using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class ServiceOrder
    {
        [Key]
        public int ServiceOrderId { get; set; }
        public List<ServiceOrderFood> OrderedFoods { get; set; }

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
