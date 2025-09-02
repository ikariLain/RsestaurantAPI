using RestaurantAPI.Models;

namespace RestaurantAPI.Respositories.IRepositories;

public interface IReservation
{
    Task <List<Reservation>> GetAllReservationsAsync();
    Task<Reservation> GetReservationByIdAsync(int id);
    Task<int> CreateReservationAsync(Reservation reservation);
    Task<bool> UpdateCustomerAsync(Reservation reservation);
    Task<bool> DeleteReservationAsync(int id);
}