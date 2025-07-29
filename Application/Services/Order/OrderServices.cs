using Application.Abstraction.Models.OrderDtos;
using Application.Abstraction.Models.OrderDtos;
using Application.Abstraction.Services._Order;
using Application.Abstraction.Services.Shared;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Exceptions;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using System.ComponentModel.DataAnnotations;

public class OrderService : IOrderServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailService = emailService;
    }

    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var orderItemDtos = createOrderDto.OrderItems;

        var orderItems = new List<OrderItem>();
        decimal total = 0;
        foreach (var item in orderItemDtos)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(item.ProductId);
            if (product is null) throw new NotFoundException($"Product is not found");
            if (item.Quantity > product.Stock) throw new ValidationException($"Product is out of stock");
            total += (product.Price * item.Quantity);
            var orderItem = _mapper.Map<OrderItem>(item); 
            orderItem.UnitPrice = product.Price;
            orderItems.Add(orderItem);
            product.Stock -= item.Quantity;
            _unitOfWork.GetRepository<Product, int>().Update(product);
        }
        // Discount
        if (total > 200) total *= 0.90m;
        else if (total > 100) total *= 0.95m;

        var order = new Order
        {
            CustomerId = createOrderDto.CustomerId,
            OrderDate = DateTime.UtcNow,
            TotalAmount = total,
            PaymentMethod = createOrderDto.PaymentMethod,
            Status = OrderStatus.Pending,
            OrderItems = orderItems
        };

        await _unitOfWork.GetRepository<Order, int>().AddAsync(order);
        var invoice = new Invoice
        {
            OrderId = order.Id,
            InvoiceDate = DateTime.UtcNow,
            TotalAmount = order.TotalAmount
        };

        await _unitOfWork.GetRepository<Invoice, int>().AddAsync(invoice);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> GetOrderById(int orderId)
    {
        var order = await _unitOfWork.GetRepository<Order, int>().GetAsync(orderId);
        if (order is null) throw new NotFoundException("Order not found");
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _unitOfWork.GetRepository<Order, int>().GetAllAsync();
        if (orders is null || !orders.Any()) return new List<OrderDto>();
        return _mapper.Map<List<OrderDto>>(orders);
    }

    public async Task<UpdateOrderStatusDto> UpdateOrderStatusAsync(int orderId, UpdateOrderStatusDto dto)
    {
        var order = await _unitOfWork.GetRepository<Order, int>().GetAsync(orderId);
        if (order is null) throw new NotFoundException("Order not found");
        order.Status = dto.Status;
        _unitOfWork.GetRepository<Order, int>().Update(order);
        await _unitOfWork.CompleteAsync();
        await _emailService.SendEmail(order.Id);
        return dto;
    }
}
