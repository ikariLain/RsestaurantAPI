using RestaurantAPI.DTOs.Food;
using RestaurantAPI.Models;

namespace RestaurantAPI.Service.IService
{
    public interface IFoodService
    {
        Task<List<Food>> GetAllFoodsAsync();
        Task<Food> FoodByIdAsync(int id);
        Task<int> CreateFoodAsync(Food food);
        Task<FoodDTO> UpdateFoodAsync(int id, FoodPatchDTO foodPatchDTO);
        Task<bool> DeleteFoodAsync(int Id);
    }
}
