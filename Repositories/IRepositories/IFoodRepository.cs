using RestaurantAPI.Models;

namespace RestaurantAPI.Repositories.IRepositories
{
    public interface IFoodRepository
    {
        Task<List<Food>> GetAllFoodsAsync();
        Task<Food> GetFoodByIdAsync(int id);
        Task<int> CreateFoodAsync(Food food);
        Task<bool> UpdateFoodAsync(Food food);
        Task<bool> DeleteFoodAsync(int Id);

    }
}
