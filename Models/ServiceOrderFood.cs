using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class ServiceOrderFood
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ServiceOrder")]
        public int ServiceOrderId { get; set; }
        public ServiceOrder ServiceOrder { get; set; }

        [ForeignKey("Food")]
        public int FoodId { get; set; }
        public Food Food { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}

