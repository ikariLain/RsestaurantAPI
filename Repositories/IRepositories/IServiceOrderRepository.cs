using RestaurantAPI.Models;

namespace RestaurantAPI.Repositories.IRepositories
{
    public interface IServiceOrderRepository
    {
        Task<int> CreateServiceOrderAsync(ServiceOrder serviceOrder);
        Task<ServiceOrder> GetServiceOrderByIdAsync(int id);
        Task<List<ServiceOrder>> GetAllServiceOrdersAsync();
        Task<bool> UpdateServiceOrderAsync(ServiceOrder serviceOrder);
        Task<bool> DeleteServiceOrderAsync(int id);
    }
}
