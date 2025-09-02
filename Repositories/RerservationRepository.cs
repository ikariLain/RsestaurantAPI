using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories.IRepositories;

namespace RestaurantAPI.Respositories;

public class RerservationRepository : IReservationRepository
{
    private readonly AppDBContext _context;

    public RerservationRepository(AppDBContext context)
    {
        _context = context;
    }
    
    
    public Task<List<Reservation>> GetAllReservationsAsync()
    {
        var reservationList = _context.Reservations.ToListAsync();
        return reservationList;
    }

    public Task<Reservation> GetReservationByIdAsync(int id)
    {
        var reservation = _context.Reservations
            .FirstOrDefaultAsync(r => r.BookingOrderId == id );
        
        return reservation;
    }

    public async Task<int> CreateReservationAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        
        return Reservation.BookingOrderId;
    }
    public async Task<bool> UpdatereservationAsync(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        var result = await _context.SaveChangesAsync();

        if (result != 0)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteReservationAsync(int id)
    {
        var RowAffected = await _context.Reservations
            .Where(r => r.BookingOrderId == id).ExecuteDeleteAsync();

        if (RowAffected > 0)
        {
            return true;
        }

        return false;

    }
}