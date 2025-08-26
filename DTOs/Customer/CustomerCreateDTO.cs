using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.DTOs.User
{
    public class CustomerCreateDTO
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Missing Name"), StringLength(50, ErrorMessage = "Name is over 50 character")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Missing Email"),EmailAddress, StringLength(50, ErrorMessage = "Email is over 50 character")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Missing PhoneNumber"),Phone, StringLength(50,ErrorMessage = "PhoneNumber is over 50 character")]
        public string PhoneNumber { get; set; }
    }
}
