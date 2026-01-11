using Application.Abstraction.Models.OrderDtos;

namespace Application.Abstraction.Services._Order
{
    public interface IOrderServices
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<OrderDto> GetOrderById(int orderId);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<UpdateOrderStatusDto> UpdateOrderStatusAsync(int orderId, UpdateOrderStatusDto updateOrderDto);

    }
}
