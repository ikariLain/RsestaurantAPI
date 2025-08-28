using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs.Table;
using RestaurantAPI.Service;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : Controller
    {
        private readonly ITableService _TableService;

        public TableController(ITableService tableService)
        {
            _TableService = tableService;
        }

        [HttpGet]
        public async Task<ActionResult<TableDTO>> GetAllTable()
        {
            var tables = await _TableService.GetAllTableAsync();

            return Ok(tables);
        }

        [HttpPost]
        public async Task<ActionResult<TableDTO>> CreateTable(TableCreateDTO table)
        {
            var tableId = await _TableService.CreateTableAsync(table);

            return CreatedAtAction(nameof(GetAllTable), new { id = tableId });
        }

        [HttpDelete]
        public async Task<ActionResult<TableDTO>> DelateTable(int id)
        {
            var isDeleted = await _TableService.DeleteTableAsync(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch]
        public async Task<ActionResult<TableDTO>> UpdateTable(int id, TablePatchDTO tablePatch)
        {
            var updatedTable = await _TableService.UpdateTableAsync(id, tablePatch);
            if (updatedTable == null)
            {
                return NotFound();
            }
            return Ok(updatedTable);
        }

        [HttpGet]
        public async Task<ActionResult<TableDTO>> GetTableById(int id)
        {
            var table = await _TableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }
        [HttpGet]
        [Route("GetAllAvailableTable")]
        public async Task<ActionResult<TableDTO>> GetAllAvailableTable()
        {
            var table = await _TableService.GetAllAvailableTableAsync();
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

    }
}
