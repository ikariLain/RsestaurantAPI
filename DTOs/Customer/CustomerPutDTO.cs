using System.ComponentModel.DataAnnotations;

namespace ResturangAPI.DTOs.User
{
    public class CustomerPutDTO
    {
        [Required(ErrorMessage = "Missing Name"), StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Missing Email"), EmailAddress, StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Missing PhoneNumber"), Phone, StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
