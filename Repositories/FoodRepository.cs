using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories.IRepositories;

namespace RestaurantAPI.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDBContext _context;

        public FoodRepository(AppDBContext context )
        {
            _context = context;
        }

        public async Task<int> CreateFoodAsync(Food food)
        {
            _context.Foods.Add(food);

            await _context.SaveChangesAsync();

            return food.FoodId;
        }

        public async Task<bool> DeleteFoodAsync(int Id)
        {
            var RowAffected = await _context.Foods
                .Where(f => f.FoodId == Id).ExecuteDeleteAsync();

            if (RowAffected > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<Food> GetFoodByIdAsync(int id)
        {
           var food = await _context.Foods
                .FirstOrDefaultAsync(f => f.FoodId == id);

            return food;
        }

        public async Task<List<Food>> GetAllFoodsAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<bool> UpdateFoodAsync(Food food)
        {
             _context.Foods.Update(food);

            await _context.SaveChangesAsync();

            var result = await _context.SaveChangesAsync();

            return result != 0;
        }
    }
}
