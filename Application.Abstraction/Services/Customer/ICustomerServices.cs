using Application.Abstraction.Models.Customer_DTOs;
using Application.Abstraction.Models.NewFolder;
using Application.Abstraction.Models.OrderDto;
namespace Application.Abstraction.Services._Customer
{
    public interface ICustomerServices
    {
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task<IEnumerable<OrderDto>> GetCustomerOrdersAsync(int customerId);
    }
}
    