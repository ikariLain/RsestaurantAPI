using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.DTOs.User;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories.IRepositories;

namespace RestaurantAPI.Respositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly AppDBContext _context;

        public CustomerRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer.CustomerId;
        }

        public async Task<bool> DeleteCustomerAsync(int Id)
        {
            var RowAffected = await _context.Customers.Where(c => c.CustomerId == Id).ExecuteDeleteAsync();

            if (RowAffected > 0)
            {
                return true;
            }

            return false;
        }

        public Task<List<Customer>> GetAllCustomersAsync()
        {
            var Customers = _context.Customers.ToListAsync();

            return Customers;
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            var Result = await _context.SaveChangesAsync();

            if (Result != 0)
            {
                return true;
            }

            return false;
        }
    }
}
