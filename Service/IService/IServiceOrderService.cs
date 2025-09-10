using RestaurantAPI.DTOs.Food;
using RestaurantAPI.DTOs.ServiceOrder;
using RestaurantAPI.Models;

namespace RestaurantAPI.Service.IService
{
    public interface IServiceOrderService
    {
        Task<int> CreateServiceOrderAsync(ServiceOrderCreateDTO serviceOrderDTO);
        Task<bool> DeleteServiceOrderAsync(int id);
        Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync();
        Task<ServiceOrderDTO> GetServiceOrderByIdAsync(int id);
        Task<ServiceOrderDTO> UpdateServiceOrderAsync(int id, ServiceOrderPatchDTO serviceOrderPatch);
    }
}
