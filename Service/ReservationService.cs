
using RestaurantAPI.DTOs.Reservation;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories.IRepositories;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepo;
        private readonly ITableRepostory _tableRepo;

        public ReservationService(IReservationRepository reservationRepo, ITableRepostory tableRepostory)
        {
            _reservationRepo = reservationRepo;
            _tableRepo = tableRepostory;
            
        }

        private async Task<bool> IsTableAviableAsync(List<int> tableId,DateOnly bookingdate , DateTime StartTime )
        {
            var checkTable = await _reservationRepo.AreTablesAvailableAsync(tableId, bookingdate, StartTime );

            return checkTable;
        }


        public async Task<int> CreateReservation(ReservationCreateDTO reservationDTO)
        {

            var checkAvaiableTable = await IsTableAviableAsync(reservationDTO.Tables, reservationDTO.BookingDate, reservationDTO.StartTime);



            var reservation = new Reservation
            {

            };

            return; 
        }

        public Task DeleteReservationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReservationDTO>> GetAllReservationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReservationDTO> GetReservationIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReservationDTO> UpdateReservationAsync(int id, ReservationPatchDTO reservationPatchDTO)
        {
            throw new NotImplementedException();
        }
    }
}
