using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.Models
{
    public class Reservation
    {
        [Key]
        public int BookingOrderId { get; set; }
        [ForeignKey("Customer")]
        public int Customer_FK { get; set; }
        public virtual Customer Customer { get; set; }

        public List<Table> Tables { get; set; }

        public List<ServiceOrder> FoodOrders { get; set; }

        public string status { get; set; } = "Pending";
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public int AmountOfGuests { get; set; }

        public int AmountOfTables { get; set; }
    }
}
