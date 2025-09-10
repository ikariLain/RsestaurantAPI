using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class ReservationTable
    {
        public int Id { get; set; }

        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        [ForeignKey("Table")]
        public int TableId { get; set; }
        public Table Table { get; set; }


    }
}
