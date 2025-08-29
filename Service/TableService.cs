using RestaurantAPI.DTOs.Table;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Service;

public class TableService : ITableService
{
    private readonly TableRepository _tableRepo;

    public TableService(TableRepository tableRepo)
    {
        _tableRepo = tableRepo;
    }
    
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

    public Task<TableDTO> GetAllAvailableTableAsync()
    {
        var availableTable = _tableRepo.GetAllAvailableTableAsync();

        if (availableTable == null)
        {
            return null;
        }

        var tableDTO = availableTable.ContinueWith(t => new TableDTO
        {
            TableId = t.Result.TableId,
            SeatAmount = t.Result.SeatAmount,
            IsAvailable = t.Result.IsAvailable
        });

        return tableDTO;
    }


    public Task<int> CreateTableAsync(TableCreateDTO TableDTO)
    {
        var table = new Table
        {
            TableId = TableDTO.TableId,
            SeatAmount = TableDTO.SeatAmount,
            IsAvailable = TableDTO.IsAvailable
        };

        var newTableId = _tableRepo.CreateTableAsync(table);

        return newTableId;
    }

    public async Task<TableDTO> UpdateTableAsync(int TableId, TablePatchDTO tablePatch)
    {
        var existingTable = await _tableRepo.GetTableByIdAsync(TableId);

        if (existingTable == null)
        {
            return null;
        }

        if(tablePatch.SeatAmount.HasValue)
            existingTable.SeatAmount = tablePatch.SeatAmount.Value;

        if (tablePatch.IsAvailable.HasValue)
            existingTable.IsAvailable = tablePatch.IsAvailable.Value;

        var updateTableDB = await _tableRepo.UpdateTableAsync(existingTable);

        return new TableDTO
        {
            TableId = existingTable.TableId,
            SeatAmount = existingTable.SeatAmount,
            IsAvailable = existingTable.IsAvailable
        };
    }

    public async Task<bool> DeleteTableAsync(int id)
    {
        var exsistingTable = await _tableRepo.DeleteTableAsync(id);

        if (exsistingTable == false)
        {
            return false;
        }

        var deleteTable = await _tableRepo.DeleteTableAsync(id);

        return deleteTable;
    }
}