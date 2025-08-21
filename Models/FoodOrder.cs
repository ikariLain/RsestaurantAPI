using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.Models
{
    public class FoodOrder
    {
        [Key]
        public int FoodOrderId { get; set; }

        [ForeignKey("Food")]
        public int FoodId_FK { get; set; }
        public virtual Food Food { get; set; }

        [ForeignKey("Reservation")]
        public int Reservation_FK { get; set; }
        public virtual Reservation Reservation { get; set; }

        public decimal TotalPriceAmount { get; set; }
        public int Quantity { get; set; }
        [MaxLength(200)]
        public string? Note { get; set; }
    }
}
