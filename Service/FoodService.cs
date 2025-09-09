using RestaurantAPI.DTOs.Food;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories;
using RestaurantAPI.Service.IService;
using RestaurantAPI.Repositories.IRepositories;

namespace RestaurantAPI.Service
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepo;

        public FoodService(IFoodRepository foodRepo)
        {
            _foodRepo = foodRepo;
        }

        public async Task<int> CreateFoodAsync(Food food)
        {
            if (string.IsNullOrWhiteSpace(food.Name))
            {
                throw new ArgumentException("Food must have a valid name.");
            }

            if (food.Price <= 0)
            {
                throw new ArgumentException("Food must have a valid price.");
            }

            if (food.Description == null)
                food.Description = "No description provided.";

            if (food.IsAvailable == false)
                food.IsAvailable = true;

            return await _foodRepo.CreateFoodAsync(food);
        }

        public async Task<bool> DeleteFoodAsync(int Id)
        {
            var existingFood = await _foodRepo.GetFoodByIdAsync(Id);

            if (existingFood == null)
            {
                return false;
            }

            var deleteFood = await _foodRepo.DeleteFoodAsync(Id);

            return true;
        }

        public async Task<Food> FoodByIdAsync(int id)
        {
            var food = await _foodRepo.GetFoodByIdAsync(id);

            if (food == null)
            {
                throw new KeyNotFoundException($"Food with ID {id} not found.");
            }

            return food;
        }

        public async Task<List<Food>> GetAllFoodsAsync()
        {
            var foodsList = await _foodRepo.GetAllFoodsAsync();

            if (foodsList == null )
            {
                throw new InvalidOperationException("No foods available.");
            }
            return foodsList;
        }

        public async Task<FoodDTO> UpdateFoodAsync(int id, FoodPatchDTO foodPatchDTO)
        {
            var existingFood = await _foodRepo.GetFoodByIdAsync(id);

            if (existingFood == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(foodPatchDTO.Name))
                existingFood.Name = foodPatchDTO.Name;
            if (!string.IsNullOrEmpty(foodPatchDTO.Description))
                existingFood.Description = foodPatchDTO.Description;
            if (foodPatchDTO.Price.HasValue && foodPatchDTO.Price.Value > 0)
                existingFood.Price = foodPatchDTO.Price.Value;
            if (foodPatchDTO.IsPopular.HasValue)
                existingFood.IsPopular = foodPatchDTO.IsPopular.Value;
            if (foodPatchDTO.IsVegetarian.HasValue)
                existingFood.IsVegetarian = foodPatchDTO.IsVegetarian.Value;
            if (foodPatchDTO.IsAvailable.HasValue)
                existingFood.IsAvailable = foodPatchDTO.IsAvailable.Value;
            if (!string.IsNullOrEmpty(foodPatchDTO.ImageUrl))
                existingFood.ImageUrl = foodPatchDTO.ImageUrl;



            var updated = await _foodRepo.UpdateFoodAsync(existingFood);
            if (!updated) return null;

            var updatedFoodDTO = new FoodDTO
            {
                Name = existingFood.Name,
                Description = existingFood.Description,
                Price = existingFood.Price,
                IsPopular = existingFood.IsPopular,
                IsVegetarian = existingFood.IsVegetarian,
                IsAvailable = existingFood.IsAvailable,
                ImageUrl = existingFood.ImageUrl
            };

            return updatedFoodDTO;
        }
    }
}
