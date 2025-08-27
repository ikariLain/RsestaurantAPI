using RestaurantAPI.DTOs.Table;

namespace RestaurantAPI.Service.IService;

public interface ITableService
{
    Task<List<TableDTO>> GetAllTableAsync();
    Task<TableDTO> GetTableByIdAsync(int TableId);
    Task<int> CreateTableAsync(TableDTO TableDTO);
    Task<bool> UpdateTableAsync(TableDTO TableDTO);
    Task<bool> DeleteTableAsync(int id);
}