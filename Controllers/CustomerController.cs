using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs.Table;
using RestaurantAPI.DTOs.Customer;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomer()
        {
            var users = await _CustomerService.GetAllCustomerAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerCreateDTO customer)
        {
            var custumerId = await _CustomerService.CreateCustomerAsync(customer);

            return CreatedAtAction(nameof(GetAllCustomer), new { id = custumerId });

        }

        [HttpPatch]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(int Id, CustomerPatchDTO customer)
        {
            var isUpdated = await _CustomerService.UpdateCustomerAsync(Id, customer);

            if (isUpdated == null)
            {
                return NotFound();
            }
            return Ok(isUpdated);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _CustomerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

    }
}
