using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories.IRepositories;

namespace RestaurantAPI.Repositories
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly AppDBContext _context;
        public ServiceOrderRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> CreateServiceOrderAsync(ServiceOrder serviceOrder)
        {
            _context.Add(serviceOrder);
            await _context.SaveChangesAsync();

            if (serviceOrder.OrderedFoods != null && serviceOrder.OrderedFoods.Any())
            {
                foreach (var of in serviceOrder.OrderedFoods)
                {
                    of.ServiceOrderId = serviceOrder.ServiceOrderId;
                    _context.serviceOrderFoods.Add(of);
                }
                await _context.SaveChangesAsync();
            }

            return serviceOrder.ServiceOrderId;
        }

        public async Task<bool> DeleteServiceOrderAsync(int id)
        {
            var serviceOrder = await _context.ServiceOrders.Where(s => s.ServiceOrderId == id).ExecuteDeleteAsync();

            if (serviceOrder > 0)
            {
                return false;
            }
            
            _context.SaveChanges();
            return true;
        }

        public async Task<List<ServiceOrder>> GetAllServiceOrdersAsync()
        {
            var serviceOrders = await _context.ServiceOrders.Include(s => s.OrderedFoods).ToListAsync();
            return serviceOrders;
        }

        public async Task<ServiceOrder> GetServiceOrderByIdAsync(int id)
        {
            var serviceOrder = await _context.ServiceOrders
                .FirstOrDefaultAsync(s => s.ServiceOrderId == id);
            return serviceOrder;
        }

        public async Task<bool> UpdateServiceOrderAsync(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Update(serviceOrder);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
