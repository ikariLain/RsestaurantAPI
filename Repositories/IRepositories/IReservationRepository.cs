using RestaurantAPI.Models;

namespace RestaurantAPI.Respositories.IRepositories;

public interface IReservationRepository
{
    Task <List<Reservation>> GetAllReservationsAsync();
    Task<Reservation> GetReservationByIdAsync(int id);
    Task<int> CreateReservationAsync(Reservation reservation);
    Task<bool> UpdateReservationAsync(Reservation reservation);
    Task<bool> DeleteReservationAsync(int id);
}