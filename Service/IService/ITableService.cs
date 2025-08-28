using RestaurantAPI.DTOs.Table;

namespace RestaurantAPI.Service.IService;

public interface ITableService
{
    Task<List<TableDTO>> GetAllTableAsync();
    Task<TableDTO> GetTableByIdAsync(int TableId);
    Task<int> CreateTableAsync(TableCreateDTO TableDTO);
    Task<TableDTO> UpdateTableAsync(int TableId, TablePatchDTO tablePatch);
    Task<bool> DeleteTableAsync(int id);
}