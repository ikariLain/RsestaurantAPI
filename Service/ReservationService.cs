
using RestaurantAPI.DTOs.Reservation;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories.IRepositories;
using RestaurantAPI.Service.IService;
using System.Formats.Asn1;

namespace RestaurantAPI.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepo;
        private readonly ITableRepository _tableRepo;

        public ReservationService(IReservationRepository reservationRepo, ITableRepository tableRepostory)
        {
            _reservationRepo = reservationRepo;
            _tableRepo = tableRepostory;
            
        }

        private async Task<bool> IsTableAvailableAsync(List<int> tableId,DateOnly bookingdate , DateTime StartTime )
        {
            var checkTable = await _reservationRepo.AreTablesAvailableAsync(tableId, bookingdate, StartTime );

            return checkTable;
        }

        public async Task<int> CreateReservation(ReservationCreateDTO reservationDTO)
        {

            var tablesAvailable = await IsTableAvailableAsync(reservationDTO.Tables, reservationDTO.BookingDate, reservationDTO.StartTime);
            if (!tablesAvailable)
            {
                throw new Exception("Selected tables are not available at this time.");
            }


            var tables = await _tableRepo.GetListOfTablesByIdsAsync(reservationDTO.Tables);

            var reservation = new Reservation
            {
                Customer_FK = reservationDTO.Customer_Fk,
                status = reservationDTO.status ?? "Pending",
                BookingDate = reservationDTO.BookingDate,
                StartTime = reservationDTO.StartTime,
                Duration = reservationDTO.Duration ?? TimeSpan.FromHours(2),
                AmountOfGuests = reservationDTO.AmountOfGuests,
                AmountOfTables = reservationDTO.AmountOfTables,
                ReservationTables = tables.Select(t => new ReservationTable
                {
                    TableId = t.TableId
                }).ToList()
            };

            
            var createdReservation = await _reservationRepo.CreateReservationAsync(reservation);


            return createdReservation;
        }

        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _reservationRepo.GetReservationByIdAsync(id);
            if (reservation == null) throw new Exception("Reservation not found");

            await _reservationRepo.DeleteReservationAsync(reservation.ReservationId);
        }

        public Task<List<ReservationDTO>> GetAllReservationAsync()
        {
            var reservations = _reservationRepo.GetAllReservationsAsync();

            if (reservations == null) throw new Exception("No reservations found");

            var reservationDTOs = reservations.Result.Select(r => new ReservationDTO
            {
                ReservationId = r.ReservationId,
                BookingDate = r.BookingDate,
                StartTime = r.StartTime,
                AmountOfGuests = r.AmountOfGuests,
                Status = r.status
            }).ToList();

            return Task.FromResult(reservationDTOs);
        }

        public async Task<ReservationDTO> GetReservationIdAsync(int id)
        {
           var reservation = await _reservationRepo.GetReservationByIdAsync(id);

            if (reservation == null) throw new Exception("Reservation not found");

            var reservationDTO =  new ReservationDTO
            {
                ReservationId = reservation.ReservationId,
                BookingDate = reservation.BookingDate,
                StartTime = reservation.StartTime,
                AmountOfGuests = reservation.AmountOfGuests,
                Status = reservation.status
            };

            return reservationDTO;
        }

        public async Task<ReservationDTO> UpdateReservationAsync(int id, ReservationPatchDTO reservationPatchDTO)
        {
            var reservation = await _reservationRepo.GetReservationByIdAsync(id);
            if (reservation == null) throw new Exception("Reservation not found");


            if (reservationPatchDTO.Customer_Fk.HasValue)
                reservation.Customer_FK = reservationPatchDTO.Customer_Fk.Value;

            if (reservationPatchDTO.Tables != null && reservationPatchDTO.Tables.Any())
            {
                var tablesAvailable = await IsTableAvailableAsync(
                    reservationPatchDTO.Tables,
                    reservationPatchDTO.BookingDate ?? reservation.BookingDate,
                    reservationPatchDTO.StartTime ?? reservation.StartTime);

                if (!tablesAvailable)
                    throw new Exception("Selected tables are not available at this time.");

                var tables = await _tableRepo.GetListOfTablesByIdsAsync(reservationPatchDTO.Tables);

                reservation.ReservationTables = tables.Select(t => new ReservationTable
                {
                    TableId = t.TableId,
                    ReservationId = reservation.ReservationId
                }).ToList();

                reservation.AmountOfTables = tables.Count;
            }

            if (reservationPatchDTO.Status != null)
                reservation.status = reservationPatchDTO.Status;

            if (reservationPatchDTO.BookingDate.HasValue)
                reservation.BookingDate = reservationPatchDTO.BookingDate.Value;

            if (reservationPatchDTO.StartTime.HasValue)
                reservation.StartTime = reservationPatchDTO.StartTime.Value;

            if (reservationPatchDTO.Duration.HasValue)
                reservation.Duration = reservationPatchDTO.Duration.Value;

            var updated = await _reservationRepo.UpdatereservationAsync(reservation);
            if (!updated) throw new Exception("Failed to update reservation.");

            return new ReservationDTO
            {
                ReservationId = reservation.ReservationId,
                BookingDate = reservation.BookingDate,
                StartTime = reservation.StartTime,
                AmountOfGuests = reservation.AmountOfGuests,
                Status = reservation.status
            };
        }
    }
}
