using Application.Abstraction.Models._NewFolder;
using Application.Abstraction.Models.Customer_DTOs;
using Application.Abstraction.Models.OrderDto;
using Application.Abstraction.Models.Product;
using Application.Abstraction.Models.User;
using AutoMapper;
using Domain.Entities.Customers;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Users;

namespace Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, UserToReturnDto>();
            CreateMap<LoginUserDto, User>();

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductToReturnDto>();

            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();


            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderStatusDto, Order>();
            CreateMap<Order, OrderDto>();

        }
    }
}
