using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.Models
{
    //TODO: Change this obj to Customer and make a new obj for User to handle login and roles
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required,EmailAddress, StringLength(50)]
        public string Email { get; set; }
        [Required,Phone, StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
