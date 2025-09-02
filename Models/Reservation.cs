using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        [ForeignKey("Customer")]
        public int Customer_FK { get; set; }
        public virtual Customer Customer { get; set; }

        public List<Table> Tables { get; set; }

        public List<ServiceOrder> FoodOrders { get; set; }

        public string status { get; set; } 
        public DateOnly BookingDate { get; set; } 
        public TimeSpan? Duration { get; set; }
        public int AmountOfGuests { get; set; }

        public int AmountOfTables { get; set; }
        
    }
}
