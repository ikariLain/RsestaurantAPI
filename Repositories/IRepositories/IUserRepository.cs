using System.Runtime.CompilerServices;
using RestaurantAPI.Models;

namespace RestaurantAPI.Respositories.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();
        Task<User> GetByIdAsync(int id);
        Task<int> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
