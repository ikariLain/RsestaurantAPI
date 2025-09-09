using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs.ServiceOrder;
using RestaurantAPI.Models;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceOrderContorller: ControllerBase
    {
        private readonly IServiceOrderService _serviceOrderService;

        public ServiceOrderContorller(IServiceOrderService serviceOrderService)
        {
            _serviceOrderService = serviceOrderService;
        }


        [HttpGet]
        public async Task<ActionResult<List<ServiceOrder>>> GetAllServiceOrders()
        {
            try
            {
                var orders = await _serviceOrderService.GetAllServiceOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceOrder>> GetServiceOrderById(int id)
        {
            try
            {
                var order = await _serviceOrderService.GetServiceOrderByIdAsync(id);
                return Ok(order);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateServiceOrder([FromBody] ServiceOrderCreateDTO serviceOrderDTO)
        {
            try
            {
                var id = await _serviceOrderService.CreateServiceOrderAsync(serviceOrderDTO);
                return CreatedAtAction(nameof(GetServiceOrderById), new { id }, new { ServiceOrderId = id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ServiceOrderDTO>> UpdateServiceOrder(int id, [FromBody] ServiceOrderPatchDTO patchDTO)
        {
            try
            {
                var updatedOrder = await _serviceOrderService.UpdateServiceOrderAsync(id, patchDTO);
                if (updatedOrder == null)
                    return NotFound(new { message = $"ServiceOrder with ID {id} not found or not updated." });

                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServiceOrder(int id)
        {
            try
            {
                var deleted = await _serviceOrderService.DeleteServiceOrderAsync(id);
                if (!deleted)
                    return NotFound(new { message = $"ServiceOrder with ID {id} not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
