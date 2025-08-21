using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required,EmailAddress, StringLength(50)]
        public string Email { get; set; }
        [Required,Phone, StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
