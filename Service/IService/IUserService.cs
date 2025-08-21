using ResturangAPI.DTOs.User;

namespace ResturangAPI.Service.IService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUserAsync();
        Task<UserDTO> GetByIdAsync(int UserId);
        Task<int> CreateUserAsync(UserCreateDTO UserDTO);
        Task<bool> UpdateUserAsync(int UserId);
        Task<bool> DeleteUserAsync(int UserId);


    }
}
