using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs.Food;
using RestaurantAPI.Models;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]

        public async Task<ActionResult<List<Food>>> GetAllFoods()
        {
            try
            {
                var foods = await _foodService.GetAllFoodsAsync();
                return Ok(foods);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFoodById(int id)
        {
            try
            {
                var food = await _foodService.FoodByIdAsync(id);
                return Ok(food);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateFood([FromBody] Food food)
        {
            try
            {
                var foodId = await _foodService.CreateFoodAsync(food);
                return CreatedAtAction(nameof(GetFoodById), new { id = foodId }, new { FoodId = foodId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<FoodDTO>> UpdateFood(int id, [FromBody] FoodPatchDTO foodPatchDTO)
        {
            try
            {
                var updatedFood = await _foodService.UpdateFoodAsync(id, foodPatchDTO);
                if (updatedFood == null)
                    return NotFound(new { message = $"Food with ID {id} not found or not updated." });

                return Ok(updatedFood);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFood(int id)
        {
            try
            {
                var deleted = await _foodService.DeleteFoodAsync(id);
                if (!deleted)
                    return NotFound(new { message = $"Food with ID {id} not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
