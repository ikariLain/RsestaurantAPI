using RestaurantAPI.DTOs;
using RestaurantAPI.DTOs.Reservation;

namespace RestaurantAPI.Service.IService
{
    public interface IReservationService
    {
        Task<List<ReservationDTO>> GetAllReservationAsync();
        Task<ReservationDTO> GetReservationIdAsync(int id);
        Task<int> CreateReservation(ReservationCreateDTO reservationDTO);
        Task<ReservationDTO> UpdateReservationAsync(int id, ReservationPatchDTO reservationPatchDTO);
        Task DeleteReservationAsync(int id);


    }
}
