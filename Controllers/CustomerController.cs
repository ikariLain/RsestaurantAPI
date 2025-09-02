using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs.Table;
using RestaurantAPI.DTOs.User;
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
        [Route("getAllCustomer")]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomer()
        {
            var users = await _CustomerService.GetAllCustomerAsync();
           
            return Ok(users);
        }

        [HttpPost]
        [Route("createCustomer")]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerCreateDTO customer)
        {
            var custumerId = await _CustomerService.CreateCustomerAsync(customer);

            return CreatedAtAction(nameof(GetAllCustomer), new { id = custumerId }); 
            
        }

        [HttpPatch]
        [Route("updateCustomer")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(int Id, CustomerPatchDTO customer)
        {
            var isUpdated = await _CustomerService.UpdateCustomerAsync(Id, customer);

            if (isUpdated == null)
            {
                return NotFound();
            }
            return Ok(isUpdated);
        }

    }
}
