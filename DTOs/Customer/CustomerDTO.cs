using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs.User
{
    public class CustomerDTO
    {
        public int CustomserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
