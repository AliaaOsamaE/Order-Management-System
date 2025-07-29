using Application.Abstraction.Models._NewFolder;
using Application.Abstraction.Models.Customer_DTOs;
using Application.Abstraction.Models.Invoice_DTOs;
using Application.Abstraction.Models.OrderDtos;
using Application.Abstraction.Models.OrderItemsDto;
using Application.Abstraction.Models.Product;
using Application.Abstraction.Models.User;
using AutoMapper;
using Domain.Entities.Customers;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Users;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User 
            CreateMap<RegisterDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<LoginDto, User>();

            // Product 
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductDto>();

            // Customer 
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            // Order 
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderStatusDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();

            // Invoice
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
        }
    }
}
