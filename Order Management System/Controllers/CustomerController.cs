using Application.Abstraction.Models._NewFolder;
using Application.Abstraction.Models.Customer_DTOs;
using Application.Abstraction.Models.OrderDtos;
using Application.Abstraction.Services._Customer;
using Application.Services._Customer;
using Domain.Entities.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    public class CustomerController : ApiController

    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCustomer = await _customerServices.CreateCustomerAsync(createCustomerDto);
            return Ok(createdCustomer);
        }

        [HttpGet("{id}/orders")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetCustomerOrders(int id)
        {
            var orders = await _customerServices.GetCustomerOrdersAsync(id);

            if (orders is null)
                return NotFound();

            return Ok(orders);
        }

    }
}
