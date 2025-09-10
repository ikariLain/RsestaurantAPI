using RestaurantAPI.Models;

namespace RestaurantAPI.Respositories.IRepositories
{
    public interface ITableRepository
    {
        Task<List<Table>> GetAllTableAsync();
        Task<Table> GetTableByIdAsync(int tableId);
        Task<List<Table>> GetListOfTablesByIdsAsync(List<int> tableIds);
        Task<Table> GetAllAvailableTableAsync();
        Task<int> CreateTableAsync(Table table);
        Task<bool> UpdateTableAsync(Table table);
        Task<bool> DeleteTableAsync(int Id);
       
    }
}
