using RestaurantAPI.DTOs.Customer;

namespace RestaurantAPI.Service.IService
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomerAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int Id);
        Task<int> CreateCustomerAsync(CustomerCreateDTO CustomerDTO);
        Task<CustomerDTO> UpdateCustomerAsync(int Id, CustomerPatchDTO CustomerPatch);
        Task<bool> DeleteCustomerAsync(int Id);
    }
}
