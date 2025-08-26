using RestaurantAPI.DTOs.User;

namespace RestaurantAPI.Service.IService
{
    public interface IUserService
    {
        Task<List<CustomerDTO>> GetAllUserAsync();
        Task<CustomerDTO> GetByIdAsync(int UserId);
        Task<int> CreateUserAsync(UserCreateDTO UserDTO);
        Task<bool> UpdateUserAsync(int UserId);
        Task<bool> DeleteUserAsync(int UserId);


    }
}
