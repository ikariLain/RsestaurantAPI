using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.DTOs.User
{
    public class CustomerPatchDTO
    {
        [Required(ErrorMessage = "Can't have more than 50 characters "), StringLength(50, ErrorMessage = "Can't have more than 50")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Can't have more than 50 characters "), EmailAddress, StringLength(50, ErrorMessage = "Can't have more than 50")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "phonenumber is in a wrong format or missing"), Phone, StringLength(50, ErrorMessage = "Can't have more than 50 characters ")]
        public string? PhoneNumber { get; set; }
    }
}
