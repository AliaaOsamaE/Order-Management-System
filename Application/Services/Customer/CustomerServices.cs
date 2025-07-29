using Application.Abstraction.Models._NewFolder;
using Application.Abstraction.Models.Customer_DTOs;
using Application.Abstraction.Models.OrderDtos;
using Application.Abstraction.Services._Customer;
using AutoMapper;
using Domain.Entities.Customers;
using Domain.Entities.Orders;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;

namespace Application.Services._Customer
{
    public class CustomerService(IUnitOfWork _unitOfWork, IMapper _mapper) : ICustomerServices
    {
        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Customer>(createCustomerDto);
            await  _unitOfWork.GetRepository<Customer, int>().AddAsync(customer);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<IEnumerable<OrderDto>> GetCustomerOrdersAsync(int customerId)
        {
            var orders = await _unitOfWork.GetRepository<Order, int>().GetWhereAsync(o => o.CustomerId == customerId); 
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

          
    }
}
