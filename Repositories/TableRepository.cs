using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories.IRepositories;

namespace RestaurantAPI.Respositories
{
    public class TableRepository : ITableRepostory
    {
        private readonly AppDBContext _context;

        public TableRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return table.TableId;
        }

        public async Task<bool> DeleteTableAsync(int Id)
        {
            var RowAffected = await _context.Tables.Where(t => t.TableId == Id).ExecuteDeleteAsync();

            if (RowAffected > 0)
            {
                return true;
            }

            return false;
        }

        public Task<Table> GetAllAvailableTableAsync()
        {
            var AvailableTable = _context.Tables.FirstOrDefaultAsync(t => t.IsAvailable == true);

            return AvailableTable;
        }

        public Task<List<Table>> GetAllTableAsync()
        {
            var AllTables = _context.Tables.ToListAsync();

            return AllTables;
        }

        public async Task<List<Table>> GetListOfTablesByIdsAsync(List<int> tableIds)
        {
            var Table = await _context.Tables
                .Where
                (t => tableIds.Contains(t.TableId))
            .ToListAsync();

            return Table;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            var table = await _context.Tables
                .FirstOrDefaultAsync(t => t.TableId == tableId);
            return table;
        }


        public async Task<bool> UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            var Result = await _context.SaveChangesAsync();

            if (Result != 0)
            {
                return true;
            }

            return false;
        }
    }
}
