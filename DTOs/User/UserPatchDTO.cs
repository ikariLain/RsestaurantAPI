namespace RestaurantAPI.DTOs.User;

public class UserPatchDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? Role { get; set; }
}