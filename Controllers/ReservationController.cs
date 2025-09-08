using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs.Reservation;
using RestaurantAPI.Models;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDTO>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservationById(int id)
        {
            try
            {
                var reservation = await _reservationService.GetReservationIdAsync(id);
                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation([FromBody] ReservationCreateDTO reservationDTO)
        {
            try
            {
                var reservationId = await _reservationService.CreateReservation(reservationDTO);
                return CreatedAtAction(nameof(GetReservationById), new { id = reservationId }, new { ReservationId = reservationId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ReservationDTO>> UpdateReservation(int id, [FromBody] ReservationPatchDTO reservationPatchDTO)
        {
            try
            {
                var updated = await _reservationService.UpdateReservationAsync(id, reservationPatchDTO);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


    }
}
