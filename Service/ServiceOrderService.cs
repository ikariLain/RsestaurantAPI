using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.DTOs.ServiceOrder;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories.IRepositories;
using RestaurantAPI.Service.IService;
using System.Data;

namespace RestaurantAPI.Service
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderRepository _serviceOrderRepo;

        public ServiceOrderService(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepo = serviceOrderRepository;
        }


        public async Task<int> CreateServiceOrderAsync(ServiceOrderCreateDTO serviceOrderDTO)
        {
            var newServiceOrder = new ServiceOrder
            {
                FoodId_FK = serviceOrderDTO.FoodId_FK.Value,
                Reservation_FK = serviceOrderDTO.Reservation_FK,
                TotalPriceAmount = serviceOrderDTO.TotalPriceAmount,
                Quantity = serviceOrderDTO.Quantity,
                Note = serviceOrderDTO.Note
            };

            return await _serviceOrderRepo.CreateServiceOrderAsync(newServiceOrder);
        }

        public async Task<bool> DeleteServiceOrderAsync(int id)
        {
           var existingServiceOrder = await _serviceOrderRepo.GetServiceOrderByIdAsync(id);

            if (existingServiceOrder == null)
            {
                return false;
            }

            return  await _serviceOrderRepo.DeleteServiceOrderAsync(id);
        }

        public async Task<List<ServiceOrder>> GetAllServiceOrdersAsync()
        {
            var serviceOrdersList = await _serviceOrderRepo.GetAllServiceOrdersAsync();

            if (serviceOrdersList == null)
            {
                throw new InvalidCastException("No Serviceorders found.");
            }

            return serviceOrdersList;
        }

        public async Task<ServiceOrder> GetServiceOrderByIdAsync(int id)
        {
            var serviceOrder = await _serviceOrderRepo.GetServiceOrderByIdAsync(id);
            if (serviceOrder == null)
            {
                throw new KeyNotFoundException($"Serviceorder with ID {id} not found.");
            }
            return serviceOrder;
        }

        public async Task<ServiceOrderDTO> UpdateServiceOrderAsync(int id ,ServiceOrderPatchDTO serviceOrderPatch)
        {
            var existingServiceOrder =  await _serviceOrderRepo.GetServiceOrderByIdAsync(id);

            if (existingServiceOrder == null)
            {
                return null;
            }

            if (serviceOrderPatch.FoodId_FK.HasValue)
                existingServiceOrder.FoodId_FK = serviceOrderPatch.FoodId_FK.Value;
            if (serviceOrderPatch.Reservation_FK.HasValue)
                existingServiceOrder.Reservation_FK = serviceOrderPatch.Reservation_FK.Value;
            if (serviceOrderPatch.TotalPriceAmount.HasValue && serviceOrderPatch.TotalPriceAmount.Value > 0)
                existingServiceOrder.TotalPriceAmount = serviceOrderPatch.TotalPriceAmount.Value;
            if (serviceOrderPatch.Quantity.HasValue && serviceOrderPatch.Quantity.Value > 0)
                existingServiceOrder.Quantity = serviceOrderPatch.Quantity.Value;
            if (!string.IsNullOrEmpty(serviceOrderPatch.Note))
                existingServiceOrder.Note = serviceOrderPatch.Note;

            var update = await _serviceOrderRepo.UpdateServiceOrderAsync(existingServiceOrder);
            if (!update)
            {
                return null;
            }

            var UpdatedServiceOrder = new ServiceOrderDTO
            {
                FoodId_FK = existingServiceOrder.FoodId_FK,
                Reservation_FK = existingServiceOrder.Reservation_FK,
                TotalPriceAmount = existingServiceOrder.TotalPriceAmount,
                Quantity = existingServiceOrder.Quantity,
                Note = existingServiceOrder.Note
            };

            return UpdatedServiceOrder;

        }
    }
}
