using Application.Abstraction.Models._NewFolder;
using Application.Abstraction.Models.Customer_DTOs;
using Application.Abstraction.Models.OrderDtos;
namespace Application.Abstraction.Services._Customer
{
    public interface ICustomerServices
    {
        public Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        public Task<IEnumerable<OrderDto>> GetCustomerOrdersAsync(int customerId);
    }
}
    