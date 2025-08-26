using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, EmailAddress, MaxLength(200)]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
