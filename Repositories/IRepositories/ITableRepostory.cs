using RestaurantAPI.Models;

namespace RestaurantAPI.Respositories.IRepositories
{
    public interface ITableRepostory
    {
        Task<List<Table>> GetAllTableAsync();
        Task<Table> GetTableByIdAsync(int Id);
        Task<Table> GetAllAvailableTableAsync();
        Task<int> CreateTableAsync(Table table);
        Task<bool> UpdateTableAsync(Table table);
        Task<bool> DeleteTableAsync(int Id);
       
    }
}
