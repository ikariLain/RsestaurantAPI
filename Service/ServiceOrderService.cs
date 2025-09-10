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
                Reservation_FK = serviceOrderDTO.Reservation_FK,
                Note = serviceOrderDTO.Note,
                TotalPriceAmount = 0, 
                OrderedFoods = new List<ServiceOrderFood>()
            };

            decimal totalPrice = 0;

            foreach (var foodItem in serviceOrderDTO.Foods)
            {
                var orderFood = new ServiceOrderFood
                {
                    FoodId = foodItem.FoodId,
                    Quantity = foodItem.Quantity,
                    Price = foodItem.Price
                };

                totalPrice += foodItem.Price * foodItem.Quantity;

                newServiceOrder.OrderedFoods.Add(orderFood);
            }

            newServiceOrder.TotalPriceAmount = totalPrice;


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

        public async Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync()
        {
            var serviceOrders = await _serviceOrderRepo.GetAllServiceOrdersAsync();

            if (serviceOrders == null)
            {
                throw new InvalidCastException("No Serviceorders found.");
            }

            var serviceOrdersDTO = serviceOrders.Select(s => new ServiceOrderDTO
            {
                ServiceOrderId = s.ServiceOrderId,
                Reservation_FK = s.Reservation_FK,
                TotalPriceAmount = s.TotalPriceAmount,
                Note = s.Note,
                Foods = s.OrderedFoods.Select(of => new ServiceOrderFood
                {
                    FoodId = of.FoodId,
                    Quantity = of.Quantity,
                    Price = of.Price
                }).ToList()
            }).ToList();


            return serviceOrdersDTO;
        }

        public async Task<ServiceOrderDTO> GetServiceOrderByIdAsync(int id)
        {
            var serviceOrder = await _serviceOrderRepo.GetServiceOrderByIdAsync(id);

            if (serviceOrder == null)
            {
                throw new KeyNotFoundException($"Serviceorder with ID {id} not found.");
            }

            var serviceOrderDTO = new ServiceOrderDTO
            {
                ServiceOrderId = serviceOrder.ServiceOrderId,
                Reservation_FK = serviceOrder.Reservation_FK,
                TotalPriceAmount = serviceOrder.TotalPriceAmount,
                Note = serviceOrder.Note,
                Foods = serviceOrder.OrderedFoods.Select(of => new ServiceOrderFood
                {
                    FoodId = of.FoodId,
                    Quantity = of.Quantity,
                    Price = of.Price
                }).ToList()
            };

            return serviceOrderDTO;
        }

        public async Task<ServiceOrderDTO> UpdateServiceOrderAsync(int id ,ServiceOrderPatchDTO serviceOrderPatch)
        {
            var existingServiceOrder =  await _serviceOrderRepo.GetServiceOrderByIdAsync(id);

            if (existingServiceOrder == null)
            {
                return null;
            }

            if (serviceOrderPatch.Foods != null && serviceOrderPatch.Foods.Any())
            {
                existingServiceOrder.OrderedFoods.Clear();

                decimal totalPrice = 0;

                
                foreach (var foodItem in serviceOrderPatch.Foods)
                {
                    var orderFood = new ServiceOrderFood
                    {
                        FoodId = foodItem.FoodId,
                        Quantity = foodItem.Quantity,
                        Price = foodItem.Price
                    };
                    totalPrice += foodItem.Price * foodItem.Quantity;
                    existingServiceOrder.OrderedFoods.Add(orderFood);
                }

                existingServiceOrder.TotalPriceAmount = totalPrice;
            }


            if (serviceOrderPatch.Reservation_FK.HasValue)
                existingServiceOrder.Reservation_FK = serviceOrderPatch.Reservation_FK.Value;
            
           
            if (!string.IsNullOrEmpty(serviceOrderPatch.Note))
                existingServiceOrder.Note = serviceOrderPatch.Note;

            var update = await _serviceOrderRepo.UpdateServiceOrderAsync(existingServiceOrder);
            if (!update)
            {
                return null;
            }

            var UpdatedServiceOrder = await GetServiceOrderByIdAsync(id);


            return UpdatedServiceOrder;

        }
    }
}
