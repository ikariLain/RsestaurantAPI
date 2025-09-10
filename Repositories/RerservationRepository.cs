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
    
    
    public async Task<List<Reservation>> GetAllReservationsAsync()
    {
        var reservationList = await _context.Reservations.ToListAsync();
        return reservationList;
    }

    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        var reservation = await _context.Reservations
            .FirstOrDefaultAsync(r => r.ReservationId == id );
        
        return reservation;
    }

    public async Task<int> CreateReservationAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        
        return reservation.ReservationId;
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
            .Where(r => r.ReservationId == id).ExecuteDeleteAsync();

        if (RowAffected > 0)
        {
            return true;
        }

        return false;

    }

    public async Task<bool> AreTablesAvailableAsync(List<int> tableId, DateOnly bookingDate, DateTime StartTime)
    {
        var endTime = StartTime.AddHours(2);


        var overlapExists = await _context.ReservationTables
            .Include(rt => rt.Reservation)
            .AnyAsync(rt =>
                tableId.Contains(rt.TableId) &&
                rt.Reservation.BookingDate == bookingDate &&
                (rt.Reservation.StartTime < endTime &&
                 rt.Reservation.StartTime.AddHours(2) > StartTime)
            );

        return overlapExists;

    }

}