using RestaurantAPI.DTOs.Table;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Service;

public class TableService : ITableService
{
    private readonly ITableService _tableRepo;

    public TableService(ITableService tableRepo)
    {
        _tableRepo = tableRepo;
    }
    
    //TODO: Add all methods 
    
    public async Task<List<TableDTO>> GetAllTableAsync()
    {
        var tables = await _tableRepo.GetAllTableAsync();
        
        var tableDTO = tables.Select(t => new TableDTO
        {
            TableId = t.TableId,
            SeatAmount = t.SeatAmount,
            IsAvailable = t.IsAvailable
            
        }).ToList();
        
        return tableDTO;
            
    }

    public async Task<TableDTO> GetTableByIdAsync(int TableId)
    {
        var existingTable = await _tableRepo.GetTableByIdAsync(TableId);

        if (existingTable == null)
        {
            return null;
        }

        var tableDTO = new TableDTO
        {
            TableId = existingTable.TableId,
            SeatAmount = existingTable.SeatAmount,
            IsAvailable = existingTable.IsAvailable
        };


        return tableDTO;

    }

    public Task<int> CreateTableAsync(TableDTO TableDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateTableAsync(TableDTO TableDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTableAsync(int id)
    {
        throw new NotImplementedException();
    }
}