using RestaurantAPI.DTOs.User;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories.IRepositories;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<int> CreateCustomerAsync(CustomerCreateDTO customerDTO)
        {
            var customer = new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                PhoneNumber = customerDTO.PhoneNumber

            };

            var CustomerId = await _customerRepo.CreateCustomerAsync(customer);

            return CustomerId; 
        }

        public async Task<bool> DeleteCustomerAsync(int Id)
        {
            var existingCustomer = await _customerRepo.GetCustomerByIdAsync(Id);
            
            if (existingCustomer == null )
            {
                return false;
            }
            
            var deleteCustomer = await _customerRepo.DeleteCustomerAsync(Id);

            return deleteCustomer;
        }
         
        public async Task<List<CustomerDTO>> GetAllCustomerAsync()
        {
            var customers = await _customerRepo.GetAllCustomersAsync();

            var customerDTO = customers.Select(c =>  new CustomerDTO
            {
                CustomserId = c.CustomerId,
                Name = c.Name,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber

            }).ToList();

            return customerDTO;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int Id)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(Id);

            if (customer == null)
            {
                return null; 
            }

            var customerDTO = new CustomerDTO
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };

            return customerDTO;
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(int Id, CustomerPatchDTO customerPatch)
        {
            var existingCustomer = await _customerRepo.GetCustomerByIdAsync(Id);

            if (existingCustomer == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(customerPatch.Name))
                existingCustomer.Name = customerPatch.Name;
            if (!string.IsNullOrEmpty(customerPatch.PhoneNumber))
                existingCustomer.PhoneNumber = customerPatch.PhoneNumber; 
            if (!string.IsNullOrEmpty(customerPatch.Email))
                existingCustomer.Email = customerPatch.Email;

            var updateCustumerDB = await _customerRepo.UpdateCustomerAsync(existingCustomer);

            return new CustomerDTO
            {
                Name = existingCustomer.Name,
                PhoneNumber = existingCustomer.PhoneNumber
            };
        }
    }
}
