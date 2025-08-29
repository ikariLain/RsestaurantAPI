using RestaurantAPI.DTOs.User;
using RestaurantAPI.Models;

namespace RestaurantAPI.Respositories.IRepositories
{
    public interface ICustomerRepository
    {
        Task <List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<int> CreateCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int Id);
    }
}
